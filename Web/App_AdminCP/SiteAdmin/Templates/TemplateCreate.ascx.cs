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
using Nexus.Core.Templates;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Templates_TemplateCreate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            #region Set Default Setting

            // Master Page
            tbx_MasterPage_Name.Text = "";
            tbx_MasterPage_Description.Text = "";

            if (droplist_Template.Items.Count > 1)
            {
                droplist_Template.SelectedIndex = 1;
                droplist_Masterpage.DataBind();
                droplist_Theme.DataBind();

                MasterPageMgr myMasterPageMgr = new MasterPageMgr();

                TemplateMgr myTemplateMgr = new TemplateMgr();
                Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(droplist_Masterpage.SelectedValue);

                ThemeMgr myThemeMgr = new ThemeMgr();
                Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

                Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));
            }


            #endregion

        }

        protected void droplist_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            droplist_Masterpage.DataBind();
            droplist_Theme.DataBind();

            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(droplist_Masterpage.SelectedValue);

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));

        }

        protected void droplist_Masterpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(droplist_Masterpage.SelectedValue);

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));

        }

        protected void droplist_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(droplist_Masterpage.SelectedValue);

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));

        }

        protected void droplist_Theme_DataBound(object sender, EventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(droplist_Masterpage.SelectedValue);

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));
        }

        protected void btn_AddMasterpage_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string MasterPageIndexID = Tools.IDGenerator.Get_New_GUID_PlainText();

                // MasterPage Index
                e2Data[] UpdateData = {
                                          new e2Data("MasterPageIndexID", MasterPageIndexID),
                                          new e2Data("MasterPage_Name", tbx_MasterPage_Name.Text),
                                          new e2Data("TemplateID", droplist_Template.SelectedValue),
                                          new e2Data("Template_MasterPageID", droplist_Masterpage.SelectedValue),
                                          new e2Data("ThemeID", droplist_Theme.SelectedValue),
                                          new e2Data("MasterPage_Description", tbx_MasterPage_Description.Text)
                                      };

                MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                myMasterPageMgr.Add_MasterPageIndex(UpdateData);

                // MasterPage Version
                string MasterPageID = Tools.IDGenerator.Get_New_GUID_PlainText();
                string NowDate = DateTime.Now.ToString();

                e2Data[] UpdateData_MasterPage = {
                                                     new e2Data("MasterPageID", MasterPageID),
                                                     new e2Data("MasterPageIndexID", MasterPageIndexID),
                                                     new e2Data("MasterPage_Version", "1"),
                                                     new e2Data("Create_Date", NowDate),
                                                     new e2Data("LastUpdate_Date", NowDate),
                                                     new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                                     new e2Data("IsActive", "1"),
                                                     new e2Data("IsDelete", "0")
                                                  };

                myMasterPageMgr.Add_MasterPage(UpdateData_MasterPage);

                // Finishe Update
                Response.Redirect(string.Format("Templates.aspx?MasterPageIndexID={0}", MasterPageIndexID));

            }
        }

    }
}