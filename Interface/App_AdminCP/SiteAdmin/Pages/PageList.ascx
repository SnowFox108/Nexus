<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageList.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageList" %>
<asp:ListView ID="ListView_Page_List" runat="server" 
    onpagepropertieschanging="ListView_Page_List_PagePropertiesChanging">
    <ItemTemplate>
        <tr>
            <td>
                <img src='<%# Eval("IconUrl") %>' />
            </td>
            <td>
                <asp:LinkButton ID="lbtn_Page_Name" runat="server" CommandArgument='<%# Eval("PageIndexID") %>'
                    OnCommand="lbtn_Edit_Command"><%# Eval("Page_Name")%></asp:LinkButton>
            </td>
            <td>
                <%# Eval("ChildrenCount")%>
            </td>
            <td>
                <asp:CheckBox ID="chkBox_OnMenu" runat="server" Enabled="False" Checked='<%# Eval("IsOnMenu")%>' />
            </td>
            <td>
                <asp:CheckBox ID="chkBox_OnNavigator" runat="server" Enabled="False" Checked='<%# Eval("IsOnNavigator")%>' />
            </td>
            <td>
                <asp:CheckBox ID="chkBox_IsTemplate" runat="server" Enabled="False" Checked='<%# Eval("IsTemplate_Inherited")%>' />
            </td>
            <td>
                <asp:CheckBox ID="chkBox_IsAttribute" runat="server" Enabled="False" Checked='<%# Eval("IsAttribute_Inherited")%>' />
            </td>
            <td>
                <asp:CheckBox ID="chkBox_IsPrivacy" runat="server" Enabled="False" Checked='<%# Eval("IsPrivacy_Inherited")%>' />
            </td>
            <td>
                <asp:CheckBox ID="chkBox_IsSSL" runat="server" Enabled="False" Checked='<%# Eval("IsSSL")%>' />
            </td>
            <td>
                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("PageIndexID") %>'
                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <table id="Table1" runat="server">
            <tr>
                <td>
                    No pages under this category.
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <LayoutTemplate>
        <table id="itemPlaceholderContainer" class="itemPlaceholderContainer" runat="server">
            <tr id="Tr1" runat="server">
                <th id="Th1" runat="server">
                </th>
                <th id="Th2" runat="server">
                    Page Name
                </th>
                <th id="Th3" runat="server">
                    Sub Pages
                </th>
                <th id="Th4" runat="server">
                    On Menu
                </th>
                <th id="Th5" runat="server">
                    On Navigator
                </th>
                <th id="Th6" runat="server">
                    Inherited Template
                </th>
                <th id="Th7" runat="server">
                    Inherited Attribute
                </th>
                <th id="Th8" runat="server">
                    Inherited Privacy
                </th>
                <th id="Th9" runat="server">
                    SSL
                </th>
                <th id="Th10" runat="server">
                    Actions
                </th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
<div align="right">
    <asp:DataPager ID="DataPager_Page_List" runat="server" 
        PagedControlID="ListView_Page_List" PageSize="15">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                ShowPreviousPageButton="False" ButtonCssClass="page_btn" />
            <asp:NumericPagerField CurrentPageLabelCssClass="current_pageNo" />
            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                ShowPreviousPageButton="False" ButtonCssClass="page_btn" />
        </Fields>
    </asp:DataPager>
</div>