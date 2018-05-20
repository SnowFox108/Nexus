<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Nexus.Core.App_AdminCP_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e2CMS Login</title>
</head>
<body>
    <form id="form1" runat="server">
    Login<br />
    <h2>
        <asp:Label ID="lbl_ErrorText" runat="server" ForeColor="Red"></asp:Label></h2>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_Email"
                    Display="Dynamic" ErrorMessage="Please enter your email." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_Email"
                    Display="Dynamic" ErrorMessage="Please enter a valid email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="Nexus_Control_Login">*</asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator_Email" runat="server" ControlToValidate="tbx_Email"
                    Display="Dynamic" ErrorMessage="The email has not been registed." OnServerValidate="CustomValidator_Email_ServerValidate"
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbx_Password"
                    Display="Dynamic" ErrorMessage="Please enter your password." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator_Password" runat="server" ErrorMessage="Login failed, email or password is incorrect."
                    OnServerValidate="CustomValidator_Password_ServerValidate" ValidationGroup="Nexus_Control_Login">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:CheckBox ID="chkbox_RememberMe" runat="server" Text="Remember this computer." />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btn_Submit" runat="server" Text="Login" OnClick="btn_Submit_Click"
                    ValidationGroup="Nexus_Control_Login" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
