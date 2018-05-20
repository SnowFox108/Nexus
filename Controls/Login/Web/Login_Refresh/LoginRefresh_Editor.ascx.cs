using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Login.LoginRefresh
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

        private string _loginrefreshid;

        private string _returnurl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LoginRefreshID
        {
            get
            {
                return _loginrefreshid;
            }
            set
            {
                _loginrefreshid = value;
                ViewState["LoginRefreshID"] = _loginrefreshid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string ReturnURL
        {
            get
            {
                return _returnurl;
            }
            set
            {
                _returnurl = value;
                ViewState["ReturnURL"] = _returnurl;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _loginrefreshid = ViewState["LoginRefreshID"].ToString();
                    _returnurl = ViewState["ReturnURL"].ToString();
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

            tbx_ReturnURL.Text = "/";

            #endregion

            if (!DataEval.IsEmptyQuery(_loginrefreshid))
            {

                #region Login Properties

                tbx_ReturnURL.Text = _returnurl;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string LoginRefreshID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_loginrefreshid))
            {

                // Login Refresh Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "LoginRefreshID", LoginRefreshID),
                                                               new Control_Property(_page_controlid, "ReturnURL", tbx_ReturnURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // Login Refresh Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "LoginRefreshID", _loginrefreshid),
                                                               new Control_Property(_page_controlid, "ReturnURL", tbx_ReturnURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _loginrefreshid, _page_controlid, Update_Properties);

            #endregion

            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}