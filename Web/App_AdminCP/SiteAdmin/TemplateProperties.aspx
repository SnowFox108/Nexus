<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master"
    AutoEventWireup="true" CodeFile="TemplateProperties.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_TemplateProperties"
    Title="Website Control Panel - MasterPage Properties" StylesheetTheme="NexusCore" %>

<%@ Register Src="Templates/TemplateCreate.ascx" TagName="TemplateCreate" TagPrefix="nexus" %>
<%@ Register Src="Templates/TemplateList.ascx" TagName="TemplateList" TagPrefix="nexus" %>
<%@ Register Src="Templates/TemplateProperties.ascx" TagName="TemplateProperties"
    TagPrefix="nexus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <div id="templates_main">
        <div class="in">
            <asp:MultiView ID="MultiView_Templates" runat="server">
                <asp:View ID="View_ListTemplate" runat="server">
                    <div class="nexusCore_templates_templatesList">
                        <nexus:TemplateList ID="TemplateList_MasterPage" TemplateEdit_URL="TemplateProperties.aspx" runat="server" />
                    </div>
                </asp:View>
                <asp:View ID="View_ShowTemplate" runat="server">
                    <div class="nexusCore_templates_templatesShow">
                        <nexus:TemplateProperties ID="TemplateProperties_Property" runat="server" />
                    </div>
                </asp:View>
                <asp:View ID="View_CreateTemplate" runat="server">
                    <div class="nexusCore_templates_create">
                        <nexus:TemplateCreate ID="TemplateCreate" runat="server" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div id="templates_side">
        <div class="in">
            <asp:Button ID="btn_CreateTemplate" runat="server" Text="Create a Masterpage" OnClick="btn_CreateTemplate_Click"
                CssClass="nexusCore_createMasterPage_btn" SkinID="e2CMS_Button" />
            <asp:Button ID="btn_Template_Alllist" runat="server" Text="List all Masterpage" CssClass="nexusCore_listMasterPages_btn"
                OnClick="btn_Template_Alllist_Click" SkinID="e2CMS_Button" />
            <div class="nexusCore_templateList">
                <h3>
                    Masterpage List</h3>
                <asp:DataList ID="DataList_TemplateList" runat="server" DataSourceID="ObjectDataSource_TemplateList">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbnt_Template_Select" runat="server" CommandArgument='<%# Eval("MasterPageIndexID") %>'
                            OnCommand="lbnt_Template_Select_Command" Width="100%" CssClass="nexusCore_side_link"><%# Eval("MasterPage_Name") %></asp:LinkButton>
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
    </div>
    <br class="clearfloat" />
</asp:Content>
