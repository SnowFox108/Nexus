<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SIH_ContactUs.ascx.cs" Inherits="User_Files_WebUserControls_SIH_ContactUs" %>
<div style="padding: 10px;">
    <asp:MultiView ID="mvContactUs" runat="server">
        <asp:View ID="viewForm" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right;"></td>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ContactUs" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请填写您的姓名" ControlToValidate="tbxName" ValidationGroup="ContactUs">*</asp:RequiredFieldValidator>
                        姓名：</td>
                    <td>
                        <asp:TextBox ID="tbxName" runat="server" ValidationGroup="ContactUs" Width="250px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请填写您的QQ号码" ControlToValidate="tbxQQ" ValidationGroup="ContactUs">*</asp:RequiredFieldValidator>
                        QQ号码：</td>
                    <td>
                        <asp:TextBox ID="tbxQQ" runat="server" ValidationGroup="ContactUs" Width="250px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right;">电话：</td>
                    <td>
                        <asp:TextBox ID="tbxTel" runat="server" ValidationGroup="ContactUs" Width="250px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right; vertical-align: top;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请填写您的留言" ControlToValidate="tbxMsg" ValidationGroup="ContactUs">*</asp:RequiredFieldValidator>
                        您的留言：</td>
                    <td>
                        <asp:TextBox ID="tbxMsg" runat="server" ValidationGroup="ContactUs" Rows="10" Width="450px" TextMode="MultiLine" MaxLength="2000"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; padding: 10px; text-align: right;"></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="联系我们" ValidationGroup="ContactUs" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewSubmitted" runat="server">
            <div style="text-align:center;">
                <h3>感谢您的联系, 我们会尽快回复您的</h3>
            </div>
        </asp:View>
    </asp:MultiView>
</div>

