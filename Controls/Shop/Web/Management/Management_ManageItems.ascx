<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_ManageItems.ascx.cs"
    Inherits="Nexus.Controls.Ebay.Management.ManageItems" ClassName="Nexus.Controls.Ebay.Management.Management_ManageItems" %>
<table>
    <tr>
        <td width="250px" valign="top">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" Height="550px" ScrollBars="Auto"
                Width="250px" BorderStyle="Dashed" BorderWidth="1px">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6"
                    OnCategorySelected="CategoryTree_Menu_CategorySelected" runat="server" />
            </asp:Panel>
        </td>
        <td align="left" valign="top">
            <telerik:RadTabStrip ID="RadTabStrip_Commands" runat="server" Skin="Black" MultiPageID="RadMultiPage_Actions">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Move" Value="Move">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Copy" Value="Copy">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="(In)Active" Value="IsActive">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage_Actions" runat="server">
                <telerik:RadPageView ID="RadPageView_Move" runat="server">
                    Move item(s) to:
                    <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_Dump"
                        ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                        ValidationGroup="Item_Move"></asp:CustomValidator>
                    <asp:TextBox ID="tbx_Dump" runat="server" Enabled="False" Height="1px" ValidationGroup="Item_Move"
                        Visible="False" Text="validate" Width="1px"></asp:TextBox>
                    <br />
                    <asp:Panel ID="Panel_CategoryMoveTo" runat="server" Height="150px" ScrollBars="Auto"
                        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
                        <nexus:CategoryTree ID="CategoryTree_MoveTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6"
                            runat="server" />
                    </asp:Panel>
                    <asp:Button ID="btn_Move" runat="server" Text="Confirm to Move" OnClick="btn_Move_Click"
                        ValidationGroup="Item_Move" />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView_Copy" runat="server">
                    Copy item(s) to (This usually for promotion):
                    <asp:CustomValidator ID="CustomValidator_Category_Copy" runat="server" ControlToValidate="tbx_Dump_Copy"
                        ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_Copy_ServerValidate"
                        ValidationGroup="Item_Copy"></asp:CustomValidator>
                    <asp:TextBox ID="tbx_Dump_Copy" runat="server" Enabled="False" Height="1px" ValidationGroup="Item_Copy"
                        Visible="False" Text="validate" Width="1px"></asp:TextBox>
                    <br />
                    <asp:Panel ID="Panel_CategoryCopyTo" runat="server" Height="150px" ScrollBars="Auto"
                        Width="350px" BorderStyle="Dashed" BorderWidth="1px">
                        <nexus:CategoryTree ID="CategoryTree_CopyTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6"
                            runat="server" />
                    </asp:Panel>
                    <asp:Button ID="btn_Copy" runat="server" Text="Confirm to Copy" OnClick="btn_Copy_Click"
                        ValidationGroup="Item_Copy" />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView_Delete" runat="server">
                    <p>
                        Change item(s) list status to</p>
                    <asp:RadioButtonList ID="rbtn_IsActive" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="True">Active</asp:ListItem>
                        <asp:ListItem Value="false">Inactive</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="btn_IsActive" runat="server" Text="Confirm to Change Status" OnClick="btn_IsActive_Click" />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
                            <asp:UpdatePanel ID="UpdatePanel_Update" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ListView_ItemList" 
                                        EventName="ItemCommand" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:UpdateProgress ID="UpdateProgress_UpdateAlt" runat="server">
                                        <ProgressTemplate>
                                            <img src="/App_Control_Style/Nexus_Ebay/Images/progressBar.gif" alt="updating..." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
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
                            <asp:CheckBox ID="chk_Selected" runat="server" />
                            <asp:HiddenField ID="Hidden_ItemID" runat="server" Value='<%# Eval("Ebay_ItemID") %>' />
                            <asp:HiddenField ID="Hidden_Item_MapID" runat="server" Value='<%# Eval("Item_MapID") %>' />
                        </td>
                        <th rowspan="2">
                            <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("Ebay_Gallery") %>' Width="64px" runat="server" />
                        </th>
                        <td colspan="9">
                            [ID: <%# Eval("Ebay_ItemID") %> ] <b><%# Eval("Ebay_Title") %></b><br />
                            <%# Eval("Ebay_SubTitle") %>
                        </td>
                        <td rowspan="2">
                                <asp:LinkButton ID="lbtn_Update" runat="server" CommandArgument='<%# Eval("Ebay_ItemID") %>'
                                    OnCommand="lbtn_Update_Command" ToolTip="Update data from Ebay">Update</asp:LinkButton>
                                <p>
                                    <asp:HyperLink ID="hlink_Edit" runat="server" ToolTip="Edit local information">Edit</asp:HyperLink></p>
                        </td>
                    </tr>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                        </td>
                        <td>
                            <%# Eval("Currency_Web") %><%# Eval("CurrentPrice") %>
                        </td>
                        <td>
                            <%# Eval("StartTime") %>
                        </td>
                        <td>
                            <%# Eval("EndTime") %>
                        </td>
                        <td>
                            <%# Eval("HitCount") %>
                        </td>
                        <td>
                            <%# Eval("View_Count")%>
                        </td>
                        <td>
                            <%# Eval("IsActive") %>
                        </td>
                        <td>
                            <%# Eval("IsSync") %>
                        </td>
                        <td>
                            <%# Eval("LastSync_Date") %>
                        </td>
                        <td>
                            <%# Eval("Ebay_ListType")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" />
                            <asp:HiddenField ID="Hidden_ItemID" runat="server" Value='<%# Eval("Ebay_ItemID") %>' />
                            <asp:HiddenField ID="Hidden_Item_MapID" runat="server" Value='<%# Eval("Item_MapID") %>' />
                        </td>
                        <th rowspan="2">
                            <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("Ebay_Gallery") %>' Width="64px" runat="server" />
                        </th>
                        <td colspan="9">
                            [ID: <%# Eval("Ebay_ItemID") %> ] <b><%# Eval("Ebay_Title") %></b><br />
                            <%# Eval("Ebay_SubTitle") %>
                        </td>
                        <td rowspan="2">
                                    <asp:LinkButton ID="lbtn_Update" runat="server" CommandArgument='<%# Eval("Ebay_ItemID") %>'
                                        OnCommand="lbtn_Update_Command" ToolTip="Update data from Ebay">Update</asp:LinkButton>
                            <p><asp:HyperLink ID="hlink_Edit" runat="server" ToolTip="Edit local information" >Edit</asp:HyperLink></p>
                        </td>
                    </tr>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                        </td>
                        <td>
                            <%# Eval("Currency_Web") %><%# Eval("CurrentPrice") %>
                        </td>
                        <td>
                            <%# Eval("StartTime") %>
                        </td>
                        <td>
                            <%# Eval("EndTime") %>
                        </td>
                        <td>
                            <%# Eval("HitCount") %>
                        </td>
                        <td>
                            <%# Eval("View_Count")%>
                        </td>
                        <td>
                            <%# Eval("IsActive") %>
                        </td>
                        <td>
                            <%# Eval("IsSync") %>
                        </td>
                        <td>
                            <%# Eval("LastSync_Date") %>
                        </td>
                        <td>
                            <%# Eval("Ebay_ListType")%>
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
                            <th id="Th2" runat="server">
                                Product
                            </th>
                            <th id="Th3" runat="server">
                                Price
                            </th>
                            <th id="Th4" runat="server">
                                Start Time
                            </th>
                            <th id="Th5" runat="server">
                                Ending Time
                            </th>
                            <th id="Th6" runat="server">
                                Ebay View Count
                            </th>
                            <th id="Th7" runat="server">
                                Website View Count
                            </th>
                            <th id="Th8" runat="server">
                                Active Stauts
                            </th>
                            <th id="Th9" runat="server">
                                Sync with Ebay
                            </th>
                            <th id="Th10" runat="server">
                                Last Update Date
                            </th>
                            <th id="Th11" runat="server">
                                Ebay Category
                            </th>
                            <th id="Th12" runat="server">
                                Actions
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

            <asp:DataPager ID="DataPager_ItemList" runat="server" PagedControlID="ListView_ItemList"
                PageSize="10">
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
