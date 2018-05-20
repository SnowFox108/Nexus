<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemDetail_Editor.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemDetail.Editor" ClassName="Nexus.Controls.Gallery.ItemDetail.ItemDetail_Editor" %>
<div>
    Override page title (Enable 
    photo title to replace page title.)
    <asp:RadioButtonList ID="rbtn_IsPageTitle" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div>
Display ID
    <asp:DropDownList ID="droplist_DisplayID" runat="server">
    </asp:DropDownList>
</div>
<div>
    Photo Display Template
    <asp:RadioButtonList ID="rbtn_ItemTemplate" runat="server" RepeatColumns="3">
        <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
        <asp:ListItem Value="Custom">Custom</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div>
Custom Template URL: (This works only when Photo Display Template is Custom.) <br />
Sample: (~/App_Control_Style/Nexus_Gallery/Templates/ItemDetail_Custom.ascx) <br />
    <asp:TextBox ID="tbx_ItemTemplateURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
    <asp:Button ID="btn_FileSelector" runat="server" ToolTip="Select a template file" Text="Select Template"
        OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_ItemTemplateURL&FileTypes=ModuleTemplates'); return false;" />

</div>

<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
