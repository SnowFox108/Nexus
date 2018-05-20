<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnquiryForm.ascx.cs" Inherits="User_Files_WebUserControls_EnquiryForm" %>
<style type="text/css">
    .style1
    {
        text-align: right;
    }
</style>
<asp:MultiView ID="MultiView_EnquiryForm" runat="server">
    <asp:View ID="View_Form" runat="server">
        <table cellpadding="5" cellspacing="5">
            <tr>
                <th colspan="2" align="left">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="EnquiryForm" />
                </th>
            </tr>
            <tr>
                <th colspan="2" align="left" style="background-color: #cbe8c9">
                    <h2>
                        About Your Project</h2>
                </th>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>Choose your Design Option.</strong>
                    <asp:RadioButtonList ID="rbtn_DesignOption" runat="server">
                        <asp:ListItem Selected="True" Value="DO1">Design Option 1</asp:ListItem>
                        <asp:ListItem Value="DO2">Design Option 2</asp:ListItem>
                        <asp:ListItem Value="DO3">Design Option 3</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>Choose your montly service plan.</strong>
                    <asp:RadioButtonList ID="rbtn_MonthlyService" runat="server">
                        <asp:ListItem Value="SO1">SO1 (&amp;pound;4.99)</asp:ListItem>
                        <asp:ListItem Value="SO2">SO2 (&amp;pound;9.99)</asp:ListItem>
                        <asp:ListItem Value="SO3" Selected="True">SO3 (&amp;pound;14.99)</asp:ListItem>
                        <asp:ListItem Value="SO4">SO4 (&amp;pound;25)</asp:ListItem>
                        <asp:ListItem Value="SO5">SO5 (&amp;pound;49)</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>Summarise your project in a few words *</strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter summariy of your project."
                        ValidationGroup="EnquiryForm" ControlToValidate="tbx_Subject">*</asp:RequiredFieldValidator>
                    <br />
                    E.g: "Website needed to sell books."
                    <br />
                    <asp:TextBox ID="tbx_Subject" runat="server" ValidationGroup="EnquiryForm" MaxLength="400"
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>Describe in detail what you do and what you need *</strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your project details."
                        ValidationGroup="EnquiryForm" ControlToValidate="tbx_Enquiry">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="tbx_Enquiry" runat="server" ValidationGroup="EnquiryForm" MaxLength="4000"
                        Rows="15" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>Are there any sites on the Web that are similar to what you are looking for?</strong>
                    <br />
                    Please enter their website addresses bleow:
                    <br />
                    <asp:TextBox ID="tbx_SimilarWebsite" runat="server" ValidationGroup="EnquiryForm"
                        MaxLength="2500" Rows="10" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="2" align="left" style="background-color: #cbe8c9">
                    <h2>
                        Your Contact Information</h2>
                </th>
            </tr>
            <tr>
                <th class="style1">
                    First Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Please enter your first name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_FirstName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_FirstName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style1">
                    Last Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Please enter your last name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_LastName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_LastName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style1">
                    Email Address *:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Please enter your Email." ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid Email."
                        ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic">*</asp:RegularExpressionValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Email" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="style1">
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
                <th class="style1">
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
        <h1>
            Thank you for your enquiry, we will contact you shortly.</h1>
    </asp:View>
</asp:MultiView>
