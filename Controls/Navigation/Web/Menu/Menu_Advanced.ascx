<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu_Advanced.ascx.cs" Inherits="Nexus.Controls.Navigation.Menu.Advanced" ClassName="Nexus.Controls.Navigation.Menu.Menu_Advanced" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <telerik:RadTabStrip ID="RadTabStrip_Menu" runat="server" ViewStateMode="Disabled">
        </telerik:RadTabStrip>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to config Menu.</div>
    </asp:View>
</asp:MultiView>