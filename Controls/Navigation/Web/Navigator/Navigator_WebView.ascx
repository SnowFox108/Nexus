﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigator_WebView.ascx.cs" Inherits="Nexus.Controls.Navigation.Navigator.WebView" ClassName="Nexus.Controls.Navigation.Navigator.Navigator_WebView" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:Panel ID="Panel_Navigator" runat="server">
            <asp:PlaceHolder ID="PlaceHolder_Navigator" runat="server"></asp:PlaceHolder>
        </asp:Panel>
    </asp:View>
    <asp:View ID="View_New" runat="server">
    </asp:View>
</asp:MultiView>