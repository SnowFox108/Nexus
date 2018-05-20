<%@ Page Title="" Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="ContentManager.aspx.cs" Inherits="App_AdminCP_SiteAdmin_ContentManager"
    StylesheetTheme="NexusCore" %>

<%@ Register Src="Modules/ModuleCPMenu.ascx" TagName="ModuleCPMenu" TagPrefix="nexus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <div id="contentManager_side">
        <div class="in">
            <nexus:ModuleCPMenu ID="ModuleCPMenu_List" OnCategorySelected="ModuleCPMenu_List_OnCategorySelected"
                runat="server" />
        </div>
    </div>
    <div id="contentManager_main">
        <div class="in">
            <div class="nexusCore_iframe_ControlPanel_Wrapper">
                <h3><asp:Label ID="lbl_ControlName" runat="server"></asp:Label>                    
                </h3>

                <iframe id="iframe_ControlPanel" runat="server" frameborder="0"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
