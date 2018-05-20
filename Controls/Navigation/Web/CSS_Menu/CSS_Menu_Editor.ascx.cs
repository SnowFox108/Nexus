using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Navigation.CSS_Menu
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

        private string _css_menuid;

        private bool _isstatic = true;
        private string _rootpageindexid = "-1";
        private bool _displaysamelevel = false;
        private bool _displaycategory = true;
        private string _cssclass;
        private string _active_cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CSS_MenuID
        {
            get
            {
                return _css_menuid;
            }
            set
            {
                _css_menuid = value;
                ViewState["CSS_MenuID"] = _css_menuid;
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

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string Active_CssClass
        {
            get
            {
                return _active_cssclass;
            }
            set
            {
                _active_cssclass = value;
                ViewState["Active_CssClass"] = _active_cssclass;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {

                    _css_menuid = ViewState["CSS_MenuID"].ToString();
                    _isstatic = Convert.ToBoolean(ViewState["IsStatic"]);
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaysamelevel = Convert.ToBoolean(ViewState["DisplaySameLevel"]);
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _cssclass = ViewState["CssClass"].ToString();
                    _active_cssclass = ViewState["Active_CssClass"].ToString();

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
            tbx_CSS.Text = "";
            tbx_ActiveCSS.Text = "";

            #endregion

            if (!DataEval.IsEmptyQuery(_css_menuid))
            {

                #region Menu Properties

                rbtnlist_IsStatic.SelectedValue = _isstatic.ToString();
                tbx_RootPageID.Text = _rootpageindexid;
                rbtnlist_DisplaySameLevel.SelectedValue = _displaysamelevel.ToString();
                rbtnlist_DisplayCategory.SelectedValue = _displaycategory.ToString();
                tbx_CSS.Text = _cssclass;
                tbx_ActiveCSS.Text = _active_cssclass;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string CSS_MenuID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_css_menuid))
            {

                // Menu Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "CSS_MenuID", CSS_MenuID),
                                                               new Control_Property(_page_controlid, "IsStatic", rbtnlist_IsStatic.SelectedValue),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplaySameLevel", rbtnlist_DisplaySameLevel.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "CssClass", tbx_CSS.Text),
                                                               new Control_Property(_page_controlid, "Active_CssClass", tbx_ActiveCSS.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // Menu Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "CSS_MenuID", _css_menuid),
                                                               new Control_Property(_page_controlid, "IsStatic", rbtnlist_IsStatic.SelectedValue),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplaySameLevel", rbtnlist_DisplaySameLevel.SelectedValue),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "CssClass", tbx_CSS.Text),
                                                               new Control_Property(_page_controlid, "Active_CssClass", tbx_ActiveCSS.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _css_menuid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}