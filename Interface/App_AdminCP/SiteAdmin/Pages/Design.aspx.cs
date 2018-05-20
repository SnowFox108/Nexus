using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Nexus.Core;
using Nexus.Core.Pages;
using Telerik.Web.UI;
using System.Reflection;
using System.Collections.Generic;

public partial class App_AdminCP_SiteAdmin_Pages_Design : System.Web.UI.Page
{

    private Page_Loading_Info myPage_Loading_Info;

    #region Event
    // Page PostBack Event
    private static readonly object EventPostBack = new object();

    public event EventHandler Event
    {
        add
        {
            Events.AddHandler(EventPostBack, value);
        }
        remove
        {
            Events.RemoveHandler(EventPostBack, value);
        }
    }

    protected void OnEvent(object sender, CommandEventArgs e)
    {
        EventHandler myEventHandler = (EventHandler)Events[EventPostBack];

        if (myEventHandler != null)
            myEventHandler(sender, e);

    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        //Page_Controls();

    }

    private void Page_Init()
    {

        #region Page Properties
        // Load Page Properties
        HtmlMeta myKeyword = new HtmlMeta();
        myKeyword.Name = "Keyword";
        myKeyword.Content = myPage_Loading_Info.Page_Keyword;
        Header.Controls.Add(myKeyword);

        HtmlMeta myDescription = new HtmlMeta();
        myDescription.Name = "Description";
        myDescription.Content = myPage_Loading_Info.Page_Description;
        Header.Controls.Add(myDescription);

        // Add CSS for Editor
        string[] CssFiles = {
                                 "~/App_Themes/NexusCore/Editor.css",
                                 "~/App_Themes/NexusCore/TreeView.Black.css"
                             };

        foreach (string CssFile in CssFiles)
        {
            HtmlLink cssEditor_Link = new HtmlLink();
            cssEditor_Link.Href = CssFile;
            cssEditor_Link.Attributes.Add("type", "text/css");
            cssEditor_Link.Attributes.Add("rel", "stylesheet");
            Header.Controls.Add(cssEditor_Link);
        }


        // Add Script File for Editor
        string[] Scripts = {
                               "/App_AdminCP/SiteAdmin/Pages/TreeViewDock.js"
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

        #endregion

        // Add Script Manager
        //ScriptManager myScriptMgr = new ScriptManager();
        RadScriptManager myScriptMgr = new RadScriptManager();
        myScriptMgr.ID = "ScriptManager_Editor";

        HtmlForm myForm = (HtmlForm)Page.Master.FindControl("Form_NexusCore");
        myForm.Controls.AddAt(0, myScriptMgr);

        // Add PlaceHolder
        PlaceHolder myPlaceHolder = new PlaceHolder();
        myPlaceHolder.ID = "PlaceHolder_DesignMode";

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

        #region Add TreeView Toolbox

        // Div and apply with class style
        HtmlGenericControl myToolboxDiv = new HtmlGenericControl("Div");
        myToolboxDiv.Attributes.Add("Class", "nexusCore_Editor_ToolPanel");
        //myToolboxDiv.ID = "NexusCore_Editor_Toolbox";

        // TreeView Toolbox Div Panel
        HtmlGenericControl myToolbox_TopDiv = new HtmlGenericControl("Div");
        myToolbox_TopDiv.Attributes.Add("Class", "sidebartop");

        HtmlGenericControl myToolbox_BotDiv = new HtmlGenericControl("Div");
        myToolbox_BotDiv.Attributes.Add("Class", "sidebarbot");

        #region Sidebar Top

        // Tree Hidden Input used to exchange data with server: Place holder position and currentZone
        HtmlInputText _currentPlaceholderPosition = new HtmlInputText();
        _currentPlaceholderPosition.ID = "currentPlaceholderPosition";
        _currentPlaceholderPosition.Attributes.Add("style", "display: none");

        HtmlInputText _currentZoneTB = new HtmlInputText();
        _currentZoneTB.ID = "currentZoneTB";
        _currentZoneTB.Attributes.Add("style", "display: none");

        myToolbox_TopDiv.Controls.Add(_currentPlaceholderPosition);
        myToolbox_TopDiv.Controls.Add(_currentZoneTB);

        // Add TreeView Dock Script
        HtmlGenericControl myDock_ScriptTag = new HtmlGenericControl("Script");
        myDock_ScriptTag.Attributes.Add("type", "text/javascript");
        myDock_ScriptTag.InnerHtml = Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_PageEditor_Dock");
        myToolbox_TopDiv.Controls.Add(myDock_ScriptTag);

        // Tree Toolbox
        RadTreeView RadTreeView_Toolbox = new RadTreeView();
        RadTreeView_Toolbox.Skin = "Black";
        RadTreeView_Toolbox.EnableEmbeddedSkins = false;
        RadTreeView_Toolbox.ID = "RadTreeView_Toolbox";
        RadTreeView_Toolbox.EnableDragAndDrop = true;
        RadTreeView_Toolbox.ShowLineImages = false;
        RadTreeView_Toolbox.OnClientNodeDropping = "onClientNodeDropping";
        RadTreeView_Toolbox.OnClientNodeDropped = "onNodeDropped";
        RadTreeView_Toolbox.OnClientNodeDragging = "onNodeDragging";

        // Tree Toolbox event
        RadTreeView_Toolbox.NodeDrop += new RadTreeViewDragDropEventHandler(RadTreeView_Toolbox_NodeDrop);

        Nexus.Core.ToolBoxes.ToolBoxMgr myToolBoxMgr = new Nexus.Core.ToolBoxes.ToolBoxMgr();
        myToolBoxMgr.Load_Toolbox_Group(RadTreeView_Toolbox);

        myToolbox_TopDiv.Controls.Add(RadTreeView_Toolbox);

        #endregion

        myToolboxDiv.Controls.Add(myToolbox_TopDiv);
        myToolboxDiv.Controls.Add(myToolbox_BotDiv);
        myPlaceHolder.Controls.Add(myToolboxDiv);

        #endregion

        #region Toolbox button
        
        // Add Toolbox button
        HtmlGenericControl Toolbox_btnLink = new HtmlGenericControl("A");
        Toolbox_btnLink.Attributes.Add("href", "");
        Toolbox_btnLink.Attributes.Add("onclick", "initSlideLeftPanel();return false");

        HtmlGenericControl myToolbox_btnDiv = new HtmlGenericControl("Div");
        myToolbox_btnDiv.Attributes.Add("class", "nexusCore_toolsTab");
        Toolbox_btnLink.Controls.Add(myToolbox_btnDiv);

        myPlaceHolder.Controls.Add(Toolbox_btnLink);

        #endregion

        #region Add Warp Controls and Dock Layout

        // Remove inline Controls
        HtmlGenericControl myContentDiv = (HtmlGenericControl)Page.Master.FindControl("pageWrapContainer");
        Page.Master.Controls.Remove(myContentDiv);

        // Create Page Content Div
        HtmlGenericControl myEditor_Div = new HtmlGenericControl("Div");
        myEditor_Div.Attributes.Add("class", "nexusCore_Editor_MainPanel");

        // Create DockLayOut
        RadDockLayout myDockLayout = new RadDockLayout();
        myDockLayout.ID = "RadDockLayout_DesignMode";
        myDockLayout.StoreLayoutInViewState = true;

        // DockLayOut Event
        myDockLayout.LoadDockLayout += new DockLayoutEventHandler(RadDockLayout_DesignMode_LoadDockLayout);
        myDockLayout.SaveDockLayout += new DockLayoutEventHandler(RadDockLayout_DesignMode_SaveDockLayout);


        // Create Hidden Update_Panel
        UpdatePanel myUpdatePanel_Docks = new UpdatePanel();
        myUpdatePanel_Docks.ID = "UpdatePanel_Docks";

        // Create Wrap Update_Panel
        //UpdatePanel myUpdatePanel_DockLayout = new UpdatePanel();
        //myUpdatePanel_DockLayout.ID = "UpdatePanel_DockLayout";

        // Create myRadAjaxManager Postback Trigger
        PostBackTrigger RadAjaxTrigger = new PostBackTrigger();
        RadAjaxTrigger.ControlID = myRadAjaxManager.ID;
        myUpdatePanel_Docks.Triggers.Add(RadAjaxTrigger);

        // Create Tree Toolbox Trigger
        //AsyncPostBackTrigger nodeDropTrigger = new AsyncPostBackTrigger();
        PostBackTrigger nodeDropTrigger = new PostBackTrigger();
        nodeDropTrigger.ControlID = RadTreeView_Toolbox.ID;
        //nodeDropTrigger.EventName = "NodeDrop";
        myUpdatePanel_Docks.Triggers.Add(nodeDropTrigger);

        // Add inLine Controls back
        myDockLayout.Controls.Add(myContentDiv);
        myDockLayout.Controls.Add(myUpdatePanel_Docks);

        //myUpdatePanel_DockLayout.ContentTemplateContainer.Controls.Add(myDockLayout);

        myEditor_Div.Controls.Add(myDockLayout);
        myPlaceHolder.Controls.Add(myEditor_Div);
        myForm.Controls.Add(myPlaceHolder);

        #endregion

        // Load MasterPage Control
        Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
        myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myPage_Loading_Info.MasterPageIndexID);

        // Load Page Control
        PageEditorMgr myPageEditorMgr = new PageEditorMgr();
        myPageEditorMgr.Load_PageDocks_Design(this.Page, myPage_Loading_Info);

        // Recreate the docks in order to ensure their proper operation
        for (int i = 0; i < CurrentDockStates.Count; i++)
        {
            if (CurrentDockStates[i].Closed == false)
            {
                RadDock myDock = myPageEditorMgr.Load_PageControls_FromState(this.Page, myPage_Loading_Info, CurrentDockStates[i]);

                LinkButton Linkbtn_Delete = (LinkButton)myDock.TitlebarContainer.FindControl("Linkbtn_Delete");
                Linkbtn_Delete.Command +=new CommandEventHandler(Linkbtn_Delete_Command);
                Linkbtn_Delete.OnClientClick = string.Format("return confirm('Are you sure you want to delete {0} ?');", myDock.Title);

                string _pageindexid = Request["PageIndexID"];

                myDockLayout.Controls.Add(myDock);
                CreateSaveStateTrigger(myDock);
            }
        }

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

        // Check PageIxist        
        PageEditorMgr myPageEditorMgr = new PageEditorMgr();
        Page_Lock myPage_Lock = myPageEditorMgr.Get_Page_Lock(_pageindexid);
        // Check Properties

        // Check Security

        // Load Pages Template
        Nexus.Core.Pages.Page_PropertyMgr myPropertyMgr = new Nexus.Core.Pages.Page_PropertyMgr();

        myPage_Loading_Info = myPropertyMgr.Get_Page_Lock_Loading_Info(_pageindexid);

        // Get MasterPageID
        //_master_pageindexid = myPage_Loading_Info.MasterPageIndexID;

        //this.StyleSheetTheme = myPage_Loading_Info.Theme;
        this.Theme = myPage_Loading_Info.Theme;
        this.MasterPageFile = myPage_Loading_Info.MasterPage_URL;

        this.Title = myPage_Loading_Info.Page_Title;
        
        base.OnPreInit(e);
    }


    #region TreeView Event
    protected void RadTreeView_Toolbox_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;

        if (e.HtmlElementID != null)
        {

            PlaceHolder myPlaceHolder = (PlaceHolder)Page.Master.FindControl("PlaceHolder_DesignMode");
            HtmlInputText _currentPlaceholderPosition = (HtmlInputText)myPlaceHolder.FindControl("currentPlaceholderPosition");
            HtmlInputText _currentZoneTB = (HtmlInputText)myPlaceHolder.FindControl("currentZoneTB");

            int dockCurrentPos = int.Parse(_currentPlaceholderPosition.Value);

            PageEditorMgr myPageEditorMgr = new PageEditorMgr();

            RadDockLayout myDockLayout = (RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode");

            RadDock myDock = myPageEditorMgr.Add_DesignMode_NewControl(this.Page, myPage_Loading_Info, sourceNode, _currentZoneTB.Value, dockCurrentPos);

            myDockLayout.Controls.Add(myDock);

            //UpdatePanel myUpdatePanel = (UpdatePanel)myDockLayout.FindControl("UpdatePanel_Docks");
            //myUpdatePanel.ContentTemplateContainer.Controls.Add(myDock);


            ScriptManager.RegisterStartupScript(
            myDock,
            this.GetType(),
            "AddDock",
            string.Format(@"function _addDock() {{  
            Sys.Application.remove_load(_addDock);  
            $find('{1}').dock($find('{0}'),{2});   
            $find('{0}').doPostBack('DockPositionChanged');   
            }};  
            Sys.Application.add_load(_addDock);", myDock.ClientID, _currentZoneTB.Value, dockCurrentPos),
            true);

            CreateSaveStateTrigger(myDock);

        }

    }

    #endregion

    #region Control Window Event

    protected void Linkbtn_Delete_Command(object sender, CommandEventArgs e)
    {
        //Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "This is Delete_Button Command");

        // Remove Page Control from Database
        PageEditorMgr myPageEditorMgr = new PageEditorMgr();

        RadDockLayout myDockLayout = (RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode");
        RadDock myDock = (RadDock)myDockLayout.FindControl(e.CommandArgument.ToString());

        myPageEditorMgr.Remove_DesignMode_Control(myDock.Tag);
       

        // Remove from DockLayout
        myDock.Closed = true;

        string _finishupdate_script = string.Format("refreshControl({0});", myDock.Tag);
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

    }

    protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        // Refresh Docks
        //RadDockLayout myDockLayout = (RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode");
        //myDockLayout.DataBind();

        //the clear state button was clicked, so we refresh the page and start over.
        //Response.Redirect(Request.RawUrl, false);

    }

    #endregion

    #region Dock Event
    private void ReCreateDocks(RadDockLayout myDockLayout)
    {
        PageEditorMgr myPageEditorMgr = new PageEditorMgr();

        // Recreate the docks in order to ensure their proper operation
        for (int i = 0; i < CurrentDockStates.Count; i++)
        {
            if (CurrentDockStates[i].Closed == false)
            {
                RadDock myDock = myPageEditorMgr.Load_PageControls_FromState(this.Page, myPage_Loading_Info, CurrentDockStates[i]);

                LinkButton Linkbtn_Delete = (LinkButton)myDock.TitlebarContainer.FindControl("Linkbtn_Delete");
                Linkbtn_Delete.Command += new CommandEventHandler(Linkbtn_Delete_Command);

                myDockLayout.Controls.Add(myDock);
                CreateSaveStateTrigger(myDock);
            }
        }

    }

    private List<DockState> CurrentDockStates
    {
        get
        {
            //Store the info about the added docks in the session. For real life
            // applications we recommend using database or other storage medium 
            // for persisting this information.
            List<DockState> _currentDockStates = (List<DockState>)Session["CurrentDockStatesDesignMode"];
            if (Object.Equals(_currentDockStates, null))
            {
                PageEditorMgr myPageEditorMgr = new PageEditorMgr();
                RadDockLayout myDockLayout = (RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode");

                _currentDockStates = myPageEditorMgr.Load_PageControls_StateList(this.Page, myPage_Loading_Info, myDockLayout);
                Session["CurrentDockStatesDesignMode"] = _currentDockStates;
            }
            return _currentDockStates;
        }
        set
        {
            Session["CurrentDockStatesDesignMode"] = value;

        }
    }

    private void CreateSaveStateTrigger(RadDock myDock)
    {
        //Ensure that the RadDock control will initiate postback
        // when its position changes on the client or any of the commands is clicked.
        RadDockLayout myDockLayout = (RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode");
        UpdatePanel myUpdatePanel = (UpdatePanel)myDockLayout.FindControl("UpdatePanel_Docks");

        // Using the trigger we will "ajaxify" that postback.
        myDock.AutoPostBack = true;
        myDock.CommandsAutoPostBack = true;

        // Add UpdatePanel Trigger
        AsyncPostBackTrigger saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = myDock.ID;
        saveStateTrigger.EventName = "DockPositionChanged";
        myUpdatePanel.Triggers.Add(saveStateTrigger);

        saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = myDock.ID;
        saveStateTrigger.EventName = "Command";
        myUpdatePanel.Triggers.Add(saveStateTrigger);

        //LinkButton Linkbtn_Delete = (LinkButton)myDock.TitlebarContainer.FindControl("Linkbtn_Delete");
        //Linkbtn_Delete.Command += new CommandEventHandler(Linkbtn_Delete_Command);

        //PostBackTrigger deleteTrigger = new PostBackTrigger();
        //deleteTrigger.ControlID = Linkbtn_Delete.ID;
        //myUpdatePanel.Triggers.Add(deleteTrigger);
        

        #region Auto Create Hidden Panel

        //Ensure that the RadDock control will initiate postback
        // when its position changes on the client or any of the commands is clicked.
        //Using the trigger we will "ajaxify" that postback.
        //myDock.AutoPostBack = true;
        //myDock.CommandsAutoPostBack = true;

        //AjaxUpdatedControl updatedControl = new AjaxUpdatedControl();
        //updatedControl.ControlID = "Panel_Docks";

        //AjaxSetting setting1 = new AjaxSetting(myDock.ID);
        //setting1.EventName = "DockPositionChanged";
        //setting1.UpdatedControls.Add(updatedControl);

        //AjaxSetting setting2 = new AjaxSetting(myDock.ID);
        //setting2.EventName = "Command";
        //setting2.UpdatedControls.Add(updatedControl);

        //// Get myRadAjaxManager Control
        //UpdatePanel myUpdatePanel = (UpdatePanel)Page.Master.FindControl("UpdatePanel_DesignMode"); ;
        //RadAjaxManager myRadAjaxManager = (RadAjaxManager)myUpdatePanel.FindControl("RadAjaxManager_ControlManger");

        //myRadAjaxManager.AjaxSettings.Add(setting1);
        //myRadAjaxManager.AjaxSettings.Add(setting2);

        #endregion

    }

    protected void RadDockLayout_DesignMode_LoadDockLayout(object sender, DockLayoutEventArgs e)
    {

        foreach (DockState state in CurrentDockStates)
        {
            // Comment these two lines and you will see that the indices are not applied correctly

            e.Positions[state.UniqueName] = state.DockZoneID;
            e.Indices[state.UniqueName] = state.Index;
        }


    }

    protected void RadDockLayout_DesignMode_SaveDockLayout(object sender, DockLayoutEventArgs e)
    {
            List<DockState> _CurrentDockStates = ((RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode")).GetRegisteredDocksState();
            CurrentDockStates = ((RadDockLayout)this.Page.Master.FindControl("RadDockLayout_DesignMode")).GetRegisteredDocksState();

            PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            myPageEditorMgr.Edit_DesignMode_Control_Position(this.Page, myPage_Loading_Info, CurrentDockStates);
    }


    #endregion 

}
