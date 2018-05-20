<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DockAndTreeView.aspx.cs" Inherits="DockAndTreeView" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">   
<head>  
    <title>Untitled Page</title>  
    <script type="text/javascript">   
    var currentTreeView;   
    var previousZone;   
    var currentZone;   
    function onNodeDragging(sender, args)   
    {   
        currentTreeView = sender;   
        var target = args.get_htmlElement();   
          
        var zone = null;   
        var parentNode = target;   
        while (parentNode != null)   
        {   
            if(parentNode.id)   
            {   
                if($find(parentNode.id))   
                {   
                    if(Object.getTypeName($find(parentNode.id)) == "Telerik.Web.UI.RadDockZone")                   
                    {   
                        zone = $find(parentNode.id);   
                        break;   
                    }   
                }    
            }   
            parentNode = parentNode.parentNode;   
        }   
  
        if(previousZone != null)   
        {   
            previousZone._hidePlaceholder();   
            previousZone= null;   
        }   
        if(zone != null)   
        {   
            zone._showPlaceholder(args._node);   
            previousZone = zone;   
            currentZone = zone;   
        }        
    }
    function onClientNodeDropping(sender, eventArgs)
    {   		    
	    var command = {};
	    htmlElement = eventArgs.get_htmlElement();		    
								    
	    if(eventArgs.destinationNode && (eventArgs.destinationNode.get_allowDrop() || sender._draggingPosition != "over") && eventArgs.destinationNode.get_isEnabled())
	    {		    
	        if(eventArgs.destinationNode._getControl() == this)
	        {			    
	            command.commandName = "NodeDrop";
		    }
		    else
		    {
		        command.commandName = "NodeDropOnTree";        
		    }
	    } 		    
	    else if(htmlElement.id && htmlElement.id != "")
	    {
	        command.commandName = "NodeDropOnHtmlElement";
	    } 
	    if(!command.commandName)
	    {   				
	        currentZone._hidePlaceholder();
	    }
    }
   
    function onNodeDropped(obj, args)   
    {   
        $get("currentZoneTB").value = currentZone.get_id();   
        currentZone._hidePlaceholder();   
    }   
    </script>  
</head>  
<body>  
    <form id="form1" runat="server" style="overflow:scroll">   
        <asp:ScriptManager ID="ScriptManager1" runat="server">   
        </asp:ScriptManager>  
        <%--hidden inputs used to exchange data with server: Place holder position and currentZone--%>  
        <input type="text" id="currentPlaceholderPosition" runat="server" style="display:none"/>   
        <input type="text" id="currentZoneTB" runat="server" style="display:none" />  
           
        <telerik:RadTreeView ID="RadTreeView1" runat="server"  
                   
             EnableDragAndDrop="True"  
             OnNodeDrop="RadTreeView1_HandleDrop"  
             OnClientNodeDropping="onClientNodeDropping"
             OnClientNodeDropped="onNodeDropped"    
             OnClientNodeDragging="onNodeDragging" ToolTip="ABC">  
                        <Nodes>  
                            <telerik:RadTreeNode Text="Node1" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node2" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node3" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node4" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node5" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node6" PostBack="true"></telerik:RadTreeNode>  
                            <telerik:RadTreeNode Text="Node7" PostBack="true"></telerik:RadTreeNode>  
                        </Nodes>  
                </telerik:RadTreeView>  
               
            <telerik:RadDockLayout runat="server" ID="RadDockLayout1"  
             onsavedocklayout="RadDockLayout1_SaveDockLayout"  
            onloaddocklayout="RadDockLayout1_LoadDockLayout" >  
                <telerik:RadDockZone runat="server" ID="RadDockZone1"    
                Width="400px" MinHeight="300px" style="float:left" BorderStyle="Dotted" 
                    ToolTip="Dock Zone 1">   
                </telerik:RadDockZone>                                   
                <telerik:RadDockZone runat="server" ID="RadDockZone2" Width="400px" 
                    MinHeight="300px" BorderStyle="Dotted" ToolTip="Dock Zone 2">                            
                </telerik:RadDockZone>     
              
                     <div style="display:none">   
                        Hidden UpdatePanel, which is used to receive the new dock controls.    
                        We will move them with script to the desired initial dock zone.   
                        <asp:updatepanel runat="server" id="UpdatePanel1">   
                            <triggers>  
                                <asp:asyncpostbacktrigger controlid="RadTreeView1" eventname="NodeDrop" />  
                            </triggers>  
                </asp:updatepanel>  
            </div>  
             
        </telerik:RadDockLayout>  
        <script type="text/javascript">   
       var isNodeDragged = false;   
       //parameter can be dock or treeNode   
       function Telerik.Web.UI.RadDockZone.prototype._showPlaceholder(obj, location)   
        {     
            if(Object.getTypeName(obj) == "Telerik.Web.UI.RadTreeNode")   
            {   
                isNodeDragged = true;   
                var node = obj;   
                this._repositionPlaceholder(node.get_element(), location);   
                var placeholderStyle = this._placeholder.style;   
                placeholderStyle.height = "30px";   
                placeholderStyle.width = "100%";   
                placeholderStyle.display = "block";   
                isNodeDragged = false;   
            }   
            else   
            {      
                var dock = obj;   
                this._repositionPlaceholder(dock.get_element(), location);   
                var dockBounds = dock._getBoundsWithBorderAndMargin();   
                var placeholderMargin = dock._getMarginBox(this._placeholder);   
                var placeholderBorder = dock._getBorderBox(this._placeholder);   
                var horizontal = this.get_isHorizontal();   
                var placeholderStyle = this._placeholder.style;   
                placeholderStyle.height = dockBounds.height - (placeholderMargin.vertical + placeholderBorder.vertical) + "px";   
                placeholderStyle.width = this.get_fitDocks() && !horizontal ? "100%" : dockBounds.width - (placeholderMargin.horizontal + placeholderBorder.horizontal) + "px";   
                placeholderStyle.display = "block";   
            }   
        }  
         
    Telerik.Web.UI.RadDockZone.prototype._repositionPlaceholder = function(dock_element, location)//TEKI: Add location
	{
	     //fix TreeNode drag   
        if(isNodeDragged == true)   
        {      
            location = new Sys.UI.Point(currentTreeView._mousePos.x, currentTreeView._mousePos.y);         
        }      
        //end fix   

		var nearestChild = this._findItemAt(location, dock_element);

		var zone_element = this.get_element();

		if (null == nearestChild)
		{
		    //Bug fix: ID 9516
		    // _clearElement must be after all docks and _placeholder
			zone_element.insertBefore(this._placeholder, this._clearElement);
		}
		else
		{
			if(nearestChild.previousSibling != this._placeholder)
			{
				zone_element.insertBefore(this._placeholder, nearestChild);
			}
		}
		//GET placeholder position   
        for(var i = 0;i < zone_element.childNodes.length; i++)   
        {   
            if(zone_element.childNodes[i] == this._placeholder)   
            {   
                var currentPos = i;
                document.title = currentPos - 2;   
                $get('currentPlaceholderPosition').value = currentPos - 2;      
            }   
        }   
        //end Get 
	}         
      
        </script>  
    </form>  
</body>  
</html>  
  

