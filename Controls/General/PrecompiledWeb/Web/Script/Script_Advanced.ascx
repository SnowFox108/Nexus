<%@ control language="C#" autoeventwireup="true" inherits="Nexus.Controls.General.Script.Advanced, App_Web_zqa4zrth" classname="Nexus.Controls.General.Script.Script_Advanced" %>
<asp:MultiView ID="MultiView_Content" runat="server">
    <asp:View ID="View_Show" runat="server">
        <asp:Literal ID="Literal_TextContent" runat="server"></asp:Literal>
    </asp:View>
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to enter content.</div>
    </asp:View>
</asp:MultiView>