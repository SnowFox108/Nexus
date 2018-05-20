<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master"
    AutoEventWireup="true" CodeFile="WebsiteSetting.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_WebsiteSetting"
    Title="Website Control Panel - Website Setting" StylesheetTheme="NexusCore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>
    <div id="singleMain">
        <div class="in">
            <asp:Panel ID="Panel_Updated" runat="server">
                <div class="nexusCore_error_message">
                    Page properties have been updated!</div>
            </asp:Panel>
            <div class="nexusCore_panel_homeSwitch">
                            <asp:Panel ID="Panel_HomeSwitch" runat="server">
                    <h3>
                        Website Control</h3>
                        <table>
                        <tr>
                        <th>Trun you website</th>
                        <td>
                            <asp:RadioButtonList ID="rbtn_HomeSwitch" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">On</asp:ListItem>
                                <asp:ListItem Value="False">Off</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                            <td>
                            <asp:Button ID="btn_HomeSwitch" runat="server" Text="Switch" 
                                    onclick="btn_HomeSwitch_Click" SkinID="e2CMS_Button" />
                        </td>
                        </tr>
                        </table>
                        </asp:Panel>

            </div>
            <div class="nexusCore_headContent">
                <asp:Panel ID="Panel_HeadContent" runat="server">
                    <h3>
                        Head Content</h3>
                    <asp:Panel ID="Panel_PageAttribute" runat="server">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <th>
                                    Title
                                </th>
                                <td>
                                    <asp:TextBox ID="tbx_Page_Title" runat="server" Width="450" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Keywords
                                </th>
                                <td>
                                    <asp:TextBox ID="tbx_Page_Keyword" runat="server" Width="450" MaxLength="250"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Description
                                </th>
                                <td>
                                    <asp:TextBox ID="tbx_Page_Description" runat="server" Width="450" MaxLength="1000"
                                        Rows="5" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </div>
            
            <div class="nexusCore_pageTemplates">
                <asp:Panel ID="Panel_Page_Templates" runat="server">
                    <h3>
                        Page Template</h3>
                    <asp:Panel ID="Panel_Template" runat="server">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <th>
                                    Template
                                </th>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
                                        <ContentTemplate>
                                            <div class="UpdatePanel_Template">
                                                <asp:DropDownList ID="droplist_Template" runat="server" DataSourceID="ObjectDataSource_Template"
                                                    DataTextField="MasterPage_Name" DataValueField="MasterPageIndexID" AutoPostBack="True"
                                                    OnSelectedIndexChanged="droplist_Template_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:FormView ID="FormView_Template" runat="server" DataSourceID="ObjectDataSource_Template"
                                                   >
                                                    <ItemTemplate>
                                                        <img src='<%# Eval("MasterPage_PreviewURL")%>' />
                                                    </ItemTemplate>
                                                </asp:FormView>
                                                <asp:ObjectDataSource ID="ObjectDataSource_Template" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="sGet_Template_MasterPage_DropList" TypeName="Nexus.Core.Templates.MasterPageMgr">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="SortOrder" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </div>

            <div class="nexusCore_pageSecurities">
                <asp:Panel ID="Panel_Page_Securities" runat="server">
                    <h3>
                        Security</h3>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                Require SSL
                            </th>
                            <td>
                                <div class="rbt_width">
                                    <asp:RadioButtonList ID="rbtn_IsSSL" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Return URL
                            </th>
                            <td>
                                <asp:TextBox ID="tbx_ReturnURL" runat="server" Width="450" MaxLength="250"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <br class="clear" />
            <div class="nexusCore_btn_goRight">
                <asp:Button ID="btn_UpdatePage" runat="server" Text="Update Properties" OnClick="btn_UpdatePage_Click" SkinID="e2CMS_Button"/>
            </div>

<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Page_Scripts" runat="server">        
        <h3>
            Website Global JavaScripts</h3>
        Script URL :
        <asp:TextBox ID="tbx_ScriptURL" runat="server" MaxLength="300" Width="450px" ValidationGroup="AddScript"></asp:TextBox>
        <asp:Button ID="btn_AddScript" runat="server" Text="Add Script" SkinID="e2CMS_Button"
            ValidationGroup="AddScript" onclick="btn_AddScript_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Script" runat="server" ErrorMessage="Please enter script URL."
            ControlToValidate="tbx_ScriptURL" ValidationGroup="AddScript"></asp:RequiredFieldValidator>
        <asp:GridView ID="GridView_Scripts" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Script URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ScriptURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="Script URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel_PrivacyCommand" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbtn_Script_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit" CommandArgument='<%# Bind("MetaTagID") %>' OnCommand="lbtn_Script_Edit_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Script_Delete" runat="server" CausesValidation="False" Text="Delete"
                                    CommandArgument='<%# Eval("MetaTagID") %>' OnCommand="lbtn_Script_Delete_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lbtn_Script_Edit" />
                                <asp:PostBackTrigger ControlID="lbtn_Script_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no Scripts.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
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
        <asp:Panel ID="Panel_Update_Script" runat="server">
            Script URL :
            <asp:TextBox ID="tbx_UpdateScriptURL" runat="server" MaxLength="300" Width="450px"
                ValidationGroup="UpdateScript"></asp:TextBox>
            <asp:Button ID="btn_UpdateScript" runat="server" Text="Update Script" OnCommand="btn_UpdateScript_Command"
                SkinID="e2CMS_Button" ValidationGroup="UpdateScript" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Update_Script" runat="server"
                ErrorMessage="Please enter script URL." ControlToValidate="tbx_UpdateScriptURL"
                ValidationGroup="UpdateScript"></asp:RequiredFieldValidator>
        </asp:Panel>
    </asp:Panel>
</div>
<br class="clear" />

<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Page_CSS" runat="server">        
        <h3>
            Website Global CSS</h3>
        CSS URL :
        <asp:TextBox ID="tbx_CSSURL" runat="server" MaxLength="300" Width="450px" ValidationGroup="AddCSS"></asp:TextBox>
        <asp:Button ID="btn_AddCSS" runat="server" Text="Add CSS" SkinID="e2CMS_Button"
            ValidationGroup="AddCSS" onclick="btn_AddCSS_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_CSS" runat="server" ErrorMessage="Please enter CSS URL."
            ControlToValidate="tbx_CSSURL" ValidationGroup="AddCSS"></asp:RequiredFieldValidator>
        <asp:GridView ID="GridView_CSS" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="CSS URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_CSSURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="CSS URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel_CSS_Command" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbtn_CSS_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit" CommandArgument='<%# Bind("MetaTagID") %>' OnCommand="lbtn_CSS_Edit_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                <asp:LinkButton ID="lbtn_CSS_Delete" runat="server" CausesValidation="False" Text="Delete"
                                    CommandArgument='<%# Eval("MetaTagID") %>' OnCommand="lbtn_CSS_Delete_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lbtn_CSS_Edit" />
                                <asp:PostBackTrigger ControlID="lbtn_CSS_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no CSS.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
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
        <asp:Panel ID="Panel_Update_CSS" runat="server">
            CSS URL :
            <asp:TextBox ID="tbx_UpdateCSSURL" runat="server" MaxLength="300" Width="450px"
                ValidationGroup="UpdateCSS"></asp:TextBox>
            <asp:Button ID="btn_UpdateCSS" runat="server" Text="Update CSS" OnCommand="btn_UpdateCSS_Command"
                SkinID="e2CMS_Button" ValidationGroup="UpdateCSS" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Update_CSS" runat="server"
                ErrorMessage="Please enter CSS URL." ControlToValidate="tbx_UpdateCSSURL"
                ValidationGroup="UpdateCSS"></asp:RequiredFieldValidator>
        </asp:Panel>
    </asp:Panel>
</div>
<br class="clear" />

            <div class="nexusCore_pagePermissions">
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
                            <asp:TemplateField HeaderText="User Group">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_GroupName" runat="server" Text='<%# Bind("UserGroup_Name") %>'
                                        ToolTip='<%# Bind("UserGroup_Description") %>' CssClass="left"></asp:Label>
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
                            <asp:TemplateField HeaderText="Enter Design Mode">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_DesignMode" runat="server" Checked='<%# Bind("Allow_DesignMode") %>'
                                        Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                        Text="Edit" CommandArgument='<%# Bind("PrivacyID") %>' OnCommand="lbtn_Edit_Command" SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Delete" runat="server" CausesValidation="False" Text="Delete"
                                        CommandArgument='<%# Eval("PrivacyID") %>' OnCommand="lbtn_Delete_Command" SkinID="e2CMS_LinkButton"></asp:LinkButton>
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
                                <td>
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
                                    <asp:Button ID="btn_UpdatePermission" runat="server" Text="Update Privacy" OnCommand="btn_UpdatePermission_Command" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
