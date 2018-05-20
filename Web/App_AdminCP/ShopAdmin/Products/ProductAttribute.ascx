<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAttribute.ascx.cs"
    Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_ProductAttribute" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        There are not any attribute available for this product! You can manage them <a href="Attributes.aspx">here</a>!
    </div>
</asp:Panel>
<div class="nexusCore_panel_productEditor">
    <h3>
        Product Attributes
    </h3>
    <asp:MultiView ID="MultiView_AttributeForm" runat="server">
        <asp:View ID="View_Form" runat="server">
            <table>
                <tr>
                    <th>
                        Attribute Type
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_Attribute_TypeID" Width="200px" runat="server" 
                            ValidationGroup="AttributeForm">
                        </asp:DropDownList>                         
                        &nbsp;<asp:Button ID="btn_DisplayText" runat="server" Text="Use Attribute Text" SkinID="e2CMS_Button"
                             ValidationGroup="AttributeForm" CausesValidation="False" 
                            onclick="btn_DisplayText_Click" />

                    </td>
                </tr>
                <tr>
                    <th>
                        Display Text
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_DisplayText" runat="server" MaxLength="400" ValidationGroup="AttributeForm"
                            Width="195px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_DisplayText" runat="server"
                            ErrorMessage="Please enter a Display Text." ControlToValidate="tbx_DisplayText"
                            ValidationGroup="AttributeForm"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        Required Option
                    </th>
                    <td>
                        <asp:CheckBox ID="chkbox_IsRequired" runat="server" 
                            ValidationGroup="AttributeForm" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Control Type
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_InputOption" Width="200px" runat="server" 
                            ValidationGroup="AttributeForm">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Active Status
                    </th>
                    <td>
                        <asp:CheckBox ID="chkbox_IsActive" runat="server" 
                            ValidationGroup="AttributeForm" />
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button ID="btn_Add_Attribute" runat="server" Text="Create" SkinID="e2CMS_Button"
                            OnClick="btn_Add_Attribute_Click" ValidationGroup="AttributeForm" />
                        &nbsp;<asp:Button ID="btn_Update_Attribute" runat="server" Text="Update" SkinID="e2CMS_Button"
                            OnCommand="btn_Update_Attribute_Command" ValidationGroup="AttributeForm" />
                        &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" SkinID="e2CMS_Button"
                            CausesValidation="False" OnClick="btn_Cancel_Click" 
                            ValidationGroup="AttributeForm" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View_Button" runat="server">
            <asp:Button ID="btn_Show_AddForm" runat="server" Text="Add a Attribute" SkinID="e2CMS_Button"
                CausesValidation="False" OnClick="btn_Show_AddForm_Click" />
        </asp:View>
    </asp:MultiView>
    <br />
    <h3>
        Attribute List
    </h3>
    <telerik:radgrid id="RadGrid_Attributes" runat="server" cellspacing="0" gridlines="None"
        skin="WebBlue" borderwidth="0px" onitemdatabound="RadGrid_Attributes_ItemDataBound"
        onneeddatasource="RadGrid_Attributes_NeedDataSource" onrowdrop="RadGrid_Attributes_RowDrop">
                    <ClientSettings AllowRowsDragDrop="true"> 
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                    </ClientSettings> 
                    <mastertableview autogeneratecolumns="False" datakeynames="Attribute_IndexID">
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
                            <telerik:GridBoundColumn DataField="Display_Text" 
                                FilterControlAltText="Filter Display_Text column" HeaderText="Display Text" 
                                ReadOnly="True" SortExpression="Display_Text" UniqueName="Display_Text">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Input_OptionName" 
                                FilterControlAltText="Filter Input_OptionName column" HeaderText="Input Option" 
                                ReadOnly="True" SortExpression="Input_OptionName" UniqueName="Input_OptionName">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsRequired" HeaderText="Required" 
                                FilterControlAltText="Filter IsRequired column"  
                                ReadOnly="True" UniqueName="IsRequired" DataType="System.Boolean">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="IsActive" HeaderText="Active Status" 
                                FilterControlAltText="Filter IsActive column"  
                                ReadOnly="True" UniqueName="IsActive" DataType="System.Boolean">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                HeaderText="Actions" UniqueName="TemplateColumn_Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_Edit_Attribute" runat="server" CommandArgument='<%# Eval("Attribute_IndexID")%>' 
                                        oncommand="lbtn_Edit_Attribute_Command">Edit</asp:LinkButton>
                                    <asp:HyperLink ID="hlink_Edit_AttributeOption" runat="server">Manage Options</asp:HyperLink>
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
</div>