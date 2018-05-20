<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Pages_Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="ctl00_Head1">
    <title></title>
    <link href="/App_Themes/NexusCore/Pages.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/default.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/global.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="nexusCorePop_wrapper">
    <div class="nexusCore_pages_MasterPage_List">
        <asp:ListView ID="ListView_MasterPage_List" runat="server" DataSourceID="ObjectDataSource_PageList">
            <ItemTemplate>
                <tr>
                    <td >
                        <img src='<%# Eval("IconUrl") %>' alt="Icon" />
                    </td>
                    <td style="text-align:left;">
                        <asp:LinkButton ID="lbtn_Menu_Title" runat="server" CommandArgument='<%# Eval("PageIndexID") %>'
                            OnCommand="lbtn_Edit_Command"><%# Eval("Menu_Title")%></asp:LinkButton>                        
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
                             <div class="nexusCore_error_message">No pages under this category.</div>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer" class="nexusCore_itemPlaceholderContainer" runat="server" >
                    <tr id="Tr1" runat="server">
                        <th id="Th1" runat="server">
                        </th>
                        <th id="Th2" runat="server">
                            Menu Title
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
        <div class="nexusCore_pager">
            <asp:DataPager ID="DataPager_TemplateList" runat="server" PagedControlID="ListView_MasterPage_List">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" ButtonCssClass="page_btn" />
                    <asp:NumericPagerField CurrentPageLabelCssClass="current_pageNo" />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" ButtonCssClass="page_btn" />
                </Fields>
            </asp:DataPager>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource_PageList" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="sGet_PageIndex_FullList" TypeName="Nexus.Core.Pages.PageMgr">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="Parent_PageIndexID" QueryStringField="PageIndexID"
                    Type="String" />
                <asp:Parameter DefaultValue="1,2" Name="CategoryIDs" Type="String" />
                <asp:Parameter DefaultValue="" Name="SortOrder" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </div>
    </form>
</body>
</html>
