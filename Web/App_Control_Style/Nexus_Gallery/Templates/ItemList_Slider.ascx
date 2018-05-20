<%@ Control Language="C#" %>
<li>
<a href="<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), "SliderDetail") %>">
    <img src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>'
        title='<%# Eval("Photo_Title") %>'>
</a>
</li>
