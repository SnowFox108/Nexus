<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ebay_ItemList_Editor.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ItemList.Editor" ClassName="Nexus.Controls.Ebay.ItemList.ItemList_Editor" %>
<h2>
    Ebay Item List Setting</h2>
<p>
    Select Category to List
    <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_EbayDetailURL"
        ErrorMessage="You must select at least one category." 
        OnServerValidate="CustomValidator_Category_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Panel ID="Panel_Parent_CategoryID" runat="server" Height="150px" ScrollBars="Auto"
        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
        <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
            Enable_CheckBox="true" Enable_HomeRoot="false" Module_ItemID="707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6"
            runat="server" />
    </asp:Panel>
</p>
<p>
Ebay ListType 
    <asp:DropDownList ID="droplist_ListType" runat="server">
    </asp:DropDownList>
</p>
<p>
    Ebay Detail URL (The URL that link to ebay detail page.)<br />
    <asp:TextBox ID="tbx_EbayDetailURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
    Sort Order
    <asp:DropDownList ID="droplist_SortOrder" runat="server">
        <asp:ListItem Value="Ebay_Title">Ebay Title</asp:ListItem>
        <asp:ListItem Value="CurrentPrice">Current Price</asp:ListItem>
        <asp:ListItem Value="StartTime">Item Start Time</asp:ListItem>
        <asp:ListItem Value="EndTime">Item Ending Time</asp:ListItem>
        <asp:ListItem Value="Quantity">Quantity</asp:ListItem>
        <asp:ListItem Value="QuantityAvailable">Quantity Available</asp:ListItem>
        <asp:ListItem Value="BidCount">Bid Count</asp:ListItem>
        <asp:ListItem Value="HitCount">Hit Count</asp:ListItem>
        <asp:ListItem Value="View_Count">View Count</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    List Orientation
    <asp:DropDownList ID="droplist_Orientation" runat="server">
        <asp:ListItem Value="DESC">Descending</asp:ListItem>
        <asp:ListItem Value="ASC">Ascending</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
List Template
    <asp:RadioButtonList ID="rbtn_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when List Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Custom.ascx) <br />
    <asp:TextBox ID="tbx_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
    Repeat Column (Number of repeat List Template in one row)
    <telerik:RadNumericTextBox ID="RadNumericTbx_RepeatColumn" runat="server" Value="3"
        Width="75px" DataType="System.Int16" MaxValue="20" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>

<p>
    Show pager
    <asp:RadioButtonList ID="rbtn_Enable_Pager" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>

<p>
    Number of items per page
    <telerik:RadNumericTextBox ID="RadNumericTbx_NumPerPage" runat="server" Value="10"
        Width="75px" DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<p>
    Total Number of items 
    <telerik:RadNumericTextBox ID="RadNumericTbx_TotalNumber" runat="server" Value="100"
        Width="75px" DataType="System.Int16" MaxValue="2000" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
