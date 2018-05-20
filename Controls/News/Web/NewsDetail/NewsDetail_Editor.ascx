<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDetail_Editor.ascx.cs"
    Inherits="Nexus.Controls.News.NewsDetail.Editor" ClassName="Nexus.Controls.News.NewsDetail.NewsDetail_Editor" %>
<h2>
News Detail</h2>
<p>
Override page title (Enable news title replace page title.)
    <asp:RadioButtonList ID="rbtn_IsPageTitle" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
News Template
    <asp:RadioButtonList ID="rbtn_NewsDetail_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when News Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_News/Templates/NewsDetail_Custom.ascx) <br />
    <asp:TextBox ID="tbx_NewsDetail_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>

<h2>
    Comment</h2>
<p>
Show Comment (Allow user see and post comment.)
    <asp:RadioButtonList ID="rbtn_IsComment" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Comment Title Template
    <asp:RadioButtonList ID="rbtn_CommentTitle_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when Comment 
    Title Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_News/Templates/NewsCommentTitle_Custom.ascx) <br />
    <asp:TextBox ID="tbx_CommentTitle_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
Comment List Template
    <asp:RadioButtonList ID="rbtn_Comment_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when Comment List Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_News/Templates/NewsComment_Custom.ascx) <br />
    <asp:TextBox ID="tbx_Comment_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>
<p>
    Allow guest comment (Allow guest post comment or only registed user. Only works when Show Comment is Yes.)
    <asp:RadioButtonList ID="rbtn_IsGuestComment" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    Number of comment per page (Only works when Show Comment is Yes.)
    <telerik:RadNumericTextBox ID="RadNumericTbx_NumPerPage" runat="server" Value="10"
        Width="75px" DataType="System.Int16" MaxValue="100" MinValue="1" ShowSpinButtons="True"
        CssClass="txt_area">
        <NumberFormat DecimalDigits="0" GroupSeparator="" />
    </telerik:RadNumericTextBox>
</p>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
