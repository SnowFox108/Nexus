using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Gallery.ItemList
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

        private string _photo_itemlistid;

        private string _categoryid = "";
        private string _photo_itemdetailurl = "/";
        private string _sortorder = "SortOrder";
        private string _orientation = "ASC";
        private string _displayid = "Default";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _numberperpage = 12;
        private int _totalnumber = 100;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Photo_ItemListID
        {
            get
            {
                return _photo_itemlistid;
            }
            set
            {
                _photo_itemlistid = value;
                ViewState["Photo_ItemListID"] = _photo_itemlistid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string Photo_ItemDetailURL
        {
            get
            {
                return _photo_itemdetailurl;
            }
            set
            {
                _photo_itemdetailurl = value;
                ViewState["Photo_ItemDetailURL"] = _photo_itemdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("SortOrder")]
        [Localizable(true)]
        public string SortOrder
        {
            get
            {
                return _sortorder;
            }
            set
            {
                _sortorder = value;
                ViewState["SortOrder"] = _sortorder;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("ASC")]
        [Localizable(true)]
        public string Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                ViewState["Orientation"] = _orientation;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string DisplayID
        {
            get
            {
                return _displayid;
            }
            set
            {
                _displayid = value;
                ViewState["DisplayID"] = _displayid;
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
        [DefaultValue("12")]
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
        [DefaultValue("100")]
        [Localizable(true)]
        public int TotalNumber
        {
            get
            {
                return _totalnumber;
            }
            set
            {
                _totalnumber = value;
                ViewState["TotalNumber"] = _totalnumber;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _photo_itemlistid = ViewState["Photo_ItemListID"].ToString();
                    _categoryid = ViewState["CategoryID"].ToString();
                    _photo_itemdetailurl = ViewState["Photo_ItemDetailURL"].ToString();
                    _sortorder = ViewState["SortOrder"].ToString();
                    _orientation = ViewState["Orientation"].ToString();
                    _displayid = ViewState["DisplayID"].ToString();

                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                    _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);

                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
                    _totalnumber = Convert.ToInt16(ViewState["TotalNumber"]);
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

            Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

            #region Bind Data to droplist

            //Bind DisplayID default data
            droplist_DisplayID.DataSource = myPhotoMgr.Get_Photo_Settings();
            droplist_DisplayID.DataTextField = "DisplayID";
            droplist_DisplayID.DataValueField = "DisplayID";
            droplist_DisplayID.DataBind();

            #endregion

            CategoryTree_Menu.UnSelectItems();
            tbx_Photo_ItemDetailURL.Text = "/";
            droplist_SortOrder.SelectedIndex = 0;
            droplist_Orientation.SelectedIndex = 0;
            droplist_DisplayID.SelectedIndex = 0;
            rbtn_ItemTemplate.SelectedValue = "Default";
            tbx_ItemTemplateURL.Text = "";
            rbtn_Enable_Pager.SelectedValue = "True";
            RadNumericTbx_NumPerPage.Value = 12;
            RadNumericTbx_TotalNumber.Value = 100;

            #endregion

            if (!DataEval.IsEmptyQuery(_photo_itemlistid))
            {

                #region Item Properties

                CategoryTree_Menu.Checked_CategoryID = _categoryid;
                tbx_Photo_ItemDetailURL.Text = _photo_itemdetailurl;
                droplist_SortOrder.SelectedValue = _sortorder;
                droplist_Orientation.SelectedValue = _orientation;
                droplist_DisplayID.SelectedValue = _displayid;
                rbtn_ItemTemplate.SelectedValue = _itemtemplate;
                tbx_ItemTemplateURL.Text = _itemtemplateurl;
                rbtn_Enable_Pager.SelectedValue = _enable_pager.ToString();
                RadNumericTbx_NumPerPage.Value = _numberperpage;
                RadNumericTbx_TotalNumber.Value = _totalnumber;

                #endregion

            }
        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CategoryTree_Menu.Get_CheckedNodes().Count < 1)
                args.IsValid = false;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                string Photo_ItemListID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
                Control_Property[] Update_Properties = { };

                #region Update for Control Data

                // Check Control is New
                if (DataEval.IsEmptyQuery(_photo_itemlistid))
                {

                    // The Control Does not have extra table

                    // Create Page_Control Property
                    Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "Photo_ItemListID", Photo_ItemListID),
                                                               new Control_Property(_page_controlid, "CategoryID", CategoryTree_Menu.Get_CheckdNodes_String()),
                                                               new Control_Property(_page_controlid, "Photo_ItemDetailURL", tbx_Photo_ItemDetailURL.Text),
                                                               new Control_Property(_page_controlid, "SortOrder", droplist_SortOrder.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayID", droplist_DisplayID.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplate", rbtn_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplateURL", tbx_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Pager", rbtn_Enable_Pager.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "TotalNumber", RadNumericTbx_TotalNumber.Value.ToString())
                                                    };

                    Update_Properties = PropertieData;

                }
                else
                {
                    // The Control Does not have extra table

                    // Update Page_Control Property
                    Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "Photo_ItemListID", _photo_itemlistid),
                                                               new Control_Property(_page_controlid, "CategoryID", CategoryTree_Menu.Get_CheckdNodes_String()),
                                                               new Control_Property(_page_controlid, "Photo_ItemDetailURL", tbx_Photo_ItemDetailURL.Text),
                                                               new Control_Property(_page_controlid, "SortOrder", droplist_SortOrder.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayID", droplist_DisplayID.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplate", rbtn_ItemTemplate.SelectedValue),
                                                               new Control_Property(_page_controlid, "ItemTemplateURL", tbx_ItemTemplateURL.Text),
                                                               new Control_Property(_page_controlid, "Enable_Pager", rbtn_Enable_Pager.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "TotalNumber", RadNumericTbx_TotalNumber.Value.ToString())
                                                    };

                    Update_Properties = PropertieData;

                }

                #endregion

                #region Update for Control Properties

                ControlMgr myControlMgr = new ControlMgr();
                myControlMgr.Update_Control_Properties(_editmode,
                    _photo_itemlistid,
                    _page_controlid,
                    Update_Properties,
                    Security.Users.UserStatus.Current_UserID(this.Page));

                #endregion


                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }

    }
}