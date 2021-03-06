﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.News.NewsList
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

        private string _newslistid;

        private string _categoryid = "";
        private string _newsdetailurl = "/";
        private string _sortorder = "News_Date";
        private string _orientation = "DESC";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _numberperpage = 10;
        private int _totalnumber = 100;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsListID
        {
            get
            {
                return _newslistid;
            }
            set
            {
                _newslistid = value;
                ViewState["NewsListID"] = _newslistid;
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
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsDetailURL
        {
            get
            {
                return _newsdetailurl;
            }
            set
            {
                _newsdetailurl = value;
                ViewState["NewsDetailURL"] = _newsdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
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
        [DefaultValue("")]
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
        [DefaultValue("")]
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
                    _newslistid = ViewState["NewsListID"].ToString();
                    _categoryid = ViewState["CategoryID"].ToString();
                    _newsdetailurl = ViewState["NewsDetailURL"].ToString();
                    _sortorder = ViewState["SortOrder"].ToString();
                    _orientation = ViewState["Orientation"].ToString();

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

            CategoryTree_Menu.UnSelectItems();
            tbx_NewsDetailURL.Text = "/";
            droplist_SortOrder.SelectedIndex = 0;
            droplist_Orientation.SelectedIndex = 0;
            rbtn_ItemTemplate.SelectedValue = "Default";
            tbx_ItemTemplateURL.Text = "";
            rbtn_Enable_Pager.SelectedValue = "True";
            RadNumericTbx_NumPerPage.Value = 10;
            RadNumericTbx_TotalNumber.Value = 100;

            #endregion

            if (!DataEval.IsEmptyQuery(_newslistid))
            {

                #region News Properties

                CategoryTree_Menu.Checked_CategoryID = _categoryid;
                tbx_NewsDetailURL.Text = _newsdetailurl;
                droplist_SortOrder.SelectedValue = _sortorder;
                droplist_Orientation.SelectedValue = _orientation;
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
                string NewsListID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
                Control_Property[] Update_Properties = { };

                #region Update for Control Data

                // Check Control is New
                if (DataEval.IsEmptyQuery(_newslistid))
                {

                    // The Control Does not have extra table

                    // Create Page_Control Property
                    Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "NewsListID", NewsListID),
                                                               new Control_Property(_page_controlid, "CategoryID", CategoryTree_Menu.Get_CheckdNodes_String()),
                                                               new Control_Property(_page_controlid, "NewsDetailURL", tbx_NewsDetailURL.Text),
                                                               new Control_Property(_page_controlid, "SortOrder", droplist_SortOrder.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
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
                                                               new Control_Property(_page_controlid, "NewsListID", _newslistid),
                                                               new Control_Property(_page_controlid, "CategoryID", CategoryTree_Menu.Get_CheckdNodes_String()),
                                                               new Control_Property(_page_controlid, "NewsDetailURL", tbx_NewsDetailURL.Text),
                                                               new Control_Property(_page_controlid, "SortOrder", droplist_SortOrder.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
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
                myControlMgr.Update_Control_Properties(
                    _editmode,
                    _newslistid,
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
}