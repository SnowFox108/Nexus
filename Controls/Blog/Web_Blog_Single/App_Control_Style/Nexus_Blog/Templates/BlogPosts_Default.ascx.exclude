<%@ Control Language="C#" %>
<h2>
    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("Post_View_URL_Full") %>' runat="server"><%# Eval("Post_Title")%></asp:HyperLink>
</h2>
<div>
    Posted on
    <%# Eval("Post_Date_Short") %>
    by
    <%# Eval("UserName") %></div>
<div>
    <%# Eval("Post_Content") %></div>
<div>
    <asp:HyperLink ID="hlink_Comment" NavigateUrl='<%# Eval("Post_View_URL_Full") %>'
        runat="server">Comments (<%# Eval("Comment_Count") %>)</asp:HyperLink>
</div>
<div>
    Last updated at:
    <%# Eval("Post_ModifyDate") %></div>
