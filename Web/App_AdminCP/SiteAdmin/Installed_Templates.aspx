<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Installed_Templates.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Installed_Templates"
    Title="Website Control Panel - Template Viewer" StylesheetTheme="NexusCore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <div id="singleMain">
        <div class="nexusCore_panel_templateInstalled">
            <h2>
                Template Installed</h2>
            <asp:DataList ID="DataList_TemplateList" runat="server" DataSourceID="ObjectDataSource_TemplateList"
                RepeatDirection="Horizontal" RepeatColumns="4"  ItemStyle-CssClass="templateList">
                <ItemTemplate>
                    <div class="nexusCore_templateInstalled_holder">
                        <asp:HiddenField ID="hidden_TemplateID" Value='<%# Eval("TemplateID") %>' runat="server" />
                        <h3>
                            <%# Eval("Template_Name") %>
                            (
                            <%# Eval("Template_Version") %>
                            )</h3>
                        &nbsp;&nbsp;&nbsp; <span class="listOutter">
                            <asp:DropDownList ID="droplist_Themes" runat="server" DataSourceID="ObjectDataSource_ThemeList"
                                DataTextField="Theme_Name" DataValueField="ThemeID" AutoPostBack="True">
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
                        <asp:DataList ID="DataList_MasterPageList" runat="server" DataSourceID="ObjectDataSource_MasterPageList">
                            <ItemTemplate>
                                <div class="nexusCore_templateInstalled_inner">
                                    <a href='<%# Eval("MasterPage_PreviewURL_Big")%>' title='<%# Eval("MasterPage_Template_Name")%>'
                                        target="preview" rel="Installed_Template">
                                        <img src='<%# Eval("MasterPage_PreviewURL")%>' style="border: 0px;" /></a><br />
                                    <%# Eval("MasterPage_Template_Name") %>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="ObjectDataSource_MasterPageList" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="sGet_Template_List" TypeName="Nexus.Core.Templates.TemplateMgr">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hidden_TemplateID" DefaultValue="0" Name="TemplateID"
                                    PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="droplist_Themes" DefaultValue="" Name="ThemeID"
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:Parameter DefaultValue="MasterPage_Template_Name" Name="SortOrder" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
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
    </div>
    <script src="/App_Themes/NexusCore/Scripts/jquery-1.6.2.js" type="text/javascript"></script>
    <script src="/App_Themes/NexusCore/Scripts/jquery.colorbox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //Examples of how to assign the ColorBox event to elements
            $("a[rel='Installed_Template']").colorbox();

            //Example of preserving a JavaScript event for inline calls.
            $("#click").click(function () {
                $('#click').css({ "background-color": "#f00", "color": "#fff", "cursor": "inherit" }).text("Open this window again and this message will still be here.");
                return false;
            });
        });

    </script>
</asp:Content>
