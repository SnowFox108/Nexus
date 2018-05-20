<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ControlManager.aspx.cs" Inherits="App_AdminCP_SiteAdmin_ControlManager" %>

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

    <div>
        <asp:Image ID="img_ControlIcon" runat="server" /><asp:Label ID="lbl_ControlName" runat="server"></asp:Label>
        <hr />
        <asp:PlaceHolder ID="PlaceHolder_Editor" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
