<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Script_Editor.ascx.cs"
    Inherits="Nexus.Controls.General.Script.Editor" ClassName="Nexus.Controls.General.Script.Script_Editor" %>
<asp:MultiView ID="MultiView_Editor" runat="server">
    <asp:View ID="View_Editor" runat="server">
        <p>
            <asp:LinkButton ID="lbtn_ShareContent" runat="server" OnClick="lbtn_ShareContent_Click">Share this content</asp:LinkButton>
            <asp:LinkButton ID="lbtn_BranchContent" runat="server" OnClick="lbtn_BranchContent_Click">Branch this content</asp:LinkButton>
            <asp:LinkButton ID="lbtn_SelectContent" runat="server" OnClick="lbtn_SelectContent_Click">Select shared content</asp:LinkButton>
        </p>
        <asp:Panel ID="Panel_Warning" runat="server" CssClass="nexusCore_info_message">
            This content is shared. Any changes made to it will affect all pages linked to it.
        </asp:Panel>
        Script Type:
        <asp:DropDownList ID="droplist_Script_Type" runat="server">
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="tbx_TextContent" runat="server" Height="400px" TextMode="MultiLine"
            Width="680px" Wrap="False"></asp:TextBox>
        <br />
        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
        </div>
    </asp:View>
    <asp:View ID="View_SelectContent" runat="server">
        <h2>
            Select HTML Content</h2>
        <div>
            Select Category to show items.
            <br />
            <asp:Panel ID="Panel_Parent_CategoryID" runat="server" Height="150px" ScrollBars="Auto"
                Width="350px" BorderStyle="Dashed" BorderWidth="1">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="076A591E-1BFE-47A7-8B40-D6621C7D3DF9"
                    OnCategorySelected="CategoryTree_Menu_CategorySelected" runat="server" />
            </asp:Panel>
        </div>
        <div>
            Select conent from the list:
            <asp:GridView ID="GridView_Items" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ScriptID" OnSelectedIndexChanged="GridView_Items_SelectedIndexChanged"
                Width="350px">
                <EmptyDataTemplate>
                    <p>
                        There is no items under this category.</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_SelectItem" runat="server" CausesValidation="False" CommandName="Select"
                                Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Content Name">
                        <ItemTemplate>
                            <%# Eval("Display_Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Update Date">
                        <ItemTemplate>
                            <%# Eval("LastUpdate_Date") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="UserControlBtns">
            <asp:Button ID="btn_SelectCancel" runat="server" CausesValidation="False" Text="Cancel"
                OnClick="btn_Cancel_Click" />
        </div>
    </asp:View>
    <asp:View ID="View_ShareContent" runat="server">
        <h2>
            Share HTML Content</h2>
        <div>
            Select Category to show items.
            <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_DisplayName"
                ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                ValidationGroup="ShareContent"></asp:CustomValidator>
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Auto" Width="350px"
                BorderStyle="Dashed" BorderWidth="1">
                <nexus:CategoryTree ID="CategoryTree_Share" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="076A591E-1BFE-47A7-8B40-D6621C7D3DF9"
                    runat="server" />
            </asp:Panel>
        </div>
        <div class="options">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_DisplayName" runat="server"
                ErrorMessage="Please enter a item name." ControlToValidate="tbx_DisplayName"
                ValidationGroup="ShareContent"></asp:RequiredFieldValidator>
            <br />
            <label>Item Name:</label>
            <asp:TextBox ID="tbx_DisplayName" runat="server" MaxLength="150" Width="200px" ValidationGroup="ShareContent"></asp:TextBox>
        </div>
        <div class="UserControlBtns">
            <asp:Button ID="btn_ShareContent" runat="server" Text="Share this content" OnClick="btn_ShareContent_Click"
                ValidationGroup="ShareContent" />
            <asp:Button ID="btn_ShareCancel" runat="server" CausesValidation="False" Text="Cancel"
                OnClick="btn_Cancel_Click" ValidationGroup="ShareContent" />
        </div>
    </asp:View>
</asp:MultiView>
