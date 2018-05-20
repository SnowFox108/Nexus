<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login_Advanced.ascx.cs" Inherits="Nexus.Controls.Login.Login.Advanced" ClassName="Nexus.Controls.Login.Login.Login_Advanced" %>

<asp:MultiView ID="MultiView_Login" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify login options.</div>
    </asp:View>
    <asp:View ID="View_Login" runat="server">
        Login (Demo Only)
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary_SignUp" runat="server" ValidationGroup="Nexus_Control_Login" />
                </td>
            </tr>
            <tr>
                <td>
                    <font color="red">*</font> Email:
                </td>
                <td>
                    <asp:TextBox ID="tbx_Email" runat="server" ValidationGroup="Nexus_Control_Login"
                        MaxLength="150" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbx_Email" Display="Dynamic" 
                        ErrorMessage="Please enter your email." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tbx_Email" Display="Dynamic" 
                        ErrorMessage="Please enter a valid email." 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="Nexus_Control_Login">*</asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator_Email" runat="server" 
                        ControlToValidate="tbx_Email" Display="Dynamic" 
                        ErrorMessage="The email has not been registed." 
                        OnServerValidate="CustomValidator_Email_ServerValidate" 
                        ValidationGroup="Nexus_Control_Login">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <font color="red">*</font> Password:
                </td>
                <td>
                    <asp:TextBox ID="tbx_Password" runat="server" ValidationGroup="Nexus_Control_Login"
                        MaxLength="40" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="tbx_Password" Display="Dynamic" 
                        ErrorMessage="Please enter your password." 
                        ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator_Password" runat="server" 
                        ErrorMessage="Login failed, email or password is incorrect." 
                        onservervalidate="CustomValidator_Password_ServerValidate">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="chkbox_RememberMe" runat="server" 
                        Text="Remember this computer." />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btn_Submit" runat="server" Text="Login"
                        ValidationGroup="Nexus_Control_Login" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
