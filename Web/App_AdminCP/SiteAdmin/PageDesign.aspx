<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PageDesign.aspx.cs"
    Inherits="App_AdminCP_SiteAdmin_PageDesign" StylesheetTheme="NexusCore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Page Design Mode</title>
</head>
<body class="nexusCore_bg">
    <form id="form1" runat="server" style="height:100%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="nexusCore_wrapper">
        <div id="pageDesign_header">
            <div class="nexusCore_logo">
                <img src="/App_Themes/NexusCore/CSS_images/logo.png" alt="" />
                <asp:Label ID="lbl_Version" runat="server"></asp:Label>                
            </div>
            <div class="nexusCore_publish_bar">
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
                        <th>
                            Template
                        </th>
                        <td>
                            <asp:Panel ID="Panel_Template" runat="server">
                                <span>
                                    <asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadComboBox ID="RadComboBox_Template" runat="server" DataSourceID="ObjectDataSource_Template"
                                                DataTextField="MasterPage_Name" DataValueField="MasterPageIndexID" EnableVirtualScrolling="True"
                                                Height="300px">
                                                <ItemTemplate>
                                                    <img src='<%# Eval("MasterPage_PreviewURL")%>' alt='<%# Eval("MasterPage_Name")%>'
                                                        width="150" />
                                                    <%# Eval("MasterPage_Name")%>
                                                </ItemTemplate>
                                            </telerik:RadComboBox>
                                            <asp:ObjectDataSource ID="ObjectDataSource_Template" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="sGet_Template_MasterPage_DropList" TypeName="Nexus.Core.Templates.MasterPageMgr">
                                                <SelectParameters>
                                                    <asp:Parameter Name="SortOrder" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </span><span>
                                    <asp:Button ID="btn_SwitchTemplate" runat="server" Text="Change" OnClick="btn_SwitchTemplate_Click"
                                        SkinID="e2CMS_Button" /></span>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left" style="border-top: 1px #fff dotted; padding: 10px 0 0 5px;">
                            <asp:Button ID="btn_Publish" runat="server" Text="Publish" OnCommand="btn_Publish_Command"
                                SkinID="e2CMS_Button" />
                            &nbsp; Save as draft&nbsp;
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnCommand="btn_Cancel_Command"
                                SkinID="e2CMS_Button" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="pageDesign_mainWrapper">
            <div id="single">
                <iframe id="iframe_PageEditor_Design" runat="server" frameborder="0"></iframe>
            </div>
        </div>
        c
    </div>
    d
    </form>
</body>
</html>


 
