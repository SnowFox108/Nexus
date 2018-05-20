<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CTC_EnquiryForm_CN.ascx.cs" Inherits="User_Files_WebUserControls_CTC_EnquiryForm_CN" %>
<table border="0" cellspacing="0" cellpadding="0" width="300px">
    <tr>
        <td style="background-color: #004C85">
            <img src="/User_Files/Template_Images/TravelCentre/spacer.gif" height="14"
                alt="">
        </td>
    </tr>
    <tr>
        <td bgcolor="#E1F3FB" align="left">
            <asp:MultiView ID="MultiView_EnquiryForm" runat="server">
                <asp:View ID="View_Form" runat="server">
                    <table width="100%" border="0" cellspacing="15" cellpadding="0">
                        <tr>
                            <td>
                                <h2>您的旅行信息</h2>
                                <p>請告訴我們您的旅行計劃，我們會竭盡全力為您找到性價比最好的價格</p>
                                <div style="margin-left: 15px;">
                                    <asp:ValidationSummary ID="ValidationSummary_Enquiry" runat="server" ValidationGroup="EnquiryForm" />
                                </div>
                                <table>
                                    <tr>
                                        <td>特價類型:</td>
                                        <td>
                                            <asp:Label ID="lbl_OfferType" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="100px">目的地:</td>
                                        <td>
                                            <asp:TextBox ID="tbx_Destination" runat="server" MaxLength="150" Width="120px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Destination" runat="server" ErrorMessage="請填寫您的目的地" ControlToValidate="tbx_Destination" ValidationGroup="EnquiryForm">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>離境日期:</td>
                                        <td>
                                            <telerik:RadDatePicker ID="RadDatePicker_Departure" runat="server" Width="120px">
                                            </telerik:RadDatePicker>
                                            <asp:CustomValidator ID="CustomValidator_Departure" runat="server" ErrorMessage="" ControlToValidate="tbx_Destination" ValidationGroup="EnquiryForm" OnServerValidate="CustomValidator_Departure_ServerValidate">*</asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>回程日期:</td>
                                        <td>
                                            <telerik:RadDatePicker ID="RadDatePicker_ReturnDate" runat="server" Width="120px">
                                            </telerik:RadDatePicker>
                                            <asp:CustomValidator ID="CustomValidator_ReturnDate" runat="server" ErrorMessage="" ControlToValidate="tbx_Destination" ValidationGroup="EnquiryForm" OnServerValidate="CustomValidator_ReturnDate_ServerValidate">*</asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                                <h2>詳細信息</h2>
                                <div>
                                    旅行人數:
    <asp:DropDownList ID="droplist_NoPassenger" runat="server" AutoPostBack="True" Width="40px" OnSelectedIndexChanged="droplist_NoPassenger_SelectedIndexChanged">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem Selected="True">2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
    </asp:DropDownList>
                                </div>
                                <asp:PlaceHolder ID="PlaceHolder_Passenger" runat="server"></asp:PlaceHolder>
                                <table>
                                    <tr>
                                        <td width="100px">電話/手機:</td>
                                        <td>
                                            <asp:TextBox ID="tbx_Mobile" runat="server" MaxLength="50" Width="120px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Mobile" runat="server" ErrorMessage="請填寫您的電話" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Mobile">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Email:</td>
                                        <td>
                                            <asp:TextBox ID="tbx_Email" runat="server" MaxLength="100" Width="120px" ValidationGroup="EnquiryForm"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="請填寫您的Email" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server" ErrorMessage="請填寫一個有效的Email地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="EnquiryForm" ControlToValidate="tbx_Email">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">留言:</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbx_Message" runat="server" TextMode="MultiLine" MaxLength="450" Rows="5" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: right">
                                    <asp:Button ID="btn_Submit" runat="server" Text="發送" ValidationGroup="EnquiryForm" OnClick="btn_Submit_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>

                </asp:View>
                <asp:View ID="View_Submit" runat="server">
                    <table width="100%" border="0" cellspacing="15" cellpadding="0">
                        <tr>
                            <td>
                                <h2>謝謝您提交的信息， 我們富有經驗的員工很快就會處理您的請求。請靜候我們的電子郵件。謝謝。</h2>
                            </td>
                        </tr>
                    </table>

                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    <tr>
        <td style="background-color: #004C85">
            <img src="/User_Files/Template_Images/TravelCentre/spacer.gif" height="14"
                alt="">
        </td>
    </tr>
</table>
