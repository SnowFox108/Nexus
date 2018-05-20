<%@ Control Language="C#" %>
<div class="box post">
    <div class="content">
        <div class="post-date">
            <%# Eval("UserName_URL") %>
            <%# Eval("UserEmail") %>
        </div>
        <!--/post-date -->
        <div class="post-commets">
            <%# Eval("Post_Date") %></div>
        <div class="post-leave">
            <%# Eval("Post_Content") %>
        </div>
        <!--/post-commets -->
        <div class="clr">
        </div>
    </div>
    <!--/content -->
</div>
<!--/box -->
