using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class DockAndTreeView : System.Web.UI.Page
{
    private List<DockState> CurrentDockStates
    {
        get
        {
            //Store the info about the added docks in the session. For real life   
            // applications we recommend using database or other storage medium    
            // for persisting this information.   
            List<DockState> _currentDockStates = (List<DockState>)Session["CurrentDockStatesMyPortal"];
            if (Object.Equals(_currentDockStates, null))
            {
                _currentDockStates = new List<DockState>();
                Session["CurrentDockStatesMyPortal"] = _currentDockStates;
            }
            return _currentDockStates;
        }
        set
        {
            Session["CurrentDockStatesMyPortal"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //public ArrayList GetZones()   
    //{   
    //    ArrayList zones = new ArrayList();   
    //    zones.Add(RadDockZone1);   
    //    //zones.Add(RadDockZone2);   

    //    return zones;   
    //}   

    protected void Page_Init(object sender, EventArgs e)
    {
        //Recreate the docks in order to ensure their proper operation   
        for (int i = 0; i < CurrentDockStates.Count; i++)
        {
            if (CurrentDockStates[i].Closed == false)
            {
                RadDock dock = CreateRadDockFromState(CurrentDockStates[i]);
                //We will just add the RadDock control to the RadDockLayout.   
                // You could use any other control for that purpose, just ensure   
                // that it is inside the RadDockLayout control.   
                // The RadDockLayout control will automatically move the RadDock   
                // controls to their corresponding zone in the LoadDockLayout   
                // event (see below).   
                RadDockLayout1.Controls.Add(dock);
                //We want to save the dock state every time a dock is moved.   
                CreateSaveStateTrigger(dock);

            }
        }
    }

    protected void RadDockLayout1_LoadDockLayout(object sender, DockLayoutEventArgs e)
    {
        //Populate the event args with the state information. The RadDockLayout control   
        // will automatically move the docks according that information.   
        foreach (DockState state in CurrentDockStates)
        {
            e.Positions[state.UniqueName] = state.DockZoneID;
            e.Indices[state.UniqueName] = state.Index;
        }
    }

    protected void RadDockLayout1_SaveDockLayout(object sender, DockLayoutEventArgs e)
    {
        //Save the dock state in the session. This will enable us    
        // to recreate the dock in the next Page_Init.    
        CurrentDockStates = RadDockLayout1.GetRegisteredDocksState();
    }

    private RadDock CreateRadDockFromState(DockState state)
    {
        RadDock dock = new RadDock();
        dock.ID = string.Format("RadDock{0}", state.UniqueName);
        dock.ApplyState(state);
        dock.Command += new DockCommandEventHandler(dock_Command);
        dock.Commands.Add(new DockCloseCommand());
        dock.Commands.Add(new DockExpandCollapseCommand());

        return dock;
    }


    void dock_Command(object sender, DockCommandEventArgs e)
    {
        if (e.Command.Name == "Close")
        {
            ScriptManager.RegisterStartupScript(
            UpdatePanel1,
            this.GetType(),
            "RemoveDock",
            string.Format(@"function _removeDock() {{  
    Sys.Application.remove_load(_removeDock);  
    $find('{0}').undock();  
    $get('{1}').appendChild($get('{0}'));  
    $find('{0}').doPostBack('DockPositionChanged');  
}};  
Sys.Application.add_load(_removeDock);", ((RadDock)sender).ClientID, UpdatePanel1.ClientID),
            true);

        }
    }

    private void CreateSaveStateTrigger(RadDock dock)
    {
        //Ensure that the RadDock control will initiate postback   
        // when its position changes on the client or any of the commands is clicked.   
        //Using the trigger we will "ajaxify" that postback.   
        dock.AutoPostBack = true;
        dock.CommandsAutoPostBack = true;

        AsyncPostBackTrigger saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = dock.ID;
        saveStateTrigger.EventName = "DockPositionChanged";
        UpdatePanel1.Triggers.Add(saveStateTrigger);

        saveStateTrigger = new AsyncPostBackTrigger();
        saveStateTrigger.ControlID = dock.ID;
        saveStateTrigger.EventName = "Command";
        UpdatePanel1.Triggers.Add(saveStateTrigger);
    }


    protected void ButtonAddDock_Click(object sender, EventArgs e)
    {

    }

    protected void RadTreeView1_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        int currentPos = int.Parse(currentPlaceholderPosition.Value);


        int docksCount = CurrentDockStates.Count;

        RadDock dock = new RadDock();
        dock.UniqueName = Guid.NewGuid().ToString();
        dock.ID = string.Format("RadDock{0}", dock.UniqueName);
        dock.Title = "Dock" + docksCount.ToString();
        //dock.Text = sourceNode.Text;
        dock.Width = Unit.Pixel(300);        

        dock.Commands.Add(new DockCloseCommand());
        dock.Commands.Add(new DockExpandCollapseCommand());
        dock.Command += new DockCommandEventHandler(dock_Command);

        // Add Controls
        Label myLabel = new Label();
        myLabel.Text = "<h1>This is a Lable Control</h1>";

        TextBox myTextBox = new TextBox();
        myTextBox.Text = "This is a Text Box";

        dock.ContentContainer.Controls.Add(myLabel);
        dock.ContentContainer.Controls.Add(myTextBox);

        UpdatePanel1.ContentTemplateContainer.Controls.Add(dock);


        ScriptManager.RegisterStartupScript(
        dock,
        this.GetType(),
        "AddDock",
        string.Format(@"function _addDock() {{  
    Sys.Application.remove_load(_addDock);  
    $find('{1}').dock($find('{0}'),{2});   
    $find('{0}').doPostBack('DockPositionChanged');  
 
}};  
Sys.Application.add_load(_addDock);", dock.ClientID, currentZoneTB.Value, currentPos),
        true);

        CreateSaveStateTrigger(dock);
    }   

}
