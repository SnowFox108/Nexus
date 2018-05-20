<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductList.ascx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductList" %>
<telerik:radtabstrip id="RadTabStrip_Commands" runat="server" skin="WebBlue" multipageid="RadMultiPage_Actions">
    <Tabs>
        <telerik:RadTab runat="server" Text="Search" Value="AddSingle">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Filter & Sort" Value="AddSingle">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Move" Value="Move">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Copy" Value="Copy">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="(In)Active" Value="IsActive">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Close" Value="Close">
        </telerik:RadTab>
    </Tabs>
</telerik:radtabstrip>
<telerik:radmultipage id="RadMultiPage_Actions" runat="server">
    <telerik:RadPageView ID="RadPageView_Search" runat="server">
        <table class="form">
            <tr>
                <th>
                    Product SKU
                </th>
                <td>
                    <asp:TextBox ID="tbx_Search_Product_SKU" runat="server" Width="395px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_Search_Product_SKU" runat="server" Text="Search" 
                        onclick="btn_Search_Product_SKU_Click" SkinID="e2CMS_Button"></asp:Button>
                </td>
            </tr>
            <tr>
                <th>
                    Manufacturer SKU
                </th>
                <td>
                    <asp:TextBox ID="tbx_Search_Manufacturer_SKU" runat="server" Width="395px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_Search_Manufacturer_SKU" runat="server" Text="Search" 
                        onclick="btn_Search_Manufacturer_SKU_Click" SkinID="e2CMS_Button"></asp:Button>
                </td>
            </tr>
            <tr>
                <th>
                    Product Title
                </th>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList_TitleType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Title">Index Title</asp:ListItem>
                        <asp:ListItem Selected="True" Value="Product_Title">Product Title</asp:ListItem>
                        <asp:ListItem Value="Both_Title">Both</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="tbx_Search_Product_Title" runat="server" Width="395px"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <asp:Button ID="btn_Search_Product_Title" runat="server" Text="Search" 
                        onclick="btn_Search_Product_Title_Click" SkinID="e2CMS_Button"></asp:Button>
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView ID="RadPageView_Filter" runat="server">
        <table class="form">
            <tr>
                <th>
                    Filter
                </th>
                <td>
                    <table>
                        <tr>
                            <td>
                                Product Variant
                            </td>
                            <td>
                                <asp:DropDownList ID="droplist_Filter_Product_Variant" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Manufacturer
                            </td>
                            <td>
                                <asp:DropDownList ID="droplist_Filter_Manufacturer" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Active Status
                            </td>
                            <td>
                                <asp:DropDownList ID="droplist_Filter_IsActive" runat="server" Width="200px">
                                    <asp:ListItem Value="ALL">Both</asp:ListItem>
                                    <asp:ListItem Value="True">Active</asp:ListItem>
                                    <asp:ListItem Value="False">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th>
                    Sort Order
                </th>
                <td>
                    <table>
                        <tr>
                            <td>
                                Sort By
                            </td>
                            <td>
                                <asp:DropDownList ID="droplist_Filter_SortOrder" runat="server" Width="200px">
                                    <asp:ListItem Value="Title">Product Index Title</asp:ListItem>
                                    <asp:ListItem Value="Product_Title">Product Title</asp:ListItem>
                                    <asp:ListItem Value="Variant_Name">Product Variant Name</asp:ListItem>
                                    <asp:ListItem Value="Product_SKU">Product SKU</asp:ListItem>
                                    <asp:ListItem Value="Manufacturer_SKU">Manufacturer SKU</asp:ListItem>
                                    <asp:ListItem Value="Manufacturer_Name">Manufacturer Name</asp:ListItem>
                                    <asp:ListItem Value="RRP_Price">RRP Price</asp:ListItem>
                                    <asp:ListItem Value="Currency_Name">Currency Name</asp:ListItem>
                                    <asp:ListItem Value="Currency_ShortName">Currency Short Name</asp:ListItem>
                                    <asp:ListItem Value="LastUpdate_Date">Last Update Date</asp:ListItem>
                                    <asp:ListItem Value="UserName">Last Update User Name</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Direction
                            </td>
                            <td>
                                <asp:DropDownList ID="droplist_Filter_Direction" runat="server" Width="200px">
                                    <asp:ListItem Value="ASC">Ascending</asp:ListItem>
                                    <asp:ListItem Value="DESC">Descending</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btn_Search_Filter" runat="server" Text="Apply Filter" 
                        onclick="btn_Search_Filter_Click" SkinID="e2CMS_Button"></asp:Button>
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView ID="RadPageView_Move" runat="server">
        Move item(s) to following category:
        <asp:CustomValidator ID="CustomValidator_Category_Move" runat="server" ControlToValidate="tbx_Dump"
            ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_Move_ServerValidate"
            ValidationGroup="Item_Move"></asp:CustomValidator>
        <asp:TextBox ID="tbx_Dump" runat="server" Enabled="False" Height="1px" ValidationGroup="Item_Move"
            Visible="False" Text="validate" Width="1px"></asp:TextBox>
        <br />
        <asp:Panel ID="Panel_CategoryMoveTo" runat="server" Height="150px" ScrollBars="Auto"
            Width="350px" BorderStyle="Dashed" BorderWidth="1px">
            <nexus:CategoryTree ID="CategoryTree_MoveTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="B131F545-F494-447E-8B55-9F24AFADC417"
                runat="server" />
        </asp:Panel>
        <asp:Button ID="btn_Move" runat="server" Text="Confirm to Move" OnClick="btn_Move_Click"
            ValidationGroup="Item_Move" SkinID="e2CMS_Button" />
    </telerik:RadPageView>
    <telerik:RadPageView ID="RadPageView_Copy" runat="server">
        Copy item(s) to following category:
        <asp:CustomValidator ID="CustomValidator_Category_Copy" runat="server" ControlToValidate="tbx_Dump_Copy"
            ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_Copy_ServerValidate"
            ValidationGroup="Item_Copy"></asp:CustomValidator>
        <asp:TextBox ID="tbx_Dump_Copy" runat="server" Enabled="False" Height="1px" ValidationGroup="Item_Copy"
            Visible="False" Text="validate" Width="1px"></asp:TextBox>
        <br />
        <asp:Panel ID="Panel_CategoryCopyTo" runat="server" Height="150px" ScrollBars="Auto"
            Width="350px" BorderStyle="Dashed" BorderWidth="1px">
            <nexus:CategoryTree ID="CategoryTree_CopyTo" Root_CategoryID="-1" Enable_DragAndDrop="false"
                Enable_CheckBox="false" Enable_HomeRoot="false" Module_ItemID="B131F545-F494-447E-8B55-9F24AFADC417"
                runat="server" />
        </asp:Panel>
        <asp:Button ID="btn_Copy" runat="server" Text="Confirm to Copy" OnClick="btn_Copy_Click"
            ValidationGroup="Item_Copy" SkinID="e2CMS_Button" />
    </telerik:RadPageView>
    <telerik:RadPageView ID="RadPageView_Delete" runat="server">
        <p>
            Change item(s) list status to</p>
        <asp:RadioButtonList ID="rbtn_IsActive" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="True">Active</asp:ListItem>
            <asp:ListItem Value="false">Inactive</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btn_IsActive" runat="server" 
        Text="Confirm to Change Status" OnClick="btn_IsActive_Click" 
        SkinID="e2CMS_Button" />
    </telerik:RadPageView>
    <telerik:RadPageView ID="RadPageView_Close" runat="server">
    </telerik:RadPageView>
</telerik:radmultipage>
<asp:ListView ID="ListView_Product_List" runat="server" 
    onitemdatabound="ListView_Product_List_ItemDataBound" 
    onpagepropertieschanging="ListView_Product_List_PagePropertiesChanging" 
    DataKeyNames="ProductID,Product_MappingID">
    <EmptyDataTemplate>
        <div class="nexusCore_error_message">
            There are no products under this category.
        </div>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:CheckBox ID="chk_Selected" runat="server" />
            </td>
            <td>
                <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("Default_PhotoURL") %>' Width="80px"
                    runat="server" />
            </td>
            <td>
                <%# Eval("Product_SKU") %>
            </td>
            <td>
                <%# Eval("Product_Full_Title")%>
            </td>
            <td>
                <%# Eval("Currency_WebCode")%>
                <%# Eval("RRP_Price")%>
            </td>
            <td>
                <%# Eval("LastUpdate_Date")%>
            </td>
            <td>
                <%# Eval("UserName")%>
            </td>
            <td>
                <asp:CheckBox ID="chkbox_IsActive" Checked='<%# Eval("IsActive")%>' Enabled="false"
                    runat="server" />
            </td>
            <td>
                <asp:HyperLink ID="hlink_EditProduct" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="itemPlaceholderContainer" runat="server" class="nexusCore_itemPlaceholderContainer">
            <tr id="Tr1" runat="server">
                <th id="Th1" runat="server">
                    <asp:CheckBox ID="chkbox_SelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="Chk_SelectAll_CheckedChanged" />
                </th>
                <th id="Th2" runat="server">
                    Photo
                </th>
                <th id="Th3" runat="server">
                    Product SKU
                </th>
                <th id="Th4" runat="server">
                    Product Title
                </th>
                <th id="Th5" runat="server">
                    RRP Price
                </th>
                <th id="Th6" runat="server">
                    Last Update Date
                </th>
                <th id="Th7" runat="server">
                    Update User
                </th>
                <th id="Th8" runat="server">
                    Active Status
                </th>
                <th id="Th9" runat="server">
                    Actions
                </th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
<asp:DataPager ID="DataPager_Product_List" runat="server" PagedControlID="ListView_Product_List">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
