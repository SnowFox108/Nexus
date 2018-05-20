<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MailTest.ascx.cs" Inherits="User_Files_WebUserControls_MailTest" %>

<asp:Label ID="lbl_Msg" runat="server" ForeColor="Red"></asp:Label>

<table>
    <tr>
        <td>
            Mail Address</td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Please enter an email address. &lt;br/&gt;" 
                ControlToValidate="tbx_Mail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="tbx_Mail" 
                ErrorMessage="Please enter a valid email address. &lt;br/&gt;" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:TextBox ID="tbx_Mail" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Mail Message</td>
        <td>
            <asp:TextBox ID="tbx_Msg" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            </td>
        <td>
            <asp:Button ID="btn_Submit" runat="server" Text="Send" 
                onclick="btn_Submit_Click" />
        </td>
    </tr>
</table>

