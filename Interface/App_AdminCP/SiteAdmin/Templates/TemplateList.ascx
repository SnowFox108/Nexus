<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateList.ascx.cs"
    Inherits="App_AdminCP_SiteAdmin_Templates_TemplateList" %>
<asp:ListView ID="ListView_MasterPage_List" runat="server" DataSourceID="ObjectDataSource_MasterPage_List">
    <ItemTemplate>
        <tr>
            <td>
                <%# Eval("MasterPage_Name") %>
            </td>
            <td>
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
                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("MasterPageIndexID") %>'>Delete</asp:LinkButton>
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
            <table id="itemPlaceholderContainer" class="itemPlaceholderContainer" runat="server">
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
<div align="right">
<asp:DataPager ID="DataPager_TemplateList" runat="server" PagedControlID="ListView_MasterPage_List">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="page_btn"  />
        <asp:NumericPagerField CurrentPageLabelCssClass="current_pageNo" />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="page_btn" />
    </Fields>
</asp:DataPager></div>
<asp:ObjectDataSource ID="ObjectDataSource_MasterPage_List" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="sGet_Template_MasterPage_List" TypeName="Nexus.Core.Templates.MasterPageMgr">
    <SelectParameters>
        <asp:Parameter Name="SortOrder" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
