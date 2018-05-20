<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master"
    AutoEventWireup="true" CodeFile="Pages.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages"
    Title="Website Control Panel - Pages" StylesheetTheme="NexusCore" %>

<%@ Register Src="Pages/PageCommand_Live.ascx" TagName="PageCommand_Live" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageCommand_Normal.ascx" TagName="PageCommand_Normal" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageCreate.ascx" TagName="PageCreate" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageList.ascx" TagName="PageList" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageMenu.ascx" TagName="PageMenu" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageMenuList.ascx" TagName="PageMenuList" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageShow.ascx" TagName="PageShow" TagPrefix="nexus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>
    <div id="pages_main">
        <div class="in">
            <asp:MultiView ID="MultiView_Pages" runat="server">
                <asp:View ID="View_ListPage" runat="server">
                    <div class="nexusCore_pages_pageList">
                        <nexus:PageList ID="PageList_Index" PageEdit_URL="Pages.aspx" runat="server" />
                    </div>
                </asp:View>
                <asp:View ID="View_ShowPage" runat="server">
                    <div class="nexusCore_Pages_URL">
                        <asp:HyperLink ID="hlink_PagePreview" runat="server" Target="PagePreview">View in New Window</asp:HyperLink>
                        <b>You are in URL:
                            <asp:Label ID="lbl_PageInfo" runat="server"></asp:Label></b> PageID =
                        <asp:TextBox ID="tbx_PageID" runat="server" BorderStyle="Dashed" ReadOnly="True"
                            Width="250px"></asp:TextBox>
                    </div>
                    <div class="nexusCore_pages_pageShow">
                        <nexus:PageShow ID="PageShow_Page" runat="server" />
                    </div>
                </asp:View>
                <asp:View ID="View_CreatePage" runat="server">
                    <div class="nexusCore_pages_create">
                        <nexus:PageCreate ID="PageCreate_Create" runat="server" />
                    </div>
                </asp:View>
            </asp:MultiView>
            <br class="clearfloat" />
        </div>
    </div>
    <div id="pages_side">
        <div class="in">
            <asp:DropDownList ID="droplist_PageFolder" runat="server" CssClass="nexusCore_pagesSide_droplist">
            </asp:DropDownList>
            <asp:Button ID="btn_Show_PageCategory" runat="server" Text="Select" OnClick="btn_Show_PageCategory_Click"
                SkinID="e2CMS_Button" />
            <asp:Panel ID="Panel_Menu" runat="server" ScrollBars="Auto" CssClass="nexusCore_panel_Menu">
                <nexus:PageMenu ID="PageMenu_PageIndex" runat="server" Root_PageIndexID="-1" OnPageIndexSelected="PageMenu_PageIndex_PageIndexSelected" />
                <nexus:PageMenuList ID="PageMenuList_PageIndex" runat="server" Page_CategoryID="1"
                    OnPageIndexSelected="PageMenuList_PageIndex_PageIndexSelected" />
            </asp:Panel>
            <asp:Panel ID="Panel_Command" runat="server" CssClass="nexusCore_panel_command">
                <nexus:PageCommand_Live ID="PageCommand_Live_PageIndex" runat="server" OnClick="PageCommand_Live_PageIndex_Click"
                    OnCreatePageClick="PageCommand_Live_PageIndex_CreatePageClick" OnDeletePageClick="PageCommand_Live_PageIndex_DeletePageClick" />
                <nexus:PageCommand_Normal ID="PageCommand_Normal_PageIndex" runat="server" OnClick="PageCommand_Normal_PageIndex_Click"
                    OnDeletePageClick="PageCommand_Normal_PageIndex_DeletePageClick" />
            </asp:Panel>
        </div>
    </div>
    <br class="clearfloat" />
</asp:Content>
