<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMetaTag.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageMetaTag" %>
<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Global_Page_Scripts" runat="server">
        <h3>
            Global JavaScripts</h3>
        <asp:GridView ID="GridView_GlobalScripts" Enabled="false" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Script URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ScriptURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="Script URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no CSS.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
</div>

<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Page_Scripts" runat="server">        
        <h3>
            Page JavaScripts</h3>
        Script URL :
        <asp:TextBox ID="tbx_ScriptURL" runat="server" MaxLength="300" Width="450px" ValidationGroup="AddScript"></asp:TextBox>
        <asp:Button ID="btn_AddScript" runat="server" Text="Add Script" SkinID="e2CMS_Button"
            ValidationGroup="AddScript" onclick="btn_AddScript_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Script" runat="server" ErrorMessage="Please enter script URL."
            ControlToValidate="tbx_ScriptURL" ValidationGroup="AddScript"></asp:RequiredFieldValidator>
        <asp:GridView ID="GridView_Scripts" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Script URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ScriptURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="Script URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel_PrivacyCommand" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbtn_Script_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit" CommandArgument='<%# Bind("MetaTagID") %>' OnCommand="lbtn_Script_Edit_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                <asp:LinkButton ID="lbtn_Script_Delete" runat="server" CausesValidation="False" Text="Delete"
                                    CommandArgument='<%# Eval("MetaTagID") %>' OnCommand="lbtn_Script_Delete_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lbtn_Script_Edit" />
                                <asp:PostBackTrigger ControlID="lbtn_Script_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no Scripts.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="Panel_Update_Script" runat="server">
            Script URL :
            <asp:TextBox ID="tbx_UpdateScriptURL" runat="server" MaxLength="300" Width="450px"
                ValidationGroup="UpdateScript"></asp:TextBox>
            <asp:Button ID="btn_UpdateScript" runat="server" Text="Update Script" OnCommand="btn_UpdateScript_Command"
                SkinID="e2CMS_Button" ValidationGroup="UpdateScript" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Update_Script" runat="server"
                ErrorMessage="Please enter script URL." ControlToValidate="tbx_UpdateScriptURL"
                ValidationGroup="UpdateScript"></asp:RequiredFieldValidator>
        </asp:Panel>
    </asp:Panel>
</div>
<br class="clear" />

<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Global_Page_CSS" runat="server">
        <h3>
            Global CSS</h3>
        <asp:GridView ID="GridView_GlobalCSS" Enabled="false" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="CSS URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_CSSURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="CSS URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no CSS.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
</div>

<div class="nexusCore_panel_pageMetaTag">
    <asp:Panel ID="Panel_Page_CSS" runat="server">        
        <h3>
            Page CSS</h3>
        CSS URL :
        <asp:TextBox ID="tbx_CSSURL" runat="server" MaxLength="300" Width="450px" ValidationGroup="AddCSS"></asp:TextBox>
        <asp:Button ID="btn_AddCSS" runat="server" Text="Add CSS" SkinID="e2CMS_Button"
            ValidationGroup="AddCSS" onclick="btn_AddCSS_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_CSS" runat="server" ErrorMessage="Please enter CSS URL."
            ControlToValidate="tbx_CSSURL" ValidationGroup="AddCSS"></asp:RequiredFieldValidator>
        <asp:GridView ID="GridView_CSS" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="MetaTagID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="CSS URL" ItemStyle-CssClass="URL">
                    <ItemTemplate>
                        <asp:Label ID="lbl_CSSURL" runat="server" Text='<%# Bind("Meta_Src") %>' ToolTip="CSS URL"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel_PrivacyCommand" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbtn_CSS_Edit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit" CommandArgument='<%# Bind("MetaTagID") %>' OnCommand="lbtn_CSS_Edit_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                                <asp:LinkButton ID="lbtn_CSS_Delete" runat="server" CausesValidation="False" Text="Delete"
                                    CommandArgument='<%# Eval("MetaTagID") %>' OnCommand="lbtn_CSS_Delete_Command"
                                    SkinID="e2CMS_LinkButton"></asp:LinkButton>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lbtn_CSS_Edit" />
                                <asp:PostBackTrigger ControlID="lbtn_CSS_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                        <th>
                            There is no CSS.
                        </th>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="Panel_Update_CSS" runat="server">
            CSS URL :
            <asp:TextBox ID="tbx_UpdateCSSURL" runat="server" MaxLength="300" Width="450px"
                ValidationGroup="UpdateCSS"></asp:TextBox>
            <asp:Button ID="btn_UpdateCSS" runat="server" Text="Update CSS" OnCommand="btn_UpdateCSS_Command"
                SkinID="e2CMS_Button" ValidationGroup="UpdateCSS" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Update_CSS" runat="server"
                ErrorMessage="Please enter CSS URL." ControlToValidate="tbx_UpdateCSSURL"
                ValidationGroup="UpdateCSS"></asp:RequiredFieldValidator>
        </asp:Panel>
    </asp:Panel>
</div>
<br class="clear" />
