<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_SpliterEditor.aspx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Variants_PoP_SpliterEditor" StylesheetTheme="NexusShop" %>

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
        <h4>
            Spliter Name:</h4>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Spliter_Name" runat="server"
            ErrorMessage="Enter a Spliter Name! &lt;br/&gt;" ControlToValidate="tbx_Spliter_Name"
            Display="Dynamic" ValidationGroup="EditSpliter"></asp:RequiredFieldValidator>
        <asp:TextBox ID="tbx_Spliter_Name" runat="server" Width="195px" ValidationGroup="EditSpliter"></asp:TextBox>
        <div class="nexusCore_variantCommand">
            <asp:Button ID="btn_UpdateVariant" runat="server" Text="Update Spliter" CssClass="nexusCore_editVariant_btn"
                SkinID="e2CMS_Button" ValidationGroup="EditSpliter" OnClick="btn_UpdateVariant_Click" />
                            &nbsp; 
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_cancel_btn"
                                SkinID="e2CMS_Button" ValidationGroup="EditSpliter" 
                                onclick="btn_Cancel_Click" CausesValidation="False" />

        </div>
    </div>
    </form>
</body>
</html>
