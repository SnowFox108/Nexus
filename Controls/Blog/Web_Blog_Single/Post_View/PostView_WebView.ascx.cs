using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Controls.Blog.Lib;

namespace Nexus.Controls.Blog.PostView
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _postviewid;

        private bool _ispagetitle = true;
        private string _postview_itemtemplate = "Default";
        private string _postview_itemtemplateurl = "";

        private bool _isguestcomment = true;
        private string _comment_itemtemplate = "Default";
        private string _comment_itemtemplateurl = "";

        private bool _enable_pager = true;
        private int _numberperpage = 10;

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
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string PostView_ItemTemplate
        {
            get
            {
                return _postview_itemtemplate;
            }
            set
            {
                _postview_itemtemplate = value;
                ViewState["PostView_ItemTemplate"] = _postview_itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PostView_ItemTemplateURL
        {
            get
            {
                return _postview_itemtemplateurl;
            }
            set
            {
                _postview_itemtemplateurl = value;
                ViewState["PostView_ItemTemplateURL"] = _postview_itemtemplateurl;
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
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string Comment_ItemTemplate
        {
            get
            {
                return _comment_itemtemplate;
            }
            set
            {
                _comment_itemtemplate = value;
                ViewState["Comment_ItemTemplate"] = _comment_itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Comment_ItemTemplateURL
        {
            get
            {
                return _comment_itemtemplateurl;
            }
            set
            {
                _comment_itemtemplateurl = value;
                ViewState["Comment_ItemTemplateURL"] = _comment_itemtemplateurl;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("true")]
        [Localizable(true)]
        public bool Enable_Pager
        {
            get
            {
                return _enable_pager;
            }
            set
            {
                _enable_pager = value;
                ViewState["Enable_Pager"] = _enable_pager;
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

        #endregion

        string _view_stage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _postviewid = ViewState["PostViewID"].ToString();
                _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                _postview_itemtemplate = ViewState["PostView_ItemTemplate"].ToString();
                _postview_itemtemplateurl = ViewState["PostView_ItemTemplateURL"].ToString();

                _isguestcomment = Convert.ToBoolean(ViewState["IsGuestComment"]);
                _comment_itemtemplate = ViewState["Comment_ItemTemplate"].ToString();
                _comment_itemtemplateurl = ViewState["Comment_ItemTemplateURL"].ToString();

                _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);
                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);

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
                        List<Blog_Post> myPostViews = new List<Blog_Post>();
                        myPostViews.Add(myBlog_Post);

                        FormView_PostView.DataSource = myPostViews;
                        FormView_PostView.DataKeyNames = new string[] { "PostID" };

                        Core.Tools.AppItemTemplates myPostView_ItemTemplate = new Core.Tools.AppItemTemplates();

                        switch (_postview_itemtemplate)
                        {
                            case "Default":
                                myPostView_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/PostView_Default.ascx";
                                break;
                            case "Custom":
                                myPostView_ItemTemplate.ItemTemplatePath = _postview_itemtemplateurl;
                                break;
                            default:
                                myPostView_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/PostView_Default.ascx";
                                break;
                        }

                        FormView_PostView.ItemTemplate = Page.LoadTemplate(myPostView_ItemTemplate.ItemTemplatePath);

                        try
                        {

                            FormView_PostView.DataBind();
                        }
                        catch
                        {
                            // Load Template Failed
                        }

                        //lbl_Title.Text = myBlog_Post.Post_Title;
                        //lbl_Post_Date.Text = myBlog_Post.Post_Date_Short;
                        //lbl_UserName.Text = myBlog_Post.UserName;
                        //Literal_Content.Text = myBlog_Post.Post_Content;
                        //lbl_Post_ModifyDate.Text = myBlog_Post.Post_ModifyDate;
                        //lbl_Comment_Count.Text = myBlog_Post.Comment_Count;

                        //// Add Social button
                        //PlaceHolder_SocialNetwork.Controls.Clear();

                        //string _facebook = string.Format("http://www.facebook.com/sharer.php?u={0}&t={1}", Server.UrlEncode(Request.Url.ToString()), Server.UrlEncode(myBlog_Post.Post_Title));
                        //HyperLink myHyperLink = new HyperLink();
                        //myHyperLink.NavigateUrl = _facebook;
                        //myHyperLink.Target = "_blank";
                        //myHyperLink.ImageUrl = "~/App_Control_Style/Nexus_Blog/SocialBookmark/Facebook_24.png";

                        //PlaceHolder_SocialNetwork.Controls.Add(myHyperLink);

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
                            Panel_Comment_Contact.Visible = false;
                        }
                        else
                        {
                            tbx_Comment_UserName.Text = _current_username;
                            tbx_Comment_UserName.Enabled = false;
                            Panel_Comment_Contact.Visible = true;
                        }

                        // Bind Post Comment
                        ListView_Comment.DataSource = myBlogMgr.Get_Blog_Comments(Request["NexusBlogPostID"], "1");
                        ListView_Comment.DataKeyNames = new string[] { "CommentID" };

                        Core.Tools.AppItemTemplates myComment_ItemTemplate = new Core.Tools.AppItemTemplates();

                        switch (_comment_itemtemplate)
                        {
                            case "Default":
                                myComment_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/PostComment_Default.ascx";
                                break;
                            case "Custom":
                                myComment_ItemTemplate.ItemTemplatePath = _comment_itemtemplateurl;
                                break;
                            default:
                                myComment_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/PostComment_Default.ascx";
                                break;
                        }

                        myComment_ItemTemplate.Set_Separator("");
                        myComment_ItemTemplate.Set_DataEmpty("");

                        ListView_Comment.ItemTemplate = Page.LoadTemplate(myComment_ItemTemplate.ItemTemplatePath);
                        ListView_Comment.AlternatingItemTemplate = Page.LoadTemplate(myComment_ItemTemplate.AltPath);

                        if (!DataEval.IsEmptyQuery(myComment_ItemTemplate.Separator))
                            ListView_Comment.ItemSeparatorTemplate = Page.LoadTemplate(myComment_ItemTemplate.Separator);

                        if (!DataEval.IsEmptyQuery(myComment_ItemTemplate.DataEmpty))
                            ListView_Comment.EmptyDataTemplate = Page.LoadTemplate(myComment_ItemTemplate.DataEmpty);

                        try
                        {
                            ListView_Comment.DataBind();
                        }
                        catch
                        {
                            // Load Template Failed
                        }

                        DataPager_PostView.PageSize = _numberperpage;
                        DataPager_PostView.Visible = _enable_pager;


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
                TextEditor_BlogContent.Content = myBlog_Post.Post_Content;
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
                                               new e2Data("Post_Content", TextEditor_BlogContent.Content),
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