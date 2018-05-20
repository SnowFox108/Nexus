<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FreeTrial.ascx.cs" Inherits="User_Files_WebUserControls_FreeTrial" %>

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
                <th style="text-align:right;">
                    First Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Please enter your first name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_FirstName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_FirstName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Last Name *:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Please enter your last name." ValidationGroup="EnquiryForm" ControlToValidate="tbx_LastName">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_LastName" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
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
                <th style="text-align: right">
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
                <th style="text-align: right">
                    Company *:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="Please enter your Company name." ValidationGroup="EnquiryForm"
                        ControlToValidate="tbx_Company">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Company" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Employees *:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="Please select your number of employees." ValidationGroup="EnquiryForm"
                        ControlToValidate="drop_Employees" InitialValue="0">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:DropDownList ID="drop_Employees" runat="server" 
                        ValidationGroup="EnquiryForm">
                        <asp:ListItem Value="0">-- Select One --</asp:ListItem>
                        <asp:ListItem Value="1">Sole Proprietor</asp:ListItem>
                        <asp:ListItem Value="3">2 - 3 employees</asp:ListItem>
                        <asp:ListItem Value="17">4 - 17 employees</asp:ListItem>
                        <asp:ListItem Value="80">18 - 80 employees</asp:ListItem>
                        <asp:ListItem Value="425">81 - 425 employees</asp:ListItem>
                        <asp:ListItem Value="2000">426 - 2,000 employees</asp:ListItem>
                        <asp:ListItem Value="3000">> 2,000 employees</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Postal code *:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ErrorMessage="Please enter your Telephone No." ValidationGroup="EnquiryForm"
                        ControlToValidate="tbx_Postcode">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Postcode" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    How did you find us? *:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ErrorMessage="Please tell us how did you find us?" ValidationGroup="EnquiryForm"
                        ControlToValidate="tbx_Findus">*</asp:RequiredFieldValidator>
                </th>
                <td>
                    <asp:TextBox ID="tbx_Findus" runat="server" ValidationGroup="EnquiryForm" MaxLength="250"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
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
