<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanel_EditScript.ascx.cs"
    Inherits="Nexus.Controls.General.ControlPanel.EditScript" ClassName="Nexus.Controls.General.ControlPanel.ControlPanel_EditScript" %>
            <div>
            Item Name *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter a item name."
                ControlToValidate="tbx_DisplayName" ValidationGroup="Edit_Item"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_DisplayName" runat="server" MaxLength="350" Width="550px" ValidationGroup="Edit_Item"></asp:TextBox>
        </div>
        <div>
            Content *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Content" runat="server" ControlToValidate="tbx_TextContent"
                ErrorMessage="Please enter content." ValidationGroup="Edit_Item"></asp:RequiredFieldValidator>
            <br />
        Script Type:
        <asp:DropDownList ID="droplist_Script_Type" runat="server">
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="tbx_TextContent" runat="server" Height="400px" TextMode="MultiLine"
            Width="680px" Wrap="False" ValidationGroup="Edit_Item"></asp:TextBox>
        </div>
        <div>
            Select Category * 
            <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_DisplayName"
                ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                ValidationGroup="Edit_Item"></asp:CustomValidator>
            <br />
            <asp:Panel ID="Panel_Parent_CategoryID" runat="server" BorderStyle="Dashed" Height="150px"
                ScrollBars="Auto" Width="350px" BorderWidth="1">
                <nexus:CategoryTree ID="CategoryTree_Menu" runat="server" Module_ItemID="076A591E-1BFE-47A7-8B40-D6621C7D3DF9"
                    Enable_CheckBox="false" Enable_DragAndDrop="false" Enable_HomeRoot="false" Root_CategoryID="-1" />
            </asp:Panel>
        </div>

        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Create this Item"
                ValidationGroup="Edit_Item" />
        </div>
