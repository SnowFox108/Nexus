<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Attributes.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Attributes" 
    Title="Shop Control Panel - Product Variants" StylesheetTheme="NexusShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>

    <div id="main">
        <div class="in">
            <div class="nexusCore_attribute_list">
                <h3>
                    Attribute list -
                    <asp:Label ID="lbl_Variant" runat="server"></asp:Label></h3>
                <asp:GridView ID="GridView_Attributes" runat="server" AutoGenerateColumns="False"
                    SkinID="e2CMS_GridView" AllowSorting="True" 
                    DataKeyNames="Attribute_TypeID" AllowPaging="True"
                    PageSize="20" onrowdatabound="GridView_Attributes_RowDataBound">
                    <EmptyDataTemplate>
                        <div class="nexusCore_error_message">
                            Please add attribute by using form on the left.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Attribute_TypeID" HeaderText="Attribute ID" 
                            ReadOnly="True" SortExpression="Attribute_TypeID" ItemStyle-Width="300px" >
<ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Attribute_Name" HeaderText="Name" ReadOnly="True" SortExpression="Attribute_Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" />
                        <asp:CheckBoxField DataField="IsActive" HeaderText="Active Status" 
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("Attribute_TypeID")%>'
                                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("Attribute_TypeID")%>'
                                    OnCommand="lbtn_Delete_Command">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>

            </div>

        </div>
    </div>
    <div id="side">
        <div class="in">

            <asp:MultiView ID="MultiView_Attribute" runat="server">
                <asp:View ID="View_VariantList" runat="server">
                    <asp:Panel ID="Panel_listVariant" runat="server" CssClass="nexusCore_panel_sideAttribute">
                        <h3>
                            Product Variant List</h3>
                        <div class="nexusCore_variantList">
                            <asp:DataList ID="DataList_VariantList" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_Variant_Select" runat="server" CommandArgument='<%# Eval("Product_VariantID") %>'
                                        Width="100%" OnCommand="lbtn_Variant_Select_Command"><%# Eval("Variant_Name") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </asp:Panel>
                    <div class="nexusCore_attributeCommand">
                        <asp:Button ID="btn_Add_Atrribute" runat="server" Text="Add a Attribute" CssClass="nexusCore_createAttribute_btn"
                            SkinID="e2CMS_Button" ValidationGroup="CreateAttribute" OnClick="btn_Add_Atrribute_Click" /><br />
                    </div>
                </asp:View>
                <asp:View ID="View_Add" runat="server">
                    <asp:Panel ID="Panel_createAttribute" runat="server" CssClass="nexusCore_panel_sideAttribute">
                        <h3>
                            Create a Attribute</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Product Variant:</h4>
                        <asp:DropDownList ID="droplist_AddAttribute_VariantID" runat="server" 
                            Width="200px">
                        </asp:DropDownList>
                        <div class="spliter">
                        </div>
                        <h4>
                            Name:</h4>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_AddAttribute_Name" runat="server" ErrorMessage="Enter a Attribute Name! &lt;br/&gt;"
                            ControlToValidate="tbx_AddAttribute_Name" Display="Dynamic" ValidationGroup="CreateAttribute"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_AddAttribute_Name" runat="server" Width="195px" ValidationGroup="CreateAttribute"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Description:</h4>
                        <asp:TextBox ID="tbx_AddAttribute_Description" runat="server" Width="195px" 
                            ValidationGroup="CreateAttribute" Rows="8" TextMode="MultiLine"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_AddAttribute_IsActive" runat="server" Text="Active" />
                    </asp:Panel>
                    <div class="nexusCore_attributeCommand">
                        <asp:Button ID="btn_AddAttribute_Create" runat="server" Text="Create a Attribute" CssClass="nexusCore_createAttribute_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="CreateAttribute" 
                            onclick="btn_AddAttribute_Create_Click" /><br />
                        <asp:Button ID="btn_AddAttribute_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_return_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="CreateAttribute" 
                            CausesValidation="False" onclick="btn_EditAttribute_Cancel_Click" /><br />
                    </div>
                </asp:View>
                <asp:View ID="View_Edit" runat="server">
                    <asp:Panel ID="Panel_editAttribute" runat="server" CssClass="nexusCore_panel_sideAttribute">
                        <h3>
                            Edit a Attribute</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Product Variant:</h4>
                        <asp:Label ID="lbl_editAttribute_VariantID" runat="server" Text="Label"></asp:Label>
                        <div class="spliter">
                        </div>
                        <h4>
                            Name:</h4>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_EditAttribute_Name" runat="server" ErrorMessage="Enter a Attribute Name! &lt;br/&gt;"
                            ControlToValidate="tbx_EditAttribute_Name" Display="Dynamic" ValidationGroup="EditAttribute"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_EditAttribute_Name" runat="server" Width="195px" ValidationGroup="EditAttribute"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Description:</h4>
                        <asp:TextBox ID="tbx_EditAttribute_Description" runat="server" Width="195px" 
                            ValidationGroup="EditAttribute" Rows="8" TextMode="MultiLine"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_EditAttribute_IsActive" runat="server" Text="Active" />
                    </asp:Panel>
                    <div class="nexusCore_attributeCommand">
                        <asp:Button ID="btn_EditAttribute_Update" runat="server" Text="Update a Attribute" CssClass="nexusCore_editAttribute_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="EditAttribute" 
                            oncommand="btn_EditAttribute_Update_Command" /><br />
                        <asp:Button ID="btn_EditAttribute_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_return_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="EditAttribute" 
                            CausesValidation="False" onclick="btn_EditAttribute_Cancel_Click" /><br />

                    </div>
                </asp:View>
            </asp:MultiView>

        </div>
    </div>

</asp:Content>

