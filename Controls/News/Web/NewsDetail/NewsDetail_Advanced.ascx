<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDetail_Advanced.ascx.cs"
    Inherits="Nexus.Controls.News.NewsDetail.Advanced" ClassName="Nexus.Controls.News.NewsDetail.NewsDetail_Advanced" %>
    <asp:MultiView ID="MultiView_NewsDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify News Detail options.</div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
    <h2>News Detail Templates</h2>
        <asp:Literal ID="Literal_NewsDetail" runat="server"></asp:Literal>
    <h2>Comment Title Templates</h2>
        <asp:Literal ID="Literal_CommentTitle" runat="server"></asp:Literal>
    <h2>Comment Templates</h2>
        <asp:Literal ID="Literal_Comment" runat="server"></asp:Literal>
    </asp:View>
</asp:MultiView>