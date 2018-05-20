<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Product_Variant.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Variants_Product_Variant"
    Title="Shop Control Panel - Product Variant" StylesheetTheme="NexusShop" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

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

    <telerik:radwindowmanager id="RadWindowManager_ControlManager" runat="server">   
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
                 VisibleStatusbar="False" />
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
            <div class="nexusCore_variant_list">
            <h3>
                <asp:Label ID="lbl_Variant_Name" runat="server"></asp:Label></h3>
                <telerik:RadGrid id="RadGrid_VariantSpliter" runat="server" cellspacing="0" 
                    gridlines="None" showheader="False" BorderWidth="0px" 
                    onneeddatasource="RadGrid_VariantSpliter_NeedDataSource" Skin="WebBlue" 
                    onitemdatabound="RadGrid_VariantSpliter_ItemDataBound" 
                    AutoGenerateColumns="False" onrowdrop="RadGrid_VariantSpliter_RowDrop">
                    <MasterTableView DataKeyNames="Variant_SpliterID" HierarchyDefaultExpanded="true">

<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" >
                            <HeaderStyle Width="18px"></HeaderStyle>
                            </telerik:GridDragDropColumn>
                            <telerik:GridTemplateColumn DataField="Variant_SpliterID" UniqueName="Variant_SpliterID">
                                <ItemTemplate>
                                    <h4><%# Eval("Spliter_Name")%> 
                                    <span> 
                                        [ <asp:HyperLink ID="hlink_AddProperty" runat="server">Add Property</asp:HyperLink> ] 
                                        [ <asp:HyperLink ID="hlink_EditSpliter" runat="server">Edit</asp:HyperLink> ] 
                                        [ <asp:LinkButton ID="lbtn_DeleteSpliter" CommandArgument='<%# Eval("Variant_SpliterID")%>'
                                         OnCommand="lbtn_DeleteSpliter_Command" runat="server">Delete</asp:LinkButton> ]
                                    </span></h4> 
                                    <div class="spliter"></div>
                                </ItemTemplate>                                
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <norecordstemplate>
                            Please create a spliter to begin adding variant properties.
                        </norecordstemplate>
                        <NestedViewTemplate>
                            <telerik:RadGrid runat=server ID="RadGrid_VariantProperties" 
                                AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                                Skin="Windows7" onitemdatabound="RadGrid_VariantProperties_ItemDataBound" 
                                onrowdrop="RadGrid_VariantProperties_RowDrop">
                                <mastertableview DataKeyNames="Variant_PropertyID">
                                    <Columns>
                                        <telerik:GridDragDropColumn HeaderStyle-Width="18px" >
                                        <HeaderStyle Width="18px"></HeaderStyle>
                                        </telerik:GridDragDropColumn>
                                        <telerik:GridBoundColumn DataField="Variant_PropertyID" 
                                            FilterControlAltText="Filter Variant_PropertyID column" 
                                            HeaderText="Property ID" ReadOnly="True" SortExpression="Variant_PropertyID" 
                                            UniqueName="Variant_PropertyID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Property_Name" 
                                            FilterControlAltText="Filter Property_Name column" HeaderText="Name" 
                                            ReadOnly="True" SortExpression="Property_Name" UniqueName="Property_Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Input_Option" 
                                            FilterControlAltText="Filter Input_Option column" HeaderText="Control Option" 
                                            ReadOnly="True" SortExpression="Input_Option" UniqueName="Input_Option">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Default_Value" 
                                            FilterControlAltText="Filter Default_Value column" HeaderText="Default Value" 
                                            ReadOnly="True" SortExpression="Default_Value" UniqueName="Default_Value">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridCheckBoxColumn DataField="IsRequired" DataType="System.Boolean" 
                                            FilterControlAltText="Filter IsRequired column" HeaderText="Required" 
                                            ReadOnly="True" SortExpression="IsRequired" UniqueName="IsRequired">
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridCheckBoxColumn DataField="IsFilter" DataType="System.Boolean" 
                                            FilterControlAltText="Filter IsFilter column" HeaderText="Allow Filter" 
                                            ReadOnly="True" SortExpression="IsFilter" UniqueName="IsFilter">
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridCheckBoxColumn DataField="IsSort" DataType="System.Boolean" 
                                            FilterControlAltText="Filter IsSort column" HeaderText="Allow Sort" 
                                            ReadOnly="True" SortExpression="IsSort" UniqueName="IsSort">
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridBoundColumn DataField="Field_Name" 
                                            FilterControlAltText="Filter Field_Name column" HeaderText="Field Name" 
                                            ReadOnly="True" SortExpression="Field_Name" UniqueName="Field_Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                            HeaderText="Actions" UniqueName="TemplateColumn_Actions">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlink_EditProperty" runat="server">Edit</asp:HyperLink>
                                                <asp:LinkButton ID="lbtn_DeleteProperty" runat="server"  CommandArgument='<%# Eval("Variant_PropertyID")%>'
                                                    oncommand="lbtn_Property_Delete_Command">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <editformsettings>
                                        <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                        </editcolumn>
                                    </editformsettings>
                                </mastertableview>

                                <ClientSettings AllowRowsDragDrop="true"> 
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                                </ClientSettings> 
                                <filtermenu enableimagesprites="False">
                                </filtermenu>
                                <headercontextmenu cssclass="GridContextMenu GridContextMenu_Windows7">
                                </headercontextmenu>
                            </telerik:RadGrid>
                        </NestedViewTemplate>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
                    </MasterTableView>
                    <ClientSettings AllowRowsDragDrop="true"> 
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                    </ClientSettings> 

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue"></HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:Panel ID="Panel_UpdateVariant" runat="server" CssClass="nexusCore_panel_sideVariant">
                <h4>
                    Name:</h4>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ErrorMessage="Enter a Variant Name! &lt;br/&gt;"
                    ControlToValidate="tbx_Variant_Name" Display="Dynamic" 
                    ValidationGroup="EditVariant"></asp:RequiredFieldValidator>
                <asp:TextBox
                        ID="tbx_Variant_Name" runat="server" Width="195px" 
                    ValidationGroup="EditVariant"></asp:TextBox>
                <div class="spliter">
                </div>
                <h4>
                    Type:</h4>
                <asp:Label ID="lbl_Variant_Type" runat="server"></asp:Label>
                <div class="spliter">
                </div>
                <h4>
                    Table Name:</h4>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Table_Name" runat="server"
                    ErrorMessage="Enter a Table Name! &lt;br/&gt;" ControlToValidate="tbx_Table_Name"
                    Display="Dynamic" ValidationGroup="EditVariant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbx_Table_Name" runat="server" Width="195px" 
                    ValidationGroup="EditVariant"></asp:TextBox>

            </asp:Panel>
            <div class="nexusCore_variantCommand">
                <asp:Button ID="btn_UpdateVariant" runat="server" Text="Update Variant" CssClass="nexusCore_editVariant_btn"
                    SkinID="e2CMS_Button" ValidationGroup="EditVariant" 
                    onclick="btn_UpdateVariant_Click" /><br />
            </div>
            <br />
            <asp:Panel ID="Panel_CreateSpliter" runat="server" CssClass="nexusCore_panel_sideVariant">
                <h4>
                    Spliter Name:</h4>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Spliter_Name" runat="server" ErrorMessage="Enter a Spliter Name! &lt;br/&gt;"
                    ControlToValidate="tbx_Spliter_Name" Display="Dynamic" 
                    ValidationGroup="CreateSpliter"></asp:RequiredFieldValidator>
                <asp:TextBox
                        ID="tbx_Spliter_Name" runat="server" Width="195px" 
                    ValidationGroup="CreateSpliter"></asp:TextBox>
            </asp:Panel>

            <div class="nexusCore_variantCommand">
                <asp:Button ID="btn_CreateSpliter" runat="server" Text="Create a Spliter" CssClass="nexusCore_createVariant_btn"
                    SkinID="e2CMS_Button" ValidationGroup="CreateSpliter" 
                    onclick="btn_CreateSpliter_Click" /><br />
                <asp:Button ID="btn_Return" runat="server" Text="Back to Variant List" CssClass="nexusCore_return_btn"
                    SkinID="e2CMS_Button" PostBackUrl="Default.aspx" /><br />

            </div>
        </div>
    </div>

</asp:Content>

