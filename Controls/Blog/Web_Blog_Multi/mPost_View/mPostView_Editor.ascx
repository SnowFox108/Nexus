<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mPostView_Editor.ascx.cs"
    Inherits="Nexus.Controls.Blog.mPostView.Editor" ClassName="Nexus.Controls.Blog.mPostView.mPostView_Editor" %>
<p>
Override page title (Enable post title replace page title.)
    <asp:RadioButtonList ID="rbtn_IsPageTitle" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    Allow guest comment (Allow guest post comment or only registed user.)
    <asp:RadioButtonList ID="rbtn_IsGuestComment" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    Number of comment per page
    <telerik:RadNumericTextBox ID="RadNumericTbx_NumPerPage" runat="server" Value="10"
        Width="75px" DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<p>
    Blog Post URL (The URL that link to blog post list page.)<br />
    <asp:TextBox ID="tbx_BlogPostsURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
