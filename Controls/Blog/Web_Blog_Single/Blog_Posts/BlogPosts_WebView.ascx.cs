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

    public partial class WebView : System.Web.UI.UserControl
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

        string _view_stage;
        string _post_status_show;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _blogpostsid = ViewState["BlogPostsID"].ToString();
                _ownership_userid = ViewState["Ownership_UserID"].ToString();
                _postviewurl = ViewState["PostViewURL"].ToString();

                _itemtemplate = ViewState["ItemTemplate"].ToString();
                _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);

                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
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
                    lbtn_Add_Post.Enabled = false;
                    ListView_BlogPosts.Enabled = false;
                    btn_PostStatus_Show.Enabled = false;
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

                    ListView_BlogPosts.DataSource = myBlogMgr.Get_Blog_Posts(_ownership_userid, _post_status_show, _postviewurl);
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

        protected void btn_PostStatus_Show_Click(object sender, EventArgs e)
        {
            _post_status_show = droplist_PostStatus_Show.SelectedValue;
            Control_Init();
        }

        //protected string Get_PostViewURL(string BlogPostID)
        //{
        //    return Nexus.Core.Tools.URLParse.Combine_Arg(_postviewurl, string.Format("NexusBlogPostID={0}", BlogPostID));

        //}

        protected void lbtn_Add_Post_Click(object sender, EventArgs e)
        {
            _view_stage = "view_add_post";
            ViewState["ViewStage"] = _view_stage;

            MultiView_BlogPosts.SetActiveView(View_Add_Post);

            #region Initiate Post form default setting

            tbx_Title.Text = "";
            TextEditor_BlogContent.Content = "";

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
                                               new e2Data("Post_Content", TextEditor_BlogContent.Content),
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
        //protected void ListView_BlogPosts_List_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    DataPager_BlogPosts_List.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    Control_Init();
        //}
    }
}