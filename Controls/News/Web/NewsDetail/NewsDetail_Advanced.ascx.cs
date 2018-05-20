using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.News.NewsDetail
{
    public partial class Advanced : System.Web.UI.UserControl
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
                try
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
                catch
                {
                    // nothing to do
                }


            }

            Control_Init();

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

                // Init Item Template Check
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

                Literal_NewsDetail.Text = "Item Template: " + myNewsDetail_ItemTemplate.ItemTemplatePath;

                // Comment Title
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

                Literal_CommentTitle.Text = "Item Template: " + myCommentTitle_ItemTemplate.ItemTemplatePath;

                // Comment

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

                Literal_Comment.Text = "Item Template: " + myComment_ItemTemplate.ItemTemplatePath;
                Literal_Comment.Text += "\n <br /> " + "Item Alter Template: " + myComment_ItemTemplate.AltPath;

                if (!DataEval.IsEmptyQuery(myComment_ItemTemplate.Separator))
                    Literal_Comment.Text += "\n <br /> " + "Item Template Separator: " + myComment_ItemTemplate.Separator;
                else
                    Literal_Comment.Text += "\n <br /> " + "Item Template Separator: None";


                if (!DataEval.IsEmptyQuery(myComment_ItemTemplate.DataEmpty))
                    Literal_Comment.Text += "\n <br /> " + "Item Data Empty Template: " + myComment_ItemTemplate.DataEmpty;
                else
                    Literal_Comment.Text += "\n <br /> " + "Item Data Empty Template: None";



            }

        }

    }
}