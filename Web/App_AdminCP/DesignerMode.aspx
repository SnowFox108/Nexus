<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DesignerMode.aspx.cs" Inherits="Nexus.Core.App_AdminCP_DesignerMode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel_Redirecting" runat="server">
        Loading Desinger Mode ...
        </asp:Panel>   
        <asp:Panel ID="Panel_PageLock_Failed" runat="server">
            <asp:Label ID="lbl_ErrorMsg" runat="server"></asp:Label>
        </asp:Panel>   
    </div>
    </form>
</body>
</html>
