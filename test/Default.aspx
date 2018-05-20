<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    // Firefox worked fine. Internet Explorer shows scrollbar because of frameborder
    function resizeFrame(f) {
        f.style.width = f.contentWindow.document.body.scrollWidth + "px";
        f.style.height = f.contentWindow.document.body.scrollHeight + "px";
    }
</script>
    <link href="App_Themes/default/Default.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body class="bg" onLoad="resizeFrame(document.getElementById('childframe'))" bgcolor="#cccccc">
<form id="form1" runat="server"> <div id="nexusCore_Wrapper">   <div id="nexusCore_header">
        <div class="logo">
            <a href="Default.aspx">
                <img src="App_Themes/default/CSS_images/logo.gif" /></a></div>
        <div class="mainMenu">
            <ul>
                <li><a href="Default.aspx" class="selected">Home</a></li>
                <li><a href="EditorwithIframe.aspx">Pages</a></li>
            </ul>
        </div>
        <div class="Level2Menu">
            <ul>
                <li><a href="Default.aspx">Site map</a></li>
                <li><a href="Pages.aspx">News</a></li>
                <li><a href="Default.aspx">Blog</a></li>
                <li><a href="Pages.aspx">Lists</a></li>
            </ul>
        </div>
    </div>


    <div id="nexusCore_mainWapper">
        <div id="nexusCore_sideBar">
            Right_SideBar
            <h3>
                sidebar1 Content</h3>

                        <p>
                The background color on this div will only show for the length of the content. If
                you'd like a dividing line instead, place a border on the right side of the #mainContent
                div if the #mainContent div will always contain more content than the #sidebar1
                div.
            </p>
                        <p>
                The background color on this div will only show for the length of the content. If
                you'd like a dividing line instead, place a border on the right side of the #mainContent
                div if the #mainContent div will always contain more content than the #sidebar1
                div.
            </p>

            <p>
                Donec eu mi sed turpis feugiat feugiat. Integer turpis arcu, pellentesque eget,
                cursus et, fermentum ut, sapien.
            </p>          <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Praesent aliquam, justo
                convallis luctus rutrum, erat nulla fermentum diam, at nonummy quam ante ac quam.
                Maecenas urna purus, fermentum id, molestie in, commodo porttitor, felis. Nam blandit
                quam ut lacus.
            </p>
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Praesent aliquam, justo
                convallis luctus rutrum, erat nulla fermentum diam, at nonummy quam ante ac quam.
                Maecenas urna purus, fermentum id, molestie in, commodo porttitor, felis. Nam blandit
                quam ut lacus.
            </p>
            <p>
                Quisque ornare risus quis ligula. Phasellus tristique purus a augue condimentum
                adipiscing. Aenean sagittis. Etiam leo pede, rhoncus venenatis, tristique in, vulputate
                at, odio. Donec et ipsum et sapien vehicula nonummy. Suspendisse potenti. Fusce
                varius urna id quam. Sed neque mi, varius eget, tincidunt nec, suscipit id, libero.
                In eget purus. Vestibulum ut nisl. Donec eu mi sed turpis feugiat feugiat. Integer
                turpis arcu, pellentesque eget, cursus et, fermentum ut, sapien. Fusce metus mi,
                eleifend sollicitudin, molestie id, varius et, nibh. Donec nec libero.</p>
            <h2>
                H2 level heading
            </h2>
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Praesent aliquam, justo
                convallis luctus rutrum, erat nulla fermentum diam, at nonummy quam ante ac quam.
                Maecenas urna purus, fermentum id, molestie in, commodo porttitor, felis. Nam blandit
                quam ut lacus. Quisque ornare risus quis ligula. Phasellus tristique purus a augue
                condimentum adipiscing. Aenean sagittis. Etiam leo pede, rhoncus venenatis, tristique
                in, vulputate at, odio.</p>
            <!-- end #sidebar1 -->
        </div>
    <div id="nexusCore_mainContent">
            MainContainer
            <h1>
                Main Content
            </h1>
              


                        <iframe  name="childframe" id="childframe" src="Editor.aspx" runat="server" scrolling="Auto" frameborder="0" />

            
        </div><!-- end #mainContent -->


       
        <div class="clear"></div>
        <div> label</div>
    </div><!-- end #nexusCore_mainWapper -->
    <div id="nexusCore_footer">
        Copyright
        </div><!-- end #nexusCore_footer -->
</div><!-- end #nexusCore_Wapper -->
</form>
</body>
</html>
