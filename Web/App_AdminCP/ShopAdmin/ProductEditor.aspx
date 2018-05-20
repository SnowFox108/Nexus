<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="ProductEditor.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_ProductEditor"
    Title="Shop Control Panel - Product Editor" StylesheetTheme="NexusShop" %>

<%@ Register src="Products/ProductIndex.ascx" tagname="ProductIndex" tagprefix="nexus" %>
<%@ Register src="Products/ProductInfo.ascx" tagname="ProductInfo" tagprefix="nexus" %>
<%@ Register src="Products/ProductCategory.ascx" tagname="ProductCategory" tagprefix="nexus" %>
<%@ Register src="Products/ProductAttribute.ascx" tagname="ProductAttribute" tagprefix="nexus" %>
<%@ Register src="Products/Webpage.ascx" tagname="Webpage" tagprefix="nexus" %>
<%@ Register src="Products/Webmedia.ascx" tagname="Webmedia" tagprefix="nexus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function Show_ControlManager(paraCommand) {
            var oWnd = window.radopen(paraCommand, "RadWindow_ControlManager");
            oWnd.add_close(OnClientClose);
        }

        function OnClientClose(oWnd) {
            oWnd.setUrl('about:blank'); // Sets url to blank 
            oWnd.remove_close(OnClientClose); //remove the close handler - it will be set again on the next opening 
        }

        function refreshControl(arg) {
            $find("<%= RadAjaxManager_ControlManager.ClientID %>").ajaxRequest(arg);
        }
    </script>
</telerik:RadCodeBlock>

    <telerik:radwindowmanager id="RadWindowManager1" runat="server" destroyonclose="True">
            <Windows>
                <telerik:RadWindow ID="RadWindow_ControlManager" runat="server"
                 Title="Module Control Manager"
                 ReloadOnShow="true" 
                 ShowContentDuringLoad="false"
                 Modal="true"
                 Animation ="Fade"
                 AutoSize="True"
                 Behaviors="Close, Maximize" 
                 InitialBehaviors="Resize"
                 KeepInScreenBounds="True"
                 VisibleStatusbar="False"
                 DestroyOnClose="False" />
            </Windows>     
    </telerik:radwindowmanager>
    <telerik:RadAjaxManager ID="RadAjaxManager_ControlManager" runat="server" 
        onajaxrequest="RadAjaxManager_AjaxRequest">
    </telerik:RadAjaxManager>

    <asp:UpdatePanel ID="UpdatePanel_Refresh" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="RadAjaxManager_ControlManager">
            </asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>

    <div id="main">
        <div class="in">
            <h3>
                <asp:Label ID="lbl_Product_Name" runat="server"></asp:Label>
            </h3>
            <asp:MultiView ID="MultiView_Product" runat="server">
                <asp:View ID="View_Index" runat="server">
                    <nexus:ProductIndex ID="ProductIndex_Editor" runat="server" />
                </asp:View>
                <asp:View ID="View_Info" runat="server">
                    <nexus:ProductInfo ID="ProductInfo_Editor" runat="server" />
                </asp:View>
                <asp:View ID="View_Category" runat="server">
                    <nexus:ProductCategory ID="ProductCategory_Editor" runat="server" />
                </asp:View>
                <asp:View ID="View_Attribute" runat="server">
                    <nexus:ProductAttribute ID="ProductAttribute_Editor" runat="server" />
                </asp:View>
                <asp:View ID="View_Webpage" runat="server">
                    <nexus:Webpage ID="Webpage_Editor" runat="server" />
                </asp:View>
                <asp:View ID="View_Webmedia" runat="server">
                    <nexus:Webmedia ID="Webmedia_Editor" runat="server" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:Panel ID="Panel_Product" runat="server" CssClass="nexusCore_panel_sideProduct">
                <div style="text-align: center">
                    <asp:Image ID="img_ItemPicture" runat="server" Width="80px" />
                </div>
            </asp:Panel>
            <div class="nexusCore_productCommand">
                <asp:Button ID="btn_Product_Index" runat="server" Text="Product Index" CssClass="nexusCore_general_btn"
                    SkinID="e2CMS_Button" OnClick="btn_Product_Index_Click" /><br />
                <asp:Button ID="btn_Product_Info" runat="server" Text="Product Info" CssClass="nexusCore_general_btn"
                    SkinID="e2CMS_Button" OnClick="btn_Product_Info_Click" /><br />
                <asp:Button ID="btn_Product_Category" runat="server" Text="Category mappings" CssClass="nexusCore_general_btn"
                    SkinID="e2CMS_Button" OnClick="btn_Product_Category_Click" /><br />
                <asp:Button ID="btn_Product_Attribute" runat="server" Text="Specification Attributes"
                    CssClass="nexusCore_general_btn" SkinID="e2CMS_Button" OnClick="btn_Product_Attribute_Click" /><br />
                <asp:Button ID="btn_Product_Webpage" runat="server" Text="SEO & Web content" CssClass="nexusCore_general_btn"
                    SkinID="e2CMS_Button" OnClick="btn_Product_Webpage_Click" /><br />
                <asp:Button ID="btn_Product_Webmedia" runat="server" Text="Web media" CssClass="nexusCore_general_btn"
                    SkinID="e2CMS_Button" OnClick="btn_Product_Webmedia_Click" /><br />
            </div>
            <div class="nexusCore_productCommand">
                <asp:Button ID="btn_Refresh" runat="server" Text="Refresh Data" CssClass="nexusCore_refresh_btn"
                    SkinID="e2CMS_Button" PostBackUrl="Products.aspx" 
                    onclick="btn_Refresh_Click" /><br />
                <asp:Button ID="btn_Return" runat="server" Text="Back to Product List" CssClass="nexusCore_return_btn"
                    SkinID="e2CMS_Button" PostBackUrl="Products.aspx" /><br />
            </div>
        </div>
    </div>
</asp:Content>

