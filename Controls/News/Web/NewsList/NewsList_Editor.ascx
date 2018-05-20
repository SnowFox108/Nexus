<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList_Editor.ascx.cs"
    Inherits="Nexus.Controls.News.NewsList.Editor" ClassName="Nexus.Controls.News.NewsList.NewsList_Editor" %>
<h2>
    News Setting</h2>
<p>
    Select Category to List
    <asp:CustomValidator ID="CustomValidator_Category" runat="server" 
        ControlToValidate="tbx_NewsDetailURL" 
        ErrorMessage="You must select at least one category." 
        onservervalidate="CustomValidator_Category_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Panel ID="Panel_Parent_CategoryID" runat="server" Height="150px" ScrollBars="Auto"
        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
        <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
            Enable_CheckBox="true" Enable_HomeRoot="false" Module_ItemID="3A79BF21-D0DF-4825-BFB2-7F6738C12BA7" runat="server" />
    </asp:Panel>
</p>
<p>
    News Detail URL (The URL that link to news detail page.)<br />
    <asp:TextBox ID="tbx_NewsDetailURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
    Sort Order
    <asp:DropDownList ID="droplist_SortOrder" runat="server">
        <asp:ListItem Value="News_Date">News Date</asp:ListItem>
        <asp:ListItem Value="News_ModifyDate">News Modified Date</asp:ListItem>
        <asp:ListItem Value="News_Title">News Title</asp:ListItem>
        <asp:ListItem Value="UserName">User Name</asp:ListItem>
        <asp:ListItem Value="View_Count">View Count</asp:ListItem>
        <asp:ListItem Value="Comment_Count">Comment Count</asp:ListItem>
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
        <asp:ListItem Value="TitleOnly">Title Only</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when List Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_News/Templates/NewsList_Custom.ascx) <br />
    <asp:TextBox ID="tbx_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>

<p>
    Show pager
    <asp:RadioButtonList ID="rbtn_Enable_Pager" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    Number of news per page
    <telerik:RadNumericTextBox ID="RadNumericTbx_NumPerPage" runat="server" Value="10"
        Width="75px" DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<p>
    Total Number of news
    <telerik:RadNumericTextBox ID="RadNumericTbx_TotalNumber" runat="server" Value="100"
        Width="75px" DataType="System.Int16" MaxValue="200" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
