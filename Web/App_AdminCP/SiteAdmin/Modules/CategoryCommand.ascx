<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryCommand.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Modules_CategoryCommand" %>
<p>Selected Category: <b> <asp:Label ID="lbl_CategoryName" runat="server"></asp:Label></b></p>
<asp:Button ID="btn_Create" runat="server" Text="Create a Category" CssClass="nexusCore_createCategory_btn" OnClick="btn_Create_Click" SkinID="e2CMS_Button" /><br />
<asp:Button ID="btn_Delete" runat="server" Text="Delete a Category" CssClass="nexusCore_deleteCategory_btn" OnClick="btn_Delete_Click"  SkinID="e2CMS_Button"/><br />
