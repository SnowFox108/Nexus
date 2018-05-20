<%@ Control Language="C#" %>
<div class="gadget">
    <h2 class="star">
        <span>
            <%# Eval("Photo_Title") %></span></h2>
    <div style="text-align: center;">
        <a href='<%# string.Format("{0}?NexusPhotoID={1}", Eval("Photo_DetailURL"), Eval("PhotoID")) %>'>
            <img style="border: 0px; padding: 0px; margin: 0px;" alt="<%# Eval("AlternateText") %>"
                src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>' />
        </a>
    </div>
</div>
