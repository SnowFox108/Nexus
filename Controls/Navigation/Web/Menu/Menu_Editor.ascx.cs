using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Navigation.Menu
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
                return _editmode;
            }
            set
            {
                _editmode = value;
                ViewState["EditMode"] = _editmode;
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
                return _page_controlid;
            }
            set
            {
                _page_controlid = value;
                ViewState["Page_ControlID"] = _page_controlid;
            }
        }

        #endregion

        #region Properties

        private string _menuid;

        private bool _isstatic;
        private string _rootpageindexid;
        private bool _displaysamelevel;
        private bool _displaycategory;
        private string _orientation;
        private string _skin;
        private string _cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string MenuID
        {
            get
            {
                return _menuid;
            }
            set
            {
                _menuid = value;
                ViewState["MenuID"] = _menuid;
            }
        }


        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool IsStatic
        {
            get
            {
                return _isstatic;
            }
            set
            {
                _isstatic = value;
                ViewState["IsStatic"] = _isstatic;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("-1")]
        [Localizable(true)]
        public string RootPageIndexID
        {
            get
            {
                return _rootpageindexid;
            }
            set
            {
                _rootpageindexid = value;
                ViewState["RootPageIndexID"] = _rootpageindexid;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("False")]
        [Localizable(true)]
        public bool DisplaySameLevel
        {
            get
            {
                return _displaysamelevel;
            }
            set
            {
                _displaysamelevel = value;
                ViewState["DisplaySameLevel"] = _displaysamelevel;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool DisplayCategory
        {
            get
            {
                return _displaycategory;
            }
            set
            {
                _displaycategory = value;
                ViewState["DisplayCategory"] = _displaycategory;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("HorizontalBottom")]
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
        public string Skin
        {
            get
            {
                return _skin;
            }
            set
            {
                _skin = value;
                ViewState["Skin"] = _skin;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CssClass
        {
            get
            {
                return _cssclass;
            }
            set
            {
                _cssclass = value;
                ViewState["CssClass"] = _cssclass;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                try
                {
                    _menuid = ViewState["MenuID"].ToString();
                    _isstatic = Convert.ToBoolean(ViewState["IsStatic"]);
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaysamelevel = Convert.ToBoolean(ViewState["DisplaySameLevel"]);
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _orientation = ViewState["Orientation"].ToString();
                    _skin = ViewState["Skin"].ToString();
                    _cssclass = ViewState["CssClass"].ToString();
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

            rbtnlist_IsStatic.SelectedValue = "True";
            tbx_RootPageID.Text = "-1";
            rbtnlist_DisplaySameLevel.SelectedValue = "False";
            rbtnlist_DisplayCategory.SelectedValue = "True";
            droplist_Orientation.SelectedIndex = 0;
            droplist_Skin.SelectedIndex = 0;
            RadComboBox_CssClass.Text = "Default";

            #endregion

            if (!DataEval.IsEmptyQuery(_menuid))
            {

                #region Menu Properties

                rbtnlist_IsStatic.SelectedValue = _isstatic.ToString();
                tbx_RootPageID.Text = _rootpageindexid;
                rbtnlist_DisplaySameLevel.SelectedValue = _displaysamelevel.ToString();
                rbtnlist_DisplayCategory.SelectedValue = _displaycategory.ToString();
                droplist_Orientation.SelectedValue = _orientation;
                droplist_Skin.SelectedValue = _skin;
                RadComboBox_CssClass.Text = _cssclass;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string MenuID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_menuid))
            {

                // Menu Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "MenuID", MenuID),
                                                               new Control_Property(_page_controlid, "IsStatic", rbtnlist_IsStatic.SelectedValue),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplaySameLevel", rbtnlist_DisplaySameLevel.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
                                                               new Control_Property(_page_controlid, "Skin", droplist_Skin.SelectedValue),
                                                               new Control_Property(_page_controlid, "CssClass", RadComboBox_CssClass.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // Menu Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "MenuID", _menuid),
                                                               new Control_Property(_page_controlid, "IsStatic", rbtnlist_IsStatic.SelectedValue),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplaySameLevel", rbtnlist_DisplaySameLevel.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "Orientation", droplist_Orientation.SelectedValue),
                                                               new Control_Property(_page_controlid, "Skin", droplist_Skin.SelectedValue),
                                                               new Control_Property(_page_controlid, "CssClass", RadComboBox_CssClass.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _menuid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }
    }
}