using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.LoginView
{

    public partial class Advanced : System.Web.UI.UserControl
    {

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

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_loginviewid))
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

                lbl_UserName.Text = "Logged as: " + Security.Users.UserStatus.Current_UserName(this.Page);

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