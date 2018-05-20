using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Blog.BlogPosts
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _blogpostsid;

        private string _ownership_userid = "";
        private string _postviewurl = "/";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _numberperpage = 10;

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
        public string Ownership_UserID
        {
            get
            {
                return _ownership_userid;
            }
            set
            {
                _ownership_userid = value;
                ViewState["Ownership_UserID"] = _ownership_userid;
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
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string ItemTemplate
        {
            get
            {
                return _itemtemplate;
            }
            set
            {
                _itemtemplate = value;
                ViewState["ItemTemplate"] = _itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ItemTemplateURL
        {
            get
            {
                return _itemtemplateurl;
            }
            set
            {
                _itemtemplateurl = value;
                ViewState["ItemTemplateURL"] = _itemtemplateurl;
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
                    _blogpostsid = ViewState["BlogPostsID"].ToString();
                    _ownership_userid = ViewState["Ownership_UserID"].ToString();
                    _postviewurl = ViewState["PostViewURL"].ToString();

                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
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

            if (DataEval.IsEmptyQuery(_blogpostsid))
            {
                MultiView_BlogPosts.SetActiveView(View_New);
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_BlogPosts.Enabled = false;
                    btn_PostStatus_Show.Enabled = false;
                }

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


                    if (Security.Users.UserStatus.Validate_Ownership(this.Page, _ownership_userid) ||
                        Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {
                        lbtn_Add_Post.Visible = true;
                        droplist_PostStatus_Show.Visible = true;
                        btn_PostStatus_Show.Visible = true;
                    }
                    else
                    {
                        lbtn_Add_Post.Visible = false;
                        droplist_PostStatus_Show.Visible = false;
                        btn_PostStatus_Show.Visible = false;
                    }

                    Lib.BlogMgr myBlogMgr = new Lib.BlogMgr();

                    ListView_BlogPosts.DataSource = myBlogMgr.Get_Blog_Posts(_ownership_userid, "Publish", _postviewurl);
                    ListView_BlogPosts.DataKeyNames = new string[] { "PostID" };

                    Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                    switch (_itemtemplate)
                    {
                        case "Default":
                            myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/BlogPosts_Default.ascx";
                            break;
                        case "TitleOnly":
                            myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/BlogPosts_TitleOnly.ascx";
                            break;
                        case "Custom":
                            myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                            break;
                        default:
                            myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Blog/Templates/BlogPosts_Default.ascx";
                            break;
                    }

                    myItemTemplate.Set_Separator("");
                    myItemTemplate.Set_DataEmpty("");

                    ListView_BlogPosts.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);
                    ListView_BlogPosts.AlternatingItemTemplate = Page.LoadTemplate(myItemTemplate.AltPath);

                    if (!DataEval.IsEmptyQuery(myItemTemplate.Separator))
                        ListView_BlogPosts.ItemSeparatorTemplate = Page.LoadTemplate(myItemTemplate.Separator);

                    if (!DataEval.IsEmptyQuery(myItemTemplate.DataEmpty))
                        ListView_BlogPosts.EmptyDataTemplate = Page.LoadTemplate(myItemTemplate.DataEmpty);

                    try
                    {

                        ListView_BlogPosts.DataBind();
                    }
                    catch
                    {
                        // Load Template Failed
                    }


                    DataPager_BlogPosts.PageSize = _numberperpage;
                    DataPager_BlogPosts.Visible = _enable_pager;
            }

        }

    }
}