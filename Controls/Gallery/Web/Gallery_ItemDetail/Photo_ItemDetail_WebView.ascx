<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemDetail_WebView.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemDetail.WebView" ClassName="Nexus.Controls.Gallery.ItemDetail.ItemDetail_WebView" %>
<asp:MultiView ID="MultiView_ItemDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            The Item can not be found.
        </div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
        <asp:HyperLink ID="hlink_Edit_Item" runat="server">Edit Item</asp:HyperLink>
        <div style="NexusPhotoDetail">
            <asp:FormView ID="FormView_ItemDetail" runat="server" RenderOuterTable="False">
                <ItemTemplate>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </asp:View>
</asp:MultiView>