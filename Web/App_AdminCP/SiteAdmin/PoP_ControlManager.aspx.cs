using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Core.Controls;
using Nexus.Core.Pages;
using Nexus.Core.Templates;

public partial class App_AdminCP_SiteAdmin_ControlManager : System.Web.UI.Page
{
    string _editmode;
    string _page_controlid;

    private Nexus.Core.Modules.Component myComponenet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        Page_Controls();

    }

    private void Page_Init()
    {

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
        myRadWindow.Title = "Module Control Manager";
        myRadWindow.ReloadOnShow = true;
        myRadWindow.ShowContentDuringLoad = false;
        myRadWindow.Modal = true;
        myRadWindow.Animation = WindowAnimation.Fade;
        myRadWindow.AutoSize = true;
        myRadWindow.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Close;
        myRadWindow.InitialBehaviors = WindowBehaviors.Resize;
        //myRadWindow.DestroyOnClose = true;
        myRadWindow.KeepInScreenBounds = true;
        myRadWindow.VisibleStatusbar = false;

        myWindowManager.Windows.Add(myRadWindow);

        // Create AjaxManager
        RadAjaxManager myRadAjaxManager = new RadAjaxManager();
        myRadAjaxManager.ID = "ctl00_RadAjaxManager_ControlManger";
        myRadAjaxManager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate(RadAjaxManager_AjaxRequest);

        // Add to Place Holder
        PlaceHolder_Editor.Controls.Add(myCodeBlock);
        PlaceHolder_Editor.Controls.Add(myWindowManager);
        PlaceHolder_Editor.Controls.Add(myRadAjaxManager);

        #endregion

        #region Add Page Update refresh panel

        // Create Hidden Update_Panel
        UpdatePanel myUpdatePanel = new UpdatePanel();
        myUpdatePanel.ID = "UpdatePanel_Refresh";

        // Create myRadAjaxManager Postback Trigger
        PostBackTrigger RadAjaxTrigger = new PostBackTrigger();
        RadAjaxTrigger.ControlID = myRadAjaxManager.ID;
        myUpdatePanel.Triggers.Add(RadAjaxTrigger);

        // Add inLine Controls back
        PlaceHolder_Editor.Controls.Add(myUpdatePanel);

        #endregion

        _page_controlid = Request.QueryString["Page_ControlID"];
        _editmode = Request.QueryString["EditMode"];

        // Check EditMode
        if (_editmode == "PageAdvancedMode"
            || _editmode == "PageDesignMode"
            || _editmode == "TemplateAdvancedMode"
            || _editmode == "TemplateDesignMode")
        {
            // Do nothing
        }
        else
        {
            // Display errors
            return;
        }

        if (_page_controlid != null)
        {
            ControlCPMgr myControlCPMgr = new ControlCPMgr();

            // Load Component Information
            Nexus.Core.Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();

            switch (_editmode)
            {
                case "PageAdvancedMode":
                    // Load Advance Mode UI
                    myControlCPMgr.Load_ControlEditor_PageAdvancedMode(this.Page, _page_controlid);
                    // Load Component Info
                    PageMgr myPageMgr = new PageMgr();
                    Page_Control myPage_Control = myPageMgr.Get_Page_Control(_page_controlid);
                    myComponenet = myModuleMgr.Get_Component(myPage_Control.ComponentID);
                    break;

                case "PageDesignMode":
                    // Load Design Mode UI
                    myControlCPMgr.Load_ControlEditor_PageDesignMode(this.Page, _page_controlid);
                    // Load Component Info
                    PageEditorMgr myPageEditorMgr = new PageEditorMgr();
                    Page_Lock_Control myPage_Lock_Control = myPageEditorMgr.Get_Page_Lock_Control(_page_controlid);
                    myComponenet = myModuleMgr.Get_Component(myPage_Lock_Control.ComponentID);
                    break;

                case "TemplateAdvancedMode":
                    // Load Advance Mode UI
                    myControlCPMgr.Load_ControlEditor_TemplateAdvancedMode(this.Page, _page_controlid);
                    // Load Component Info
                    MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                    MasterPage_Control myMasterPage_Control = myMasterPageMgr.Get_MasterPage_Control(_page_controlid);
                    myComponenet = myModuleMgr.Get_Component(myMasterPage_Control.ComponentID);
                    break;

                case "TemplateDesignMode":
                    // Load Design Mode UI
                    myControlCPMgr.Load_ControlEditor_TemplateDesignMode(this.Page, _page_controlid);
                    // Load Component Info
                    MasterPageEditorMgr myMasterPageEditorMgr = new MasterPageEditorMgr();
                    MasterPage_Lock_Control myMasterPage_Lock_Control = myMasterPageEditorMgr.Get_MasterPage_Lock_Control(_page_controlid);
                    myComponenet = myModuleMgr.Get_Component(myMasterPage_Lock_Control.ComponentID);
                    break;

            }
        }
        else
        {
            // Display errors
        }
    }

    protected void OnFinishUpdate()
    {
        // nothing

    }

    private void Page_Controls()
    {
        img_ControlIcon.ImageUrl = myComponenet.Component_Icon_Big;
        lbl_ControlName.Text = myComponenet.Component_Name;
    }

    #region Control Window Event

    protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {

        string[] fields = e.Argument.ToString().Split('^');

        if (fields.Length >= 3)
        {
            Nexus.Core.Tools.PoP_ReturnMsg myReturnMsg = new Nexus.Core.Tools.PoP_ReturnMsg();
            myReturnMsg.Command = fields[0];
            myReturnMsg.ControlID = fields[1];
            myReturnMsg.Value = fields[2];

            Nexus.Core.Tools.PoPWindows.ReturnMsg(PlaceHolder_Editor.Controls[PlaceHolder_Editor.Controls.Count - 1], myReturnMsg);
        }

    }

    #endregion

}