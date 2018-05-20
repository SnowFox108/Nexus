using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Ebay.ItemDetail
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

        private string _ebay_itemdetailid;
        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";

        private bool _ispagetitle = true;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Ebay_ItemDetailID
        {
            get
            {
                return _ebay_itemdetailid;
            }
            set
            {
                _ebay_itemdetailid = value;
                ViewState["Ebay_ItemDetailID"] = _ebay_itemdetailid;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _ebay_itemdetailid = ViewState["Ebay_ItemDetailID"].ToString();
                    _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();

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
            rbtn_ItemTemplate.SelectedValue = "Default";
            tbx_ItemTemplateURL.Text = "";

            #endregion

            if (!DataEval.IsEmptyQuery(_ebay_itemdetailid))
            {

                #region Item Properties

                rbtn_IsPageTitle.SelectedValue = _ispagetitle.ToString();
                rbtn_ItemTemplate.SelectedValue = _itemtemplate;
                tbx_ItemTemplateURL.Text = _itemtemplateurl;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string Ebay_ItemDetailID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_ebay_itemdetailid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "Ebay_ItemDetailID", Ebay_ItemDetailID),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplate", rbtn_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplateURL", tbx_ItemTemplateURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "Ebay_ItemDetailID", _ebay_itemdetailid),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplate", rbtn_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplateURL", tbx_ItemTemplateURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _ebay_itemdetailid, _page_controlid, Update_Properties, Security.Users.UserStatus.Current_UserID(this.Page));

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}