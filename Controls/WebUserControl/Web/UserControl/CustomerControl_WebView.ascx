<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerControl_WebView.ascx.cs" Inherits="Nexus.Controls.WebUserControls.CustomerControl.WebView" ClassName="Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_WebView" %>

<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:PlaceHolder ID="PlaceHolder_UserControl" runat="server"></asp:PlaceHolder>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <asp:Literal ID="Literal_TextContent" runat="server"></asp:Literal>            
    </asp:View>
</asp:MultiView>