<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RequestDemo.ascx.cs" Inherits="User_Files_WebUserControls_RequestDemo" %>

<asp:MultiView ID="MultiView_EnquiryForm" runat="server">
    <asp:View ID="View_Form" runat="server">
        <table cellpadding="5" cellspacing="5" width="100%" border="0">
            <tr>
                <th colspan="2" align="left" style="background-color: #cbe8c9">
                    <h2>
                        Get a Free Demo</h2>
                </th>
            </tr>
            <tr>
                <th colspan="2" align="left">
                    We’re happy to give you a free demonstration of our specialist e2CMS system. We
                    can discuss your requirements in full – don’t worry, there won’t be any pushy sales
                    pitch! If you’re based in London, then we’ll be happy to pay you a visit. If you
                    are further afield, then we’ll happily carry out an online demonstration.
                </th>
            </tr>
            <tr>
            <th style="text-align: right; min-width:90px;">Location :</th>
            <td>
                <asp:DropDownList ID="droplist_Location" runat="server" 
                    ValidationGroup="RequestDemo" Width="170px">
                    <asp:ListItem Selected="True">London</asp:ListItem>
                    <asp:ListItem>Outside London</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    First Name :</th>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbx_FirstName" Display="Dynamic" 
                        ErrorMessage="Please enter your first name.<br />" ValidationGroup="RequestDemo"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbx_FirstName" runat="server" ValidationGroup="RequestDemo" MaxLength="250"
                        Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Last Name :</th>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbx_LastName" Display="Dynamic" 
                        ErrorMessage="Please enter your last name.<br />" ValidationGroup="RequestDemo"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbx_LastName" runat="server" ValidationGroup="RequestDemo" MaxLength="250"
                        Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Email Address :</th>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tbx_Email" Display="Dynamic" 
                        ErrorMessage="Please enter your Email.<br />" ValidationGroup="RequestDemo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tbx_Email" Display="Dynamic" 
                        ErrorMessage="Please enter a valid Email. <br />" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="RequestDemo"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="tbx_Email" runat="server" ValidationGroup="RequestDemo" MaxLength="250"
                        Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    Telephone No :</th>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="tbx_Telephone" Display="Dynamic" 
                        ErrorMessage="Please enter your Telephone No. <br />" ValidationGroup="RequestDemo"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbx_Telephone" runat="server" ValidationGroup="RequestDemo" MaxLength="250"
                        Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th style="text-align: right">
                    &nbsp;
                </th>
                <td>
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                        ValidationGroup="RequestDemo" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View_Submit" runat="server">
        <h1>
            Thank you for your enquiry, we will contact you shortly.</h1>
    </asp:View>
</asp:MultiView>
