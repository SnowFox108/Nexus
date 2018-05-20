<%@ Control Language="C#" %>
<h1>
    <%# Eval("Post_Title") %></h1>
<div>
    Posted on
    <%# Eval("Post_Date_Short")%>
    by
    <%# Eval("UserName")%>
</div>
<div>
    <%# Eval("Post_Content")%></div>
<div>
    Last updated at:
    <%# Eval("Post_ModifyDate")%></div>
<hr />
<h2>
    Comments (<%# Eval("Comment_Count")%>)
</h2>
