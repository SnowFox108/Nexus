<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanel_EditItem.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ControlPanel.EditItem" ClassName="Nexus.Controls.Gallery.ControlPanel.ControlPanel_EditItem" %>
<div>
    Photo Title:
    <asp:TextBox ID="tbx_Photo_Title" runat="server" MaxLength="250" Width="150px"></asp:TextBox>
</div>
<div>
    Description:
    <br />
    <nexus:TextEditor ID="TextEditor_Description" runat="server" EnableResize="false" />
</div>
<div>
    Image Type:
    <asp:DropDownList ID="droplist_ImageType" runat="server">
    </asp:DropDownList>
</div>
<div>
    Image URL:
    <asp:TextBox ID="tbx_ImageURL" runat="server" MaxLength="400" Width="350px"></asp:TextBox>
    <asp:Button ID="btn_FileSelector" runat="server" ToolTip="Select a image file" Text="Select Image"
        OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_ImageURL&FileTypes=Images'); return false;" />
</div>
<div>
    Alternate Text:
    <asp:TextBox ID="tbx_AlternateText" runat="server" MaxLength="150" Width="150px"></asp:TextBox>
</div>
<div>
    Item List Status
    <asp:RadioButtonList ID="rbtn_IsActive" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Active</asp:ListItem>
        <asp:ListItem Value="False">Inactive</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update"
        ValidationGroup="eBay_Edit_Post" />
</div>
