<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_PropertyCreate.aspx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Variants_PoP_PropertyCreate" StylesheetTheme="NexusShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
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
        <div class="nexusCore_variant_property_editor">
            <h2>
                Create a Property</h2>
            <div class="spliter">
            </div>
            <table class="form">
                <tr>
                    <th>
                        Property Name:
                    </th>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Property_Name" runat="server"
                            ErrorMessage="Enter a Property Name! &lt;br/&gt;" ControlToValidate="tbx_Property_Name"
                            Display="Dynamic" ValidationGroup="CreateProperty"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_Property_Name" runat="server" Width="195px" 
                            ValidationGroup="CreateProperty" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Input Option:
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_InputOption" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Default Value:
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Default_Value" runat="server" Width="195px" 
                            ValidationGroup="CreateProperty" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Tooltips:
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Tooltips" runat="server" Width="280px" 
                            ValidationGroup="CreateProperty" TextMode="MultiLine" ToolTip="500" 
                            Rows="3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Control Option:
                    </th>
                    <td>
                        &nbsp;
                        <asp:CheckBox ID="chkbox_IsRequired" runat="server" Text="Required" />
                        &nbsp;<asp:CheckBox ID="chkbox_IsFilter" runat="server" Text="Allow Filter" />
                        &nbsp;<asp:CheckBox ID="chkbox_IsSort" runat="server" Text="Allow Sort" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Table Field Name:
                    </th>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Field_Name" runat="server"
                            ErrorMessage="Enter a Table Field Name! &lt;br/&gt;" ControlToValidate="tbx_Field_Name"
                            Display="Dynamic" ValidationGroup="CreateProperty"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_Field_Name" runat="server" Width="195px" ValidationGroup="CreateProperty"
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <div class="nexusCore_variantCommand">
                            <asp:Button ID="btn_CreateProperty" runat="server" Text="Create Property" CssClass="nexusCore_createVariant_btn"
                                SkinID="e2CMS_Button" ValidationGroup="CreateProperty" 
                                onclick="btn_CreateProperty_Click" />                                
                            &nbsp; 
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_cancel_btn"
                                SkinID="e2CMS_Button" ValidationGroup="CreateProperty" 
                                onclick="btn_Cancel_Click" CausesValidation="False" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
