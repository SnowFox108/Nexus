<%@ Control Language="C#" %>
<div style="text-align: center;">
        <img style="border: 0px;" alt="<%# Eval("AlternateText") %>" src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>' />
<h3>
    <%# Eval("Photo_Title") %></h3>
</div>

