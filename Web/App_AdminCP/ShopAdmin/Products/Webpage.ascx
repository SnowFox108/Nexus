<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Webpage.ascx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_Webpage" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Product web content have been updated!
    </div>
</asp:Panel>
<div class="nexusCore_panel_productEditor">
    <h3>
        SEO
    </h3>
    <table>
        <tr>
            <th>
                Meta Title
            </th>
            <td>
                <asp:TextBox ID="tbx_Meta_Title" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Index"
                    Width="195px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter a title."
                    ControlToValidate="tbx_Meta_Title" ValidationGroup="ProductCreate_Index"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Meta Keywords
            </th>
            <td>
                <asp:TextBox ID="tbx_Meta_Keywords" runat="server" 
                    Width="295px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Meta Description
            </th>
            <td>
                <asp:TextBox ID="tbx_Meta_Description" runat="server" Rows="5" TextMode="MultiLine"
                    Width="300px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
            </td>
        </tr>
    </table>
    <h3>Web content</h3>
    <table>
        <tr>
            <th>
                Header Text
            </th>
            <td>
                <asp:TextBox ID="tbx_Page_Title" Width="295px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Overview
            </th>
            <td>    
                <nexus:TextEditor ID="TextEditor_Overview" runat="server" Toolbar_Status="Basic"
                    EnableResize="false" />                        
            </td>
        </tr>
        <tr>
            <th>
                Content
            </th>
            <td>
                <nexus:TextEditor ID="TextEditor_Content" runat="server" Toolbar_Status="Basic" EnableResize="false" />
            </td>
        </tr>

    </table>
</div>
<div class="nexusCore_btn_goRight">
    <asp:Button ID="btn_Update" runat="server" Text="Update" SkinID="e2CMS_Button" 
        onclick="btn_Update_Click" />
</div>
