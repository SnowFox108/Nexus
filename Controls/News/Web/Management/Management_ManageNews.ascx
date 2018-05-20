<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_ManageNews.ascx.cs"
    Inherits="Nexus.Controls.News.Management.ManageNews" ClassName="Nexus.Controls.News.Management.Management_ManageNews" %>
<table>
    <tr>
        <td width="250px" valign="top">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" Height="550px" ScrollBars="Auto"
                Width="250px" BorderStyle="Dashed" BorderWidth="1px">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="3A79BF21-D0DF-4825-BFB2-7F6738C12BA7"
                    OnCategorySelected="CategoryTree_Menu_CategorySelected" runat="server" />
            </asp:Panel>
        </td>
        <td align="left" valign="top">
            <telerik:RadTabStrip ID="RadTabStrip_Commands" runat="server" Skin="Black" MultiPageID="RadMultiPage_Actions">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Move" Value="Move">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Delete" Value="Delete">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage_Actions" runat="server">
                <telerik:RadPageView ID="RadPageView_Move" runat="server">
                    Move to:
                    <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_Dump"
                        ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                        ValidationGroup="News_Move"></asp:CustomValidator>
                    <asp:TextBox ID="tbx_Dump" runat="server" Enabled="False" Height="1px" ValidationGroup="News_Move"
                        Visible="False" Text="validate" Width="1px"></asp:TextBox>
                    <br />
                    <asp:Panel ID="Panel_CategoryMoveTo" runat="server" Height="150px" ScrollBars="Auto"
                        Width="350px" BorderStyle="Dashed">
                        <nexus:CategoryTree ID="CategoryTree_MoveTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="3A79BF21-D0DF-4825-BFB2-7F6738C12BA7"
                            runat="server" />
                    </asp:Panel>
                    <asp:Button ID="btn_Move" runat="server" Text="Confirm to Move" OnClick="btn_Move_Click"
                        ValidationGroup="News_Move" />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView_Delete" runat="server">
                    <p>
                        This action can not be reverted, are you sure you want to continue?</p>
                    <asp:Button ID="btn_Delete" runat="server" Text="Confirm to Delete" OnClick="btn_Delete_Click" />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <asp:ListView ID="ListView_NewsList" runat="server" 
                OnPagePropertiesChanging="ListView_NewsList_PagePropertiesChanging" 
                onitemdatabound="ListView_NewsList_ItemDataBound">
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse;
                        border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>
                                No news in this category.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" /><asp:HiddenField ID="Hidden_NewsID"
                                runat="server" Value='<%# Eval("NewsID") %>' />
                        </td>
                        <td>
                            <%# Eval("NewsID") %>
                        </td>
                        <td>
                            <%# Eval("News_Title") %>
                        </td>
                        <td>
                            <%# Eval("UserName") %>
                        </td>
                        <td>
                            <%# Eval("News_Date") %>
                        </td>
                        <td>
                            <%# Eval("News_ModifyDate") %>
                        </td>
                        <td>
                            <%# Eval("News_Status") %>
                        </td>
                        <td>
                            <%# Eval("View_Count") %>
                        </td>
                        <td>
                            <%# Eval("Comment_Count") %>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlink_Edit" runat="server">Edit</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" /><asp:HiddenField ID="Hidden_NewsID"
                                runat="server" Value='<%# Eval("NewsID") %>' />
                        </td>
                        <td>
                            <%# Eval("NewsID") %>
                        </td>
                        <td>
                            <%# Eval("News_Title") %>
                        </td>
                        <td>
                            <%# Eval("UserName") %>
                        </td>
                        <td>
                            <%# Eval("News_Date") %>
                        </td>
                        <td>
                            <%# Eval("News_ModifyDate") %>
                        </td>
                        <td>
                            <%# Eval("News_Status") %>
                        </td>
                        <td>
                            <%# Eval("View_Count") %>
                        </td>
                        <td>
                            <%# Eval("Comment_Count") %>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlink_Edit" runat="server">Edit</asp:HyperLink>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <LayoutTemplate>
                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;
                        border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;
                        font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server">
                                <asp:CheckBox ID="chk_SelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="Chk_SelectAll_CheckedChanged" />
                            </th>
                            <th runat="server">
                                ID
                            </th>
                            <th runat="server">
                                Title
                            </th>
                            <th runat="server">
                                User
                            </th>
                            <th runat="server">
                                Publish Date
                            </th>
                            <th runat="server">
                                Last Modify
                            </th>
                            <th runat="server">
                                Status
                            </th>
                            <th runat="server">
                                Views
                            </th>
                            <th runat="server">
                                Comments
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
            <asp:DataPager ID="DataPager_NewsList" runat="server" PagedControlID="ListView_NewsList"
                PageSize="20">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </td>
    </tr>
</table>
