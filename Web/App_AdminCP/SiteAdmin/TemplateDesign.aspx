<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateDesign.aspx.cs" Inherits="App_AdminCP_SiteAdmin_TemplateDesign"
    StylesheetTheme="NexusCore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Template Design Mode</title>
</head>
<body  class="nexusCore_bg">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
   <div id="nexusCore_wrapper">
        <div id="templateDesign_header">
            <div class="nexusCore_logo">
                <img src="/App_Themes/NexusCore/CSS_images/logo.png" />
                <asp:Label ID="lbl_Version" runat="server"></asp:Label>                
            </div>
            <div class="nexusCore_publish_bar nexusCore_publish_bar_templateDesign">
                <asp:Button ID="btn_Publish" runat="server" Text="Publish" OnCommand="btn_Publish_Command" SkinID="e2CMS_Button" />
                &nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnCommand="btn_Cancel_Command" SkinID="e2CMS_Button" />
            </div>
        </div>
       <div id="templateDesign_mainWrapper">
           <div id="single">
               <iframe id="iframe_PageEditor_Design" runat="server" frameborder="0"></iframe>
           </div>
       </div>
   </div>
    </form>
</body>
</html>
