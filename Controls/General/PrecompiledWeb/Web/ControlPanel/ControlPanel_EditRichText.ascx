<%@ control language="C#" autoeventwireup="true" inherits="Nexus.Controls.General.ControlPanel.EditRichText, App_Web_jvoxhdcg" classname="Nexus.Controls.General.ControlPanel.ControlPanel_EditRichText" %>
            <div>
            Item Name *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter a item name."
                ControlToValidate="tbx_DisplayName" ValidationGroup="Edit_Item"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_DisplayName" runat="server" MaxLength="350" Width="550px" ValidationGroup="Edit_Item"></asp:TextBox>
        </div>
        <div>
            Content *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Content" runat="server" ControlToValidate="RadEditor_TextContent"
                ErrorMessage="Please enter content." ValidationGroup="Edit_Item"></asp:RequiredFieldValidator>
            <br />
        <telerik:RadTabStrip ID="RadTabStrip_EditorBar" runat="server" OnTabClick="RadTabStrip_EditorBar_TabClick"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Selected="True" Text="Basic" Value="BasicTools">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Advanced" Value="Default">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadEditor ID="RadEditor_TextContent" runat="server">
        </telerik:RadEditor>
        </div>
        <div>
            Select Category * 
            <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_DisplayName"
                ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                ValidationGroup="Edit_Item"></asp:CustomValidator>
            <br />
            <asp:Panel ID="Panel_Parent_CategoryID" runat="server" BorderStyle="Dashed" Height="150px"
                ScrollBars="Auto" Width="350px" BorderWidth="1">
                <nexus:CategoryTree ID="CategoryTree_Menu" runat="server" Module_ItemID="A2E21E10-FF09-4D3F-9D70-DF9376FCF8B7"
                    Enable_CheckBox="false" Enable_DragAndDrop="false" Enable_HomeRoot="false" Root_CategoryID="-1" />
            </asp:Panel>
        </div>

        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Create this Item"
                ValidationGroup="Edit_Item" />
        </div>
