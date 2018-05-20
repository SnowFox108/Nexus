using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Controls.News.Lib;

namespace Nexus.Controls.News.NewsDetail
{
    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _newsdetailid;

        private bool _ispagetitle = true;
        private string _newsdetail_itemtemplate = "Default";
        private string _newsdetail_itemtemplateurl = "";

        private bool _iscomment = true;
        private string _commenttitle_itemtemplate = "Default";
        private string _commenttitle_itemtemplateurl = "";
        private string _comment_itemtemplate = "Default";
        private string _comment_itemtemplateurl = "";
        private bool _isguestcomment = true;
        private int _numberperpage = 10;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsDetailID
        {
            get
            {
                return _newsdetailid;
            }
            set
            {
                _newsdetailid = value;
                ViewState["NewsDetailID"] = _newsdetailid;
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
        public string NewsDetail_ItemTemplate
        {
            get
            {
                return _newsdetail_itemtemplate;
            }
            set
            {
                _newsdetail_itemtemplate = value;
                ViewState["NewsDetail_ItemTemplate"] = _newsdetail_itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsDetail_ItemTemplateURL
        {
            get
            {
                return _newsdetail_itemtemplateurl;
            }
            set
            {
                _newsdetail_itemtemplateurl = value;
                ViewState["NewsDetail_ItemTemplateURL"] = _newsdetail_itemtemplateurl;
            }
        }


        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool Enable_Comment
        {
            get
            {
                return _iscomment;
            }
            set
            {
                _iscomment = value;
                ViewState["Enable_Comment"] = _iscomment;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string CommentTitle_ItemTemplate
        {
            get
            {
                return _commenttitle_itemtemplate;
            }
            set
            {
                _commenttitle_itemtemplate = value;
                ViewState["CommentTitle_ItemTemplate"] = _commenttitle_itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CommentTitle_ItemTemplateURL
        {
            get
            {
                return _commenttitle_itemtemplateurl;
            }
            set
            {
                _commenttitle_itemtemplateurl = value;
                ViewState["CommentTitle_ItemTemplateURL"] = _commenttitle_itemtemplateurl;
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
        [Category("Behavior")]
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _newsdetailid = ViewState["NewsDetailID"].ToString();
                _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                _newsdetail_itemtemplate = ViewState["NewsDetail_ItemTemplate"].ToString();
                _newsdetail_itemtemplateurl = ViewState["NewsDetail_ItemTemplateURL"].ToString();

                _iscomment = Convert.ToBoolean(ViewState["Enable_Comment"]);
                _commenttitle_itemtemplate = ViewState["CommentTitle_ItemTemplate"].ToString();
                _commenttitle_itemtemplateurl = ViewState["CommentTitle_ItemTemplateURL"].ToString();
                _comment_itemtemplate = ViewState["Comment_ItemTemplate"].ToString();
                _comment_itemtemplateurl = ViewState["Comment_ItemTemplateURL"].ToString();

                _isguestcomment = Convert.ToBoolean(ViewState["IsGuestComment"]);
                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);

            }
            else
            {
                Control_PreInit();
            }

            Control_Init();

        }

        private void Control_PreInit()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusNewsPostID"]))
            {
                // Add View Count
                Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();

                Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(Request["NexusNewsPostID"]);

                int _view_count = Convert.ToInt32(myNews_Post.View_Count) + 1;

                e2Data[] UpdateData_Post = {
                                               new e2Data("NewsID", myNews_Post.NewsID),
                                               new e2Data("View_Count", _view_count.ToString())
                                           };

                myNewsMgr.Edit_News_Post(UpdateData_Post);
            }
        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_newsdetailid))
            {
                MultiView_NewsDetail.SetActiveView(View_New);
            }
            else
            {

                MultiView_NewsDetail.SetActiveView(View_Detail);

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    hlink_Edit_News.Enabled = false;
                    btn_PostComment.Enabled = false;
                }

                // Init Comment Form
                RadEditor_Comment.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                RadEditor_Comment.EditModes = Telerik.Web.UI.EditModes.Design | Telerik.Web.UI.EditModes.Preview;
                RadEditor_Comment.Content = "";

                if (!DataEval.IsEmptyQuery(Request["NexusNewsPostID"]))
                {

                    Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();

                    Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(Request["NexusNewsPostID"]);

                    if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {
                        hlink_Edit_News.Visible = true;

                        hlink_Edit_News.Attributes["href"] = "#";
                        hlink_Edit_News.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusNewsPostID={1}');", "60B08E61-40DA-4989-B401-81B75A619F85", myNews_Post.NewsID);

                    }
                    else
                    {
                        hlink_Edit_News.Visible = false;
                    }

                    // Page Title
                    if (_ispagetitle)
                        Page.Title = myNews_Post.News_Title;

                    // Fillup Post Content
                    List<News_Post> myNews_Posts = new List<News_Post>();
                    myNews_Posts.Add(myNews_Post);

                    FormView_NewsDetail.DataSource = myNews_Posts;
                    FormView_NewsDetail.DataKeyNames = new string[] { "NewsID" };

                    Core.Tools.AppItemTemplates myNewsDetail_ItemTemplate = new Core.Tools.AppItemTemplates();

                    switch (_newsdetail_itemtemplate)
                    {
                        case "Default":
                            myNewsDetail_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsDetail_Default.ascx";
                            break;
                        case "Custom":
                            myNewsDetail_ItemTemplate.ItemTemplatePath = _newsdetail_itemtemplateurl;
                            break;
                        default:
                            myNewsDetail_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsDetail_Default.ascx";
                            break;
                    }

                    FormView_NewsDetail.ItemTemplate = Page.LoadTemplate(myNewsDetail_ItemTemplate.ItemTemplatePath);

                    try
                    {

                        FormView_NewsDetail.DataBind();
                    }
                    catch
                    {
                        // Load Template Failed
                    }


                    //lbl_Title.Text = myNews_Post.News_Title;
                    //lbl_News_Date.Text = myNews_Post.News_Date_Short;
                    //lbl_UserName.Text = myNews_Post.UserName;
                    //Literal_Content.Text = myNews_Post.News_Content;
                    //lbl_Post_ModifyDate.Text = myNews_Post.News_ModifyDate;
                    //lbl_Comment_Count.Text = myNews_Post.Comment_Count;

                    //// Fillup Author
                    //if (DataEval.IsEmptyQuery(myNews_Post.Author) && DataEval.IsEmptyQuery(myNews_Post.Source_Name))
                    //{
                    //    Panel_Original_Source.Visible = false;
                    //}
                    //else
                    //{
                    //    Panel_Original_Source.Visible = true;

                    //    if (!DataEval.IsEmptyQuery(myNews_Post.Author))
                    //        lbl_Author.Text = "Author : " + myNews_Post.Author;

                    //    if (!DataEval.IsEmptyQuery(myNews_Post.Source_Name_URL))
                    //        lbl_Source_Name.Text = "Source : " + myNews_Post.Source_Name_URL;                        

                    //}

                    // Enable Comment
                    if (_iscomment)
                    {

                        // Show Comment Title
                        #region Show Comment Title
                        FormView_Comment.DataSource = myNews_Posts;
                        FormView_Comment.DataKeyNames = new string[] { "NewsID" };

                        Core.Tools.AppItemTemplates myCommentTitle_ItemTemplate = new Core.Tools.AppItemTemplates();

                        switch (_commenttitle_itemtemplate)
                        {
                            case "Default":
                                myCommentTitle_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsCommentTitle_Default.ascx";
                                break;
                            case "Custom":
                                myCommentTitle_ItemTemplate.ItemTemplatePath = _commenttitle_itemtemplateurl;
                                break;
                            default:
                                myCommentTitle_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsCommentTitle_Default.ascx";
                                break;
                        }

                        FormView_Comment.ItemTemplate = Page.LoadTemplate(myCommentTitle_ItemTemplate.ItemTemplatePath);

                        try
                        {

                            FormView_Comment.DataBind();
                        }
                        catch
                        {
                            // Load Template Failed
                        }

                        #endregion

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
                        ListView_Comment.DataSource = myNewsMgr.Get_News_Comments(Request["NexusNewsPostID"], "1");
                        ListView_Comment.DataKeyNames = new string[] { "CommentID" };

                        Core.Tools.AppItemTemplates myComment_ItemTemplate = new Core.Tools.AppItemTemplates();

                        switch (_comment_itemtemplate)
                        {
                            case "Default":
                                myComment_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsComment_Default.ascx";
                                break;
                            case "Custom":
                                myComment_ItemTemplate.ItemTemplatePath = _comment_itemtemplateurl;
                                break;
                            default:
                                myComment_ItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsComment_Default.ascx";
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

                        Panel_Comment.Visible = true;
                    }
                    else
                    {
                        Panel_Comment.Visible = false;
                    }


                }
                else
                {
                    // No Post ID
                    hlink_Edit_News.Visible = false;
                    Panel_Comment.Visible = false;
                }

            }

        }

        protected void btn_PostComment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!DataEval.IsEmptyQuery(Request["NexusNewsPostID"]))
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


                    Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();

                    e2Data[] UpdateData = {
                                               new e2Data("Parent_CommentID", "-1"),
                                               new e2Data("NewsID", Request["NexusNewsPostID"]),
                                               new e2Data("UserID", _current_userid),
                                               new e2Data("UserName", tbx_Comment_UserName.Text),
                                               new e2Data("UserEmail", tbx_Comment_UserEmail.Text),
                                               new e2Data("UserURL", tbx_Comment_UserURL.Text),
                                               new e2Data("UserIPaddress", Request.ServerVariables["REMOTE_ADDR"]),
                                               new e2Data("Post_Date", DateTime.Now.ToString()),
                                               new e2Data("Post_Content", RadEditor_Comment.Content),
                                               new e2Data("Comment_Approved", "1")
                                           };

                    myNewsMgr.Add_News_Comment(UpdateData);

                    // Add Comment Count
                    Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(Request["NexusNewsPostID"]);

                    int _comment_count = Convert.ToInt32(myNews_Post.Comment_Count) + 1;

                    e2Data[] UpdateData_Post = {
                                               new e2Data("NewsID", myNews_Post.NewsID),
                                               new e2Data("Comment_Count", _comment_count.ToString())
                                           };

                    myNewsMgr.Edit_News_Post(UpdateData_Post);

                    Control_Init();
                }

            }
        }

        //protected void lbtn_Edit_News_Click(object sender, EventArgs e)
        //{

        //}

        protected void ListView_Comment_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_PostView.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }
    }
}