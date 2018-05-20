<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateUser_WebView.ascx.cs"
    Inherits="Nexus.Controls.Login.CreateUser.WebView" ClassName="Nexus.Controls.Login.CreateUser.CreateUser_WebView" %>
<telerik:RadAjaxPanel ID="AjaxPanel" runat="server">
    <asp:MultiView ID="MultiView_SignUp" runat="server">
        <asp:View ID="View_New" runat="server">
        </asp:View>
        <asp:View ID="View_SignUp" runat="server">
            Sign up
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary_SignUp" runat="server" ValidationGroup="Nexus_Control_Login" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="red">*</font> User name:
                    </td>
                    <td>
                        <asp:TextBox ID="tbx_UserName" runat="server" ValidationGroup="Nexus_Control_Login"
                            MaxLength="40" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_UserName"
                            Display="Dynamic" ErrorMessage="Please enter your user name." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator_UserName" runat="server" ControlToValidate="tbx_UserName"
                            Display="Dynamic" ErrorMessage="The user name has been used by another account."
                            OnServerValidate="CustomValidator_UserName_ServerValidate" ValidationGroup="Nexus_Control_Login">*</asp:CustomValidator>
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
                            Display="Dynamic" ErrorMessage="The email has been registed." OnServerValidate="CustomValidator_Email_ServerValidate"
                            ValidationGroup="Nexus_Control_Login">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="red">*</font> Confirm email:
                    </td>
                    <td>
                        <asp:TextBox ID="tbx_EmailConfirm" runat="server" ValidationGroup="Nexus_Control_Login"
                            MaxLength="150" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbx_EmailConfirm"
                            Display="Dynamic" ErrorMessage="Please enter your confirm email." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbx_Email"
                            ControlToValidate="tbx_EmailConfirm" Display="Dynamic" ErrorMessage="Your confirm email is different."
                            ValidationGroup="Nexus_Control_Login">*</asp:CompareValidator>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbx_Password"
                            Display="Dynamic" ErrorMessage="Password must be between 8 and 12 characters, contain at least one digit and one alphabetic character, and must not contain special characters."
                            ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,20})$" ValidationGroup="Nexus_Control_Login">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="red">*</font> Confirm password
                    </td>
                    <td>
                        <asp:TextBox ID="tbx_PasswordConfirm" runat="server" ValidationGroup="Nexus_Control_Login"
                            MaxLength="40" Width="200px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbx_PasswordConfirm"
                            Display="Dynamic" ErrorMessage="Please enter your confirm password." ValidationGroup="Nexus_Control_Login">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbx_Password"
                            ControlToValidate="tbx_PasswordConfirm" Display="Dynamic" ErrorMessage="Your confirm password is different."
                            ValidationGroup="Nexus_Control_Login">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btn_Submit" runat="server" Text="Sign up" OnClick="btn_Submit_Click"
                            ValidationGroup="Nexus_Control_Login" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View_Succeed" runat="server">
            <asp:Literal ID="Literal_SuccessfulText" runat="server"></asp:Literal>
        </asp:View>
    </asp:MultiView>
</telerik:RadAjaxPanel>
