<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Nexus.Core.App_AdminCP_Login" StylesheetTheme="NexusCore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e2CMS Login</title>
</head>
<body class="nexusCore_loginPage_bg">
    <form id="form1" runat="server">
    <div id="nexusCore_wrapper">
        <div class="nexusCore_loginBox">
            <fieldset>
                <div class="nexusCore_login">
                    <p>
                        <asp:Label ID="lbl_ErrorText" runat="server" class="nexusCore_failure" Height="22"></asp:Label></p>
                    <p>
                        &nbsp;<asp:ValidationSummary ID="ValidationSummary_SignUp" runat="server" ValidationGroup="Nexus_Control_Login"
                            CssClass="nexusCore_validator" /></p>
                    <ol>
                        <li>
                            <p class="nexusCore_label">
                                <span class="nexusCore_star">*</span> Module:</p>
                            <asp:DropDownList ID="droplist_Module" runat="server" Width="205px">
                            </asp:DropDownList>
                        </li>
                        <li>
                            <p class="nexusCore_label">
                                <span class="nexusCore_star">*</span> Email:</p>
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
                        </li>
                        <li>
                            <p class="nexusCore_label">
                                <span class="nexusCore_star">*</span> Password:</p>
                            <asp:TextBox ID="tbx_Password" runat="server" ValidationGroup="Nexus_Control_Login"
                                MaxLength="40" Width="200px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbx_Password"
                                Display="Dynamic" ErrorMessage="Please enter your password." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator_Password" runat="server" ErrorMessage="Login failed, email or password is incorrect."
                                OnServerValidate="CustomValidator_Password_ServerValidate" ValidationGroup="Nexus_Control_Login">*</asp:CustomValidator>
                        </li>
                        <li>
                            <asp:CheckBox ID="chkbox_RememberMe" runat="server" Text="Remember this computer." />
                        </li>
                        <li class="nexusCore_btn_goRight">
                            <asp:Button ID="btn_Submit" runat="server" Text="Login" OnClick="btn_Submit_Click"
                                ValidationGroup="Nexus_Control_Login" SkinID="e2CMS_Button" CssClass="nexusCore_loginBtn" />
                        </li>
                    </ol>
                </div>
                <address class="nexusCore">
                    Copyright &copy; 2011 - 2012, e2Tech.co.uk. All rights reserved.</address>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
