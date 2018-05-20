<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginStatus_WebView.ascx.cs" Inherits="Nexus.Controls.Login.LoginStatus.WebView" ClassName="Nexus.Controls.Login.LoginStatus.LoginStatus_WebView" %>
<asp:MultiView ID="MultiView_Status" runat="server">
    <asp:View ID="View_New" runat="server">
    </asp:View>
    <asp:View ID="View_Login" runat="server">
        <asp:LinkButton ID="lbtn_Login" runat="server" onclick="lbtn_Login_Click">Login</asp:LinkButton>
    </asp:View>
    <asp:View ID="View_Logout" runat="server">
        <asp:LinkButton ID="lbtn_Logout" runat="server" onclick="lbtn_Logout_Click">Logout</asp:LinkButton></asp:View>
</asp:MultiView>
