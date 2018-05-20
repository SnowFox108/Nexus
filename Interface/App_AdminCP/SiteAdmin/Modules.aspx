<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master" AutoEventWireup="true" CodeFile="Modules.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">
<div class="NexusCore_Modules">
<h1>Module Installed</h1>
    <asp:DataList ID="DataList_ModuleList" runat="server" DataSourceID="ObjectDataSource_ModuleList">
        <ItemTemplate>
            <div class="NexusCore_ModuleList">
                <table border="1" bgcolor="#82A0C4">
                    <tr>
                        <td colspan="2">
                            <h2>
                                <%# Eval("Module_Name") %></h2>
                            Description: <%# Eval("Description") %>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="64" bgcolor="#66CCFF">
                            <img src='<%# Eval("Module_Icon_Big") %>' alt='<%# Eval("Description") %>' />
                            <br />ver.<%# Eval("Module_Version") %>
                            <br /><%# Convert.ToDateTime(Eval("Release_Date")).ToShortDateString() %>
                        </td>
                        <td bgcolor="#6699FF">
                            <!-- Components List -->
                            <div class="NexusCore_ModuleList_Components">
                                <asp:HiddenField ID="hidden_ModuleID" Value='<%# Eval("ModuleID") %>' runat="server" />
                                <asp:DataList ID="DataList_Componenets" runat="server" DataSourceID="ObjectDataSource_Components"
                                    RepeatColumns="4">
                                    <ItemTemplate>
                                        <div class="NexusCore_ModuleList_Components_inner">
                                            <img src='<%# Eval("Component_Icon_Big") %>' alt='<%# Eval("Component_Name") %> (<%# Eval("Component_Version") %>)' />
                                            <br />
                                            <%# Eval("Component_Name") %>
                                            (<%# Eval("Component_Version") %>)
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:ObjectDataSource ID="ObjectDataSource_Components" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="sGet_Components" TypeName="Nexus.Core.Modules.ModuleMgr">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hidden_ModuleID" Name="ModuleID" PropertyName="Value"
                                            Type="String" />
                                        <asp:Parameter DefaultValue="-1" Name="Parent_ComponentID" Type="String" />
                                        <asp:Parameter DefaultValue="Component_Name" Name="SortOrder" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource_ModuleList" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="sGet_Modules" TypeName="Nexus.Core.Modules.ModuleMgr">
        <SelectParameters>
            <asp:Parameter DefaultValue="Module_Name" Name="SortOrder" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

<h1>Template Installed</h1>
    <asp:DataList ID="DataList_TemplateList" runat="server" DataSourceID="ObjectDataSource_TemplateList">
        <ItemTemplate>
         <div class="NexusCore_ModuleTemplateList">
            <asp:HiddenField ID="hidden_TemplateID" Value='<%# Eval("TemplateID") %>' runat="server" />
             <h3>
            <%# Eval("Template_Name") %> 
            ( <%# Eval("Template_Version") %> )</h3> &nbsp;&nbsp;&nbsp;
            <span class="listOutter">
            <asp:DropDownList ID="droplist_Themes" runat="server" DataSourceID="ObjectDataSource_ThemeList" 
                DataTextField="Theme_Name" DataValueField="ThemeID" AutoPostBack="True" CssClass="txt_input">
            </asp:DropDownList>
            </span>
            <asp:ObjectDataSource ID="ObjectDataSource_ThemeList" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="sGet_Themes" TypeName="Nexus.Core.Templates.ThemeMgr">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hidden_TemplateID" DefaultValue="0" Name="TemplateID"
                        PropertyName="Value" Type="String" />
                    <asp:Parameter DefaultValue="Theme_Name" Name="SortOrder" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
<div class="NexusCore_ModuleList_Templates">           
            <asp:DataList ID="DataList_MasterPageList" runat="server" 
                DataSourceID="ObjectDataSource_MasterPageList" RepeatColumns="4">
                <ItemTemplate>
                <div class="NexusCore_ModuleList_Templates_inner">
                    <img src='<%# Eval("MasterPage_PreviewURL")%>' /><br />
                    <%# Eval("MasterPage_Template_Name") %>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource_MasterPageList" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="sGet_Template_List"
                TypeName="Nexus.Core.Templates.TemplateMgr">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hidden_TemplateID" DefaultValue="0" Name="TemplateID"
                        PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="droplist_Themes" DefaultValue="" 
                        Name="ThemeID" PropertyName="SelectedValue" Type="String" />
                    <asp:Parameter DefaultValue="MasterPage_Template_Name" Name="SortOrder" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource_TemplateList" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="sGet_Templates" TypeName="Nexus.Core.Templates.TemplateMgr">
        <SelectParameters>
            <asp:Parameter DefaultValue="Template_Name" Name="SortOrder" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </div>
</asp:Content>

