<%@ Control Language="C#" %>
      <div class="box post">
        <div class="content">
          <div class="post-title">
            <h2><a href='<%# Eval("Post_View_URL_Full") %>'><%# Eval("Post_Title")%></a> </h2>
          </div>
          <!--/post-title -->
          <div class="post-excerpt" style="text-align:justify;">
			<%# Eval("Post_Content") %>
          </div>
          <!--/post-excerpt -->
          <div class="post-leave"> 
    <a href='<%# Eval("Post_View_URL_Full") %>'>read more</a>
		  </div>
          <div class="post-date">
            <div class="post-commets">| <a href='<%# Eval("Post_View_URL_Full") %>' title="View Comments" class="font-sm"> <%# Eval("Comment_Count") %></a> Comments</div>
            <!--/post-commets -->
            On <%# Eval("Post_Date_Short") %>, by <%# Eval("UserName") %> </div>
          <!--/post-date -->
          <div class="clr"></div>
        </div>
        <!--/content -->
      </div>
      <!--/box -->