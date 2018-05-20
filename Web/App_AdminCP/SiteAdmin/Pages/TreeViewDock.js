var currentTreeView;
var previousZone;
var currentZone;
function onNodeDragging(sender, args) {
    currentTreeView = sender;
    var target = args.get_htmlElement();

    var zone = null;
    var parentNode = target;
    while (parentNode != null) {
        if (parentNode.id) {
            if ($find(parentNode.id)) {
                if (Object.getTypeName($find(parentNode.id)) == "Telerik.Web.UI.RadDockZone") {
                    zone = $find(parentNode.id);
                    break;
                }
            }
        }
        parentNode = parentNode.parentNode;
    }

    //// Modify the condition to stop 
    if (previousZone != null && previousZone != zone) {
        previousZone._hidePlaceholder();
        previousZone = null;
    }
    if (zone != null) {
        previousZone = zone;
        currentZone = zone;

        /////TODO: Forbidden Zones logic
        //if (currentZone.get_id() == "RadDockZone1")
        //{
        zone._showPlaceholder(args._node);
        //}

    }
}
function onClientNodeDropping(sender, eventArgs) {
    var command = {};
    htmlElement = eventArgs.get_htmlElement();
    var className = htmlElement.className;

    if (eventArgs.destinationNode && (eventArgs.destinationNode.get_allowDrop() || sender._draggingPosition != "over") && eventArgs.destinationNode.get_isEnabled()) {
        if (eventArgs.destinationNode._getControl() == this) {
            command.commandName = "NodeDrop";
        }
        else {
            command.commandName = "NodeDropOnTree";
        }
    }
    else if (className.indexOf("RadDock") != -1) {
        command.commandName = "NodeDropOnHtmlElement";
    }
    else {
        eventArgs.set_cancel(true);
    }

    if (currentZone) {
        if (!command.commandName) {
            currentZone._hidePlaceholder();
        }

        /////TODO: Forbidden Zones logic
        //if (currentZone.get_id() != "RadDockZone1")
        //{
        //	currentZone._hidePlaceholder();
        //	eventArgs.set_cancel(true);
        //}

    }
}

function onNodeDropped(obj, args) {
    if (currentZone) {
        $get("ctl00_currentZoneTB").value = currentZone.get_id();
        currentZone._hidePlaceholder();
        currentZone = null;
    }
}
