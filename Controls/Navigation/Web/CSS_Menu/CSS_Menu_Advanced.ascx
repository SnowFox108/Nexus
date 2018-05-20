<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CSS_Menu_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Navigation.CSS_Menu.Advanced" ClassName="Nexus.Controls.Navigation.CSS_Menu.CSS_Menu_Advanced" %>
<asp:MultiView ID="MultiView_Menu" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to config Menu.</div>
    </asp:View>
    <asp:View ID="View_Menu" runat="server">
        <asp:PlaceHolder ID="PlaceHolder_Menu" runat="server"></asp:PlaceHolder>
    </asp:View>
</asp:MultiView>