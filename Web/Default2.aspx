<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Nexus.Controls.Ebay.Management.Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<asp:Label ID="lbl_Msg" runat="server"></asp:Label>
<br />
<asp:Button ID="btn_LinkeBay" runat="server"
            Text="Link eBay to System" onclick="btn_LinkeBay_Click" />
&nbsp;<asp:Button ID="btn_GetUserToken" runat="server" Text="Get User Token" OnClick="btn_GetUserToken_Click" />    
        <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server">HyperLink</asp:HyperLink>
    </div>
    </form>
</body>
</html>
