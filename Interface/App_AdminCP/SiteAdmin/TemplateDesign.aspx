<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateDesign.aspx.cs" Inherits="App_AdminCP_SiteAdmin_TemplateDesign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Template Design Mode</title>
</head>
<body class="bg">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div id="nextusCore_header">
        <div class="nextusCore_logo">
                <img src="/App_Themes/NexusCore/CSS_images/logo.png" />
        </div>
        <div class="nextusCore_Publish_Bar nextusCore_Publish_Bar_TemplateDesign">
            <asp:Button ID="btn_Publish" runat="server" Text="Publish" OnCommand="btn_Publish_Command"/>
            &nbsp;
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnCommand="btn_Cancel_Command"/>
        </div>
    </div>
    <div class="nexusCore_Editor">
        <iframe id="iframe_PageEditor_Design" runat="server" frameborder="0"></iframe>
    </div>
    </form>
</body>
</html>
