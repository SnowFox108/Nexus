using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.LoginStatus
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _loginstatusid;

        private string _loginurl = "/";
        private string _logouturl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LoginStatusID
        {
            get
            {
                return _loginstatusid;
            }
            set
            {
                _loginstatusid = value;
                ViewState["LoginStatusID"] = _loginstatusid;
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
                    _loginstatusid = ViewState["LoginStatusID"].ToString();
                    _loginurl = ViewState["LoginURL"].ToString();
                    _logouturl = ViewState["LogoutURL"].ToString();
                }
                catch
                {
                    // nothing to do
                }                

            }

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_loginstatusid))
            {
                MultiView_Status.SetActiveView(View_New);
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    lbtn_Login.Enabled = false;
                    lbtn_Logout.Enabled = false;
                }

                if (Security.Users.UserStatus.Current_UserID(this.Page) == "0")
                {
                    MultiView_Status.SetActiveView(View_Login);
                }
                else
                {
                    MultiView_Status.SetActiveView(View_Logout);
                }
            }
        }

    }
}