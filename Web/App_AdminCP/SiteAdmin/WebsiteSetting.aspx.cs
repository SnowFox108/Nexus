using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
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

    public partial class App_AdminCP_SiteAdmin_WebsiteSetting : System.Web.UI.Page
    {

        string _pageindexid = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            Panel_Updated.Visible = false;

            // Home Switch
            rbtn_HomeSwitch.SelectedValue = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomeSwitch");

            // Website Properties
            Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();
            Page_Attribute myPage_Attribute = myPage_PropertyMgr.Get_Page_Attribute(_pageindexid);

            tbx_Page_Title.Text = myPage_Attribute.Page_Title;
            tbx_Page_Keyword.Text = myPage_Attribute.Page_Keyword;
            tbx_Page_Description.Text = myPage_Attribute.Page_Description;

            Page_Template myPage_Template = myPage_PropertyMgr.Get_Page_Template(_pageindexid);

            // Look for Template
            droplist_Template.SelectedValue = myPage_Template.MasterPageIndexID;
            droplist_Template.DataBind();
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
            FormView_Template.DataBind();

            #region Security

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

            Page_Property myPage_Property = myPage_PropertyMgr.Get_Page_Property(_pageindexid);

            rbtn_IsSSL.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsSSL);

            Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

            Security.Pages.Page_PrivacyURL myPage_PrivacyURL = myPrivacyMgr.Get_Page_PrivacyURL(_pageindexid);
            tbx_ReturnURL.Text = myPage_PrivacyURL.ReturnURL;

            // Bind Permission Grid
            GridView_Permissions.DataSource = myPrivacyMgr.Get_Page_Privacy_FullList(_pageindexid);
            GridView_Permissions.DataBind();
            Panel_Page_Permissions.Enabled = true;


            #endregion

            #region MetaTags

            tbx_ScriptURL.Text = "";
            tbx_UpdateScriptURL.Text = "";
            Panel_Update_Script.Visible = false;

            tbx_CSSURL.Text = "";
            tbx_UpdateCSSURL.Text = "";
            Panel_Update_CSS.Visible = false;

            // Script
            PageMgr myPageMgr = new PageMgr();


            GridView_Scripts.DataSource = myPageMgr.Get_Page_MetaTags(_pageindexid, Meta_Type.JavaScript);
            GridView_Scripts.DataBind();

            // CSS
            GridView_CSS.DataSource = myPageMgr.Get_Page_MetaTags(_pageindexid, Meta_Type.StyleSheet);
            GridView_CSS.DataBind();

            #endregion


        }

        protected void btn_HomeSwitch_Click(object sender, EventArgs e)
        {
            Phrases.PhraseMgr myPhraseMgr = new Phrases.PhraseMgr();

            e2Data[] UpdateData = {
                                      new e2Data("VarName", "NexusCore_HomeSwitch"),
                                      new e2Data("PhraseValue", rbtn_HomeSwitch.SelectedValue)
                                  };

            myPhraseMgr.Edit_Phrase(UpdateData);

            Panel_Updated.Visible = true;

        }

        #region Website Properties

        protected void droplist_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
        }

        protected void btn_UpdatePage_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

                // Page Attribute
                e2Data[] UpdateData_Attribute = {
                                                    new e2Data("PageIndexID", _pageindexid),
                                                    new e2Data("Page_Title", tbx_Page_Title.Text),
                                                    new e2Data("Page_Keyword", tbx_Page_Keyword.Text),
                                                    new e2Data("Page_Description", tbx_Page_Description.Text)
                                                 };

                myPropertyMgr.Edit_Page_Attribute(UpdateData_Attribute);

                Thread.Sleep(100);

                // Page Template
                e2Data[] UpdateData_Template = {
                                                   new e2Data("PageIndexID", _pageindexid),
                                                   new e2Data("MasterPageIndexID", droplist_Template.SelectedValue) // Get from Select Template list
                                                };

                myPropertyMgr.Edit_Page_Template(UpdateData_Template);

                Thread.Sleep(100);

                // Page Properties
                e2Data[] UpdateData_Property = {
                                                   new e2Data("PageIndexID", _pageindexid),
                                                   new e2Data("IsSSL", rbtn_IsSSL.SelectedValue)
                                                };

                myPropertyMgr.Edit_Page_Property(UpdateData_Property);

                Thread.Sleep(100);

                // Page Privacy
                Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();

                e2Data[] UpdateData_PrivacyURL = {
                                                 new e2Data("PageIndexID", _pageindexid),
                                                 new e2Data("ReturnURL", tbx_ReturnURL.Text)
                                             };

                myPrivacyMgr.Edit_Page_PrivacyURL(UpdateData_PrivacyURL);

                Panel_Updated.Visible = true;
            }
        }

        #endregion

        #region User Permission

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

            Control_Init();
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
            Control_Init();

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
            Control_Init();
        }

        #endregion

        #region Global Scripts

        protected void btn_AddScript_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PageMgr myPageMgr = new PageMgr();

                // Add New Script
                e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.JavaScript)),
                                      new e2Data("Meta_Src", tbx_ScriptURL.Text)
                                   };

                myPageMgr.Add_Page_MetaTag(UpdateData);

                tbx_ScriptURL.Text = "";

                Control_Init();
            }

        }

        protected void lbtn_Script_Edit_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();
            MetaTag myMetaTag = myPageMgr.Get_Page_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateScriptURL.Text = myMetaTag.Meta_Src;
            btn_UpdateScript.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_Script.Visible = true;

        }

        protected void lbtn_Script_Delete_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();

            // Delete Role
            myPageMgr.Remove_Page_MetaTag(e.CommandArgument.ToString());

            // Update Script List
            Control_Init();

        }

        protected void btn_UpdateScript_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {

                e2Data[] UpdateData = {
                                      new e2Data("MetaTagID", e.CommandArgument.ToString()),
                                      new e2Data("Meta_Src", tbx_UpdateScriptURL.Text)
                                   };

                PageMgr myPageMgr = new PageMgr();
                myPageMgr.Edit_Page_MetaTag(UpdateData);

                tbx_UpdateScriptURL.Text = "";

                // Update Script List
                Control_Init();
            }

        }

        #endregion

        #region CSS

        protected void btn_AddCSS_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PageMgr myPageMgr = new PageMgr();

                // Add New CSS
                e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.StyleSheet)),
                                      new e2Data("Meta_Src", tbx_CSSURL.Text)
                                   };

                myPageMgr.Add_Page_MetaTag(UpdateData);

                tbx_CSSURL.Text = "";

                Control_Init();
            }

        }

        protected void lbtn_CSS_Edit_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();
            MetaTag myMetaTag = myPageMgr.Get_Page_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateCSSURL.Text = myMetaTag.Meta_Src;
            btn_UpdateCSS.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_CSS.Visible = true;

        }

        protected void lbtn_CSS_Delete_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();

            // Delete CSS
            myPageMgr.Remove_Page_MetaTag(e.CommandArgument.ToString());

            // Update Script List
            Control_Init();

        }

        protected void btn_UpdateCSS_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {

                e2Data[] UpdateData = {
                                      new e2Data("MetaTagID", e.CommandArgument.ToString()),
                                      new e2Data("Meta_Src", tbx_UpdateCSSURL.Text)
                                   };

                PageMgr myPageMgr = new PageMgr();
                myPageMgr.Edit_Page_MetaTag(UpdateData);

                tbx_UpdateCSSURL.Text = "";

                // Update Script List
                Control_Init();
            }

        }

        #endregion

    }
}