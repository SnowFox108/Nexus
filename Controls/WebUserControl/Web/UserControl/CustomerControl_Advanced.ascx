<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerControl_Advanced.ascx.cs" Inherits="Nexus.Controls.WebUserControls.CustomerControl.Advanced" ClassName="Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Advanced" %>

<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:Literal ID="Literal_TextContent" runat="server"></asp:Literal>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify user control path.</div>
    </asp:View>
</asp:MultiView>