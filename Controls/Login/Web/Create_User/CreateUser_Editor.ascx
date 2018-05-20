<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateUser_Editor.ascx.cs" Inherits="Nexus.Controls.Login.CreateUser.Editor" ClassName="Nexus.Controls.Login.CreateUser.CreateUser_Editor" %>

Login Properties
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Successfully registed page:</td>
            <td>
                <asp:RadioButtonList ID="rbtn_DisplayResult" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="True">Successful Text</asp:ListItem>
                    <asp:ListItem Value="False">Redirect Page</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Successful redirect URL:</td>
            <td>
                <asp:TextBox ID="tbx_SuccessfulURL" runat="server" MaxLength="400" 
                    Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Successful Text:</td>
            <td>
                <telerik:RadEditor ID="RadEditor_SuccessfulText" Runat="server">
                </telerik:RadEditor>
            </td>
        </tr>
    </table>

 User Group Properties
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Default registed user group:
            </td>
            <td>
                <asp:DropDownList ID="droplist_UserGroup" runat="server" CssClass="txt_area">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"/>
</div>


