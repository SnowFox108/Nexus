﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageVersion.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageVersion" %>
<div class="nexusCore_panel_pageVersion">
<h3>Page Version</h3>
<asp:ListView ID="ListView_PageVersion" runat="server" DataKeyNames="PageID" OnPagePropertiesChanging="ListView_PageVersion_PagePropertiesChanging">
    <ItemTemplate>
        <tr  class="nexusCore_itemPlaceholderContainer_row1">
            <td>
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Eval("IsActive") %>'
                    Enabled="false" />
            </td>
            <td>
                <%# Eval("Page_Version") %>
            </td>
            <td>
                <%# Eval("Create_Date") %>
            </td>
            <td>
                <%# Eval("LastUpdate_Date") %>
            </td>
            <td>
                <%# Nexus.Security.Users.UserMgr.Get_UserNameByID(Eval("LastUpdate_UserID").ToString()) %>
            </td>
            <td>
                <asp:LinkButton ID="lbtn_PageActive" runat="server" CommandArgument='<%# Eval("PageID") %>'
                    OnCommand="lbtn_PageActive_Command"  SkinID="e2CMS_LinkButton">Active</asp:LinkButton>
                <asp:HyperLink ID="hlink_PagePreview" runat="server" Target="PagePreview" NavigateUrl='<%# string.Format("/App_AdminCP/SiteAdmin/Pages/DesignPreview.aspx?PageIndexID={0}&PageID={1}", PageIndexID, Eval("PageID").ToString() ) %>'>Preview</asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>    
    <AlternatingItemTemplate>
        <tr  class="nexusCore_itemPlaceholderContainer_row2">
            <td>
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Eval("IsActive") %>'
                    Enabled="false" />
            </td>
            <td>
                <%# Eval("Page_Version") %>
            </td>
            <td>
                <%# Eval("Create_Date") %>
            </td>
            <td>
                <%# Eval("LastUpdate_Date") %>
            </td>
            <td>
                <%# Nexus.Security.Users.UserMgr.Get_UserNameByID(Eval("LastUpdate_UserID").ToString()) %>
            </td>
            <td>
                <asp:LinkButton ID="lbtn_PageActive" runat="server" CommandArgument='<%# Eval("PageID") %>'
                    OnCommand="lbtn_PageActive_Command" SkinID="e2CMS_LinkButton">Active</asp:LinkButton>
                <asp:HyperLink ID="hlink_PagePreview" runat="server" Target="PagePreview" NavigateUrl='<%# string.Format("/App_AdminCP/SiteAdmin/Pages/DesignPreview.aspx?PageIndexID={0}&PageID={1}", PageIndexID, Eval("PageID").ToString() ) %>'>Preview</asp:HyperLink>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table runat="server">
            <tr>
                <td>
                     <div class="nexusCore_error_message">No data was returned.</div>
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <LayoutTemplate>
        <table runat="server" width="100%">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" class="nexusCore_itemPlaceholderContainer">
                        <tr runat="server">
                            <th runat="server">
                                Active Status
                            </th>
                            <th runat="server">
                                Page Version
                            </th>
                            <th runat="server">
                                Create Date
                            </th>
                            <th runat="server">
                                Update Date
                            </th>
                            <th runat="server">
                                Update User
                            </th>
                            <th runat="server">
                                Actions
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>

<div class="nexusCore_pager">
<asp:DataPager ID="DataPager_PageVersion" runat="server" PagedControlID="ListView_PageVersion">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="nexusCore_page_btn" />
        <asp:NumericPagerField CurrentPageLabelCssClass="nexusCore_current_pageNo" />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" ButtonCssClass="nexusCore_page_btn" />
    </Fields>
</asp:DataPager>
</div>

</div>