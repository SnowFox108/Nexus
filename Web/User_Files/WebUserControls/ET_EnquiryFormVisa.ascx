<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ET_EnquiryFormVisa.ascx.cs" Inherits="User_Files_WebUserControls_ET_EnquiryFormVisa" %>
<div class="shopping_detail1">
    <div class="itemdetail">
        <h2>簽證查詢</h2>
        <div class="ebayitem">
            <div class="description">
                <asp:MultiView ID="MultiView_EnquiryForm" runat="server">
                    <asp:View ID="View_Form" runat="server">
                        <h3>請填入以下聯絡資料，我們將有職員與您聯繫</h3>
                        <table style="border-collapse: separate; border-spacing: 5px;">
                            <tbody>
                                <tr>
                                    <th style="text-align: right; width:100px;">姓名:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbx_Name" runat="server" MaxLength="150" Width="200px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ErrorMessage="請填入姓名" ControlToValidate="tbx_Name" ValidationGroup="EnquiryForm"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="text-align: right;">電話:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbx_Mobile" runat="server" MaxLength="50" Width="200px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Mobile" runat="server" ErrorMessage="請填入電話" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Mobile"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="text-align: right;">電郵:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbx_Email" runat="server" MaxLength="100" Width="200px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="請填入電郵" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server" ErrorMessage="Please enter a valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="text-align: right;">擬入境日期:
                                    </th>
                                    <td>
                                        <telerik:RadDatePicker ID="RadDatePicker_Departure" runat="server" Width="200px">
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        <asp:CustomValidator ID="CustomValidator_Departure" runat="server" ErrorMessage="" ControlToValidate="tbx_Name" ValidationGroup="EnquiryForm" OnServerValidate="CustomValidator_Departure_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th style="text-align: right; vertical-align: top;">信息:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbx_Message" runat="server" TextMode="MultiLine" MaxLength="450" Rows="5" Width="200px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th></th>
                                    <td style="text-align: right;">
                                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="EnquiryForm" OnClick="btn_Submit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:View>
                    <asp:View ID="View_Submit" runat="server">
                        <h3>謝謝，您的查詢電郵已經成功發出，我社職員將會盡快聯繫您</h3>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <div class="clr">
    </div>
</div>
