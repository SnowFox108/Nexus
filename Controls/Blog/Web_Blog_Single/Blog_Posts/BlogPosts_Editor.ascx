<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogPosts_Editor.ascx.cs" Inherits="Nexus.Controls.Blog.BlogPosts.Editor" ClassName="Nexus.Controls.Blog.BlogPosts.BlogPosts_Editor" %>
<p>
    Blog UserID (Choose who's blog going to display.)
    <asp:TextBox ID="tbx_Ownership_UserID" runat="server"></asp:TextBox>
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
Sample: (~/App_Control_Style/Nexus_Blog/Templates/BlogPosts_Custom.ascx) <br />
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
    Number of post per page
    <telerik:RadNumericTextBox ID="RadNumericTbx_NumPerPage" runat="server" Value="10"
        Width="75px" DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<p>
    Post View URL (The URL that link to post detail page.)<br />
    <asp:TextBox ID="tbx_PostViewURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
