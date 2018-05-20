<%@ Control Language="C#" %>
<a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: '<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), "ZoomDetail") %>', largeimage: '<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), "Default") %>'}">
    <img src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>'
        title='<%# Eval("Photo_Title") %>' alt='<%# Eval("Photo_Title") %>'>
</a>

