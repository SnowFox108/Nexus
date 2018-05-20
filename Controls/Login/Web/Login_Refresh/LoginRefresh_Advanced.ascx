<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginRefresh_Advanced.ascx.cs" Inherits="Nexus.Controls.Login.LoginRefresh.Advanced" ClassName="Nexus.Controls.Login.LoginRefresh.LoginRefresh_Advanced" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify options.</div>
    </asp:View>
    <asp:View ID="View_Show" runat="server">
        <p>
            If your Browser do not return to the page, please click here
            <asp:Label ID="lbl_ReturnLink" runat="server"></asp:Label></p>
    </asp:View>
</asp:MultiView>