using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Login.CreateUser
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
                _createuserid = ViewState["CreateUserID"].ToString();
                _iscaptcha = Convert.ToBoolean(ViewState["IsCaptcha"]);
                _displayresult = Convert.ToBoolean(ViewState["DisplayResult"]);
                _successfulurl = ViewState["SuccessfulURL"].ToString();
                _successfultext = ViewState["SuccessfulText"].ToString();
                _usergroupid = ViewState["UserGroupID"].ToString();

            }
            else
            {
                Control_Init();
            }

        }

        private void Control_Init()
        {

            #region Set Default Setting

            rbtn_DisplayResult.SelectedValue = "True";
            tbx_SuccessfulURL.Text = "/";
            RadEditor_SuccessfulText.Content = "<H1>Successfully registered!</H1>";

            // Load Usergroup list
            List<Security.Users.UserGroups> myUserGroups = Security.Users.UserMgr.sGet_Usergroups();

            droplist_UserGroup.DataSource = myUserGroups;
            droplist_UserGroup.DataTextField = "UserGroup_Name";
            droplist_UserGroup.DataValueField = "UserGroupID";
            droplist_UserGroup.DataBind();

            droplist_UserGroup.SelectedValue = StringEnum.GetStringValue(Security.Users.UserGroup.RegisteredUser);

            #endregion

            if (!DataEval.IsEmptyQuery(_createuserid))
            {

                #region Login Properties

                rbtn_DisplayResult.SelectedValue = _displayresult.ToString();
                tbx_SuccessfulURL.Text = _successfulurl;
                RadEditor_SuccessfulText.Content = _successfultext;
                droplist_UserGroup.SelectedValue = _usergroupid;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string CreateUserID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_createuserid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "CreateUserID", CreateUserID),
                                                               new Control_Property(_page_controlid, "DisplayResult", rbtn_DisplayResult.SelectedValue),
                                                               new Control_Property(_page_controlid, "SuccessfulURL", tbx_SuccessfulURL.Text),
                                                               new Control_Property(_page_controlid, "SuccessfulText", RadEditor_SuccessfulText.Content),
                                                               new Control_Property(_page_controlid, "UserGroupID", droplist_UserGroup.SelectedValue)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "CreateUserID", _createuserid),
                                                               new Control_Property(_page_controlid, "DisplayResult", rbtn_DisplayResult.SelectedValue),
                                                               new Control_Property(_page_controlid, "SuccessfulURL", tbx_SuccessfulURL.Text),
                                                               new Control_Property(_page_controlid, "SuccessfulText", RadEditor_SuccessfulText.Content),
                                                               new Control_Property(_page_controlid, "UserGroupID", droplist_UserGroup.SelectedValue)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _createuserid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}