<%@ Page Title="" Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Categories"
    StylesheetTheme="NexusCore" %>

<%@ Register Src="Modules/CategoryCommand.ascx" TagName="CategoryCommand" TagPrefix="nexus" %>
<%@ Register Src="Modules/CategoryCreate.ascx" TagName="CategoryCreate" TagPrefix="nexus" %>
<%@ Register Src="Modules/CategoryProperty.ascx" TagName="CategoryProperty" TagPrefix="nexus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>
    <div id="main">
        <div class="in">
        <div class="nexusCore_category_create">
            <asp:MultiView ID="MultiView_Category" runat="server">
                <asp:View ID="View_FirstPage" runat="server">
                    <asp:LinkButton ID="lbtn_CreateCategory" runat="server" OnClick="CategoryCommand_Menu_CreateCategoryClick" CssClass="nexusCore_link_createCategory"><h2>Create Category</h2></asp:LinkButton>
                </asp:View>
                <asp:View ID="View_ListCategory" runat="server">
                    <h3>
                        <asp:Label ID="lbl_Category_Name" runat="server"></asp:Label>
                    </h3>
                    <nexus:CategoryProperty ID="CategoryProperty_Modify" OnCategoryClick="CategoryProperty_Modify_CategoryClick"
                        runat="server" />
                    <asp:GridView ID="GridView_ComponentInCategory" runat="server" AutoGenerateColumns="False" SkinID="e2CMS_GridView">
                        <EmptyDataTemplate>
                           <div class="nexusCore_error_message"> There is no items in this Category.</div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Module_Name" HeaderText="Module" ReadOnly="True" SortExpression="Module_Name" />
                            <asp:BoundField DataField="Item_Name" HeaderText="Item Type" ReadOnly="True" SortExpression="Item_Name" />
                            <asp:BoundField DataField="Item_Count" HeaderText="Number of Item" ReadOnly="True"
                                SortExpression="Item_Count" />
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View_CreateCategory" runat="server">
                    <nexus:CategoryCreate ID="CategoryCreate_New" OnCreateCategoryClick="CategoryCreate_New_CreateCategoryClick"
                        runat="server" />
                </asp:View>
            </asp:MultiView>
            </div>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:Panel ID="Panel_CategoryMenu" runat="server" ScrollBars="Auto" CssClass="nexusCore_panel_cateogryMenu">
                <nexus:CategoryTree ID="CategoryTree_Menu" Root_CategoryID="-1" Enable_DragAndDrop="true"
                    Enable_CheckBox="false" OnCategorySelected="CategoryTree_Menu_CategorySelected"
                    runat="server" />
            </asp:Panel>
            <div class="nexusCore_categoryCommand">
            <nexus:CategoryCommand ID="CategoryCommand_Menu" OnCreateCategoryClick="CategoryCommand_Menu_CreateCategoryClick"
                OnDeleteCategoryClick="CategoryCommand_Menu_DeleteCategoryClick" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
