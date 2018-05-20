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

    if (previousZone != null) {
        previousZone._hidePlaceholder();
        previousZone = null;
    }
    if (zone != null) {
        zone._showPlaceholder(args._node);
        previousZone = zone;
        currentZone = zone;
    }
}

function onClientNodeDropping(sender, eventArgs) {
    var command = {};
    htmlElement = eventArgs.get_htmlElement();

    if (eventArgs.destinationNode && (eventArgs.destinationNode.get_allowDrop() || sender._draggingPosition != "over") && eventArgs.destinationNode.get_isEnabled()) {
        if (eventArgs.destinationNode._getControl() == this) {
            command.commandName = "NodeDrop";
        }
        else {
            command.commandName = "NodeDropOnTree";
        }
    }
    else if (htmlElement.id && htmlElement.id != "") {
        command.commandName = "NodeDropOnHtmlElement";
    }
    if (!command.commandName) {
        if (currentZone != null) {
            currentZone._hidePlaceholder();
        }
    }
}

function onNodeDropped(obj, args) {
    if (currentZone != null) {
        $get("ctl00_currentZoneTB").value = currentZone.get_id();
        currentZone._hidePlaceholder();
    }
}
