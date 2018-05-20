<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductCreate.ascx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductCreate" %>
<asp:MultiView ID="MultiView_CreateProduct" runat="server">
    <asp:View ID="View_Variant_Select" runat="server">
        <div class="nexusCore_panel_productVariant">
            <h3>
                Choose a type of product</h3>
            <table>
                <tr>
                    <th>
                        Product Variant
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_Product_VariantID" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel_PageWizard" runat="server">
            <div class="nexusCore_panel_productIndexSelect">
                <h3>
                    Select a product index or choose create a new index</h3>
                <table>
                    <tr>
                        <th>
                            Filter
                        </th>
                        <td>
                            <asp:TextBox ID="tbx_Filter_ProductIndex_Title" runat="server" Width="195px"></asp:TextBox>
                            <asp:Button ID="btn_Search_ProductIndex_Title" runat="server" SkinID="e2CMS_Button"
                                Text="Search Title" OnClick="btn_Search_ProductIndex_Title_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Sort Order
                        </th>
                        <td>
                            <asp:DropDownList ID="droplist_Filter_OrderBy" runat="server" Width="200px">
                                <asp:ListItem Value="Title">Title</asp:ListItem>
                                <asp:ListItem Value="Product_Count">Product Count</asp:ListItem>
                                <asp:ListItem Value="Create_Date">Create Date</asp:ListItem>
                                <asp:ListItem Value="LastUpdate_Date">Last Update Date</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="droplist_Filter_Direction" runat="server" Width="200px">
                                <asp:ListItem Value="ASC">Ascending</asp:ListItem>
                                <asp:ListItem Value="DESC">Descending</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btn_Search_Filter" runat="server" Text="Apply Filter" SkinID="e2CMS_Button"
                                OnClick="btn_Search_Filter_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListView ID="ListView_ProductIndex_List" runat="server">
                                <EmptyDataTemplate>
                                    <div class="nexusCore_error_message">
                                        There are no products under this category.</div>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Title") %>
                                        </td>
                                        <td>
                                            <%# Eval("Product_Count") %>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkbox_IsActive" Checked='<%# Eval("IsActive")%>' Enabled="false"
                                                runat="server" />
                                        </td>
                                        <td>
                                            <%# Eval("Create_Date")%>
                                        </td>
                                        <td>
                                            <%# Eval("LastUpdate_Date")%>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtn_Select_ProductIndex" CommandArgument='<%# Eval("Product_IndexID")%>'
                                                runat="server" OnCommand="lbtn_Select_ProductIndex_Command">Select</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <table id="itemPlaceholderContainer" runat="server" class="nexusCore_itemPlaceholderContainer">
                                        <tr id="Tr1" runat="server">
                                            <th id="Th1" runat="server">
                                                Title
                                            </th>
                                            <th id="Th2" runat="server">
                                                Product Count
                                            </th>
                                            <th id="Th3" runat="server">
                                                Active Status
                                            </th>
                                            <th id="Th4" runat="server">
                                                Create Date
                                            </th>
                                            <th id="Th5" runat="server">
                                                Last Update Date
                                            </th>
                                            <th id="Th6" runat="server">
                                            </th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                            </asp:ListView>
                            <asp:DataPager ID="DataPager_ProductIndex_List" runat="server" PagedControlID="ListView_ProductIndex_List">
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
                    <tr>
                        <th>
                            Selected Product Index
                        </th>
                        <td>
                            <asp:Label ID="lbl_Selected_Product_Index" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Choose Product Index
                        </th>
                        <td>
                            <asp:RadioButtonList ID="rbtn_Product_Index_Method" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="CreateNew">Create a New Product Index</asp:ListItem>
                                <asp:ListItem Value="AddtoExist">Use Selected Product Index</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="nexusCore_btn_goRight">
                <asp:Button ID="btn_Step1_to_Step2" runat="server" Text="Next" SkinID="e2CMS_Button"
                    OnClick="btn_Step1_to_Step2_Click" />
            </div>
        </asp:Panel>
    </asp:View>
    <asp:View ID="View_ProductIndex_Create" runat="server">
        <div class="nexusCore_panel_productIndexCreate">
            <h3>
                Product Index
            </h3>
            <table>
                <tr>
                    <th>
                        Title
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Index_Title" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Index"
                            Width="195px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter a title."
                            ControlToValidate="tbx_Index_Title" ValidationGroup="ProductCreate_Index"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        Short Description
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Index_Short_Description" runat="server" Rows="5" TextMode="MultiLine"
                            Width="300px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Admin Comment
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Index_Admin_Comment" runat="server" Rows="5" TextMode="MultiLine"
                            Width="300px" ValidationGroup="ProductCreate_Index"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Active Status
                    </th>
                    <td>
                        <asp:CheckBox ID="chkbox_Index_IsActive" runat="server" Text="Active" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="nexusCore_btn_goRight">
            <asp:Button ID="btn_Step2_back_Step1" runat="server" Text="Previous" SkinID="e2CMS_Button"
                OnClick="btn_Step2_back_Step1_Click" CausesValidation="False" />
            <asp:Button ID="btn_Step2_to_Step3" runat="server" Text="Next" SkinID="e2CMS_Button"
                ValidationGroup="ProductCreate_Index" OnClick="btn_Step2_to_Step3_Click" />
        </div>
    </asp:View>
    <asp:View ID="View_Product_Create" runat="server">
        <div class="nexusCore_panel_productCreate">
            <h3>
                Product Infomation (Index Title:
                <asp:Label ID="lbl_Product_Index" runat="server"></asp:Label>)
            </h3>
            <table>
                <tr>
                    <th>
                        Title Format
                    </th>
                    <td>
                        <asp:RadioButtonList ID="rbtn_Product_Title_Type" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Product Title
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Product_Title" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                            Width="195px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Product_Title" runat="server"
                            ControlToValidate="tbx_Product_Title" ErrorMessage="Please enter a product title."
                            ValidationGroup="ProductCreate_Product"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th class="style1">
                        Product SKU
                    </th>
                    <td class="style1">
                        <asp:TextBox ID="tbx_Product_SKU" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                            Width="195px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Manufacturer
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_Product_ManufacturerID" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Manufacturer SKU
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Product_Manufacturer_SKU" runat="server" MaxLength="400" ValidationGroup="ProductCreate_Product"
                            Width="195px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Currency
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_Product_CurrencyID" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        RRP Price
                    </th>
                    <td>
                        <telerik:radnumerictextbox id="RadNumericTextBox_Product_RRP" runat="server" width="195px"
                            validationgroup="ProductCreate_Product" value="0">
                        </telerik:radnumerictextbox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Active Status
                    </th>
                    <td>
                        <asp:CheckBox ID="chkbox_Product_IsActive" runat="server" Text="Active" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="nexusCore_panel_productCreate">
            <h3>
                Product Specification
            </h3>
            <asp:PlaceHolder ID="PlaceHolder_Product_Spec" runat="server"></asp:PlaceHolder>
        </div>
        <div class="nexusCore_btn_goRight">
            <asp:Button ID="btn_Step3_back_Step2" runat="server" Text="Previous" SkinID="e2CMS_Button"
                OnClick="btn_Step3_back_Step2_Click" CausesValidation="False" />
            <asp:Button ID="btn_Finish" runat="server" Text="Create Product" SkinID="e2CMS_Button"
                ValidationGroup="ProductCreate_Product" OnClick="btn_Finish_Click" />
        </div>
    </asp:View>
    <asp:View ID="View_Product_Complete" runat="server">
        Product has been added to system.
    </asp:View>
</asp:MultiView>