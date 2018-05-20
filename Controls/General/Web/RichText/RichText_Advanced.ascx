<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RichText_Advanced.ascx.cs" Inherits="Nexus.Controls.General.RichText.Advanced" ClassName="Nexus.Controls.General.RichText.RichText_Advanced" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:Literal ID="Literal_TextContent" runat="server"></asp:Literal>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to enter content.</div>
    </asp:View>
</asp:MultiView>