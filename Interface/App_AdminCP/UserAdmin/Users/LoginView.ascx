<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginView.ascx.cs" Inherits="Nexus.Core.App_AdminCP_UserAdmin_Users_LoginView" %>
<asp:Label ID="lbl_UserName" runat="server"></asp:Label>
<asp:MultiView ID="MultiView_Status" runat="server">
    <asp:View ID="View_Login" runat="server">
        (
        <asp:LinkButton ID="lbtn_Login" runat="server" OnClick="lbtn_Login_Click">Login</asp:LinkButton>
        )
    </asp:View>
    <asp:View ID="View_Logout" runat="server">
        (
        <asp:LinkButton ID="lbtn_Logout" runat="server" OnClick="lbtn_Logout_Click">Logout</asp:LinkButton>
        )
    </asp:View>
</asp:MultiView>
