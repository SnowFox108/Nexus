<%@ Control Language="C#" %>
<a title='<%# Eval("Photo_Title") %>' href='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID=HomePageDetail", Eval("PhotoID")) %>'
    target="preview" rel="NexusGallery">
    <img style="border: 0px;" alt="<%# Eval("AlternateText") %>" src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>' /></a>
