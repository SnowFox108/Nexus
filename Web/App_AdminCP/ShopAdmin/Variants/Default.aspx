<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Variants_Default"
    Title="Shop Control Panel - Product Variants" StylesheetTheme="NexusShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>

    <div id="main">
        <div class="in">
            <div class="nexusCore_variant_list">
                <h3>
                    Product variant list</h3>
                <asp:GridView ID="GridView_Product_Variants" runat="server" AutoGenerateColumns="False"
                    SkinID="e2CMS_GridView" AllowSorting="True" 
                    onsorting="GridView_Product_Variants_Sorting" 
                    onrowdatabound="GridView_Product_Variants_RowDataBound">
                    <EmptyDataTemplate>
                        <div class="nexusCore_error_message">
                            There is no product variant.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Product_VariantID" HeaderText="Variant ID" 
                            ReadOnly="True" SortExpression="Product_VariantID" ItemStyle-Width="300px" >
<ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Variant_Name" HeaderText="Name" ReadOnly="True" SortExpression="Variant_Name" />
                        <asp:BoundField DataField="Variant_Type" HeaderText="Type" ReadOnly="True" SortExpression="Variant_Type" />
                        <asp:BoundField DataField="Table_Name" HeaderText="Data Table" ReadOnly="True"
                            SortExpression="Table_Name" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("Product_VariantID")%>'
                                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("Product_VariantID")%>'
                                    OnCommand="lbtn_Delete_Command">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:Panel ID="Panel_createVariant" runat="server" CssClass="nexusCore_panel_sideVariant">
                <h3>
                    Create a product variant</h3>
                <div class="spliter">
                </div>
                <h4>
                    Name:</h4>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ErrorMessage="Enter a Variant Name! &lt;br/&gt;"
                    ControlToValidate="tbx_Variant_Name" Display="Dynamic" 
                    ValidationGroup="CreateVariant"></asp:RequiredFieldValidator>
                <asp:TextBox
                        ID="tbx_Variant_Name" runat="server" Width="195px" 
                    ValidationGroup="CreateVariant"></asp:TextBox>
                <div class="spliter">
                </div>
                <h4>
                    Type:</h4>
                <asp:DropDownList ID="droplist_Variant_Type" runat="server" Width="200px">
                </asp:DropDownList>
                <div class="spliter">
                </div>
                <h4>
                    Table Name:</h4>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Table_Name" runat="server"
                    ErrorMessage="Enter a Table Name! &lt;br/&gt;" ControlToValidate="tbx_Table_Name"
                    Display="Dynamic" ValidationGroup="CreateVariant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbx_Table_Name" runat="server" Width="195px" 
                    ValidationGroup="CreateVariant"></asp:TextBox>
            </asp:Panel>
            <div class="nexusCore_variantCommand">
                <asp:Button ID="btn_Create" runat="server" Text="Create a Variant" CssClass="nexusCore_createVariant_btn"
                    SkinID="e2CMS_Button" onclick="btn_Create_Click" 
                    ValidationGroup="CreateVariant" /><br />
            </div>
        </div>
    </div>
</asp:Content>

