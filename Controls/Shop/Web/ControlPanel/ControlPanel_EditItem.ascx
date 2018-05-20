<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanel_EditItem.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ControlPanel.EditItem" ClassName="Nexus.Controls.Ebay.ControlPanel.ControlPanel_EditItem" %>
        <div>
            Customer Item Description * (This will be stored on your local website)
            <br />
            <nexus:TextEditor ID="TextEditor_ItemContent" runat="server" EnableResize="false" />
        </div>
        <div>
            Item List Status
            <asp:RadioButtonList ID="rbtn_IsActive" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="True">Active</asp:ListItem>
                <asp:ListItem Value="False">Inactive</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update"
                ValidationGroup="eBay_Edit_Post" />
        </div>

