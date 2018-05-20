using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;


namespace Nexus.Controls.Blog.mBlogPosts
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _blogpostsid;

        private string _postviewurl;
        private bool _showcontent;
        private int _numberperpage;

        private bool _showpublicposts;
        private int _maxnumberposts;
        private string _returnurl;


        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string BlogPostsID
        {
            get
            {
                return _blogpostsid;
            }
            set
            {
                _blogpostsid = value;
                ViewState["BlogPostsID"] = _blogpostsid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PostViewURL
        {
            get
            {
                return _postviewurl;
            }
            set
            {
                _postviewurl = value;
                ViewState["PostViewURL"] = _postviewurl;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool ShowContent
        {
            get
            {
                return _showcontent;
            }
            set
            {
                _showcontent = value;
                ViewState["ShowContent"] = _showcontent;
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
        public bool ShowPublicPosts
        {
            get
            {
                return _showpublicposts;
            }
            set
            {
                _showpublicposts = value;
                ViewState["ShowPublicPosts"] = _showpublicposts;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("10")]
        [Localizable(true)]
        public int MaxNumberPosts
        {
            get
            {
                return _maxnumberposts;
            }
            set
            {
                _maxnumberposts = value;
                ViewState["MaxNumberPosts"] = _maxnumberposts;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ReturnURL
        {
            get
            {
                return _returnurl;
            }
            set
            {
                _returnurl = value;
                ViewState["ReturnURL"] = _returnurl;
            }
        }

        #endregion

        string _ownership_userid;
        string _view_stage;
        string _post_status_show;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _blogpostsid = ViewState["BlogPostsID"].ToString();
                _postviewurl = ViewState["PostViewURL"].ToString();
                _showcontent = Convert.ToBoolean(ViewState["ShowContent"]);
                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);

                _showpublicposts = Convert.ToBoolean(ViewState["ShowPublicPosts"]);
                _maxnumberposts = Convert.ToInt16(ViewState["MaxNumberPosts"]);
                _returnurl = ViewState["ReturnURL"].ToString();

                _ownership_userid = ViewState["Ownership_UserID"].ToString();

            }
            else
            {
                _view_stage = "view_new";
                ViewState["ViewStage"] = _view_stage;
                Control_Init();
            }

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_blogpostsid))
            {
                MultiView_BlogPosts.SetActiveView(View_New);
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_BlogPosts.Enabled = false;
                    ListView_BlogPosts_List.Enabled = false;
                    btn_PostStatus_Show.Enabled = false;

                    _ownership_userid = "ALL";
                    ViewState["Ownership_UserID"] = _ownership_userid;
                }
                else
                {
                    if (DataEval.IsEmptyQuery(Request["NexusBlogUserID"]))
                    {
                        // Not valid Blog UserID
                        Invalid_BlogUserID();
                    }
                    else
                    {
                        // Check Blog UserID is valid
                        Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

                        if (myUserMgr.Chk_UserID_Exist(Request["NexusBlogUserID"]))
                        {
                            _ownership_userid = Request["NexusBlogUserID"];
                            ViewState["Ownership_UserID"] = _ownership_userid;

                            _maxnumberposts = -1;
                        }
                        else
                        {
                            // Not valid Blog UserID
                            Invalid_BlogUserID();
                        }

                    }

                }

                if (_view_stage == "view_add_post")
                {
                    MultiView_BlogPosts.SetActiveView(View_Add_Post);
                }
                else
                {

                    MultiView_BlogPosts.SetActiveView(View_Posts);

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
                    droplist_PostStatus_Show.DataSource = myPost_Statuses;
                    droplist_PostStatus_Show.DataTextField = "Name";
                    droplist_PostStatus_Show.DataValueField = "Value";
                    droplist_PostStatus_Show.DataBind();
                    #endregion

                    _view_stage = "view_posts";
                    ViewState["ViewStage"] = _view_stage;

                    if (DataEval.IsEmptyQuery(_post_status_show))
                    {
                        _post_status_show = droplist_PostStatus_Show.SelectedValue;
                        //ViewState["PostStatus_Show"] = _post_status_show;
                    }
                    else
                    {
                        droplist_PostStatus_Show.SelectedValue = _post_status_show;
                    }

                    #region Check who can change the post

                    if (Security.Users.UserStatus.Validate_Ownership(this.Page, _ownership_userid) ||
                        Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {
                        if (_ownership_userid == "ALL")
                        {
                            lbtn_Add_Post.Visible = false;
                            droplist_PostStatus_Show.Visible = false;
                            btn_PostStatus_Show.Visible = false;
                        }
                        else
                        {
                            lbtn_Add_Post.Visible = true;
                            droplist_PostStatus_Show.Visible = true;
                            btn_PostStatus_Show.Visible = true;
                        }
                    }
                    else
                    {
                        lbtn_Add_Post.Visible = false;
                        droplist_PostStatus_Show.Visible = false;
                        btn_PostStatus_Show.Visible = false;
                    }

                    #endregion

                    Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                    if (_showcontent)
                    {
                        ListView_BlogPosts.DataSource = myBlogMgr.Get_mBlog_Posts(_ownership_userid, _post_status_show, _maxnumberposts);
                        ListView_BlogPosts.DataKeyNames = new string[] { "PostID" };
                        ListView_BlogPosts.DataBind();

                        DataPager_BlogPosts.PageSize = _numberperpage;

                        ListView_BlogPosts.Visible = true;
                        DataPager_BlogPosts.Visible = true;
                        ListView_BlogPosts_List.Visible = false;
                        DataPager_BlogPosts_List.Visible = false;
                    }
                    else
                    {
                        ListView_BlogPosts_List.DataSource = myBlogMgr.Get_mBlog_Posts(_ownership_userid, _post_status_show, _maxnumberposts);
                        ListView_BlogPosts_List.DataKeyNames = new string[] { "PostID" };
                        ListView_BlogPosts_List.DataBind();

                        DataPager_BlogPosts_List.PageSize = _numberperpage;

                        ListView_BlogPosts.Visible = false;
                        DataPager_BlogPosts.Visible = false;
                        ListView_BlogPosts_List.Visible = true;
                        DataPager_BlogPosts_List.Visible = true;

                    }

                }

            }

        }

        // Not a Valid Blog UserID
        private void Invalid_BlogUserID()
        {
            if (_showpublicposts)
            {
                string _current_userid = Security.Users.UserStatus.Current_UserID(this.Page);
                if (_current_userid != "0")
                {
                    Response.Redirect(Core.Tools.URLParse.Update_Arg(Request.Url.ToString(), "NexusBlogUserID", _current_userid));
                }
                else
                {
                    _ownership_userid = "ALL";
                    ViewState["Ownership_UserID"] = _ownership_userid;
                }
            }
            else
            {
                Response.Redirect(_returnurl);
            }
        }

        protected void btn_PostStatus_Show_Click(object sender, EventArgs e)
        {
            _post_status_show = droplist_PostStatus_Show.SelectedValue;
            Control_Init();
        }

        protected string Get_PostViewURL(string BlogPostID)
        {
            return Nexus.Core.Tools.URLParse.Combine_Arg(_postviewurl, string.Format("NexusBlogPostID={0}", BlogPostID));

        }

        protected void lbtn_Add_Post_Click(object sender, EventArgs e)
        {
            _view_stage = "view_add_post";
            ViewState["ViewStage"] = _view_stage;

            MultiView_BlogPosts.SetActiveView(View_Add_Post);

            #region Initiate Post form default setting

            tbx_Title.Text = "";
            RadEditor_BlogContent.Content = "";
            RadEditor_BlogContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";

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

            RadDateTimePicker_PostDate.SelectedDate = DateTime.Now;

            #endregion


        }

        /// <summary>
        /// Create new post 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!DataEval.IsEmptyQuery(_ownership_userid))
                {

                    if (Security.Users.UserStatus.Validate_Ownership(this.Page, _ownership_userid) ||
                        Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {

                        // Check Blog UserID before post
                        if (_ownership_userid == "ALL")
                        {
                            btn_Update.Text = "Blog UserID is not valid";
                            btn_Update.Enabled = false;
                            return;
                        }

                        Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

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
                                               new e2Data("Ownership_UserID", _ownership_userid),
                                               new e2Data("UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                               new e2Data("UserName", Security.Users.UserStatus.Current_UserName(this.Page)),
                                               new e2Data("Post_Date", Post_Date),
                                               new e2Data("Post_ModifyDate", Post_Date),
                                               new e2Data("Post_Title", tbx_Title.Text),
                                               new e2Data("Post_Content", RadEditor_BlogContent.Content),
                                               new e2Data("Post_Status", droplist_PostStatus.SelectedValue),
                                               new e2Data("Post_Password", tbx_Password.Text)
                                           };

                        myBlogMgr.Add_Blog_Post(UpdateData);

                        _view_stage = "view_posts";
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

        protected void ListView_BlogPosts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_BlogPosts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }

        protected void ListView_BlogPosts_List_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_BlogPosts_List.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }
    }
}