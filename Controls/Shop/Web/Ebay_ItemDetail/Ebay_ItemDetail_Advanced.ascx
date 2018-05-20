<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ebay_ItemDetail_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ItemDetail.Advanced" ClassName="Nexus.Controls.Ebay.ItemDetail.ItemDetail_Advanced" %>
    <asp:MultiView ID="MultiView_ItemDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Item Detail options.</div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
        <asp:HyperLink ID="hlink_Edit_Item" runat="server">Edit Item</asp:HyperLink>
        <h1>
            <asp:Label ID="lbl_Title" runat="server"></asp:Label></h1>
        <h3>
            <asp:Label ID="lbl_SubTitle" runat="server"></asp:Label></h3>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Img_Product" runat="server" />
                    </td>
                    <td>
                        Quantity Available:<asp:Label ID="lbl_QuantityAvailable" runat="server"></asp:Label><br />
                        Quantity Sold:<asp:Label ID="lbl_QuantitySold" runat="server"></asp:Label><br />
                        Number of People Interested: <asp:Label ID="lbl_TotalView_Count" runat="server"></asp:Label><br />
                        <asp:HyperLink ID="hlink_ViewItemURL" Target="MyEbay" runat="server">Buy this product from Ebay</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Literal ID="Literal_Item_Description" runat="server"></asp:Literal>
        </div>
        <div>
            <asp:Literal ID="Literal_Ebay_Description" runat="server"></asp:Literal>
        </div>
    </asp:View>
</asp:MultiView>