<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageCreate.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageCreate" %>
<asp:MultiView ID="MultiView_CreatePage" runat="server">
    <asp:View ID="View_PageType" runat="server">
        <div class="nexusCore_panel_pageType">
            <h3>
                Type of Page</h3>
            <table>
                <tr>
                    <th>
                        Page Type
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_PageType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="droplist_PageType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel_PageWizard" runat="server">
            <div class="nexusCore_panel_pageWizard">
                <h3>
                    Page Wizard</h3>
                <table>
                    <tr>
                        <th>
                            Object Components
                        </th>
                        <td>
                            <asp:DropDownList ID="droplist_ComponentWizard" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <div class="nexusCore_btn_goRight">
            <asp:Button ID="btn_NextStep" runat="server" Text="Next" OnClick="btn_NextStep_Click"
                SkinID="e2CMS_Button" /></div>
    </asp:View>
    <asp:View ID="View_PageOptions" runat="server">
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
                            OnTextChanged="tbx_MenuName_TextChanged" ValidationGroup="PageCreate_Options"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_MenuName" runat="server" ErrorMessage="You must give a name for your menu."
                            ControlToValidate="tbx_MenuName" ValidationGroup="PageCreate_Options"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        Page Name
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_PageName" runat="server" MaxLength="100" AutoPostBack="True"
                            OnTextChanged="tbx_PageName_TextChanged" ValidationGroup="PageCreate_Options"></asp:TextBox>.aspx
                        *
                        <asp:Button ID="btn_GetPageName" runat="server" Text="Refresh" OnClick="btn_GetPageName_Click"
                            SkinID="e2CMS_Button" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_PageName" runat="server" ErrorMessage="You must give a name for your page."
                            ControlToValidate="tbx_PageName" ValidationGroup="PageCreate_Options" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_PageName" runat="server"
                            ControlToValidate="tbx_PageName" Display="Dynamic" ErrorMessage="Page name can contain number and letters only."
                            ValidationExpression="^[a-zA-Z0-9\-]+$" ValidationGroup="PageCreate_Options"></asp:RegularExpressionValidator>
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
                <table>
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
                    <table>
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
                                    Rows="5" TextMode="MultiLine" Wrap="False"></asp:TextBox>
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
                                    <th>
                                        Template
                                    </th>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
                                            <ContentTemplate>
                                                <div class="UpdatePanel_Template">
                                                    <asp:DropDownList ID="droplist_Template" runat="server" AutoPostBack="True" OnSelectedIndexChanged="droplist_Template_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:FormView ID="FormView_Template" runat="server">
                                                        <ItemTemplate>
                                                            <img src='<%# Eval("MasterPage_PreviewURL")%>' width="150" />
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
                <div class="nexusCore_panel_pageSecurities_createPage">
                    <asp:Panel ID="Panel_Page_Securities" runat="server">
                        <h3>
                            Security</h3>
                        <table>
                            <tr>
                                <th>
                                    Inherited Page Privacy
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="rbtn_IsPrivacy_Inherited" runat="server" RepeatDirection="Horizontal">
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
                        </table>
                    </asp:Panel>
                </div>
            </asp:Panel>
        </div>
        <div class="nexusCore_btn_goRight">
            <asp:Button ID="btn_AddPage" runat="server" Text="Add Page" OnClick="btn_AddPage_Click"
                ValidationGroup="PageCreate_Options" SkinID="e2CMS_Button" /></div>
    </asp:View>
    <asp:View ID="View_PageWizard" runat="server">
        <asp:PlaceHolder ID="PlaceHolder_PageWizard" runat="server"></asp:PlaceHolder>
        <asp:Button ID="btn_AddComponent" runat="server" Text="Add Component" SkinID="e2CMS_Button" />
        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" SkinID="e2CMS_Button" />
    </asp:View>
</asp:MultiView>
