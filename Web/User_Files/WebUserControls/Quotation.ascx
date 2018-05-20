<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Quotation.ascx.cs" Inherits="User_Files_WebUserControls_Quotation" %>
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
                    <strong>Which type of website would you like? </strong>
                    <asp:RadioButtonList ID="rbtn_ProjectType" runat="server">
                        <asp:ListItem Selected="True">A basic &quot;brochure-style&quot; site.</asp:ListItem>
                        <asp:ListItem>An e-commerce site/online shop.</asp:ListItem>
                        <asp:ListItem>A content management system.</asp:ListItem>
                        <asp:ListItem>Other type of advanced, feature-rich site.</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <strong>How much do you have available to invest into your website? </strong>
                    <asp:RadioButtonList ID="rbtn_Budget" runat="server">
                        <asp:ListItem Value="Under £500">Under &amp;pound;500</asp:ListItem>
                        <asp:ListItem Value="£500 to £1,000">&amp;pound;500 to &amp;pound;1,000</asp:ListItem>
                        <asp:ListItem Selected="True" Value="£1,000 to £2,500">&amp;pound;1,000 to &amp;pound;2,500</asp:ListItem>
                        <asp:ListItem Value="£2,500 to £5,000">&amp;pound;2,500 to &amp;pound;5,000</asp:ListItem>
                        <asp:ListItem Value="Over £5,000">Over &amp;pound;5,000</asp:ListItem>
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
