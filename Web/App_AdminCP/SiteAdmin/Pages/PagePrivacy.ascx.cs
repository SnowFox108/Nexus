using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Pages;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PagePrivacy : System.Web.UI.UserControl
    {

        #region properties

        private string _pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageIndexID
        {
            get
            {
                if (_pageindexid == null)
                {
                    return "";
                }
                return _pageindexid;
            }
            set
            {
                _pageindexid = value;
                ViewState["PageIndexID"] = _pageindexid;
                Control_Init();
                Control_FillData();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _pageindexid = ViewState["PageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_pageindexid == null)
                {
                    ViewState["PageIndexID"] = "";
                    Control_Init();
                }
            }
        }

        public void Update_Disable()
        {
            Panel_Updated.Visible = false;
        }

        private void Control_Init()
        {
            Panel_Updated.Visible = false;
        }

        #region Data Fill

        public void Control_FillData()
        {

            #region Set Default Setting

            #region Security

            // Security
            rbtn_IsPrivacy_Inherited.SelectedValue = "1";
            rbtn_IsSSL.SelectedValue = "0";
            tbx_ReturnURL.Text = "";

            #endregion

            #region Permission

            // Load Usergroup list
            List<Security.Users.UserGroups> myUserGroups = Security.Users.UserMgr.sGet_Usergroups();

            droplist_UserGroup.DataSource = myUserGroups;
            droplist_UserGroup.DataTextField = "UserGroup_Name";
            droplist_UserGroup.DataValueField = "UserGroupID";
            droplist_UserGroup.DataBind();

            droplist_UserGroup.SelectedValue = StringEnum.GetStringValue(Security.Users.UserGroup.RegisteredUser);

            // Set Add User Role Error Message to null
            lbl_AddRolesError.Text = "";

            Panel_Privacy.Visible = false;

            #endregion

            #endregion

            // Page
            Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();
            Page_Property myPage_Property = myPage_PropertyMgr.Get_Page_Property(_pageindexid);

            // Security
            rbtn_IsPrivacy_Inherited.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsPrivacy_Inherited);
            rbtn_IsSSL.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsSSL);

            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

            if (myPage_Property.IsPrivacy_Inherited)
            {
                string _inherited_pageindexid = myPrivacyMgr.Get_Inherited_Privacy_PageIndexID(_pageindexid);
                Security.Pages.Page_PrivacyURL myPage_PrivacyURL = myPrivacyMgr.Get_Page_PrivacyURL(_inherited_pageindexid);
                tbx_ReturnURL.Text = myPage_PrivacyURL.ReturnURL;
                tbx_ReturnURL.Enabled = false;

                // Bind Permission Grid
                GridView_Permissions.DataSource = myPrivacyMgr.Get_Page_Privacy_FullList(_inherited_pageindexid);
                GridView_Permissions.DataBind();
                Panel_Page_Permissions.Enabled = false;
            }
            else
            {
                Security.Pages.Page_PrivacyURL myPage_PrivacyURL = myPrivacyMgr.Get_Page_PrivacyURL(_pageindexid);
                tbx_ReturnURL.Text = myPage_PrivacyURL.ReturnURL;
                tbx_ReturnURL.Enabled = true;

                // Bind Permission Grid
                GridView_Permissions.DataSource = myPrivacyMgr.Get_Page_Privacy_FullList(_pageindexid);
                GridView_Permissions.DataBind();
                Panel_Page_Permissions.Enabled = true;

            }
        }

        #endregion

        protected void rbtn_IsPrivacy_Inherited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_IsPrivacy_Inherited.SelectedValue == "0")
            {
                tbx_ReturnURL.Enabled = true;
            }
            else
            {
                tbx_ReturnURL.Enabled = false;

                Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
                Security.Pages.Page_PrivacyURL myPage_PrivacyURL = myPrivacyMgr.Get_Page_PrivacyURL(myPrivacyMgr.Get_Inherited_Privacy_PageIndexID(_pageindexid));

                tbx_ReturnURL.Text = myPage_PrivacyURL.ReturnURL;

            }

        }

        #region Update Page

        protected void btn_UpdatePage_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

                e2Data[] UpdateData_Property = {
                                                   new e2Data("PageIndexID", _pageindexid),
                                                   new e2Data("IsPrivacy_Inherited", rbtn_IsPrivacy_Inherited.SelectedValue),
                                                   new e2Data("IsSSL", rbtn_IsSSL.SelectedValue)
                                                };

                myPropertyMgr.Edit_Page_Property(UpdateData_Property);

                if (rbtn_IsPrivacy_Inherited.SelectedValue == "1")
                    Remove_Privacy(_pageindexid);
                else
                    Edit_Privacy(_pageindexid);


                // Refresh Page
                 Panel_Updated.Visible = true;
               Control_FillData();

            }
        }

        private void Edit_Privacy(string PageIndexID)
        {
            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

            // Page Index
            e2Data[] UpdateData_PrivacyURL = {
                                                 new e2Data("PageIndexID", PageIndexID),
                                                 new e2Data("ReturnURL", tbx_ReturnURL.Text)
                                             };

            if (myPrivacyMgr.Chk_Page_PrivacyURL(PageIndexID))
            {
                myPrivacyMgr.Edit_Page_PrivacyURL(UpdateData_PrivacyURL);
            }
            else
            {
                myPrivacyMgr.Add_Page_PrivacyURL(UpdateData_PrivacyURL);

                // Add Administrator and Guest Role to Privacy
                // Administrator
                e2Data[] UpdateData_Admin = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("UserGroupID", StringEnum.GetStringValue(Security.Users.UserGroup.Administrator)),
                                      new e2Data("Allow_View", "1"),
                                      new e2Data("Allow_Create", "1"),
                                      new e2Data("Allow_Modify", "1"),
                                      new e2Data("Allow_Delete", "1"),
                                      new e2Data("Allow_Rollback", "1"),
                                      new e2Data("Allow_ChangePermissions", "1"),
                                      new e2Data("Allow_Approve", "1"),
                                      new e2Data("Allow_Publish", "1"),
                                      new e2Data("Allow_DesignMode", "1")
                                   };

                myPrivacyMgr.Add_Page_Privacy(UpdateData_Admin);

                // Guest
                e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("UserGroupID", StringEnum.GetStringValue(Security.Users.UserGroup.Guest)),
                                      new e2Data("Allow_View", "1"),
                                      new e2Data("Allow_Create", "0"),
                                      new e2Data("Allow_Modify", "0"),
                                      new e2Data("Allow_Delete", "0"),
                                      new e2Data("Allow_Rollback", "0"),
                                      new e2Data("Allow_ChangePermissions", "0"),
                                      new e2Data("Allow_Approve", "0"),
                                      new e2Data("Allow_Publish", "0"),
                                      new e2Data("Allow_DesignMode", "0")
                                   };

                myPrivacyMgr.Add_Page_Privacy(UpdateData);

            }
        }

        private void Remove_Privacy(string PageIndexID)
        {
            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

            if (myPrivacyMgr.Chk_Page_PrivacyURL(PageIndexID))
            {
                myPrivacyMgr.Remove_Page_PrivacyURL(PageIndexID);
                myPrivacyMgr.Remove_Page_Privacies(PageIndexID);
            }

        }

        #endregion

        protected void btn_AddRoles_Click(object sender, EventArgs e)
        {
            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

            lbl_AddRolesError.Text = "";
            if (myPrivacyMgr.Chk_Page_Privacy(_pageindexid, droplist_UserGroup.SelectedValue))
            {
                lbl_AddRolesError.Text = "User role already existed!";
                return;
            }
            
            // Add New Role
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("UserGroupID", droplist_UserGroup.SelectedValue),
                                      new e2Data("Allow_View", "1"),
                                      new e2Data("Allow_Create", "0"),
                                      new e2Data("Allow_Modify", "0"),
                                      new e2Data("Allow_Delete", "0"),
                                      new e2Data("Allow_Rollback", "0"),
                                      new e2Data("Allow_ChangePermissions", "0"),
                                      new e2Data("Allow_Approve", "0"),
                                      new e2Data("Allow_Publish", "0"),
                                      new e2Data("Allow_DesignMode", "0")
                                   };

            myPrivacyMgr.Add_Page_Privacy(UpdateData);

            Control_FillData();

        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
            Security.Pages.Page_Privacy_Full myPage_Privacy = myPrivacyMgr.Get_Page_Privacy_Full(e.CommandArgument.ToString());

            if (myPage_Privacy.UserGroupID == StringEnum.GetStringValue(Security.Users.UserGroup.Administrator))
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Administrators permission can not be changed!", "Action failed!");
                return;
            }

            lbl_UserGroup.Text = myPage_Privacy.UserGroup_Name;
            chk_View.Checked = myPage_Privacy.Allow_View;
            chk_Create.Checked = myPage_Privacy.Allow_Create;
            chk_Modify.Checked = myPage_Privacy.Allow_Modify;
            chk_Delete.Checked = myPage_Privacy.Allow_Delete;
            chk_Rollback.Checked = myPage_Privacy.Allow_Rollback;
            chk_ChangePermission.Checked = myPage_Privacy.Allow_ChangePermissions;
            chk_Approve.Checked = myPage_Privacy.Allow_Approve;
            chk_Publish.Checked = myPage_Privacy.Allow_Publish;
            chk_DesignMode.Checked = myPage_Privacy.Allow_DesignMode;
            btn_UpdatePermission.CommandArgument = e.CommandArgument.ToString();

            Panel_Privacy.Visible = true;

        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
            Security.Pages.Page_Privacy_Full myPage_Privacy = myPrivacyMgr.Get_Page_Privacy_Full(e.CommandArgument.ToString());

            if (myPage_Privacy.UserGroupID == StringEnum.GetStringValue(Security.Users.UserGroup.Administrator)
                || myPage_Privacy.UserGroupID == StringEnum.GetStringValue(Security.Users.UserGroup.Guest))
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Administrators and Guest roles can not be deleted!", "Action failed!", 380, 100);
                return;
            }

            // Delete Role
            myPrivacyMgr.Remove_Page_Privacy(e.CommandArgument.ToString());

            // Update Permission List
            Control_FillData();

        }

        protected void btn_UpdatePermission_Command(object sender, CommandEventArgs e)
        {
            e2Data[] UpdateData = {
                                      new e2Data("PrivacyID", e.CommandArgument.ToString()),
                                      new e2Data("Allow_View", chk_View.Checked.ToString()),
                                      new e2Data("Allow_Create", chk_Create.Checked.ToString()),
                                      new e2Data("Allow_Modify", chk_Modify.Checked.ToString()),
                                      new e2Data("Allow_Delete", chk_Delete.Checked.ToString()),
                                      new e2Data("Allow_Rollback", chk_Rollback.Checked.ToString()),
                                      new e2Data("Allow_ChangePermissions", chk_ChangePermission.Checked.ToString()),
                                      new e2Data("Allow_Approve", chk_Approve.Checked.ToString()),
                                      new e2Data("Allow_Publish", chk_Publish.Checked.ToString()),
                                      new e2Data("Allow_DesignMode", chk_DesignMode.Checked.ToString())
                                   };

            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
            myPrivacyMgr.Edit_Page_Privacy(UpdateData);

            // Update Permission List
            Control_FillData();

        }

    }
}