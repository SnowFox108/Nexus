<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditorwithIframe.aspx.cs" Inherits="Pages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/default/Default.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="App_Themes/default/Editor.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body class="bg">
    <div id="nextusCore_header">
        <div class="logo">
            <a href="Default.aspx">
                <img src="App_Themes/default/CSS_images/logo.gif"/></a></div>
    </div>
    <div class="nexusCore_Editor">
        <iframe src="Editor.aspx" frameborder="0" height="100%" />
    </div>
</body>
</html>
