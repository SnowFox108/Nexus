<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductIndex.ascx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductIndex" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Product Index have been updated!
    </div>
</asp:Panel>
<div class="nexusCore_panel_productEditor">
    <h3>
        Product Index
    </h3>
    <table>
        <tr>
            <th>
                Title
            </th>
            <td>
                <asp:TextBox ID="tbx_Index_Title" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Index"
                    Width="195px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter a title."
                    ControlToValidate="tbx_Index_Title" ValidationGroup="ProductCreate_Index"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Short Description
            </th>
            <td>
                <asp:TextBox ID="tbx_Index_Short_Description" runat="server" Rows="5" TextMode="MultiLine"
                    Width="300px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Admin Comment
            </th>
            <td>
                <asp:TextBox ID="tbx_Index_Admin_Comment" runat="server" Rows="5" TextMode="MultiLine"
                    Width="300px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Active Status
            </th>
            <td>
                <asp:CheckBox ID="chkbox_Index_IsActive" runat="server" Text="Active" />
            </td>
        </tr>
    </table>
</div>
<div class="nexusCore_btn_goRight">
    <asp:Button ID="btn_Update" runat="server" Text="Update" SkinID="e2CMS_Button" 
        onclick="btn_Update_Click" />
</div>
