<%@ Control Language="C#" %>
<h1>
    <%# Eval("Photo_Title") %></h1>
<div style="text-align: center;">
    <a href='<%# Eval("LinkURL") %>'>
        <img style="border: 0px;" alt="<%# Eval("AlternateText") %>" src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>' />
    </a>
</div>
<div>
    <%# Eval("Description")%>
</div>
