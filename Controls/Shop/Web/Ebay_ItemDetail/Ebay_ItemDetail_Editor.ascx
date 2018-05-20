<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ebay_ItemDetail_Editor.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ItemDetail.Editor" ClassName="Nexus.Controls.Ebay.ItemDetail.ItemDetail_Editor" %>
<p>
    Override page title (Enable item title replace page title.)
    <asp:RadioButtonList ID="rbtn_IsPageTitle" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Item Display Template
    <asp:RadioButtonList ID="rbtn_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
Custom Template URL: (This works only when Item Display Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_Ebay/Templates/ItemDetail_Custom.ascx) <br />
    <asp:TextBox ID="tbx_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
</p>

<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
