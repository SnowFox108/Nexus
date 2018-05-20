<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CTC_WinATicket.ascx.cs" Inherits="User_Files_WebUserControls_CTC_WinATicket" %>
<table border="0" cellspacing="0" cellpadding="0" width="95%">
    <tr>
        <td>
            <asp:MultiView ID="mvWinAticket" runat="server">
                <asp:View ID="viewForm" runat="server">
                    <table cellspacing="5">
                        <tr>
                            <td colspan="2">
                                <asp:ValidationSummary ID="vsWinATicket" runat="server" ValidationGroup="WinATicket" />
                            </td>
                        </tr>
                        <tr>
                            <td>Title
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTitle" runat="server">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                    <asp:ListItem>Miss</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Firstname
                            </td>
                            <td>
                                <asp:TextBox ID="tbxFirstname" runat="server" ValidationGroup="WinATicket" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a firstname." ControlToValidate="tbxFirstname" ValidationGroup="WinATicket">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Lastname
                            </td>
                            <td>
                                <asp:TextBox ID="tbxLastname" runat="server" ValidationGroup="WinATicket" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a lastname." ControlToValidate="tbxLastname" ValidationGroup="WinATicket">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Postcode
                            </td>
                            <td>
                                <asp:TextBox ID="tbxPostcode" runat="server" ValidationGroup="WinATicket" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a postcode." ControlToValidate="tbxPostcode" ValidationGroup="WinATicket">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Email
                            </td>
                            <td>
                                <asp:TextBox ID="tbxEmail" runat="server" ValidationGroup="WinATicket" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a email address." ControlToValidate="tbxEmail" ValidationGroup="WinATicket">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid email address." ControlToValidate="tbxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="WinATicket">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile Phone
                            </td>
                            <td>
                                <asp:TextBox ID="tbxMobile" runat="server" ValidationGroup="WinATicket" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please accept our terms and condition" ControlToValidate="tbxMobile" ValidationGroup="WinATicket">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkAccept" runat="server" Text="Accept" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="tbxFirstname" ErrorMessage="Please accept our terms and conditions." OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="WinATicket">*</asp:CustomValidator>
                                <p>
                                    By ticking this box you understand and agree to accept all the <a href="/Win-A-Ticket/Terms-and-Conditions.aspx" target="_blank">terms and conditions and privacy policy</a> issues. By registering with TRAVELCENTRECLAPHAM.COM you agree to receive information from TRAVELCENTRECLAPHAM.COM only, your details will not be passed on to 3rd parties. A 2-part password will be communicated to winner, first part by email and second part by text. You can opt-out from these communications at anytime.
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align:right;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="WinATicket" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="viewSubmit" runat="server">
                    <p>
                        Thank for registering your details, you have now entered the draw. You will also receive a &pound;20 voucher shortly by email.
                    </p>
                    <p>
                        Good luck!
                    </p>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
</table>
