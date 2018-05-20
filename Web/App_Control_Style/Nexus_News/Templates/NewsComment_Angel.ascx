<%@ Control Language="C#" %>
    <div class="box post">
        <div class="content">
            <div class="post-excerpt" style="text-align:justify;">
                <%# Eval("Post_Content") %>
            </div>
            <div>
                <div class="post-date">
                    On <%# Eval("Post_Date") %> by <%# Eval("UserName_URL") %> <%# Eval("UserEmail") %>
                </div>
                <!--/post-date -->
            </div>

            <!--/post-excerpt -->

            <div class="clr">
            </div>
        </div>
        <!--/content -->
    </div>
	