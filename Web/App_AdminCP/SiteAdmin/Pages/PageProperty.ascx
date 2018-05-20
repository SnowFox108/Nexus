<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageProperty.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageProperty" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Page properties have been updated!</div>
</asp:Panel>
<div class="nexusCore_panel_pageLink">
    <h3>
        General</h3>
    <asp:Panel ID="Panel_PageLink" runat="server">
        <table>
            <tr>
                <th>
                    <asp:Label ID="lbl_LinkURL" runat="server"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="tbx_LinkURL" runat="server" Width="450" MaxLength="250"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Page Target
                </th>
                <td>
                    <asp:TextBox ID="RadComboBox_LinkTarget" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <th>
                Menu Label
            </th>
            <td>
                <asp:TextBox ID="tbx_MenuName" runat="server" MaxLength="100" AutoPostBack="True"
                    OnTextChanged="tbx_MenuName_TextChanged" ValidationGroup="PageProperty_Options"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_MenuName" runat="server" ErrorMessage="You must give a name for your menu."
                    ControlToValidate="tbx_MenuName" ValidationGroup="PageProperty_Options"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                Page Name
            </th>
            <td>
                <asp:TextBox ID="tbx_PageName" runat="server" MaxLength="100" AutoPostBack="True"
                    OnTextChanged="tbx_PageName_TextChanged" ValidationGroup="PageProperty_Options"></asp:TextBox>.aspx
                *
                <asp:Button ID="btn_GetPageName" runat="server" Text="Refresh" 
                    onclick="btn_GetPageName_Click" SkinID="e2CMS_Button" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_PageName" runat="server" ErrorMessage="You must give a name for your page."
                    ControlToValidate="tbx_PageName" ValidationGroup="PageProperty_Options" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_PageName" runat="server"
                    ControlToValidate="tbx_PageName" Display="Dynamic" ErrorMessage="Page name can contain number and letters only."
                    ValidationExpression="^[a-zA-Z0-9\-]+$" ValidationGroup="PageProperty_Options"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th>
                Show On Menu
            </th>
            <td>
                <asp:RadioButtonList ID="rbtn_IsOnMenu" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>
                Show On Navigation
            </th>
            <td>
                <asp:RadioButtonList ID="rbtn_IsOnNavigator" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<asp:Panel ID="Panel_HeadContent" runat="server">
    <div class="nexusCore_panel_headContent">
        <h3>
            Head Content</h3>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    Inherited Page Attributes
                </th>
                <td>
                    <asp:RadioButtonList ID="rbtn_IsAttribute_Inherited" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="rbtn_IsAttribute_Inherited_SelectedIndexChanged">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
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
    </div>
</asp:Panel>
<div class="nexusCore_panel_moreOptions">
    <asp:Panel ID="Panel_OptionTitle" runat="server" CssClass="nexusCore_collapsePanelHeader">
        <h2>
            <asp:Label ID="lbl_MoreOptions" runat="server">More options </asp:Label>
        </h2>
    </asp:Panel>
    <asp:CollapsiblePanelExtender ID="cpe1" runat="server" TargetControlID="Panel_OptionContent"
        ExpandControlID="Panel_OptionTitle" CollapseControlID="Panel_OptionTitle" Collapsed="True"
        TextLabelID="lbl_MoreOptions" ExpandedText="More options" CollapsedText="More options"
        ImageControlID="Img_MoreOptions" ExpandedImage="/App_Control_Style/NexusCore/images/collapse.jpg"
        CollapsedImage="/App_Control_Style/NexusCore/images/expand.jpg" SuppressPostBack="true">
    </asp:CollapsiblePanelExtender>
    <asp:Panel ID="Panel_OptionContent" runat="server" CssClass="nexusCore_collapsePanel">
        <div class="nexusCore_panel_pageTemplates">
            <asp:Panel ID="Panel_Page_Templates" runat="server">
                <h3>
                    Page Template</h3>
                <table>
                    <tr>
                        <th>
                            Inherited Template
                        </th>
                        <td>
                            <asp:RadioButtonList ID="rbtn_IsTemplate_Inherited" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="rbtn_IsTemplate_Inherited_SelectedIndexChanged">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel_Template" runat="server">
                    <table>
                        <tr>
                            <th valign="top">
                                Template
                            </th>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
                                    <ContentTemplate>
                                        <div class="UpdatePanel_Template">
                                            <asp:DropDownList ID="droplist_Template" runat="server" AutoPostBack="True" OnSelectedIndexChanged="droplist_Template_SelectedIndexChanged"
                                                CssClass="txt_input">
                                            </asp:DropDownList>
                                            <asp:FormView ID="FormView_Template" runat="server" CssClass="txt_input">
                                                <ItemTemplate>
                                                    <img src='<%# Eval("MasterPage_PreviewURL")%>' alt='<%# Eval("MasterPage_Name")%>' />
                                                </ItemTemplate>
                                            </asp:FormView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
        </div>
        <div class="nexusCore_panel_pageURLs">
            <asp:Panel ID="Panel_Page_URLs" runat="server">
                <h3>
                    Page URLs</h3>
                <table>
                    <tr>
                        <th>
                            Page URL
                        </th>
                        <td>
                            <asp:TextBox ID="tbx_PageURL" runat="server" Width="450" MaxLength="250" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            URL list
                        </th>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </asp:Panel>
</div>
<br class="clear" />
<div class="nexusCore_btn_goRight">
    <asp:Button ID="btn_UpdatePage" runat="server" Text="Update Properties" OnClick="btn_UpdatePage_Click"
        ValidationGroup="PageProperty_Options" SkinID="e2CMS_Button" />
</div>
