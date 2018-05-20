<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PagePrivacy.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PagePrivacy" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Page properties have been updated!</div>
</asp:Panel>
<div class="nexusCore_panel_pageSecurities">
    <asp:Panel ID="Panel_Page_Securities" runat="server">
        <h3>
            Security</h3>
        <table>
            <tr>
                <th>
                    Inherited Page Privacy
                </th>
                <td>
                    <asp:RadioButtonList ID="rbtn_IsPrivacy_Inherited" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="rbtn_IsPrivacy_Inherited_SelectedIndexChanged">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    Require SSL
                </th>
                <td>
                    <asp:RadioButtonList ID="rbtn_IsSSL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    Return URL
                </th>
                <td>
                    <asp:TextBox ID="tbx_ReturnURL" runat="server" Width="450" MaxLength="250" ></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<br class="clear" />
<div class="nexusCore_btn_goRight ">
    <asp:Button ID="btn_UpdatePage" runat="server" Text="Update Properties" OnClick="btn_UpdatePage_Click" SkinID="e2CMS_Button"/>
</div>
<div class="nexusCore_panel_pagePermissions">
    <asp:Panel ID="Panel_Page_Permissions" runat="server">
        <h3>
            Permissions</h3>
        <asp:DropDownList ID="droplist_UserGroup" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_AddRoles" runat="server" Text="Add Role" OnClick="btn_AddRoles_Click" SkinID="e2CMS_Button" />
        <asp:Label ID="lbl_AddRolesError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView_Permissions" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="PrivacyID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="User Group" ItemStyle-CssClass="userGroup">
                    <ItemTemplate>
                        <asp:Label ID="lbl_GroupName" runat="server" Text='<%# Bind("UserGroup_Name") %>'
                            ToolTip='<%# Bind("UserGroup_Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_View" runat="server" Checked='<%# Bind("Allow_View") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Create">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Create" runat="server" Checked='<%# Bind("Allow_Create") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modify">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Modify" runat="server" Checked='<%# Bind("Allow_Modify") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Delete" runat="server" Checked='<%# Bind("Allow_Delete") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rollback">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Rollback" runat="server" Checked='<%# Bind("Allow_Rollback") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Change Permissions">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_ChangePermission" runat="server" Checked='<%# Bind("Allow_ChangePermissions") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Approve">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Approve" runat="server" Checked='<%# Bind("Allow_Approve") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publish">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Publish" runat="server" Checked='<%# Bind("Allow_Publish") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designer Mode">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_DesignMode" runat="server" Checked='<%# Bind("Allow_DesignMode") %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel_PrivacyCommand" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbtn_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit" CommandArgument='<%# Bind("PrivacyID") %>' OnCommand="lbtn_Edit_Command" SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CausesValidation="False" Text="Delete"
                                    CommandArgument='<%# Eval("PrivacyID") %>' OnCommand="lbtn_Delete_Command" SkinID="e2CMS_LinkButton"></asp:LinkButton>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lbtn_Edit" />
                                <asp:PostBackTrigger ControlID="lbtn_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="Panel_Privacy" runat="server">
            <table>
                <tr>
                    <th>
                        User Group
                    </th>
                    <th>
                        View
                    </th>
                    <th>
                        Create
                    </th>
                    <th>
                        Modify
                    </th>
                    <th>
                        Delete
                    </th>
                    <th>
                        Rollback
                    </th>
                    <th>
                        Change Permissions
                    </th>
                    <th>
                        Approve
                    </th>
                    <th>
                        Publish
                    </th>
                    <th>
                        Enter Design Mode
                    </th>
                    <th>
                        Actions
                    </th>
                </tr>
                <tr>
                    <td class="userGroup">
                        <asp:Label ID="lbl_UserGroup" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_View" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Create" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Modify" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Delete" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Rollback" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_ChangePermission" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Approve" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Publish" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_DesignMode" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn_UpdatePermission" runat="server" Text="Update Privacy" OnCommand="btn_UpdatePermission_Command" SkinID="e2CMS_Button"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</div>
<br class="clear" />
