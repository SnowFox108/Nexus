using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Core.Controls;

public partial class App_AdminCP_SiteAdmin_ControlPanel : System.Web.UI.Page
{

    private string _page_controlid;

    protected void Page_Load(object sender, EventArgs e)
    {

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
        PlaceHolder_ControlPanel.Controls.Add(myCodeBlock);
        PlaceHolder_ControlPanel.Controls.Add(myWindowManager);
        PlaceHolder_ControlPanel.Controls.Add(myRadAjaxManager);

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
        PlaceHolder_ControlPanel.Controls.Add(myUpdatePanel);

        #endregion

        _page_controlid = Request.QueryString["ControlID"];

        if (_page_controlid != null)
        {
            ControlCPMgr myControlCPMgr = new ControlCPMgr();
            myControlCPMgr.Load_ControlPanel(this.Page, PlaceHolder_ControlPanel, _page_controlid);
        }
        else
        {
            // Display errors
        }
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

            Nexus.Core.Tools.PoPWindows.ReturnMsg(PlaceHolder_ControlPanel.Controls[PlaceHolder_ControlPanel.Controls.Count - 1], myReturnMsg);
        }

    }

    #endregion

}