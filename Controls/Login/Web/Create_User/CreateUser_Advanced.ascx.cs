using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.CreateUser
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _createuserid;

        private bool _iscaptcha = true;
        private bool _displayresult = true;
        private string _successfulurl = "/";
        private string _successfultext = "Successfully registered!";

        private string _usergroupid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CreateUserID
        {
            get
            {
                return _createuserid;
            }
            set
            {
                _createuserid = value;
                ViewState["CreateUserID"] = _createuserid;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool IsCaptcha
        {
            get
            {
                return _iscaptcha;
            }
            set
            {
                _iscaptcha = value;
                ViewState["IsCaptcha"] = _iscaptcha;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool DisplayResult
        {
            get
            {
                return _displayresult;
            }
            set
            {
                _displayresult = value;
                ViewState["DisplayResult"] = _displayresult;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string SuccessfulURL
        {
            get
            {
                return _successfulurl;
            }
            set
            {
                _successfulurl = value;
                ViewState["SuccessfulURL"] = _successfulurl;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("Successfully registered!")]
        [Localizable(true)]
        public string SuccessfulText
        {
            get
            {
                return _successfultext;
            }
            set
            {
                _successfultext = value;
                ViewState["SuccessfulText"] = _successfultext;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string UserGroupID
        {
            get
            {
                return _usergroupid;
            }
            set
            {
                _usergroupid = value;
                ViewState["UserGroupID"] = _usergroupid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _createuserid = ViewState["CreateUserID"].ToString();
                    _displayresult = Convert.ToBoolean(ViewState["DisplayResult"]);
                    _successfulurl = ViewState["SuccessfulURL"].ToString();
                    _successfultext = ViewState["SuccessfulText"].ToString();
                    _usergroupid = ViewState["UserGroupID"].ToString();
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

            if (DataEval.IsEmptyQuery(_createuserid))
            {
                MultiView_SignUp.SetActiveView(View_New);
            }
            else
            {
                Literal_SuccessfulText.Text = _successfultext;

                // enable captcha
                //if (_iscaptcha)
                //    RadCaptcha_CreateUser.Visible = true;
                //else
                //    RadCaptcha_CreateUser.Visible = false;

                MultiView_SignUp.SetActiveView(View_SignUp);
            }

        }

        protected void CustomValidator_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (myUserMgr.Chk_UserName_Exist(tbx_UserName.Text))
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (myUserMgr.Chk_Email_Exist(tbx_Email.Text))
            {
                args.IsValid = false;
            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // User Created

                if (_displayresult)
                {
                    Literal_SuccessfulText.Text = _successfultext;

                }
                else
                {
                    Response.Redirect(_successfulurl);
                }
            }
        }
    }
}