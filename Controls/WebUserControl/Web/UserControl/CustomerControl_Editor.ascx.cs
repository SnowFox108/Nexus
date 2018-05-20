using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.WebUserControls.CustomerControl
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

        private string _webusercontrolid;
        private string _path;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string WebUserControlID
        {
            get
            {
                if (_webusercontrolid == null)
                {
                    return "";
                }
                return _webusercontrolid;
            }
            set
            {
                _webusercontrolid = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Path
        {
            get
            {
                if (_path == null)
                {
                    return "";
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }

        }

        private void Control_Init()
        {

            #region Set Default Setting

            tbx_UserControlPath.Text = "";

            #endregion

            if (!DataEval.IsEmptyQuery(_webusercontrolid))
            {
                tbx_UserControlPath.Text = _path;
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            DateTime nowTime = DateTime.Now;

            string UserControlID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_webusercontrolid))
            {

                // UserControl Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "WebUserControlID", UserControlID),
                                                               new Control_Property(_page_controlid, "Path", tbx_UserControlPath.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // UserControl Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "WebUserControlID", _webusercontrolid),
                                                               new Control_Property(_page_controlid, "Path", tbx_UserControlPath.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();

            switch (_editmode)
            {
                case "PageAdvancedMode":
                    if (DataEval.IsEmptyQuery(_webusercontrolid))
                    {
                        // Create Lock Page_Control Property
                        myControlMgr.Add_Page_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        myControlMgr.Edit_Page_Control_Properties_AdvanceMode(_page_controlid, Update_Properties);
                    }
                    break;

                case "PageDesignMode":
                    if (DataEval.IsEmptyQuery(_webusercontrolid))
                    {
                        // Create Lock Page_Control Property
                        myControlMgr.Add_Page_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        myControlMgr.Edit_Page_Control_Properties_DesignMode(_page_controlid, Update_Properties);

                    }
                    break;

                case "TemplateAdvancedMode":
                    if (DataEval.IsEmptyQuery(_webusercontrolid))
                    {
                        // Create Lock Page_Control Property
                        myControlMgr.Add_MasterPage_Control_Properties_AdvanceMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        myControlMgr.Edit_MasterPage_Control_Properties_AdvanceMode(_page_controlid, Update_Properties);
                    }
                    break;

                case "TemplateDesignMode":
                    if (DataEval.IsEmptyQuery(_webusercontrolid))
                    {
                        // Create Lock Page_Control Property
                        myControlMgr.Add_MasterPage_Control_Properties_DesignMode(Update_Properties);
                    }
                    else
                    {
                        // Update Page_Control Property
                        myControlMgr.Edit_MasterPage_Control_Properties_DesignMode(_page_controlid, Update_Properties);
                    }
                    break;
            }

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}