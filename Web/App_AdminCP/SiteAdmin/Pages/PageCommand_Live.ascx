<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageCommand_Live.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageCommand_Live" %>
<p>
    Selected Page: <b>
        <asp:Label ID="lbl_PageName" runat="server"></asp:Label></b></p>
<asp:Button ID="btn_CreatePage" runat="server" Text="Create a page" CssClass="nexusCore_createPage_btn"
    OnClick="btn_CreatePage_Click" SkinID="e2CMS_ImgButton" /><br />
<ul>
    <li>
        <asp:LinkButton ID="btn_Live_Delete" runat="server" OnClick="btn_Live_Delete_Click"
            CssClass="nexusCore_delete_link">Delete</asp:LinkButton></li>
    <li>
        <asp:LinkButton ID="btn_Live_Duplicate" runat="server" OnClick="btn_Live_Duplicate_Click"
            CssClass="nexusCore_duplicate_link">Duplicate</asp:LinkButton></li>
    <li>
        <asp:LinkButton ID="btn_Live_SetHomePage" runat="server" OnClick="btn_Live_SetHomePage_Click"
            CssClass="nexusCore_asHomepage_link">Set as Homepage</asp:LinkButton></li>
</ul>
<asp:DropDownList ID="droplist_Live_Folders" runat="server" >
</asp:DropDownList>
<asp:LinkButton ID="btn_Live_Move" runat="server" OnClick="btn_Live_Move_Click" CssClass="nexusCore_moveToFolder_link">Move to</asp:LinkButton>
