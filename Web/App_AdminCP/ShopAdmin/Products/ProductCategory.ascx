<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductCategory.ascx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductCategory" %>
<div class="nexusCore_panel_productEditor">
<h3>Category Mappings</h3>
        Select a category from following category then click add button:
        <br />
        <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_Dump"
            ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
            ValidationGroup="AddCategory"></asp:CustomValidator>
        <asp:TextBox ID="tbx_Dump" runat="server" Enabled="False" Height="1px" ValidationGroup="AddCategory"
            Visible="False" Text="validate" Width="1px"></asp:TextBox>
        <br />
        <asp:Panel ID="Panel_CategoryMoveTo" runat="server" Height="150px" ScrollBars="Auto"
            Width="350px" BorderStyle="Dashed" BorderWidth="1px">
            <nexus:CategoryTree ID="CategoryTree_Product" Root_CategoryID="-1" Enable_DragAndDrop="false"
                Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="B131F545-F494-447E-8B55-9F24AFADC417"
                runat="server" />
        </asp:Panel>
        <asp:Button ID="btn_Add_Cateogry" runat="server" Text="Confirm to Add" OnClick="btn_Add_Cateogry_Click"
            ValidationGroup="AddCategory" SkinID="e2CMS_Button" />

    <asp:ListView ID="ListView_Product_Category" runat="server" 
        DataKeyNames="CategoryID,ProductID" 
        onitemdatabound="ListView_Product_Category_ItemDataBound">
        <EmptyDataTemplate>
        <div class="nexusCore_error_message">
            There are no data returned.
        </div>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <%# Eval("CategoryID") %>
            </td>
            <td>
                <%# Eval("Category_Name") %>
            </td>
            <td>
                <asp:LinkButton ID="lbtn_Delete" CommandArgument='<%# Eval("Product_MappingID") %>' OnCommand="lbtn_Delete_Command" runat="server">Delete</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="itemPlaceholderContainer" runat="server" class="nexusCore_itemPlaceholderContainer">
            <tr id="Tr1" runat="server">
                <th id="Th1" runat="server">
                    Category ID
                </th>
                <th id="Th2" runat="server">
                    Name
                </th>
                <th id="Th3" runat="server">
                    Actions
                </th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>

</div>