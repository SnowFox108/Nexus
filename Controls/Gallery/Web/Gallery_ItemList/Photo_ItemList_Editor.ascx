<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemList_Editor.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemList.Editor" ClassName="Nexus.Controls.Gallery.ItemList.ItemList_Editor" %>
<h2>
    Gallery Item List Setting</h2>
<p>
    Select Category to List
    <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_Photo_ItemDetailURL"
        ErrorMessage="You must select at least one category." 
        OnServerValidate="CustomValidator_Category_ServerValidate"></asp:CustomValidator>
    <br />
    <asp:Panel ID="Panel_Parent_CategoryID" runat="server" Height="150px" ScrollBars="Auto"
        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
        <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
            Enable_CheckBox="true" Enable_HomeRoot="false" Module_ItemID="9473F482-CC30-4963-946A-28CA4AD44041"
            runat="server" />
    </asp:Panel>
</p>
<p>
    Gallery Detail URL (The URL that link to Gallery detail page.)<br />
    <asp:TextBox ID="tbx_Photo_ItemDetailURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
    <asp:Button ID="btn_PageURLSelector" runat="server" ToolTip="Select a page" Text="Select Page"
        OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_PageURLSelector.aspx?ControlID=tbx_Photo_ItemDetailURL'); return false;" />

</p>
<p>
    Sort Order
    <asp:DropDownList ID="droplist_SortOrder" runat="server">
        <asp:ListItem Value="SortOrder" Selected="True">Sort Order</asp:ListItem>
        <asp:ListItem Value="Photo_Title">Photo Title</asp:ListItem>
        <asp:ListItem Value="Create_Date">Create_Date</asp:ListItem>
        <asp:ListItem Value="LastUpdate_Date">Last Update Date</asp:ListItem>
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
Display ID
    <asp:DropDownList ID="droplist_DisplayID" runat="server">
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
Sample: (~/App_Control_Style/Nexus_Gallery/Template/ItemList_Custom.ascx) <br />
    <asp:TextBox ID="tbx_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
    <asp:Button ID="btn_FileSelector" runat="server" ToolTip="Select a template file" Text="Select Template"
        OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_ItemTemplateURL&FileTypes=ModuleTemplates'); return false;" />

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
