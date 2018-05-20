<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageCommand_Live.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageCommand_Live" %>
Selected Page: <b><asp:Label ID="lbl_PageName" runat="server"></asp:Label></b><br />
<asp:Button ID="btn_CreatePage" runat="server" Text="Create a page" 
    SkinID="btn_sideBar" onclick="btn_CreatePage_Click" /><br />
<asp:LinkButton ID="btn_Live_Delete" runat="server" 
    onclick="btn_Live_Delete_Click">Delete</asp:LinkButton><br />
<asp:LinkButton ID="btn_Live_Duplicate" runat="server" 
    onclick="btn_Live_Duplicate_Click">Duplicate</asp:LinkButton><br />
<asp:LinkButton ID="btn_Live_SetHomePage" runat="server" 
    onclick="btn_Live_SetHomePage_Click">Set as Homepage</asp:LinkButton><br />
<asp:DropDownList ID="droplist_Live_Folders" runat="server">
</asp:DropDownList>
<br />
<asp:LinkButton ID="btn_Live_Move" runat="server" onclick="btn_Live_Move_Click">Move to Folder</asp:LinkButton>
