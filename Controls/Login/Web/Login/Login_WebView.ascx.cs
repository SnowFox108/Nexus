using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.Login
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _loginid;

        private string _loginurl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LoginID
        {
            get
            {
                return _loginid;
            }
            set
            {
                _loginid = value;
                ViewState["LoginID"] = _loginid;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                _loginid = ViewState["LoginID"].ToString();
                _loginurl = ViewState["LoginURL"].ToString();

            }

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_loginid))
            {
                MultiView_Login.SetActiveView(View_New);
            }
            else
            {
                MultiView_Login.SetActiveView(View_Login);

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    btn_Submit.Enabled = false;
                }
                else
                {
                    Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

                    HttpCookie cookieUserInfo = myUserMgr.Get_UserCookie(this.Page);

                    if (cookieUserInfo != null)
                    {
                        try
                        {

                            if (Convert.ToBoolean(cookieUserInfo["RememberMe"]))
                            {
                                tbx_Email.Text = cookieUserInfo["Email"].ToString();
                                cookieUserInfo.Expires = DateTime.Now.AddDays(30);
                            }
                            else
                            {
                                cookieUserInfo.Expires = DateTime.Now.AddDays(1);
                            }

                            chkbox_RememberMe.Checked = Convert.ToBoolean(cookieUserInfo["RememberMe"]);
                        }
                        catch
                        {
                            chkbox_RememberMe.Checked = false;
                        }
                    }
                    else
                    {
                        chkbox_RememberMe.Checked = false;
                    }
                }

            }

        }

        protected void CustomValidator_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (!myUserMgr.Chk_Email_Exist(tbx_Email.Text))
            {
                args.IsValid = false;
            }

        }

        protected void CustomValidator_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (!myUserMgr.Chk_User_Login(tbx_Email.Text, tbx_Password.Text))
            {
                args.IsValid = false;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

                myUserMgr.Add_UserCookie(this.Page, tbx_Email.Text, tbx_Password.Text, chkbox_RememberMe.Checked);

                Response.Redirect(_loginurl);
            }
        }
    }
}