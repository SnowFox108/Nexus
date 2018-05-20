<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Webmedia.ascx.cs" Inherits="Nexus.Shop.App_AdminCP_ShopAdmin_Products_Webmedia" %>
<div class="nexusCore_panel_productEditor">
    <h3>
        Web media
    </h3>
    <asp:Image ID="Img_Default_Photo" runat="server" Width="80px" />
    <div class="spliter"></div>
    <asp:MultiView ID="MultiView_WebMediaForm" runat="server">
        <asp:View ID="View_Form" runat="server">
            <table>
                <tr>
                    <th>
                        Media Type
                    </th>
                    <td>
                        <asp:DropDownList ID="droplist_Media_Type" Width="200px" runat="server" 
                            ValidationGroup="WebMediaForm">
                        </asp:DropDownList>                         

                    </td>
                </tr>
                <tr>
                    <th>
                        Media Title
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Media_Title" runat="server" MaxLength="400" ValidationGroup="WebMediaForm"
                            Width="195px"></asp:TextBox>
                        *
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_DisplayText" runat="server"
                            ErrorMessage="Please enter a Media Title." ControlToValidate="tbx_Media_Title"
                            ValidationGroup="WebMediaForm"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        URL
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_ImageURL" runat="server" Width="350px" ValidationGroup="WebMediaForm"
                            MaxLength="400"></asp:TextBox>
                        <asp:Button ID="btn_FileSelector" runat="server" ToolTip="Select a image file" Text="Select a File"
                            SkinID="e2CMS_Button" OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_ImageURL&FileTypes=Images'); return false;" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Description
                    </th>
                    <td>
                        <asp:TextBox ID="tbx_Description" runat="server" Rows="5" TextMode="MultiLine" 
                            Width="510px" ValidationGroup="WebMediaForm"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button ID="btn_Add_WebMedia" runat="server" Text="Create" SkinID="e2CMS_Button"
                            OnClick="btn_Add_WebMedia_Click" ValidationGroup="WebMediaForm" />
                        &nbsp;<asp:Button ID="btn_Update_WebMedia" runat="server" Text="Update" SkinID="e2CMS_Button"
                            OnCommand="btn_Update_WebMedia_Command" ValidationGroup="WebMediaForm" />
                        &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" SkinID="e2CMS_Button"
                            CausesValidation="False" OnClick="btn_Cancel_Click" 
                            ValidationGroup="WebMediaForm" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View_Button" runat="server">
            <asp:Button ID="btn_Show_AddForm" runat="server" Text="Add a Media" SkinID="e2CMS_Button"
                CausesValidation="False" OnClick="btn_Show_AddForm_Click" />
        </asp:View>
    </asp:MultiView>
    <br />
    <h3>
        Web Media List
    </h3>
    <telerik:radgrid id="RadGrid_WebMedia" runat="server" cellspacing="0" gridlines="None"
        skin="WebBlue" borderwidth="0px" onitemdatabound="RadGrid_WebMedia_ItemDataBound"
        onneeddatasource="RadGrid_WebMedia_NeedDataSource" onrowdrop="RadGrid_WebMedia_RowDrop">
                    <ClientSettings AllowRowsDragDrop="true"> 
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                    </ClientSettings> 
                    <mastertableview autogeneratecolumns="False" datakeynames="WebMediaID">
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                        <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                        </rowindicatorcolumn>
                        <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px">
                                <HeaderStyle Width="18px" />
                            </telerik:GridDragDropColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter Picture column" 
                                HeaderText="Preview" UniqueName="TemplateColumn_Picture">
                                <ItemTemplate>
                                    <asp:Image ID="img_ItemPicture" ImageUrl='<%# Eval("Default_PhotoURL") %>' Width="80px"
                                    runat="server" />                                
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Media_Title" 
                                FilterControlAltText="Filter Media_Title column" HeaderText="Media Title" 
                                ReadOnly="True" SortExpression="Media_Title" UniqueName="Media_Title">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Media_Type" 
                                FilterControlAltText="Filter Media_Type column" HeaderText="Type" 
                                ReadOnly="True" SortExpression="Media_Type" UniqueName="Media_Type">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter Media_Value column" 
                                HeaderText="URL" UniqueName="Media_Value">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxGrid_Media_Value" Text='<%# Eval("Media_Value") %>' runat="server" Rows="3" ReadOnly="True" Width="295px" TextMode="MultiLine"></asp:TextBox>                                    
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter Media_Description column" 
                                HeaderText="Description" UniqueName="Media_Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxGrid_Media_Description" Text='<%# Eval("Media_Description") %>' runat="server" Rows="3" ReadOnly="True" Width="295px" TextMode="MultiLine"></asp:TextBox>                                    
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                HeaderText="Actions" UniqueName="TemplateColumn_Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_Edit_Media" runat="server" CommandArgument='<%# Eval("WebMediaID")%>' 
                                        oncommand="lbtn_Edit_Media_Command">Edit</asp:LinkButton><br />
                                    <asp:LinkButton ID="lbtn_SetDefault_Media" runat="server" CommandArgument='<%# Eval("WebMediaID")%>' 
                                        oncommand="lbtn_SetDefault_Media_Command">Set as default</asp:LinkButton><br />
                                    <asp:LinkButton ID="lbtn_Delete_Media" runat="server" CommandArgument='<%# Eval("WebMediaID")%>' 
                                        oncommand="lbtn_Delete_Media_Command">Delete</asp:LinkButton>
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