﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginView_WebView.ascx.cs" Inherits="Nexus.Controls.Login.LoginView.WebView" ClassName="Nexus.Controls.Login.LoginView.LoginView_WebView" %>
<asp:Label ID="lbl_UserName" runat="server"></asp:Label>
<asp:MultiView ID="MultiView_Status" runat="server">
    <asp:View ID="View_New" runat="server">
    </asp:View>
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
