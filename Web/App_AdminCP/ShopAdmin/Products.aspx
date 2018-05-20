<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products" 
    Title="Shop Control Panel - Products" StylesheetTheme="NexusShop" %>

<%@ Register src="Products/ProductCreate.ascx" tagname="ProductCreate" tagprefix="nexus" %>
<%@ Register src="Products/ProductList.ascx" tagname="ProductList" tagprefix="nexus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:radwindowmanager id="RadWindowManager1" runat="server" destroyonclose="True">
    </telerik:radwindowmanager>
    <div id="main">
        <div class="in">
            <asp:MultiView ID="MultiView_Product" runat="server">
                <asp:View ID="View_Product_List" runat="server">
                    <div class="nexusCore_product_list">
                        <h3>
                            <asp:Label ID="lbl_Category_Name" runat="server"></asp:Label>
                        </h3>
                        <nexus:ProductList ID="ProductList_List" OnCategoryRefreshed="ProductList_List_CategoryRefreshed"
                            runat="server" />
                    </div>
                </asp:View>
                <asp:View ID="View_Product_Create" runat="server">
                    <div class="nexusCore_product_create">
                        <nexus:ProductCreate ID="ProductCreate_Create" OnCategoryRefreshed="ProductList_List_CategoryRefreshed"
                            runat="server" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" ScrollBars="Auto" CssClass="nexusCore_panel_cateogryMenu">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="true"
                    Enable_CheckBox="false" OnCategorySelected="CategoryTree_Menu_CategorySelected"
                    Module_ItemID="B131F545-F494-447E-8B55-9F24AFADC417" runat="server" />
            </asp:Panel>
            <div class="nexusCore_productCommand">
                <asp:Button ID="btn_Create_Product" runat="server" Text="Create a Product" CssClass="nexusCore_createProduct_btn"
                    SkinID="e2CMS_Button" onclick="btn_Create_Product_Click" /><br />
            </div>
        </div>
    </div>
</asp:Content>
