<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginStatus_Editor.ascx.cs" Inherits="Nexus.Controls.Login.LoginStatus.Editor" ClassName="Nexus.Controls.Login.LoginStatus.LoginStatus_Editor" %>
Login form page URL: (e.g. "/Default.aspx")<br />
<asp:TextBox ID="tbx_LoginURL" runat="server" Width="680px" 
    MaxLength="500"></asp:TextBox>
    <br />
Logout refresh page URL: (e.g. "/Default.aspx")<br />
<asp:TextBox ID="tbx_LogoutURL" runat="server" Width="680px" 
    MaxLength="500"></asp:TextBox>
    <br />

<div class="UserControlBtns">
<asp:Button ID="btn_Update" runat="server" Text="Update" 
    onclick="btn_Update_Click" />
</div>