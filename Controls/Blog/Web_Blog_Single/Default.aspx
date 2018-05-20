<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="Blog_Posts/BlogPosts_WebView.ascx" tagname="BlogPosts_WebView" tagprefix="uc1" %>

<%@ Register src="Post_View/PostView_WebView.ascx" tagname="PostView_WebView" tagprefix="uc2" %>
<%@ Register src="Post_View/PostView_Advanced.ascx" tagname="PostView_Advanced" tagprefix="uc3" %>

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
        
        <uc1:BlogPosts_WebView ID="BlogPosts_WebView1" runat="server" 
            BlogPostsID="12345" NumberPerPage="5" Ownership_UserID="1" PostViewURL="/" 
            ShowContent="True" ItemTemplateURL="~/App_Control_Style/Nexus_Blog/Templates/BlogPosts_List.ascx" ItemTemplate="Default" />
    
    </div>
    </form>
</body>
</html>
