using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.News.NewsDetail
{
    public partial class Editor : System.Web.UI.UserControl
    {

        #region Basic Properties, Must Have to get control work

        private string _page_controlid;
        private string _editmode;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string EditMode
        {
            get
            {
                if (_editmode == null)
                {
                    return "";
                }
                return _editmode;
            }
            set
            {
                _editmode = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Page_ControlID
        {
            get
            {
                if (_page_controlid == null)
                {
                    return "";
                }
                return _page_controlid;
            }
            set
            {
                _page_controlid = value;
            }
        }

        #endregion

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
            else
            {
                Control_Init();
            }

        }

        private void Control_Init()
        {

            #region Set Default Setting

            rbtn_IsPageTitle.SelectedValue = "True";
            rbtn_NewsDetail_ItemTemplate.SelectedValue = "Default";
            tbx_NewsDetail_ItemTemplateURL.Text = "";

            rbtn_IsComment.SelectedValue = "True";
            rbtn_CommentTitle_ItemTemplate.SelectedValue = "Default";
            tbx_CommentTitle_ItemTemplateURL.Text = "";

            rbtn_Comment_ItemTemplate.SelectedValue = "Default";
            tbx_Comment_ItemTemplateURL.Text = "";

            rbtn_IsGuestComment.SelectedValue = "True";
            RadNumericTbx_NumPerPage.Value = 10;

            #endregion

            if (!DataEval.IsEmptyQuery(_newsdetailid))
            {

                #region Blog Properties

                rbtn_IsPageTitle.SelectedValue = _ispagetitle.ToString();
                rbtn_NewsDetail_ItemTemplate.SelectedValue = _newsdetail_itemtemplate;
                tbx_NewsDetail_ItemTemplateURL.Text = _newsdetail_itemtemplateurl;

                rbtn_IsComment.SelectedValue = _iscomment.ToString();
                rbtn_CommentTitle_ItemTemplate.SelectedValue = _commenttitle_itemtemplate;
                tbx_CommentTitle_ItemTemplateURL.Text = _commenttitle_itemtemplateurl;

                rbtn_Comment_ItemTemplate.SelectedValue = _comment_itemtemplate;
                tbx_Comment_ItemTemplateURL.Text = _comment_itemtemplateurl;

                rbtn_IsGuestComment.SelectedValue = _isguestcomment.ToString();
                RadNumericTbx_NumPerPage.Value = _numberperpage;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string NewsDetailID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_newsdetailid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "NewsDetailID", NewsDetailID),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "NewsDetail_ItemTemplate", rbtn_NewsDetail_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "NewsDetail_ItemTemplateURL", tbx_NewsDetail_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Comment", rbtn_IsComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "CommentTitle_ItemTemplate", rbtn_CommentTitle_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "CommentTitle_ItemTemplateURL", tbx_CommentTitle_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplate", rbtn_Comment_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplateURL", tbx_Comment_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString())
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "NewsDetailID", _newsdetailid),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "NewsDetail_ItemTemplate", rbtn_NewsDetail_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "NewsDetail_ItemTemplateURL", tbx_NewsDetail_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Comment", rbtn_IsComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "CommentTitle_ItemTemplate", rbtn_CommentTitle_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "CommentTitle_ItemTemplateURL", tbx_CommentTitle_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplate", rbtn_Comment_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplateURL", tbx_Comment_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString())
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(
                _editmode,
                _newsdetailid,
                _page_controlid,
                Update_Properties,
                Security.Users.UserStatus.Current_UserID(this.Page)
                );

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}