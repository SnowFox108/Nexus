<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlManager.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Modules_ControlManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/App_Themes/NexusCore/Global.css" rel="Stylesheet" type="text/css" />
</head>
<body class="nexusCore_controlPanel_bg">
    <form id="Form_NexusCore" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div id="nexusCorePop_wrapper">
        <asp:PlaceHolder ID="PlaceHolder_Control" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
