<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_FileSelector.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Files_PoP_FileSelector" %>

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

        function OnClientGridDblClick(sender, args) {
            var item = args.get_item();

            //If file (and not a folder) is selected - call the OnFileSelected method on the parent page
            if (item.get_type() == Telerik.Web.UI.FileExplorerItemType.File) {
                refreshControl(item.get_path());
                args.set_cancel(true);
                //Get a reference to the opener parent page  using rad window
//                var wnd = getRadWindow();
//                var openerPage = wnd.BrowserWindow;
//                //if you need the URL for the item, use get_url() instead of get_path()
//                openerPage.OnFileSelected(wnd, item.get_path());
//                //Close window
//                wnd.close();
            }
        }

        function refreshControl(arg) {
            $find('<%= RadAjaxManager_FileSelector.ClientID %>').ajaxRequest(arg);
        }

    </script>
    <div id="nexusCorePop_wrapper">
        <telerik:RadAjaxManager ID="RadAjaxManager_FileSelector" runat="server" 
            onajaxrequest="RadAjaxManager_FileSelector_AjaxRequest">
        </telerik:RadAjaxManager>
        Double click the file to select.
        <telerik:RadFileExplorer ID="RadFileExplorer_Files" runat="server" Width="530" 
            Height="400" Skin="WebBlue"
            BorderWidth="1px" OnClientFileOpen="OnClientGridDblClick">
        </telerik:RadFileExplorer>
        </div>
    </form>
</body>
</html>
