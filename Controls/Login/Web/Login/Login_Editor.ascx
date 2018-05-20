<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login_Editor.ascx.cs" Inherits="Nexus.Controls.Login.Login.Editor" ClassName="Nexus.Controls.Login.Login.Login_Editor" %>
Login URL: (e.g. "/Default.aspx")<br />
<asp:TextBox ID="tbx_LoginURL" runat="server" Width="680px" 
    MaxLength="500"></asp:TextBox>
    <br />
<div class="UserControlBtns">
<asp:Button ID="btn_Update" runat="server" Text="Update" 
    onclick="btn_Update_Click" />
</div>