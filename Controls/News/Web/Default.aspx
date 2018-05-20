<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="Management/Management_ManageNews.ascx" tagname="Management_ManageNews" tagprefix="uc1" %>

<%@ Register src="NewsList/NewsList_WebView.ascx" tagname="NewsList_WebView" tagprefix="uc2" %>
<%@ Register src="NewsDetail/NewsDetail_WebView.ascx" tagname="NewsDetail_WebView" tagprefix="uc3" %>
<%@ Register src="NewsDetail/NewsDetail_Advanced.ascx" tagname="NewsDetail_Advanced" tagprefix="uc4" %>

<%@ Register src="NewsList/NewsList_Advanced.ascx" tagname="NewsList_Advanced" tagprefix="uc5" %>

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


        <uc3:NewsDetail_WebView ID="NewsDetail_WebView1" runat="server" 
            NewsDetailID="ABC" />


    </div>
    </form>
</body>
</html>
