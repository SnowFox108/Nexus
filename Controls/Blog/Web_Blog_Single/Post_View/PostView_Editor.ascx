<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostView_Editor.ascx.cs" Inherits="Nexus.Controls.Blog.PostView.Editor" ClassName="Nexus.Controls.Blog.PostView.PostView_Editor" %>
<h2>Post View</h2>
<p>
Override page title (Enable post title replace page title.)
    <asp:RadioButtonList ID="rbtn_IsPageTitle" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Post View Template
    <asp:RadioButtonList ID="rbtn_PostView_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when Post View Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_Blog/Templates/PostView_Custom.ascx) <br />
    <asp:TextBox ID="tbx_PostView_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>

<h2>Comment</h2>
<p>
    Allow guest comment (Allow guest post comment or only registed user.)
    <asp:RadioButtonList ID="rbtn_IsGuestComment" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Comment List Template
    <asp:RadioButtonList ID="rbtn_Comment_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when Post View Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_Blog/Template/PostComment_Custom.ascx) <br />
    <asp:TextBox ID="tbx_Comment_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
    Show Comment pager
    <asp:RadioButtonList ID="rbtn_Enable_Pager" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
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
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
