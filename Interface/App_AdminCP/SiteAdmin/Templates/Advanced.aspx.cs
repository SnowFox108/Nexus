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

public partial class App_AdminCP_SiteAdmin_Templates_Advanced : System.Web.UI.Page
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

        // Add CSS for Advanced window
        string[] CssFiles = {
                                 "~/App_Themes/NexusCore/Editor.css",
                             };

        foreach (string CssFile in CssFiles)
        {
            HtmlLink cssEditor_Link = new HtmlLink();
            cssEditor_Link.Href = CssFile;
            cssEditor_Link.Attributes.Add("type", "text/css");
            cssEditor_Link.Attributes.Add("rel", "stylesheet");
            Header.Controls.Add(cssEditor_Link);
        }


        // Add Script File for Advanced window
        string[] Scripts = {
                           };

        foreach (string myScript in Scripts)
        {
            string MapPath = Request.ApplicationPath;

            if (MapPath.EndsWith("/"))
            {
                MapPath = MapPath.Remove(MapPath.Length - 1) + myScript;
            }
            else
            {
                MapPath = MapPath + myScript;
            }

            HtmlGenericControl scriptTag = new HtmlGenericControl("script");
            scriptTag.Attributes.Add("type", "text/javascript");
            scriptTag.Attributes.Add("src", MapPath);
            Header.Controls.Add(scriptTag);
        }

        // Add Script Manager
        RadScriptManager myScriptMgr = new RadScriptManager();
        myScriptMgr.ID = "RadScriptManager1";

        HtmlForm myForm = (HtmlForm)Page.Master.FindControl("Form_NexusCore");
        myForm.Controls.Add(myScriptMgr);

        // Add PlaceHolder
        PlaceHolder myPlaceHolder = new PlaceHolder();
        myPlaceHolder.ID = "PlaceHolder_AdvancedMode";

        #region Add Control Manager Windows
        // Create CodeBlock
        RadScriptBlock myCodeBlock = new RadScriptBlock();

        // Create Script Tag
        HtmlGenericControl myCodeBlock_ScriptTag = new HtmlGenericControl("Script");
        myCodeBlock_ScriptTag.Attributes.Add("type", "text/javascript");
        myCodeBlock_ScriptTag.InnerHtml = Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_PageEditor_PoPWindow");
        myCodeBlock.Controls.Add(myCodeBlock_ScriptTag);

        // Create Window Manager
        RadWindowManager myWindowManager = new RadWindowManager();
        myWindowManager.ID = "RadWindowManager_ControlManager";

        // Create RadWindow
        RadWindow myRadWindow = new RadWindow();
        myRadWindow.ID = "RadWindow_ControlManager";
        myRadWindow.Title = "User Control Manager";
        myRadWindow.ReloadOnShow = true;
        myRadWindow.ShowContentDuringLoad = false;
        myRadWindow.Modal = true;
        myRadWindow.Animation = WindowAnimation.Fade;
        myRadWindow.AutoSize = true;
        myRadWindow.Behaviors = WindowBehaviors.Close;
        myRadWindow.InitialBehaviors = WindowBehaviors.Resize;
        //myRadWindow.DestroyOnClose = true;
        myRadWindow.KeepInScreenBounds = true;
        myRadWindow.VisibleStatusbar = false;

        myWindowManager.Windows.Add(myRadWindow);

        // Create AjaxManager
        RadAjaxManager myRadAjaxManager = new RadAjaxManager();
        myRadAjaxManager.ID = "RadAjaxManager_ControlManger";
        myRadAjaxManager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate(RadAjaxManager_AjaxRequest);

        // Add to Place Holder
        myPlaceHolder.Controls.Add(myCodeBlock);
        myPlaceHolder.Controls.Add(myWindowManager);
        myPlaceHolder.Controls.Add(myRadAjaxManager);

        #endregion

        #region Add Warp Controls and Dock Layout

        // Remove inline Controls
        HtmlGenericControl myContentDiv = (HtmlGenericControl)Page.Master.FindControl("pageWrapContainer");
        Page.Master.Controls.Remove(myContentDiv);

        // Create Hidden Update_Panel
        UpdatePanel myUpdatePanel_Docks = new UpdatePanel();
        myUpdatePanel_Docks.ID = "UpdatePanel_Docks";

        // Create myRadAjaxManager Postback Trigger
        PostBackTrigger RadAjaxTrigger = new PostBackTrigger();
        RadAjaxTrigger.ControlID = myRadAjaxManager.ID;
        myUpdatePanel_Docks.Triggers.Add(RadAjaxTrigger);

        // Add inLine Controls back
        myPlaceHolder.Controls.Add(myUpdatePanel_Docks);

        //myUpdatePanel_DockLayout.ContentTemplateContainer.Controls.Add(myDockLayout);

        myPlaceHolder.Controls.Add(myContentDiv);
        myForm.Controls.Add(myPlaceHolder);

        #endregion

         // Load MasterPage Control
        MasterPageMgr myMasterPageMgr = new MasterPageMgr();
        myMasterPageMgr.Load_MasterPageControls_Advanced(this.Page, myMasterPageIndex.MasterPageIndexID);

   }

    private void Page_Controls()
    {
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

    #region Control Window Event

    protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {

    }

    #endregion

}