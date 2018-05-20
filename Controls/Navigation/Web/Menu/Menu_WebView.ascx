<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu_WebView.ascx.cs"
    Inherits="Nexus.Controls.Navigation.Menu.WebView" ClassName="Nexus.Controls.Navigation.Menu.Menu_WebView" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <telerik:RadTabStrip ID="RadTabStrip_Menu" runat="server">
        </telerik:RadTabStrip>
    </asp:View>
    <asp:View ID="View_New" runat="server">
    </asp:View>
</asp:MultiView>