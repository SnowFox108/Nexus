using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Navigation.Navigator
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

        private string _navigatorid;

        private string _rootpageindexid = "-1";
        private bool _displaycategory = true;
        private string _navigatorsign = ">";
        private string _cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NavigatorID
        {
            get
            {
                return _navigatorid;
            }
            set
            {
                _navigatorid = value;
                ViewState["NavigatorID"] = _navigatorid;
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
        [DefaultValue(">")]
        [Localizable(true)]
        public string NavigatorSign
        {
            get
            {
                return _navigatorsign;
            }
            set
            {
                _navigatorsign = value;
                ViewState["NavigatorSign"] = _navigatorsign;
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
                    _navigatorid = ViewState["NavigatorID"].ToString();
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _navigatorsign = ViewState["NavigatorSign"].ToString();
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

            tbx_RootPageID.Text = "-1";
            rbtnlist_DisplayCategory.SelectedValue = "True";
            tbx_Sign.Text = ">";
            RadComboBox_CssClass.Text = "Disable";

            #endregion

            if (!DataEval.IsEmptyQuery(_navigatorid))
            {

                #region Navigator Properties

                tbx_RootPageID.Text = _rootpageindexid;
                rbtnlist_DisplayCategory.SelectedValue = _displaycategory.ToString();
                tbx_Sign.Text = _navigatorsign;
                RadComboBox_CssClass.Text = _cssclass;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            DateTime nowTime = DateTime.Now;

            string NavigatorID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_navigatorid))
            {

                // Menu Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "NavigatorID", NavigatorID),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "NavigatorSign", tbx_Sign.Text),
                                                               new Control_Property(_page_controlid, "CssClass", RadComboBox_CssClass.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // Menu Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "NavigatorID", _navigatorid),
                                                               new Control_Property(_page_controlid, "RootPageIndexID", tbx_RootPageID.Text),
                                                               new Control_Property(_page_controlid, "DisplayCategory", rbtnlist_DisplayCategory.SelectedValue),
                                                               new Control_Property(_page_controlid, "NavigatorSign", tbx_Sign.Text),
                                                               new Control_Property(_page_controlid, "CssClass", RadComboBox_CssClass.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _navigatorid, _page_controlid, Update_Properties);

            #endregion

            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}