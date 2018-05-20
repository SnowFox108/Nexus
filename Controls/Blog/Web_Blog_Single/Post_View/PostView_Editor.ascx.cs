using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Blog.PostView
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
            else
            {
                Control_Init();
            }


        }

        private void Control_Init()
        {

            #region Set Default Setting

            rbtn_IsPageTitle.SelectedValue = "True";
            rbtn_PostView_ItemTemplate.SelectedValue = "Default";
            tbx_PostView_ItemTemplateURL.Text = "";

            rbtn_IsGuestComment.SelectedValue = "True";
            rbtn_Comment_ItemTemplate.SelectedValue = "Default";
            tbx_Comment_ItemTemplateURL.Text = "";

            rbtn_Enable_Pager.SelectedValue = true.ToString();
            RadNumericTbx_NumPerPage.Value = 10;

            #endregion

            if (!DataEval.IsEmptyQuery(_postviewid))
            {

                #region Blog Properties

                rbtn_IsPageTitle.SelectedValue = _ispagetitle.ToString();
                rbtn_PostView_ItemTemplate.SelectedValue = _postview_itemtemplate;
                tbx_PostView_ItemTemplateURL.Text = _postview_itemtemplateurl;

                rbtn_IsGuestComment.SelectedValue = _isguestcomment.ToString();
                rbtn_Comment_ItemTemplate.SelectedValue = _comment_itemtemplate;
                tbx_Comment_ItemTemplateURL.Text = _comment_itemtemplateurl;

                rbtn_Enable_Pager.SelectedValue = _enable_pager.ToString();
                RadNumericTbx_NumPerPage.Value = _numberperpage;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string PostViewID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_postviewid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "PostViewID", PostViewID),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "PostView_ItemTemplate", rbtn_PostView_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "PostView_ItemTemplateURL", tbx_PostView_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplate", rbtn_Comment_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplateURL", tbx_Comment_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Pager", rbtn_Enable_Pager.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString())
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "PostViewID", _postviewid),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "PostView_ItemTemplate", rbtn_PostView_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "PostView_ItemTemplateURL", tbx_PostView_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplate", rbtn_Comment_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "Comment_ItemTemplateURL", tbx_Comment_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Pager", rbtn_Enable_Pager.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString())
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(
                _editmode,
                _postviewid,
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