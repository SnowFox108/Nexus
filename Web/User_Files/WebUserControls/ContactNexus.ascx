<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactNexus.ascx.cs" Inherits="User_Files_WebUserControls_ContactNexus" %>
<style type="text/css">
    .style2
    {
        text-align: right;
        width: 190px;
    }
</style>
<asp:MultiView ID="MultiView_EnquiryForm" runat="server">
    <asp:View ID="View_Form" runat="server">
        <table cellpadding="5" cellspacing="5">
            <tr>
                <th colspan="2" align="left">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="EnquiryForm" />
                </th>
            </tr>
            <tr>
                <th class="style2">
                    First Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Please enter your first name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_FirstName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_FirstName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style2">
                    Last Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Please enter your last name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_LastName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_LastName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style2">
                    Email Address *:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server" ErrorMessage="Please enter your Email." ValidationGroup="EnquiryForm"
                        ControlToValidate="tbx_Email">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid Email."
                        ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        Display="Dynamic">*</asp:RegularExpressionValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Email" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style2">
                    Telephone No *:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Please enter your Telephone No." ValidationGroup="EnquiryForm"
                        ControlToValidate="tbx_Telephone">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Telephone" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style2">
                    Enquiry Subject *:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="Please enter enquiry subject." ValidationGroup="EnquiryForm" ControlToValidate="tbx_Subject">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Subject" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th valign="top" class="style2">
                    Your Enquiry *:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="Please enter your enquiry." ValidationGroup="EnquiryForm" ControlToValidate="tbx_Enquiry">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Enquiry" runat="server" ValidationGroup="EnquiryForm" MaxLength="2500"
                        Rows="15" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style2">
                    &nbsp;
                </th>
                <td>
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                        ValidationGroup="EnquiryForm" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View_Submit" runat="server">
    <h1>Thank you for your enquiry, we will contact you shortly.</h1>
    </asp:View>
</asp:MultiView>
