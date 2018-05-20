<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master" AutoEventWireup="true" CodeFile="Templates.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Templates" %>

<%@ Register src="Templates/TemplateShow.ascx" tagname="TemplateShow" tagprefix="uc" %>
<%@ Register src="Templates/TemplateCreate.ascx" tagname="TemplateCreate" tagprefix="uc" %>
<%@ Register src="Templates/TemplateList.ascx" tagname="TemplateList" tagprefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <div id="nexusCore_mainContent">

        <asp:MultiView ID="MultiView_Templates" runat="server">            
            <asp:View ID="View_ListTemplate" runat="server">
                <div class="View_ListTemplate"><uc:TemplateList ID="TemplateList" runat="server" /></div>
            </asp:View>
            
            <asp:View ID="View_ShowTemplate" runat="server">
                <uc:TemplateShow ID="TemplateShow" runat="server" />
            </asp:View>
            <asp:View ID="View_CreateTemplate" runat="server">
            <div class="TemplateCreate">
                <uc:TemplateCreate ID="TemplateCreate" runat="server" /></div>
            </asp:View>
        </asp:MultiView>
        
    </div>
    <div id="nexusCore_sideBar">
        <asp:Button ID="btn_CreateTemplate" runat="server" Text="Create a Masterpage" 
            onclick="btn_CreateTemplate_Click" SkinID="btn_sideBar" />
        <asp:Button ID="btn_Template_Alllist" runat="server" Text="List all Masterpage" 
            SkinID="btn_sideBar" onclick="btn_Template_Alllist_Click" />
        <div class="list_all_masterpage">        
        <h2>Template List</h2>
        <asp:DataList ID="DataList_TemplateList" runat="server" DataSourceID="ObjectDataSource_TemplateList">
            <ItemTemplate>
                <asp:LinkButton ID="lbnt_Template_Select" runat="server"  CommandArgument='<%# Eval("MasterPageIndexID") %>'
                    OnCommand="lbnt_Template_Select_Command" Width="100%" ><%# Eval("MasterPage_Name") %></asp:LinkButton>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource_TemplateList" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="sGet_Template_MasterPage_DropList" TypeName="Nexus.Core.Templates.MasterPageMgr">
            <SelectParameters>
                <asp:Parameter Name="SortOrder" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </div>
    </div>
    <br class="clearfloat" />
</asp:Content>
