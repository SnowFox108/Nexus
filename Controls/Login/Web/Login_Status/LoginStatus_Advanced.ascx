<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginStatus_Advanced.ascx.cs" Inherits="Nexus.Controls.Login.LoginStatus.Advanced" ClassName="Nexus.Controls.Login.LoginStatus.LoginStatus_Advanced" %>
<asp:MultiView ID="MultiView_Status" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify login status options.</div>
    </asp:View>
    <asp:View ID="View_Login" runat="server">
        <asp:LinkButton ID="lbtn_Login" runat="server">Login</asp:LinkButton>
    </asp:View>
    <asp:View ID="View_Logout" runat="server">
        <asp:LinkButton ID="lbtn_Logout" runat="server">Logout</asp:LinkButton></asp:View>
</asp:MultiView>
