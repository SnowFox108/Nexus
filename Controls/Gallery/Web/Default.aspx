<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="Management/Management_PhotoSetting.ascx" tagname="Management_PhotoSetting" tagprefix="uc1" %>

<%@ Register src="Management/Management_ManageItems.ascx" tagname="Management_ManageItems" tagprefix="uc2" %>

<%@ Register src="Gallery_ItemList/Photo_ItemList_WebView.ascx" tagname="Photo_ItemList_WebView" tagprefix="uc3" %>

<%@ Register src="Gallery_ItemDetail/Photo_ItemDetail_WebView.ascx" tagname="Photo_ItemDetail_WebView" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" DestroyOnClose="True">
    </telerik:RadWindowManager>

    <div>
    
    

    
    
        <uc4:Photo_ItemDetail_WebView ID="Photo_ItemDetail_WebView1" runat="server" 
            ItemDetailID="ABC" DisplayID="HomePageDetail" />
    
    

    
    
    </div>
    </form>
</body>
</html>
