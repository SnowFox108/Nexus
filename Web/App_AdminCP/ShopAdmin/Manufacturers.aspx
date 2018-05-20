<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Manufacturers.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Manufacturers" 
    Title="Shop Control Panel - Manufacturer" StylesheetTheme="NexusShop" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>

    <div id="main">
        <div class="in">
            <div class="nexusCore_manufacturer_list">
                <h3>
                    Product manufacturer list</h3>
                <asp:GridView ID="GridView_Manufacturers" runat="server" AutoGenerateColumns="False"
                    SkinID="e2CMS_GridView" AllowSorting="True" DataKeyNames="ManufacturerID"
                    onrowdatabound="GridView_Product_Variants_RowDataBound" 
                    onsorting="GridView_Product_Variants_Sorting" AllowPaging="True" 
                    PageSize="20">
                    <EmptyDataTemplate>
                        <div class="nexusCore_error_message">
                            Please add manufacturer by using form on the left.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="ManufacturerID" HeaderText="Manufacturer ID" 
                            ReadOnly="True" SortExpression="ManufacturerID" ItemStyle-Width="300px" >
<ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                        <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                        <img src='<%# Eval("Logo")%>' height="50px" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="URL" HeaderText="URL" ReadOnly="True" />
                        <asp:CheckBoxField DataField="IsActive" HeaderText="Active Status" 
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("ManufacturerID")%>'
                                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("ManufacturerID")%>'
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
            <asp:MultiView ID="MultiView_Manufacturer" runat="server">
                <asp:View ID="View_Add" runat="server">
                    <asp:Panel ID="Panel_createVariant" runat="server" CssClass="nexusCore_panel_sideManufacturer">
                        <h3>
                            Create a Manufacturer</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Name:</h4>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_AddMF_Name" runat="server" ErrorMessage="Enter a Manufacturer Name! &lt;br/&gt;"
                            ControlToValidate="tbx_AddMF_Name" Display="Dynamic" ValidationGroup="CreateManufacturer"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_AddMF_Name" runat="server" Width="195px" ValidationGroup="CreateManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Logo:</h4>
                        <asp:TextBox ID="tbx_AddMF_Logo" runat="server" Width="195px" ValidationGroup="CreateManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            URL:</h4>
                        <asp:TextBox ID="tbx_AddMF_URL" runat="server" Width="195px" ValidationGroup="CreateManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_AddMF_IsActive" runat="server" Text="Active" />
                    </asp:Panel>
                    <div class="nexusCore_manufacturerCommand">
                        <asp:Button ID="btn_AddMF_Create" runat="server" Text="Create a Manufacturer" CssClass="nexusCore_createManufacturer_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="CreateManufacturer" 
                            onclick="btn_AddMF_Create_Click" /><br />
                    </div>
                </asp:View>
                <asp:View ID="View_Edit" runat="server">
                    <asp:Panel ID="Panel1" runat="server" CssClass="nexusCore_panel_sideManufacturer">
                        <h3>
                            Edit a Manufacturer</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Name:</h4>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_EditMF_Name" runat="server" ErrorMessage="Enter a Manufacturer Name! &lt;br/&gt;"
                            ControlToValidate="tbx_EditMF_Name" Display="Dynamic" ValidationGroup="EditManufacturer"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_EditMF_Name" runat="server" Width="195px" ValidationGroup="EditManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Logo:</h4>
                        <asp:TextBox ID="tbx_EditMF_Logo" runat="server" Width="195px" ValidationGroup="EditManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            URL:</h4>
                        <asp:TextBox ID="tbx_EditMF_URL" runat="server" Width="195px" ValidationGroup="EditManufacturer"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_EditMF_IsActive" runat="server" Text="Active" />

                    </asp:Panel>
                    <div class="nexusCore_manufacturerCommand">
                        <asp:Button ID="btn_EditMF_Update" runat="server" Text="Update a Manufacturer" CssClass="nexusCore_editManufacturer_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="EditManufacturer" 
                            oncommand="btn_EditMF_Update_Command" /><br />
                        <asp:Button ID="btn_EditMF_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_return_btn"
                            SkinID="e2CMS_Button"  ValidationGroup="EditManufacturer" 
                            CausesValidation="False" onclick="btn_EditMF_Cancel_Click" /><br />

                    </div>

                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

