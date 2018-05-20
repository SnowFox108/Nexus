<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master"
    AutoEventWireup="true" CodeFile="Pages.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages" %>

<%@ Register Src="Pages/PageCreate.ascx" TagName="PageCreate" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageCommand_Live.ascx" TagName="PageCommand_Live" TagPrefix="nexus" %>
<%@ Register src="Pages/PageCommand_Normal.ascx" tagname="PageCommand_Normal" tagprefix="nexus" %>
<%@ Register Src="Pages/PageList.ascx" TagName="PageList" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageMenu.ascx" TagName="PageMenu" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageMenuList.ascx" TagName="PageMenuList" TagPrefix="nexus" %>
<%@ Register Src="Pages/PageShow.ascx" TagName="PageShow" TagPrefix="nexus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <div id="nexusCore_mainContent">
        <asp:MultiView ID="MultiView_Pages" runat="server">
            <asp:View ID="View_ListPage" runat="server">
                <div class="View_ListPage">
                    <nexus:PageList ID="PageList_Index" runat="server" />
                </div>
            </asp:View>
            <asp:View ID="View_ShowPage" runat="server">
                <asp:Label ID="lbl_PageInfo" runat="server"></asp:Label>
                <nexus:PageShow ID="PageShow_Page" runat="server" />
            </asp:View>
            <asp:View ID="View_CreatePage" runat="server">
                <nexus:PageCreate ID="PageCreate_Create" runat="server" />
            </asp:View>
        </asp:MultiView>
    </div>
    <div id="nexusCore_sideBar">
        <asp:DropDownList ID="droplist_PageFolder" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_Show_PageCategory" runat="server" Text="Select" OnClick="btn_Show_PageCategory_Click" />
        <nexus:PageMenu ID="PageMenu_PageIndex" runat="server" Root_PageIndexID="-1" OnPageIndexSelected="PageMenu_PageIndex_PageIndexSelected" />
        <nexus:PageMenuList ID="PageMenuList_PageIndex" runat="server" Page_CategoryID="1"
            OnPageIndexSelected="PageMenuList_PageIndex_PageIndexSelected" />
        <br />
        <br class="clearfloat" />
        <asp:Panel ID="Panel_Command" runat="server">
            <nexus:PageCommand_Live ID="PageCommand_Live_PageIndex" runat="server" OnClick="PageCommand_Live_PageIndex_Click"
                OnCreatePageClick="PageCommand_Live_PageIndex_CreatePageClick" />
                <nexus:PageCommand_Normal ID="PageCommand_Normal_PageIndex" runat="server" OnClick="PageCommand_Normal_PageIndex_Click" OnDeletePageClick="PageCommand_Normal_PageIndex_DeletePageClick" />
        </asp:Panel>
        <div class="Panel_Page_Label">
        </div>
    </div>
    <br class="clearfloat" />
</asp:Content>
