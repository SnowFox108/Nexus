<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Installed_Modules.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Installed_Modules"
    Title="Website Control Panel - Modules Viewer" StylesheetTheme="NexusCore" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <div id="singleMain">
        <div class="nexusCore_panel_moduleInstalled">
            <h2>
                Module Installed</h2>
            <asp:DataList ID="DataList_ModuleList" runat="server" DataSourceID="ObjectDataSource_ModuleList"
                RepeatDirection="Horizontal" RepeatColumns="4" ItemStyle-CssClass="moduleList">
                <ItemTemplate>
                    <div class="nexusCore_moduleInstalled_holder">
                        <img src='<%# Eval("Module_Icon_Big") %>' alt='<%# Eval("Description") %>' class="nexusCore_Module_Icon_Big" />
                        <div class="nexusCore_Module_Icon_Discription">
                            <h3>
                                <%# Eval("Module_Name") %></h3>
                            <p>
                                <b>Description: </b>&nbsp;
                                <%# Eval("Description") %></p>
                            <p>
                                ver.<%# Eval("Module_Version") %><span><%# Convert.ToDateTime(Eval("Release_Date")).ToShortDateString() %></span></p>
                        </div>
                        <br class="clear" />
                        <!-- Components List -->
                        <asp:HiddenField ID="hidden_ModuleID" Value='<%# Eval("ModuleID") %>' runat="server" />
                        <asp:DataList ID="DataList_Componenets" runat="server" DataSourceID="ObjectDataSource_Components"
                            RepeatColumns="3" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <div class="nexusCore_moduleInstalled_inner">
                                    <img src='<%# Eval("Component_Icon_Big") %>' alt='<%# Eval("Component_Name") %> (<%# Eval("Component_Version") %>)' />
                                    <br />
                                    <%# Eval("Component_Name") %>
                                    <br />
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
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource_ModuleList" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="sGet_Modules" TypeName="Nexus.Core.Modules.ModuleMgr">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Module_Name" Name="SortOrder" Type="String" />
                    <asp:Parameter DefaultValue="" Name="Module_Types" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
