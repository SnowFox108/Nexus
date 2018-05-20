<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerControl_Editor.ascx.cs" Inherits="Nexus.Controls.WebUserControls.CustomerControl.Editor" ClassName="Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Editor" %>
Customer Control Path: (eg. ~/User_Files/User_Controls/Mycontrol.ascx")<br />
<asp:TextBox ID="tbx_UserControlPath" runat="server" Width="680px" 
    MaxLength="500"></asp:TextBox>
    <br />
<div class="UserControlBtns">
<asp:Button ID="btn_Update" runat="server" Text="Update" 
    onclick="btn_Update_Click" />
</div>