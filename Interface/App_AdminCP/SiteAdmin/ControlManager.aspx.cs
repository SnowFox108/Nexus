using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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


}