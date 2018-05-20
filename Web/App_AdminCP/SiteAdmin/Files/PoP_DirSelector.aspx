<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_DirSelector.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Files_PoP_DirSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshControl(args);
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().Close();
        }
    </script>
    <div id="nexusCorePop_wrapper">
        <asp:Panel ID="Panel_DirSelector" runat="server" Height="370px" Width="350px" 
            ScrollBars="Auto" BorderStyle="Dashed" BorderWidth="1px"
            >
            <telerik:RadTreeView ID="RadTreeView_DirSelector" runat="server" Skin="WebBlue" 
                OnNodeExpand="RadTreeView_DirSelector_NodeExpand" 
                onnodeclick="RadTreeView_DirSelector_NodeClick">
            </telerik:RadTreeView>
        </asp:Panel>
        <asp:Button ID="btn_Select" runat="server" Text="Select Folder" OnCommand="btn_Select_Command" />
    </div>
    </form>
</body>
</html>
