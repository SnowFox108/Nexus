using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Blog.mPostView
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _postviewid;

        private bool _ispagetitle = true;
        private bool _isguestcomment = true;
        private int _numberperpage = 10;
        private string _blogpostsurl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PostViewID
        {
            get
            {
                return _postviewid;
            }
            set
            {
                _postviewid = value;
                ViewState["PostViewID"] = _postviewid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsPageTitle
        {
            get
            {
                return _ispagetitle;
            }
            set
            {
                _ispagetitle = value;
                ViewState["IsPageTitle"] = _ispagetitle;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsGuestComment
        {
            get
            {
                return _isguestcomment;
            }
            set
            {
                _isguestcomment = value;
                ViewState["IsGuestComment"] = _isguestcomment;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("10")]
        [Localizable(true)]
        public int NumberPerPage
        {
            get
            {
                return _numberperpage;
            }
            set
            {
                _numberperpage = value;
                ViewState["NumberPerPage"] = _numberperpage;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string BlogPostsURL
        {
            get
            {
                return _blogpostsurl;
            }
            set
            {
                _blogpostsurl = value;
                ViewState["BlogPostsURL"] = _blogpostsurl;
            }
        }

        #endregion

        string _view_stage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _postviewid = ViewState["PostViewID"].ToString();
                _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                _isguestcomment = Convert.ToBoolean(ViewState["IsGuestComment"]);
                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
                _blogpostsurl = ViewState["BlogPostsURL"].ToString();

                _view_stage = ViewState["ViewStage"].ToString();
            }
            else
            {
                _view_stage = "view_new";
                ViewState["ViewStage"] = _view_stage;

                Control_PreInit();
            }

            Control_Init();

        }

        private void Control_PreInit()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
            {
                // Add View Count
                Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                int _view_count = Convert.ToInt32(myBlog_Post.View_Count) + 1;

                e2Data[] UpdateData_Post = {
                                               new e2Data("PostID", myBlog_Post.PostID),
                                               new e2Data("View_Count", _view_count.ToString())
                                           };

                myBlogMgr.Edit_Blog_Post(UpdateData_Post);

            }
        }


        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_postviewid))
            {
                MultiView_PostView.SetActiveView(View_New);
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    lbtn_Edit_Post.Enabled = false;
                    lbtn_BlogPostsURL.Enabled = false;
                    btn_PostComment.Enabled = false;
                }

                if (_view_stage == "view_edit")
                {
                    MultiView_PostView.SetActiveView(View_Edit);
                }
                else
                {

                    MultiView_PostView.SetActiveView(View_Post);

                    _view_stage = "view_post";
                    ViewState["ViewStage"] = _view_stage;

                    // Init Comment Form
                    RadEditor_Comment.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                    RadEditor_Comment.EditModes = Telerik.Web.UI.EditModes.Design | Telerik.Web.UI.EditModes.Preview;
                    RadEditor_Comment.Content = "";

                    if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
                    {

                        Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                        Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                        if (Security.Users.UserStatus.Validate_Ownership(this.Page, myBlog_Post.Ownership_UserID) ||
                            Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                        {
                            lbtn_Edit_Post.Visible = true;
                        }
                        else
                        {
                            lbtn_Edit_Post.Visible = false;
                        }

                        // Page Title
                        if (_ispagetitle)
                            Page.Title = myBlog_Post.Post_Title;                        

                        // Fillup Post Content
                        lbl_Title.Text = myBlog_Post.Post_Title;
                        lbl_Post_Date.Text = myBlog_Post.Post_Date_Short;
                        lbl_UserName.Text = myBlog_Post.UserName;
                        Literal_Content.Text = myBlog_Post.Post_Content;
                        lbl_Post_ModifyDate.Text = myBlog_Post.Post_ModifyDate;
                        lbl_Comment_Count.Text = myBlog_Post.Comment_Count;

                        // Add Social button
                        PlaceHolder_SocialNetwork.Controls.Clear();

                        string _facebook = string.Format("http://www.facebook.com/sharer.php?u={0}&t={1}", Server.UrlEncode(Request.Url.ToString()), Server.UrlEncode(myBlog_Post.Post_Title));
                        HyperLink myHyperLink = new HyperLink();
                        myHyperLink.NavigateUrl = _facebook;
                        myHyperLink.Target = "_blank";
                        myHyperLink.ImageUrl = "~/App_Control_Style/Nexus_mBlog/SocialBookmark/Facebook_24.png";

                        PlaceHolder_SocialNetwork.Controls.Add(myHyperLink);

                        //  Load User Name and Disable Guest Comment
                        string _current_username = Security.Users.UserStatus.Current_UserName(this.Page);
                        if (_current_username == "Guest")
                        {
                            if (_isguestcomment)
                            {
                                btn_PostComment.Enabled = true;
                            }
                            else
                            {
                                btn_PostComment.Enabled = false;
                            }

                            tbx_Comment_UserName.Enabled = true;
                        }
                        else
                        {
                            tbx_Comment_UserName.Text = _current_username;
                            tbx_Comment_UserName.Enabled = false;
                        }

                        // Bind Post Comment
                        ListView_Comment.DataSource = myBlogMgr.Get_Blog_Comments(Request["NexusBlogPostID"], "1");
                        ListView_Comment.DataKeyNames = new string[] { "CommentID" };
                        ListView_Comment.DataBind();

                        DataPager_PostView.PageSize = _numberperpage;


                    }
                    else
                    {
                        // No Post ID
                        lbtn_Edit_Post.Visible = false;
                        btn_PostComment.Visible = false;
                    }

                }

            }

        }

        protected void lbtn_BlogPostsURL_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
            {
                Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();
                Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                Response.Redirect(Core.Tools.URLParse.Update_Arg(_blogpostsurl, "NexusBlogUserID", myBlog_Post.Ownership_UserID));
            }
            else
            {
                Response.Redirect(_blogpostsurl);
            }
        }

        protected void btn_PostComment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
                {
                    string _current_userid = Security.Users.UserStatus.Current_UserID(this.Page);

                    if (!_isguestcomment)
                    {
                        if (_current_userid == "0")
                        {
                            Control_Init();
                            return;
                        }
                    }


                    Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                    e2Data[] UpdateData = {
                                               new e2Data("Parent_CommentID", "-1"),
                                               new e2Data("PostID", Request["NexusBlogPostID"]),
                                               new e2Data("UserID", _current_userid),
                                               new e2Data("UserName", tbx_Comment_UserName.Text),
                                               new e2Data("UserEmail", tbx_Comment_UserEmail.Text),
                                               new e2Data("UserURL", tbx_Comment_UserURL.Text),
                                               new e2Data("UserIPaddress", Request.ServerVariables["REMOTE_ADDR"]),
                                               new e2Data("Post_Date", DateTime.Now.ToString()),
                                               new e2Data("Post_Content", RadEditor_Comment.Content),
                                               new e2Data("Comment_Approved", "1")
                                           };

                    myBlogMgr.Add_Blog_Comment(UpdateData);

                    // Add Comment Count
                    Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                    int _comment_count = Convert.ToInt32(myBlog_Post.Comment_Count) + 1;

                    e2Data[] UpdateData_Post = {
                                               new e2Data("PostID", myBlog_Post.PostID),
                                               new e2Data("Comment_Count", _comment_count.ToString())
                                           };

                    myBlogMgr.Edit_Blog_Post(UpdateData_Post);

                    Control_Init();
                }

            }
        }

        #region Edit Post

        protected void lbtn_Edit_Post_Click(object sender, EventArgs e)
        {
            _view_stage = "view_edit";
            ViewState["ViewStage"] = _view_stage;

            MultiView_PostView.SetActiveView(View_Edit);

            if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
            {

                Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                // Initiate Post form default setting
                RadEditor_BlogContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";

                #region Bind Data to droplist
                // Enable user edit mode

                //Gets your enum names and adds it to a string array
                Array enumNames = Enum.GetValues(typeof(Lib.Post_Status));

                //Creates an ArrayList
                ArrayList myPost_Statuses = new ArrayList();

                //Loop through your string array and poppulates the ArrayList
                foreach (Lib.Post_Status myPost_Status in enumNames)
                {
                    myPost_Statuses.Add(new { Value = StringEnum.GetStringValue(myPost_Status), Name = myPost_Status.ToString() });
                }


                //Bind the ArrayList to your DropDownList             
                droplist_PostStatus.DataSource = myPost_Statuses;
                droplist_PostStatus.DataTextField = "Name";
                droplist_PostStatus.DataValueField = "Value";
                droplist_PostStatus.DataBind();
                #endregion

                // Init Form data
                tbx_Title.Text = myBlog_Post.Post_Title;
                RadEditor_BlogContent.Content = myBlog_Post.Post_Content;
                droplist_PostStatus.SelectedValue = myBlog_Post.Post_Status.ToString();
                tbx_Password.Text = myBlog_Post.Post_Password;
                RadDateTimePicker_PostDate.SelectedDate = Convert.ToDateTime(myBlog_Post.Post_Date);

            }
            else
            {
                Control_Init();
            }

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
                {

                    Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();
                    Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

                    if (Security.Users.UserStatus.Validate_Ownership(this.Page, myBlog_Post.Ownership_UserID) ||
                        Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {

                        string Post_Date;
                        try
                        {
                            Post_Date = RadDateTimePicker_PostDate.SelectedDate.ToString();
                        }
                        catch
                        {
                            Post_Date = DateTime.Now.ToString();
                        }

                        e2Data[] UpdateData = {
                                               new e2Data("PostID", myBlog_Post.PostID),
                                               new e2Data("UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                               new e2Data("UserName", Security.Users.UserStatus.Current_UserName(this.Page)),
                                               new e2Data("Post_Date", Post_Date),
                                               new e2Data("Post_ModifyDate", DateTime.Now.ToString()),
                                               new e2Data("Post_Title", tbx_Title.Text),
                                               new e2Data("Post_Content", RadEditor_BlogContent.Content),
                                               new e2Data("Post_Status", droplist_PostStatus.SelectedValue),
                                               new e2Data("Post_Password", tbx_Password.Text)
                                              };

                        myBlogMgr.Edit_Blog_Post(UpdateData);

                        _view_stage = "view_post";
                        ViewState["ViewStage"] = _view_stage;

                        Control_Init();

                    }
                    else
                    {
                        btn_Update.Text = "User does not have permission";
                        btn_Update.Enabled = false;
                    }

                }
            }
        }

        #endregion

        protected void ListView_Comment_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_PostView.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }
    }
}