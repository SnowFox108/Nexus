<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageCommand_Normal.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageCommand_Normal" %>
<p>
    Selected Page: <b>
        <asp:Label ID="lbl_PageName" runat="server"></asp:Label></b></p>
<ul>
    <li>
        <asp:LinkButton ID="btn_Normal_Delete" runat="server" OnClick="btn_Normal_Delete_Click"
            CssClass="nexusCore_delete_link">Delete</asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="btn_Normal_Duplicate" runat="server" OnClick="btn_Normal_Duplicate_Click"
            CssClass="nexusCore_duplicate_link">Duplicate</asp:LinkButton>
    </li>
</ul>
<asp:DropDownList ID="droplist_Normal_Folders" runat="server">
</asp:DropDownList>
<asp:LinkButton ID="btn_Normal_Move" runat="server" OnClick="btn_Normal_Move_Click"
    CssClass="nexusCore_moveToFolder_link">Move to</asp:LinkButton>
