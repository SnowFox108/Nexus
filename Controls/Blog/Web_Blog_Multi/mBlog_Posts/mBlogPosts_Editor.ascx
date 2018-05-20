<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mBlogPosts_Editor.ascx.cs"
    Inherits="Nexus.Controls.Blog.mBlogPosts.Editor" ClassName="Nexus.Controls.Blog.mBlogPosts.mBlogPosts_Editor" %>
<fieldset class="UserControlProperties">
    <legend>Blog Properties </legend>
    <p>
        Show Content (Display post content in blog list or not.)
        <asp:RadioButtonList ID="rbtn_ShowContent" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="True">Yes</asp:ListItem>
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
</fieldset>
<fieldset class="UserControlProperties">
    <legend>Public Blog options </legend>
    <p>
        Show Public Blog (Show public blog for guest.)
        <asp:RadioButtonList ID="rbtn_ShowPublicPosts" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="True">Yes</asp:ListItem>
            <asp:ListItem Value="False">No</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
        Maximum Posts (Maximum number display on public blog.)
        <telerik:RadNumericTextBox ID="RadNumericTbx_MaxNumberPosts" runat="server" Value="50" Width="75px"
            DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True" CssClass="txt_area">
            <NumberFormat DecimalDigits="0" GroupSeparator="" />
        </telerik:RadNumericTextBox>
    </p>
    <p>
        Return URL (This only works when 'Show Public Blog' is disabled.)<br />
        <asp:TextBox ID="tbx_ReturnURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
    </p>
</fieldset>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
