<%@ Control Language="C#" %>
<h2>
    <asp:HyperLink ID="hlink_PostTitle" NavigateUrl='<%# Eval("Post_View_URL_Full") %>'
        runat="server"><%# Eval("Post_Title")%></asp:HyperLink>
</h2>
<div>
    Posted on
    <%# Eval("Post_Date_Short") %>by
    <%# Eval("UserName") %>
</div>
