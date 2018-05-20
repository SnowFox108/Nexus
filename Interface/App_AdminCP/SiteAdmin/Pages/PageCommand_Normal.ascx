<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageCommand_Normal.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageCommand_Normal" %>
Selected Page: <b><asp:Label ID="lbl_PageName" runat="server"></asp:Label></b><br />
<asp:LinkButton ID="btn_Normal_Delete" runat="server" 
    onclick="btn_Normal_Delete_Click">Delete</asp:LinkButton><br />
<asp:LinkButton ID="btn_Normal_Duplicate" runat="server" 
    onclick="btn_Normal_Duplicate_Click">Duplicate</asp:LinkButton><br />
<asp:DropDownList ID="droplist_Normal_Folders" runat="server">
</asp:DropDownList>
<br />
<asp:LinkButton ID="btn_Normal_Move" runat="server" onclick="btn_Normal_Move_Click">Move to Folder</asp:LinkButton>
<br /><asp:Button ID="Button1" runat="server" Text="Button" />