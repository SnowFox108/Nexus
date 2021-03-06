﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageProperty.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageProperty" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <h3>
        Page properties have been updated!</h3>
</asp:Panel>
<div class="Panel_PageLink">
    <h3> General</h3>
    <asp:Panel ID="Panel_PageLink" runat="server">
        <table>
            <tr>
                <td>
                    Page URL
                </td>
                <td>
                    <asp:TextBox ID="tbx_LinkURL" runat="server" Width="450" MaxLength="250" CssClass="txt_input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Page Target
                </td>
                <td>
                    <telerik:RadComboBox ID="RadComboBox_LinkTarget" runat="server" AllowCustomText="True">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="_blank" Value="_blank" />
                            <telerik:RadComboBoxItem runat="server" Text="_parent" Value="_parent" />
                            <telerik:RadComboBoxItem runat="server" Text="_self" Value="_self" />
                            <telerik:RadComboBoxItem runat="server" Text="_top" Value="_top" />
                        </Items>
                    </telerik:RadComboBox>
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
                    OnTextChanged="tbx_MenuName_TextChanged"  CssClass="txt_input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Show On Menu
            </th>
            <td>
                <div class="rbt_width">
                <asp:RadioButtonList ID="rbtn_IsOnMenu" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList></div>
            </td>
        </tr>
        <tr>
            <th>
                Show On Navigation
            </th>
            <td><div class="rbt_width">
                <asp:RadioButtonList ID="rbtn_IsOnNavigator" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList></div>
            </td>
        </tr>
    </table>
</div>
<div class="Panel_HeadContent">
    <asp:Panel ID="Panel_HeadContent" runat="server">
        <h3>
            Head Content</h3>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    Inherited Page Attributes
                </th>
                <td><div class="rbt_width">
                    <asp:RadioButtonList ID="rbtn_IsAttribute_Inherited" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="rbtn_IsAttribute_Inherited_SelectedIndexChanged">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList></div>
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
                        <asp:TextBox ID="tbx_Page_Title" runat="server" Width="450" MaxLength="100"  CssClass="txt_input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Keywords
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Page_Keyword" runat="server" Width="450" MaxLength="250"  CssClass="txt_input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Description
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Page_Description" runat="server" Width="450" MaxLength="1000"
                            Rows="5" TextMode="MultiLine" Wrap="False"  CssClass="txt_input"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</div>
<div class="Panel_More_options">
    <asp:CollapsiblePanelExtender ID="cpe" runat="server" TargetControlID="Panel_OptionContent"
        ExpandControlID="Panel_OptionTitle" CollapseControlID="Panel_OptionTitle" Collapsed="True"
        TextLabelID="lbl_MoreOptions" ExpandedText="More options" CollapsedText="More options"
        ImageControlID="Img_MoreOptions" ExpandedImage="/App_Control_Style/NexusCore/images/collapse.jpg"
        CollapsedImage="/App_Control_Style/NexusCore/images/expand.jpg" SuppressPostBack="true"  >
    </asp:CollapsiblePanelExtender>
    <asp:Panel ID="Panel_OptionTitle" runat="server" CssClass="collapsePanelHeader">
        <h2>
            <asp:Label ID="lbl_MoreOptions" runat="server">More options </asp:Label>
            <asp:Image ID="Img_MoreOptions" runat="server" ImageUrl="/App_Control_Style/NexusCore/images/expand.jpg" />
        </h2>
    </asp:Panel>
    <asp:Panel ID="Panel_OptionContent" runat="server" CssClass="collapsePanel">
        <div class="Panel_Page_Templates">
            <asp:Panel ID="Panel_Page_Templates" runat="server">
                <h3>
                    Page_Template</h3>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Inherited Template
                        </th>
                        <td><div class="rbt_width">
                            <asp:RadioButtonList ID="rbtn_IsTemplate_Inherited" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="rbtn_IsTemplate_Inherited_SelectedIndexChanged">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList></div>
                        </td>
                    </tr>
                </table>
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
                                            OnSelectedIndexChanged="droplist_Template_SelectedIndexChanged"  CssClass="txt_input">
                                        </asp:DropDownList>
                                        <asp:FormView ID="FormView_Template" runat="server" DataSourceID="ObjectDataSource_Template" CssClass="txt_input">
                                            <ItemTemplate>   
                                                <img src='<%# Eval("MasterPage_PreviewURL")%>'/>
                                            </ItemTemplate>
                                        </asp:FormView>
                                        <asp:ObjectDataSource ID="ObjectDataSource_Template" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="sGet_Template_MasterPage_DropList" TypeName="Nexus.Core.Templates.MasterPageMgr">
                                            <SelectParameters>
                                                <asp:Parameter Name="SortOrder" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource></div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
        </div>

        <div class="Panel_Page_URLs">
            <asp:Panel ID="Panel_Page_URLs" runat="server">
                <h3>
                    Page URLs</h3>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Page name
                        </th>
                        <td>
                            <asp:TextBox ID="tbx_Page_Name" runat="server" Width="450" MaxLength="250" ReadOnly="True"  CssClass="txt_input"></asp:TextBox>
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
        <div class="Panel_Page_Securities">
            <asp:Panel ID="Panel_Page_Securities" runat="server">
                <h3>
                    Security</h3>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Inherited Page Privacy
                        </th>
                        <td><div class="rbt_width">
                            <asp:RadioButtonList ID="rbtn_IsPrivacy_Inherited" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Require SSL
                        </th>
                        <td><div class="rbt_width">
                            <asp:RadioButtonList ID="rbtn_IsSSL" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList></div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </asp:Panel>
</div>
<br class="clear" />
<div class="btn_Go_Right">
    <asp:Button ID="btn_UpdatePage" runat="server" Text="Update Properties" OnClick="btn_UpdatePage_Click" SkinID="btn_long"  />
</div>
