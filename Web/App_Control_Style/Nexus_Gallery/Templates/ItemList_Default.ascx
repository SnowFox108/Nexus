<%@ Control Language="C#" %>
    <div style="text-align: center;">
        <a href='<%# string.Format("{0}?NexusPhotoID={1}", Eval("Photo_DetailURL"), Eval("PhotoID")) %>'>
            <img style="border: 0px;" alt="<%# Eval("AlternateText") %>" src='<%# string.Format("/App_Control_Style/Nexus_Gallery/ImgShow.ashx?NexusPhotoID={0}&DisplayID={1}", Eval("PhotoID"), Eval("Photo_DisplayID")) %>' />
        </a>
        <br />
        <%# Eval("Photo_Title") %>
    </div>
