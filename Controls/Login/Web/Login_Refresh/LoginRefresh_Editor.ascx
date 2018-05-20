<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginRefresh_Editor.ascx.cs" Inherits="Nexus.Controls.Login.LoginRefresh.Editor" ClassName="Nexus.Controls.Login.LoginRefresh.LoginRefresh_Editor" %>
Default Return URL: (e.g. "/Default.aspx")<br />
<asp:TextBox ID="tbx_ReturnURL" runat="server" Width="680px" 
    MaxLength="500"></asp:TextBox>
    <br />
<div class="UserControlBtns">
<asp:Button ID="btn_Update" runat="server" Text="Update" 
    onclick="btn_Update_Click" />
</div>