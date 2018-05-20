<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="Nexus.Controls.Ebay.ItemList._Default" %>

<%@ Register src="Management/Management_EbaySetting.ascx" tagname="Management_EbaySetting" tagprefix="uc1" %>

<%@ Register src="Ebay_ItemList/Ebay_ItemList_WebView.ascx" tagname="Ebay_ItemList_WebView" tagprefix="uc2" %>

<%@ Register src="Ebay_ItemDetail/Ebay_ItemDetail_WebView.ascx" tagname="Ebay_ItemDetail_WebView" tagprefix="uc3" %>

<%@ Register src="ControlPanel/ControlPanel_FetchItem.ascx" tagname="ControlPanel_FetchItem" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

    <div>
                                

        <asp:PlaceHolder ID="PlaceHolder_Control" runat="server"></asp:PlaceHolder>
                                

    </div>
    </form>
</body>
</html>
