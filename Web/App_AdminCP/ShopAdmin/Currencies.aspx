<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/ShopAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Currencies.aspx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Currencies" 
    Title="Shop Control Panel - Currency" StylesheetTheme="NexusShop" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent" Runat="Server">
    <div id="main">
        <div class="in">
            <div class="nexusCore_misc_list">
                <h3>
                    Exchange rates - <asp:Label ID="lbl_Currency_Name" runat="server"></asp:Label></h3>
                <div class="spliter">
                </div>
                <asp:Panel ID="Panel_EditExchangeRate" runat="server">
                    <table class="nexusCore_Grid">
                        <tr>
                            <th>
                                Origin Currency
                            </th>
                            <th>
                                Target Currency
                            </th>
                            <th>
                                Exchange Rate
                            </th>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_Origin_Currency" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Target_Currency" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbx_Exchange_Rate" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtn_ExchangeRate_Update" runat="server" OnCommand="lbtn_ExchangeRate_Update_Command">Update</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lbtn_ExchangRate_Cancel" runat="server" OnClick="lbtn_ExchangRate_Cancel_Click">Cancel</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:GridView ID="GridView_Currency" runat="server" AutoGenerateColumns="False" SkinID="e2CMS_GridView"
                    AllowSorting="True" OnSorting="GridView_Currency_Sorting" DataKeyNames="RateID">
                    <EmptyDataTemplate>
                        <div class="nexusCore_error_message">
                            No data returned.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Origin_Currency_Name" HeaderText="Origin Currency" ReadOnly="True" />
                        <asp:BoundField DataField="Target_Currency_Name" HeaderText="Target Currency" ReadOnly="True" />
                        <asp:BoundField DataField="Exchange_Rate" HeaderText="Exchange Rate" ReadOnly="True"
                            SortExpression="Exchange_Rate" />
                        <asp:BoundField DataField="LastUpdate_Date" HeaderText="Last Update Date" ReadOnly="True"
                            SortExpression="LastUpdate_Date" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("RateID")%>'
                                    OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="spliter">
                </div>
                <h3>
                    Exchange rates</h3>
                <asp:Literal ID="Literal_ExchangeRate" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div id="side">
        <div class="in">
            <asp:MultiView ID="MultiView_Currency" runat="server">
                <asp:View ID="View_CurrencyList" runat="server">
                    <asp:Panel ID="Panel1" runat="server" CssClass="nexusCore_panel_sideMisc">
                        <h3>
                            Currency List</h3>
                        <asp:DataList ID="DataList_CurrencyList" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_Currency_Select" runat="server" CommandArgument='<%# Eval("CurrencyID") %>'
                                    Width="100%" OnCommand="lbtn_Currency_Select_Command"><%# Eval("Currency_Name") %> (<%# Eval("Currency_ShortName") %>)</asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                    <div class="nexusCore_miscCommand">
                        <asp:Button ID="btn_Add_Currency" runat="server" Text="Add a Currency" CssClass="nexusCore_createMisc_btn"
                            SkinID="e2CMS_Button" OnClick="btn_Add_Currency_Click" /><br />
                        <asp:Button ID="btn_Edit_Currency" runat="server" Text="Edit Currency" CssClass="nexusCore_editMisc_btn"
                            SkinID="e2CMS_Button" onclick="btn_Edit_Currency_Click" /><br />
                    </div>
                </asp:View>
                <asp:View ID="View_Add" runat="server">
                    <asp:Panel ID="Panel_createCurrency" runat="server" CssClass="nexusCore_panel_sideMisc">
                        <h3>
                            Add a new currency</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Currency Name:</h4>
                        (eg &#39;British Pound&#39;)<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ErrorMessage="Enter a Currency Name! &lt;br/&gt;"
                            ControlToValidate="tbx_AddCurrency_Name" Display="Dynamic" ValidationGroup="CreateCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_AddCurrency_Name" runat="server" Width="195px" ValidationGroup="CreateCurrency"
                            MaxLength="45"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Short Name:</h4>
                        (eg &#39;GBP&#39;)
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ShortName" runat="server"
                            ErrorMessage="Enter a Currency Short Name! &lt;br/&gt;" ControlToValidate="tbx_AddCurrency_ShortName"
                            Display="Dynamic" ValidationGroup="CreateCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_AddCurrency_ShortName" runat="server" Width="195px" ValidationGroup="CreateCurrency"
                            MaxLength="5"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Web Code:</h4>
                        (eg &#39;&amp;pound;&#39;)
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Table_Name" runat="server"
                            ErrorMessage="Enter a Web Code! &lt;br/&gt;" ControlToValidate="tbx_AddCurrency_WebCode"
                            Display="Dynamic" ValidationGroup="CreateCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_AddCurrency_WebCode" runat="server" Width="195px" ValidationGroup="CreateCurrency"
                            MaxLength="10"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Description:</h4>
                        <asp:TextBox ID="tbx_AddCurrency_Description" runat="server" Width="195px" ValidationGroup="CreateCurrency"
                            Rows="8" TextMode="MultiLine"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_AddCurrency_IsActive" runat="server" Text="Active" ValidationGroup="CreateCurrency" />
                    </asp:Panel>
                    <div class="nexusCore_miscCommand">
                        <asp:Button ID="btn_AddCurrency_Create" runat="server" Text="Add a Currency" CssClass="nexusCore_createMisc_btn"
                            SkinID="e2CMS_Button" OnClick="btn_Add_Currency_Create_Click" ValidationGroup="CreateCurrency" /><br />
                        <asp:Button ID="btn_AddCurrency_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_return_btn"
                            SkinID="e2CMS_Button" ValidationGroup="CreateCurrency" CausesValidation="False"
                            OnClick="btn_EditCurrency_Cancel_Click" /><br />
                    </div>
                </asp:View>
                <asp:View ID="View_Edit" runat="server">
                    <asp:Panel ID="Panel_EditCurrency" runat="server" CssClass="nexusCore_panel_sideMisc">
                        <h3>
                            Add a new currency</h3>
                        <div class="spliter">
                        </div>
                        <h4>
                            Currency Name:</h4>
                        (eg &#39;British Pound&#39;)<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Currency Name! &lt;br/&gt;"
                            ControlToValidate="tbx_EditCurrency_Name" Display="Dynamic" ValidationGroup="EditCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_EditCurrency_Name" runat="server" Width="195px" ValidationGroup="EditCurrency"
                            MaxLength="45"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Short Name:</h4>
                        (eg &#39;GBP&#39;)
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Currency Short Name! &lt;br/&gt;"
                            ControlToValidate="tbx_EditCurrency_ShortName" Display="Dynamic" ValidationGroup="EditCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_EditCurrency_ShortName" runat="server" Width="195px" ValidationGroup="EditCurrency"
                            MaxLength="5"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Web Code:</h4>
                        (eg &#39;&amp;pound;&#39;)
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_WebCode" runat="server" ErrorMessage="Enter a Web Code! &lt;br/&gt;"
                            ControlToValidate="tbx_EditCurrency_WebCode" Display="Dynamic" ValidationGroup="EditCurrency"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="tbx_EditCurrency_WebCode" runat="server" Width="195px" ValidationGroup="EditCurrency"
                            MaxLength="10"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Description:</h4>
                        <asp:TextBox ID="tbx_EditCurrency_Description" runat="server" Width="195px" ValidationGroup="EditCurrency"
                            Rows="8" TextMode="MultiLine"></asp:TextBox>
                        <div class="spliter">
                        </div>
                        <h4>
                            Active status:</h4>
                        <asp:CheckBox ID="chkbox_EditCurrency_IsActive" runat="server" Text="Active" ValidationGroup="EditCurrency" />
                    </asp:Panel>
                    <div class="nexusCore_miscCommand">
                        <asp:Button ID="btn_EditCurrency_Update" runat="server" Text="Update a Attribute"
                            CssClass="nexusCore_editMisc_btn" SkinID="e2CMS_Button" ValidationGroup="EditCurrency"
                            OnCommand="btn_EditCurrency_Update_Command" /><br />
                        <asp:Button ID="btn_EditCurrency_Cancel" runat="server" Text="Cancel" CssClass="nexusCore_return_btn"
                            SkinID="e2CMS_Button" ValidationGroup="EditCurrency" CausesValidation="False"
                            OnClick="btn_EditCurrency_Cancel_Click" /><br />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

