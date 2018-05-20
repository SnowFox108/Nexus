<%@ Control Language="C#" %>
      <div class="box post">
        <div class="content">
          <div class="post-title">
            <h2><%# Eval("Post_Title")%></h2>
          </div>
          <!--/post-title -->
          <div class="post-excerpt" style="text-align:justify;">
			<%# Eval("Post_Content") %>
          </div>
          <!--/post-excerpt -->
          <div class="post-date">
            <div class="post-commets">| <%# Eval("Comment_Count") %> Comments</div>
            <!--/post-commets -->
            On <%# Eval("Post_Date_Short") %>, by <%# Eval("UserName") %> </div>
          <!--/post-date -->
          <div class="clr"></div>
        </div>
        <!--/content -->
      </div>
      <!--/box -->
