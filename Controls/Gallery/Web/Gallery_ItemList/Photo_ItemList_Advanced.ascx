<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemList_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemList.Advanced" ClassName="Nexus.Controls.Gallery.ItemList.ItemList_Advanced" %>
    <asp:MultiView ID="MultiView_ItemDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Gallery List options.</div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
    <h2>Gallery List Templates</h2>
        <asp:Literal ID="Literal_ItemList" runat="server"></asp:Literal>
    </asp:View>
</asp:MultiView>