<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.ascx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductInfo" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Product Index have been updated!</div>
</asp:Panel>
<div class="nexusCore_panel_productEditor">
    <h3>
        Product Infomation
    </h3>
    <table>
        <tr>
            <th>
                Title Format
            </th>
            <td>
                <asp:RadioButtonList ID="rbtn_Product_Title_Type" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>
                Product Title
            </th>
            <td>
                <asp:TextBox ID="tbx_Product_Title" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                    Width="195px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Product_Title" runat="server"
                    ControlToValidate="tbx_Product_Title" ErrorMessage="Please enter a product title."
                    ValidationGroup="ProductCreate_Product"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th class="style1">
                Product SKU
            </th>
            <td class="style1">
                <asp:TextBox ID="tbx_Product_SKU" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                    Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Manufacturer
            </th>
            <td>
                <asp:DropDownList ID="droplist_Product_ManufacturerID" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                Manufacturer SKU
            </th>
            <td>
                <asp:TextBox ID="tbx_Product_Manufacturer_SKU" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                    Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Currency
            </th>
            <td>
                <asp:DropDownList ID="droplist_Product_CurrencyID" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                RRP Price
            </th>
            <td>
                <telerik:radnumerictextbox id="RadNumericTextBox_Product_RRP" runat="server" width="195px"
                    validationgroup="ProductCreate_Product" value="0">
                        </telerik:radnumerictextbox>
            </td>
        </tr>
        <tr>
            <th>
                Active Status
            </th>
            <td>
                <asp:CheckBox ID="chkbox_Product_IsActive" runat="server" Text="Active" />
            </td>
        </tr>
    </table>
</div>
<div class="nexusCore_panel_productEditor">
    <h3>
        Product Specification
    </h3>
    <asp:PlaceHolder ID="PlaceHolder_Product_Spec" runat="server"></asp:PlaceHolder>
</div>
<div class="nexusCore_btn_goRight">
    <asp:Button ID="btn_Update" runat="server" Text="Update" SkinID="e2CMS_Button" 
        onclick="btn_Update_Click" />
</div>
