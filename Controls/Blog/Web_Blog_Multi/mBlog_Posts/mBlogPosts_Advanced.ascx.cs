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

    public partial class Advanced : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                try
                {
                    _blogpostsid = ViewState["BlogPostsID"].ToString();
                    _postviewurl = ViewState["PostViewURL"].ToString();
                    _showcontent = Convert.ToBoolean(ViewState["ShowContent"]);
                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);

                    _showpublicposts = Convert.ToBoolean(ViewState["ShowPublicPosts"]);
                    _maxnumberposts = Convert.ToInt16(ViewState["MaxNumberPosts"]);
                    _returnurl = ViewState["ReturnURL"].ToString();

                }
                catch
                {
                    // nothing to do
                }
            }

            Control_Init();

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
                }


                MultiView_BlogPosts.SetActiveView(View_Posts);


                // Check Blog UserID is valid
                _ownership_userid = "ALL";
                _maxnumberposts = -1;

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
                    ListView_BlogPosts.DataSource = myBlogMgr.Get_mBlog_Posts(_ownership_userid, "Publish", _maxnumberposts);
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
                    ListView_BlogPosts_List.DataSource = myBlogMgr.Get_mBlog_Posts(_ownership_userid, "Publish", _maxnumberposts);
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
}