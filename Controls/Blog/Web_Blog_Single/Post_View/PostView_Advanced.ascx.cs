using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Controls.Blog.Lib;

namespace Nexus.Controls.Blog.PostView
{

    public partial class Advanced : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
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


                MultiView_PostView.SetActiveView(View_Post);

                // Init Comment Form
                RadEditor_Comment.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                RadEditor_Comment.EditModes = Telerik.Web.UI.EditModes.Design | Telerik.Web.UI.EditModes.Preview;


                // Fillup Post Content
                if (!DataEval.IsEmptyQuery(Request["NexusBlogPostID"]))
                {


                    Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                    Lib.Blog_Post myBlog_Post = myBlogMgr.Get_Blog_Post(Request["NexusBlogPostID"]);

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

                    //lbl_Title.Text = "Demo Title...";
                    //lbl_Post_Date.Text = DateTime.Now.ToShortDateString();
                    //lbl_UserName.Text = "Demo User Name";
                    //Literal_Content.Text = "<p>Demo Content...</p>";
                    //lbl_Post_ModifyDate.Text = DateTime.Now.ToString();
                    //lbl_Comment_Count.Text = "0";

                    //// Add Social button
                    //PlaceHolder_SocialNetwork.Controls.Clear();

                    //HyperLink myHyperLink = new HyperLink();
                    //myHyperLink.ImageUrl = "~/App_Control_Style/Nexus_Blog/SocialBookmark/Facebook_24.png";

                    //PlaceHolder_SocialNetwork.Controls.Add(myHyperLink);
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
}