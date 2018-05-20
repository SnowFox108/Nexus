using System;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Templates;
using Telerik.Web.UI;

public partial class App_AdminCP_SiteAdmin_Templates_Default : System.Web.UI.Page
{

    private MasterPageIndex myMasterPageIndex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        Page_Controls();
    }

    private void Page_Init()
    {
        // Load Page Properties
        HtmlMeta myDescription = new HtmlMeta();
        myDescription.Name = "Description";
        myDescription.Content = myMasterPageIndex.MasterPage_Description;
        this.Header.Controls.Add(myDescription);

        // Add Script Manager
        RadScriptManager myScriptMgr = new RadScriptManager();
        myScriptMgr.ID = "RadScriptManager1";

        HtmlForm myForm = (HtmlForm)Page.Master.FindControl("Form_NexusCore");
        myForm.Controls.Add(myScriptMgr);

    }

    private void Page_Controls()
    {
        // Load MasterPage Control
        MasterPageMgr myMasterPageMgr = new MasterPageMgr();
        myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myMasterPageIndex.MasterPageIndexID);
    }

    protected override void OnPreInit(EventArgs e)
    {

        //myPage_Loading_Info = new Nexus.Core.Pages.Page_Loading_Info();

        // Check _pageindexid
        string _masterpageindexid = Request["MasterPageIndexID"];

        if (DataEval.IsEmptyQuery(_masterpageindexid))
        {
            // URLrewrite
            _masterpageindexid = "1";
        }

        // Check MasterPage Exist        
        MasterPageMgr myMasterPageMgr = new MasterPageMgr();
        myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(_masterpageindexid);

        // Check Properties

        // Check Security

        // Apply Them and MasterPage
        ThemeMgr myThemeMgr = new ThemeMgr();
        Theme myTheme = myThemeMgr.Get_Theme(myMasterPageIndex.ThemeID);
        this.Theme = myTheme.Theme_Code;

        TemplateMgr myTemplateMgr = new TemplateMgr();
        Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.MasterPageID);
        this.MasterPageFile = myTemplate_MasterPage.MasterPage_URL;

        this.Title = myMasterPageIndex.MasterPage_Name;

        base.OnPreInit(e);
    }

}