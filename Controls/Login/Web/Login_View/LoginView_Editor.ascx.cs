﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Login.LoginView
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

        private string _loginviewid;

        private string _loginurl = "/";
        private string _logouturl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LoginViewID
        {
            get
            {
                return _loginviewid;
            }
            set
            {
                _loginviewid = value;
                ViewState["LoginViewID"] = _loginviewid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string LoginURL
        {
            get
            {
                return _loginurl;
            }
            set
            {
                _loginurl = value;
                ViewState["LoginURL"] = _loginurl;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string LogoutURL
        {
            get
            {
                return _logouturl;
            }
            set
            {
                _logouturl = value;
                ViewState["LogoutURL"] = _logouturl;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _loginviewid = ViewState["LoginViewID"].ToString();
                    _loginurl = ViewState["LoginURL"].ToString();
                    _logouturl = ViewState["LogoutURL"].ToString();
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

            tbx_LoginURL.Text = "/";
            tbx_LogoutURL.Text = "/";

            #endregion

            if (!DataEval.IsEmptyQuery(_loginviewid))
            {

                #region Login Properties

                tbx_LoginURL.Text = _loginurl;
                tbx_LogoutURL.Text = _logouturl;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string LoginViewID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_loginviewid))
            {

                // Login Refresh Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "LoginViewID", LoginViewID),
                                                               new Control_Property(_page_controlid, "LoginURL", tbx_LoginURL.Text),
                                                               new Control_Property(_page_controlid, "LogoutURL", tbx_LogoutURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // Login Refresh Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "LoginViewID", _loginviewid),
                                                               new Control_Property(_page_controlid, "LoginURL", tbx_LoginURL.Text),
                                                               new Control_Property(_page_controlid, "LogoutURL", tbx_LogoutURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _loginviewid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }


    }
}