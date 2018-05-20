<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateList.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateList" %>
<asp:ListView ID="ListView_MasterPage_List" runat="server" 
    onpagepropertieschanging="ListView_MasterPage_List_PagePropertiesChanging">
    <ItemTemplate>
        <tr>
            <td style="text-align:left;">
                <%# Eval("MasterPage_Name") %>
            </td>
            <td style="text-align:left;">
                <%# Eval("MasterPage_Template_Name") %>
            </td>
            <td>
                <%# Eval("Theme_Name") %>
            </td>
            <td>
                <%# Eval("MasterPage_Version") %>
            </td>
            <td>
                <%# Eval("UsageCount") %>
            </td>
            <td>
                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("MasterPageIndexID") %>'
                    OnCommand="lbtn_Edit_Command" SkinID="e2CMS_LinkButton">Edit</asp:LinkButton>
                <asp:LinkButton ID="lbtn_Duplicate" runat="server" CommandArgument='<%# Eval("MasterPageIndexID") %>'
                    OnCommand="lbtn_Duplicate_Command" SkinID="e2CMS_LinkButton">Duplicate</asp:LinkButton>
                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("MasterPageIndexID") %>'
                    SkinID="e2CMS_LinkButton" Enabled="false">Delete</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" >
            <tr>
                <td>
                    No data was returned.
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <LayoutTemplate>
            <table id="itemPlaceholderContainer" class="nexusCore_itemPlaceholderContainer" runat="server">
                <tr runat="server">
                    <th runat="server">
                        MasterPage Name
                    </th>
                    <th runat="server">
                        Template Name
                    </th>
                    <th runat="server">
                        Theme Name
                    </th>
                    <th runat="server">
                        Template_Version
                    </th>
                    <th runat="server">
                        Usage Count
                    </th>
                    <th runat="server">
                        Actions
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
    </LayoutTemplate>
</asp:ListView>
<div class="nexusCore_pager">
<asp:DataPager ID="DataPager_TemplateList" runat="server" PagedControlID="ListView_MasterPage_List">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="nexusCore_page_btn"  />
        <asp:NumericPagerField CurrentPageLabelCssClass="nexusCore_current_pageNo" />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="nexusCore_page_btn" />
    </Fields>
</asp:DataPager></div>

