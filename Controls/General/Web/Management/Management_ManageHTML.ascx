<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_ManageHTML.ascx.cs"
    Inherits="Nexus.Controls.General.Management.ManageHTML" ClassName="Nexus.Controls.General.Management.Management_ManageHTML" %>
<table>
    <tr>
        <td width="250px" valign="top">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" Height="550px" ScrollBars="Auto"
                Width="250px" BorderStyle="Dashed" BorderWidth="1px">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="B1CD6348-796C-4E92-8C39-5CEF3D600B7C"
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
                        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
                        <nexus:CategoryTree ID="CategoryTree_MoveTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="B1CD6348-796C-4E92-8C39-5CEF3D600B7C"
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
            <asp:ListView ID="ListView_ItemList" runat="server" OnPagePropertiesChanging="ListView_ItemList_PagePropertiesChanging"
                OnItemDataBound="ListView_ItemList_ItemDataBound">
                <EmptyDataTemplate>
                    <table id="Table1" runat="server" style="background-color: #FFFFFF; border-collapse: collapse;
                        border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>
                                No items in this category.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" /><asp:HiddenField ID="Hidden_ItemID"
                                runat="server" Value='<%# Eval("HTMLID") %>' />
                        </td>
                        <td>
                            <%# Eval("Display_Name") %>
                        </td>
                        <td>
                            <%# Eval("Create_Date") %>
                        </td>
                        <td>
                            <%# Eval("LastUpdate_Date") %>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlink_Edit" runat="server">Edit</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" /><asp:HiddenField ID="Hidden_ItemID"
                                runat="server" Value='<%# Eval("HTMLID") %>' />
                        </td>
                        <td>
                            <%# Eval("Display_Name") %>
                        </td>
                        <td>
                            <%# Eval("Create_Date") %>
                        </td>
                        <td>
                            <%# Eval("LastUpdate_Date") %>
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
                        <tr id="Tr1" runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th id="Th1" runat="server">
                                <asp:CheckBox ID="chk_SelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="Chk_SelectAll_CheckedChanged" />
                            </th>
                            <th id="Th2" runat="server" width="200px">
                                Item Name
                            </th>
                            <th id="Th3" runat="server">
                                Create Date
                            </th>
                            <th id="Th4" runat="server">
                                Last Update Date
                            </th>
                            <th id="Th5" runat="server">
                                Actions
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <asp:DataPager ID="DataPager_ItemList" runat="server" PagedControlID="ListView_ItemList"
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
