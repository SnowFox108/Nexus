<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_PropertyEditor.aspx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Variants_PoP_PropertyEditor" StylesheetTheme="NexusShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshControl(args);
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().Close();
        }
    </script>
    <div id="nexusCorePop_wrapper">
        <div class="nexusCore_variant_property_editor">
            <h2>
                Edit a Property</h2>
            <asp:Panel ID="Panel_Updated" runat="server">
                <div class="nexusCore_error_message">
                    Product variant properties have been updated!</div>
            </asp:Panel>
            <div class="spliter">
            </div>
            <table class="form">
                <tr>
                    <th>
                        Property Name:
                    </th>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Property_Name" runat="server"
                            ErrorMessage="Enter a Property Name! &lt;br/&gt;" ControlToValidate="tbx_Property_Name"
                            Display="Dynamic" ValidationGroup="EditProperty"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_Property_Name" runat="server" Width="195px" 
                            ValidationGroup="EditProperty" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Input Option:
                    </th>
                    <td>
                        <asp:Label ID="lbl_InputOption" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        Default Value:
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Default_Value" runat="server" Width="195px" 
                            ValidationGroup="EditProperty" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Tooltips:
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Tooltips" runat="server" Width="280px" 
                            ValidationGroup="EditProperty" TextMode="MultiLine" ToolTip="500" 
                            Rows="3" MaxLength="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Control Option:
                    </th>
                    <td>
                        &nbsp;
                        <asp:CheckBox ID="chkbox_IsRequired" runat="server" Text="Required" />
                        &nbsp;<asp:CheckBox ID="chkbox_IsFilter" runat="server" Text="Allow Filter" />
                        &nbsp;<asp:CheckBox ID="chkbox_IsSort" runat="server" Text="Allow Sort" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Table Field Name:
                    </th>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Field_Name" runat="server"
                            ErrorMessage="Enter a Table Field Name! &lt;br/&gt;" ControlToValidate="tbx_Field_Name"
                            Display="Dynamic" ValidationGroup="EditProperty"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_Field_Name" runat="server" Width="195px" ValidationGroup="EditProperty"
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <div class="nexusCore_variantCommand">
                            <asp:Button ID="btn_UpdateProperty" runat="server" Text="Update Property" CssClass="nexusCore_editVariant_btn"
                                SkinID="e2CMS_Button" ValidationGroup="EditProperty" 
                                onclick="btn_UpdateProperty_Click" />                                
                            &nbsp; <asp:Button ID="btn_CloseWindow" runat="server" Text="Close Window" CssClass="nexusCore_return_btn"
                                SkinID="e2CMS_Button" ValidationGroup="EditProperty" 
                                CausesValidation="False" onclick="btn_CloseWindow_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel_Input_Options" runat="server">
            <h4>Property Options</h4>
                <div class="spliter">
                </div>
                <asp:MultiView ID="MultiView_InputOption" runat="server">
                    <asp:View ID="View_Add" runat="server">
                        <table class="form">
                            <tr>
                                <th>
                                    Option Name:
                                </th>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_AddOption_Name" runat="server"
                                        ControlToValidate="tbx_AddOption_Name" Display="Dynamic" ErrorMessage="Please enter a name &lt;br /&gt;"
                                        ValidationGroup="AddOption"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbx_AddOption_Name" runat="server" ValidationGroup="AddOption" 
                                        MaxLength="150" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Option Value:
                                </th>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_AddOption_Value" runat="server"
                                        ControlToValidate="tbx_AddOption_Value" Display="Dynamic" ErrorMessage="Please enter a value &lt;br /&gt;"
                                        ValidationGroup="AddOption"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbx_AddOption_Value" runat="server" 
                                        ValidationGroup="AddOption" MaxLength="150" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Active Status:
                                </th>
                                <td>
                                    <asp:CheckBox ID="chkbox_AddOption_IsActive" runat="server" Text="Active" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div class="nexusCore_variantCommand">
                                        <asp:Button ID="btn_AddOption" runat="server" Text="Add" CssClass="nexusCore_create_btn"
                                            SkinID="e2CMS_Button" ValidationGroup="AddOption" OnClick="btn_AddOption_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View_Edit" runat="server">
                        <table class="form">
                            <tr>
                                <th>
                                    Option Name:
                                </th>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_EditOption_Name" 
                                        runat="server" ControlToValidate="tbx_EditOption_Name" Display="Dynamic" 
                                        ErrorMessage="Please enter a name &lt;br /&gt;" ValidationGroup="EditOption"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbx_EditOption_Name" runat="server" 
                                        ValidationGroup="EditOption" MaxLength="150" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Option Value:
                                </th>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_EditOption_Value" 
                                        runat="server" ControlToValidate="tbx_EditOption_Value" Display="Dynamic" 
                                        ErrorMessage="Please enter a value &lt;br /&gt;" ValidationGroup="EditOption"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbx_EditOption_Value" runat="server" 
                                        ValidationGroup="EditOption" MaxLength="150" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Active Status:
                                </th>
                                <td>
                                    <asp:CheckBox ID="chkbox_EditOption_IsActive" runat="server" Text="Active" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div class="nexusCore_variantCommand">
                                        <asp:Button ID="btn_EditOption" runat="server" CssClass="nexusCore_edit_btn" 
                                            oncommand="btn_EditOption_Command" SkinID="e2CMS_Button" Text="Update" 
                                            ValidationGroup="EditOption" />
                                        <asp:Button ID="btn_EditOption_Cancel" runat="server" CausesValidation="False" 
                                            CssClass="nexusCore_cancel_btn" onclick="btn_EditOption_Cancel_Click" 
                                            SkinID="e2CMS_Button" Text="Cancel" ValidationGroup="EditOption" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
                <telerik:RadGrid ID="RadGrid_Options" runat="server" CellSpacing="0" 
                     GridLines="None" Skin="WebBlue" BorderWidth="0px" Width="500px" 
                    onitemdatabound="RadGrid_Options_ItemDataBound" 
                    onneeddatasource="RadGrid_Options_NeedDataSource" 
                    onrowdrop="RadGrid_Options_RowDrop">
                    <ClientSettings AllowRowsDragDrop="true"> 
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                    </ClientSettings> 
                    <mastertableview autogeneratecolumns="False" datakeynames="OptionID">
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                        </rowindicatorcolumn>
                        <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px">
                                <HeaderStyle Width="18px" />
                            </telerik:GridDragDropColumn>
                            <telerik:GridBoundColumn DataField="Option_Name" 
                                FilterControlAltText="Filter Option_Name column" HeaderText="Name" 
                                ReadOnly="True" SortExpression="Option_Name" UniqueName="Option_Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Option_Value" 
                                FilterControlAltText="Filter Option_Value column" HeaderText="Value" 
                                ReadOnly="True" SortExpression="Option_Value" UniqueName="Option_Value">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsActive" HeaderText="Active Status" 
                                FilterControlAltText="Filter IsActive column"  
                                ReadOnly="True" UniqueName="IsActive" DataType="System.Boolean">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                HeaderText="Actions" UniqueName="TemplateColumn_Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_EditOption" runat="server" CommandArgument='<%# Eval("OptionID")%>' 
                                        oncommand="lbtn_EditOption_Command">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_DeleteOption" runat="server" CommandArgument='<%# Eval("OptionID")%>' 
                                        oncommand="lbtn_DeleteOption_Command">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <editformsettings>
                            <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                            </editcolumn>
                        </editformsettings>
                    </mastertableview>
                    <filtermenu enableimagesprites="False">
                    </filtermenu>
                    <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                    </headercontextmenu>
                </telerik:RadGrid>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
