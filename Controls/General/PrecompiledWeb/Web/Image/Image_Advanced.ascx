<%@ control language="C#" autoeventwireup="true" inherits="Nexus.Controls.General.Image.Advanced, App_Web_d5dxhfe2" classname="Nexus.Controls.General.Image.Image_Advanced" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:PlaceHolder ID="PlaceHolder_Content" runat="server"></asp:PlaceHolder>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <div align="center">Click "Edit" to set an image.</div>
    </asp:View>
</asp:MultiView>