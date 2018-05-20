<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_ManageItems.ascx.cs"
    Inherits="Nexus.Controls.Gallery.Management.ManageItems" ClassName="Nexus.Controls.Gallery.Management.Management_ManageItems" %>
<table>
    <tr>
        <td width="250px" valign="top">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" Height="550px" ScrollBars="Auto"
                Width="250px" BorderStyle="Dashed" BorderWidth="1px">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="false"
                    Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="9473F482-CC30-4963-946A-28CA4AD44041"
                    OnCategorySelected="CategoryTree_Menu_CategorySelected" runat="server" />
            </asp:Panel>
        </td>
        <td align="left" valign="top">
            <telerik:RadTabStrip ID="RadTabStrip_Commands" runat="server" Skin="Black" MultiPageID="RadMultiPage_Actions">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Add Photo" Value="AddSingle">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Add Photos" Value="AddMulti">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Move" Value="Move">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Copy" Value="Copy">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="(In)Active" Value="IsActive">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage_Actions" runat="server">
                <telerik:RadPageView ID="RadPageView_AddSingle" runat="server" Width="100%">
                    Image Type
                    <asp:DropDownList ID="droplist_ImageType" runat="server" ValidationGroup="Add_Photo">
                    </asp:DropDownList>
                    <br />
                    Image URL
                    <asp:TextBox ID="tbx_ImageURL" runat="server" Width="350px" ValidationGroup="Add_Photo"
                        MaxLength="400"></asp:TextBox>
                    <asp:Button ID="btn_FileSelector" runat="server" ToolTip="Select a image file" Text="Select Image"
                        OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_ImageURL&FileTypes=Images'); return false;" />
                    <br />
                    <asp:Button ID="btn_AddSingle" runat="server" Text="Add Photo" OnClick="btn_AddSingle_Click"
                        ValidationGroup="Add_Photo" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_ImageURL" runat="server" ErrorMessage="Please enter a Image URL"
                        ControlToValidate="tbx_ImageURL" ValidationGroup="Add_Photo"></asp:RequiredFieldValidator>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView_AddMulti" runat="server" Width="100%">
                    Folder Path
                    <asp:TextBox ID="tbx_FolderURL" runat="server" Width="350px" ValidationGroup="Add_Photos"></asp:TextBox>
                    <asp:Button ID="btn_SelectFolder" runat="server" OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_DirSelector.aspx?ControlID=tbx_FolderURL&FileTypes=Images'); return false;"
                        Text="Select Folder" CausesValidation="False" ValidationGroup="Add_Photos" />
                    <br />
                    <asp:Button ID="btn_RefreshFolder" runat="server" Text="Refresh Folder" OnClick="btn_RefreshFolder_Click"
                        ValidationGroup="Add_Photos" />
                    &nbsp;<asp:Button ID="btn_AddMulti" runat="server" Text="Add Photos" OnClick="btn_AddMulti_Click"
                        ValidationGroup="Add_Photos" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_FolderURL" runat="server"
                        ErrorMessage="Please enter a Folder Path" ControlToValidate="tbx_FolderURL" ValidationGroup="Add_Photos"></asp:RequiredFieldValidator>
                    <asp:ListView ID="ListView_ImageFolder" runat="server" OnPagePropertiesChanging="ListView_ImageFolder_PagePropertiesChanging"
                        GroupItemCount="5">
                        <ItemTemplate>
                            <td id="Td1" runat="server" valign="top">
                                <asp:CheckBox ID="chk_Selected" runat="server" /><br />
                                <asp:HiddenField ID="Hidden_PhotoTitle" Value='<%# Eval("Photo_Title") %>' runat="server" />
                                <asp:HiddenField ID="Hidden_ImageURL" Value='<%# Eval("ImageURL") %>' runat="server" />
                                <img alt='<%# Eval("Photo_Title") %>' src='<%# Eval("ImageURL") %>' title='<%# Eval("Photo_Title") %>'
                                    width="100px" />
                            </td>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="">
                                <tr>
                                    <td>
                                        There is no image under this folder.
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <th runat="server" align="left">
                                        <asp:CheckBox ID="chk_SelectAll_Folder" runat="server" AutoPostBack="True" OnCheckedChanged="Chk_SelectAll_Folder_CheckedChanged" />
                                        Select All
                                    </th>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                                            <tr id="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                    <asp:DataPager ID="DataPager_ImageFolder" runat="server" PagedControlID="ListView_ImageFolder"
                        PageSize="15">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                                ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </telerik:RadPageView>
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
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="9473F482-CC30-4963-946A-28CA4AD44041"
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
                            Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="9473F482-CC30-4963-946A-28CA4AD44041"
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
            <asp:ListView ID="ListView_ItemList" runat="server" OnPagePropertiesChanging="ListView_ItemList_PagePropertiesChanging"
                OnItemDataBound="ListView_ItemList_ItemDataBound">
                <EmptyDataTemplate>
                    <table id="Table1" runat="server" style="background-color: #FFFFFF; border-collapse: collapse;
                        border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>
                                No photos in this category.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" />
                            <asp:HiddenField ID="Hidden_ItemID" runat="server" Value='<%# Eval("PhotoID") %>' />
                            <asp:HiddenField ID="Hidden_Item_MapID" runat="server" Value='<%# Eval("Item_MapID") %>' />
                        </td>
                        <th rowspan="2">
                            <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("ImageURL") %>' Width="100px"
                                runat="server" />
                        </th>
                        <td>
                            <%# Eval("View_Count")%>
                        </td>
                        <td>
                            <%# Eval("IsActive") %>
                        </td>
                        <td>
                            <%# Eval("Create_Date") %>
                        </td>
                        <td>
                            <%# Eval("LastUpdate_Date") %>
                        </td>
                        <td>
                            <p>
                                <asp:HyperLink ID="hlink_Edit" runat="server" ToolTip="Edit local information">Edit</asp:HyperLink></p>
                            <p>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("Item_MapID") %>'
                                    OnCommand="lbtn_Delete_Command" ToolTip="Delete Photo">Delete</asp:LinkButton>
                            </p>
                        </td>
                    </tr>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                        </td>
                        <td colspan="5">
                            <b>Title:</b>
                            <%# Eval("Photo_Title") %>
                            <br />
                            <b>URL:</b>
                            <asp:TextBox ID="tbx_ImageURL" runat="server" Width="480px" ReadOnly="True" Text='<%# Eval("ImageURL") %>'></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:CheckBox ID="chk_Selected" runat="server" />
                            <asp:HiddenField ID="Hidden_ItemID" runat="server" Value='<%# Eval("PhotoID") %>' />
                            <asp:HiddenField ID="Hidden_Item_MapID" runat="server" Value='<%# Eval("Item_MapID") %>' />
                        </td>
                        <th rowspan="2">
                            <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("ImageURL") %>' Width="100px"
                                runat="server" />
                        </th>
                        <td>
                            <%# Eval("View_Count")%>
                        </td>
                        <td>
                            <%# Eval("IsActive") %>
                        </td>
                        <td>
                            <%# Eval("Create_Date") %>
                        </td>
                        <td>
                            <%# Eval("LastUpdate_Date") %>
                        </td>
                        <td>
                            <p>
                                <asp:HyperLink ID="hlink_Edit" runat="server" ToolTip="Edit local information">Edit</asp:HyperLink></p>
                            <p>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("Item_MapID") %>'
                                    OnCommand="lbtn_Delete_Command" ToolTip="Delete Photo">Delete</asp:LinkButton>
                            </p>
                        </td>
                    </tr>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                        </td>
                        <td colspan="5">
                            <b>Title:</b>
                            <%# Eval("Photo_Title") %>
                            <br />
                            <b>URL:</b>
                            <asp:TextBox ID="tbx_ImageURL" runat="server" Width="480px" ReadOnly="True" Text='<%# Eval("ImageURL") %>'></asp:TextBox>
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
                                Image
                            </th>
                            <th id="Th3" runat="server">
                                View Count
                            </th>
                            <th id="Th4" runat="server">
                                Active Stauts
                            </th>
                            <th id="Th5" runat="server">
                                Create Date
                            </th>
                            <th id="Th6" runat="server">
                                Last Update Date
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
            <asp:DataPager ID="DataPager_ItemList" runat="server" PagedControlID="ListView_ItemList">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                        ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </td>
    </tr>
</table>
