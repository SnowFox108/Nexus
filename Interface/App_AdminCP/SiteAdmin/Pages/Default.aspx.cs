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
using Nexus.Core.Pages;
using Telerik.Web.UI;

public partial class App_AdminCP_SiteAdmin_Pages_Default : System.Web.UI.Page
{

    private Nexus.Core.Pages.Page_Loading_Info myPage_Loading_Info;

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
        HtmlMeta myKeyword = new HtmlMeta();
        myKeyword.Name = "Keyword";
        myKeyword.Content = myPage_Loading_Info.Page_Keyword;
        this.Header.Controls.Add(myKeyword);

        HtmlMeta myDescription = new HtmlMeta();
        myDescription.Name = "Description";
        myDescription.Content = myPage_Loading_Info.Page_Description;
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
        Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
        myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myPage_Loading_Info.MasterPageIndexID);

        // Load Page Control
        Nexus.Core.Pages.PageMgr myPageMgr = new Nexus.Core.Pages.PageMgr();
        myPageMgr.Load_PageControls_WebView(this.Page, myPage_Loading_Info);
   }

    protected override void OnPreInit(EventArgs e)
    {

        //myPage_Loading_Info = new Nexus.Core.Pages.Page_Loading_Info();

        // Check _pageindexid
        string _pageindexid = Request["PageIndexID"];

        if (DataEval.IsEmptyQuery(_pageindexid))
        {
            // URLrewrite
            _pageindexid = "1";
        }

        // Check PageExist        
        Nexus.Core.Pages.PageMgr myPageMgr = new Nexus.Core.Pages.PageMgr();
        Nexus.Core.Pages.PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

        // Check Properties

        // Check Security

        // Load Pages Template
        Nexus.Core.Pages.Page_PropertyMgr myPropertyMgr = new Nexus.Core.Pages.Page_PropertyMgr();

        myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

        // Get MasterPageID
        //_master_pageindexid = myPage_Loading_Info.MasterPageIndexID;

        //this.StyleSheetTheme = myPage_Loading_Info.Theme;
        this.Theme = myPage_Loading_Info.Theme;
        this.MasterPageFile = myPage_Loading_Info.MasterPage_URL;

        this.Title = myPage_Loading_Info.Page_Title;
        
        base.OnPreInit(e);
    }

}
