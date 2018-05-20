using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Login.CreateUser
{

    public partial class WebView : System.Web.UI.UserControl
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

        bool _issubmit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _createuserid = ViewState["CreateUserID"].ToString();
                _iscaptcha = Convert.ToBoolean(ViewState["IsCaptcha"]);
                _displayresult = Convert.ToBoolean(ViewState["DisplayResult"]);
                _successfulurl = ViewState["SuccessfulURL"].ToString();
                _successfultext = ViewState["SuccessfulText"].ToString();
                _usergroupid = ViewState["UserGroupID"].ToString();

                _issubmit = Convert.ToBoolean(ViewState["IsSubmit"]);

            }
            else
            {
                _issubmit = false;
                ViewState["IsSubmit"] = _issubmit;
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
                if (_issubmit)
                {
                    MultiView_SignUp.SetActiveView(View_Succeed);
                }
                else
                {
                    if (Request.QueryString["PageLink"] == "Disable")
                    {
                        btn_Submit.Enabled = false;
                    }

                    // enable captcha
                    //if (_iscaptcha)
                    //    RadCaptcha_CreateUser.Visible = true;
                    //else
                    //    RadCaptcha_CreateUser.Visible = false;


                    MultiView_SignUp.SetActiveView(View_SignUp);
                }

            }

        }


        protected void CustomValidator_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (myUserMgr.Chk_UserName_Exist_ALL(tbx_UserName.Text))
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            if (myUserMgr.Chk_Email_Exist_ALL(tbx_Email.Text))
            {
                args.IsValid = false;
            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

                string UserID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                e2Data[] UpdateData_User = {
                                               new e2Data("UserID", UserID),
                                               new e2Data("UserName", tbx_UserName.Text),
                                               new e2Data("Email", tbx_Email.Text),
                                               new e2Data("UserPass", tbx_Password.Text),
                                               new e2Data("CreateDate", DateTime.Now.ToString()),
                                               new e2Data("CreateIPaddress", Request.ServerVariables["REMOTE_ADDR"])
                                           };

                myUserMgr.Add_Users(UpdateData_User);

                e2Data[] UpdateData_UserGroup = {
                                                    new e2Data("UserID", UserID),
                                                    new e2Data("UserGroupID", _usergroupid)
                                                };

                myUserMgr.Add_UserInGroup(UpdateData_UserGroup);

                // User Created
                _issubmit = true;
                ViewState["IsSubmit"] = _issubmit;

                if (_displayresult)
                {
                    Literal_SuccessfulText.Text = _successfultext;

                    MultiView_SignUp.SetActiveView(View_Succeed);
                }
                else
                {
                    Response.Redirect(_successfulurl);
                }

            }
        }

    }
}