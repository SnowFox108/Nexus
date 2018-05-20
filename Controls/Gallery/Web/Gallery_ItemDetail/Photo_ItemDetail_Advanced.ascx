<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemDetail_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemDetail.Advanced" ClassName="Nexus.Controls.Gallery.ItemDetail.ItemDetail_Advanced" %>
    <asp:MultiView ID="MultiView_ItemDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Gallery Detail options.</div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
    <h2>Gallery Detial Templates</h2>
        <asp:Literal ID="Literal_ItemTemplate" runat="server"></asp:Literal>
    </asp:View>
</asp:MultiView>