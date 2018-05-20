<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColorBox.aspx.cs" Inherits="Test_ColorBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="/App_Themes/NexusCore/Scripts/jquery-1.5.2.js"></script>

  	<link media="screen" rel="stylesheet" href="/App_Themes/NexusCore/ColorBox.css" />

</head>
<body>
    <form id="form1" runat="server">
	<script src="/App_Themes/NexusCore/Scripts/jquery.colorbox.js"></script>
	<script>
	    $(document).ready(function () {
	        //Examples of how to assign the ColorBox event to elements
	        $("a[rel='e2CMS']").colorbox();

	        //Example of preserving a JavaScript event for inline calls.
	        $("#click").click(function () {
	            $('#click').css({ "background-color": "#f00", "color": "#fff", "cursor": "inherit" }).text("Open this window again and this message will still be here.");
	            return false;
	        });
	    });
	</script>

    <div>
	<p><a href="/User_Files/Images/e2CMS/Component.jpg" rel="e2CMS" title="Me and my grandfather on the Ohoopee.">Grouped Photo 1</a></p>
	<p><a href="/User_Files/Images/e2CMS/EasyToUse1.jpg" rel="e2CMS" title="On the Ohoopee as a child">Grouped Photo 2</a></p>
	<p><a href="/User_Files/Images/e2CMS/SEO1.jpg" rel="e2CMS" title="On the Ohoopee as an adult">Grouped Photo 3</a></p>
    
    </div>
    </form>
</body>
</html>
