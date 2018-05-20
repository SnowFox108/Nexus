<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PageDesign.aspx.cs" Inherits="App_AdminCP_SiteAdmin_PageDesign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Page Design Mode</title>
</head>
<body class="bg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="nextusCore_header">
        <div class="nextusCore_logo">
                <img src="/App_Themes/NexusCore/CSS_images/logo.png" />
        </div>
        <div class="nextusCore_Publish_Bar">
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
                                                <img src='<%# Eval("MasterPage_PreviewURL")%>' width="150" />
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
                                <asp:Button ID="btn_SwitchTemplate" runat="server" Text="Change" OnClick="btn_SwitchTemplate_Click"/></span>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
   
                    <td colspan="4" align="left" style="border-top: 1px #fff dotted;">
                        <asp:Button ID="btn_Publish" runat="server" Text="Publish" OnCommand="btn_Publish_Command"/>
                        &nbsp; Save as draft&nbsp; 
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnCommand="btn_Cancel_Command"/>
                    </td>

                </tr>
            </table>
        </div>
    </div>
    <div class="nexusCore_Editor">
        <iframe id="iframe_PageEditor_Design" runat="server" frameborder="0"></iframe>
    </div>
    </form>
</body>
</html>
