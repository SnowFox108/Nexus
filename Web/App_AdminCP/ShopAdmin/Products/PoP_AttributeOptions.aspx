<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PoP_AttributeOptions.aspx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_PoP_AttributeOptions" StylesheetTheme="NexusShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
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
        <div class="nexusCore_product_editor">
            <h3>
                Attribute Options 
                (<asp:Label ID="lbl_AttributeName" runat="server"></asp:Label>
                )</h3>
            <asp:Panel ID="Panel_Updated" runat="server">
                <div class="nexusCore_error_message">
                    Attribute option have been updated!</div>
            </asp:Panel>
            <div class="spliter">
            </div>
            <asp:MultiView ID="MultiView_OptionForm" runat="server">
                <asp:View ID="View_Form" runat="server">
                    <table class="form">
                        <tr>
                            <th>
                                Attribute Name
                            </th>
                            <td>
                                <asp:TextBox ID="tbx_AttributeName" runat="server" MaxLength="400" ValidationGroup="OptionForm"
                                    Width="195px"></asp:TextBox>
                                *
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_DisplayText" runat="server"
                                    ErrorMessage="Please enter a Attribute Name." ControlToValidate="tbx_AttributeName"
                                    ValidationGroup="OptionForm"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Price Adjustment
                            </th>
                            <td>
                                <telerik:radnumerictextbox id="RadNumericTextBox_PriceAdjustment" 
                                    runat="server" width="195px"
                                    validationgroup="OptionForm" value="0">
                                </telerik:radnumerictextbox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Weight_Adjustment
                            </th>
                            <td>
                                <telerik:radnumerictextbox id="RadNumericTextBox_WeightAdjustment" runat="server"
                                    width="195px" validationgroup="OptionForm" value="0">
                                </telerik:radnumerictextbox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Pre-selected
                            </th>
                            <td>
                                <asp:CheckBox ID="chkbox_IsPreSelected" runat="server" 
                                    ValidationGroup="OptionForm" Text="Selected" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Active Status
                            </th>
                            <td>
                                <asp:CheckBox ID="chkbox_IsActive" runat="server" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btn_Add_Option" runat="server" Text="Create" SkinID="e2CMS_Button"
                                    ValidationGroup="OptionForm" onclick="btn_Add_Option_Click" />
                                &nbsp;<asp:Button ID="btn_Update_Option" runat="server" Text="Update" SkinID="e2CMS_Button"
                                    ValidationGroup="OptionForm" oncommand="btn_Update_Option_Command" />
                                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" SkinID="e2CMS_Button"
                                    CausesValidation="False" ValidationGroup="AttributeForm" 
                                    onclick="btn_Cancel_Click" />
                                &nbsp;<asp:Button ID="btn_CloseWindow" runat="server" Text="Close Window" SkinID="e2CMS_Button"
                                    CausesValidation="False" ValidationGroup="AttributeForm" 
                                    onclick="btn_CloseWindow_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Button" runat="server">
                    <asp:Button ID="btn_Show_AddForm" runat="server" Text="Add a Option" SkinID="e2CMS_Button"
                        CausesValidation="False" onclick="btn_Show_AddForm_Click" />
                    &nbsp;<asp:Button ID="btn_CloseWindow1" runat="server" CausesValidation="False" 
                        SkinID="e2CMS_Button" Text="Close Window" ValidationGroup="AttributeForm" 
                        onclick="btn_CloseWindow_Click" />
                </asp:View>
            </asp:MultiView>
            <br />
            <asp:Panel ID="Panel_Input_Options" runat="server">
            <h3>
                Option List
            </h3>
            <telerik:radgrid id="RadGrid_Options" runat="server" cellspacing="0" gridlines="None"
                skin="WebBlue" borderwidth="0px" onitemdatabound="RadGrid_Options_ItemDataBound"
                onneeddatasource="RadGrid_Options_NeedDataSource" onrowdrop="RadGrid_Options_RowDrop">
                    <ClientSettings AllowRowsDragDrop="true"> 
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                    </ClientSettings> 
                    <mastertableview autogeneratecolumns="False" datakeynames="AttributeID">
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                        </rowindicatorcolumn>
                        <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px">
                                <HeaderStyle Width="18px" />
                            </telerik:GridDragDropColumn>
                            <telerik:GridBoundColumn DataField="Attribute_Name" 
                                FilterControlAltText="Filter Attribute_Name column" HeaderText="Attribute Name" 
                                ReadOnly="True" SortExpression="Attribute_Name" UniqueName="Attribute_Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Price_Adjustment" 
                                FilterControlAltText="Filter Price_Adjustment column" HeaderText="Price Adjustment" 
                                ReadOnly="True" SortExpression="Price_Adjustment" UniqueName="Price_Adjustment">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Weight_Adjustment" 
                                FilterControlAltText="Filter Weight_Adjustment column" HeaderText="Weight Adjustment" 
                                ReadOnly="True" SortExpression="Weight_Adjustment" UniqueName="Weight_Adjustment">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsPreSelected" HeaderText="Pre-selected" 
                                FilterControlAltText="Filter IsPreSelected column"  
                                ReadOnly="True" UniqueName="IsPreSelected" DataType="System.Boolean">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="IsActive" HeaderText="Active Status" 
                                FilterControlAltText="Filter IsActive column"  
                                ReadOnly="True" UniqueName="IsActive" DataType="System.Boolean">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                HeaderText="Actions" UniqueName="TemplateColumn_Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_Edit_Option" runat="server" CommandArgument='<%# Eval("AttributeID")%>' 
                                        oncommand="lbtn_Edit_Option_Command">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Delete_Option" runat="server" CommandArgument='<%# Eval("AttributeID")%>' 
                                        oncommand="lbtn_Delete_Option_Command">Delete</asp:LinkButton>
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
                </telerik:radgrid>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
