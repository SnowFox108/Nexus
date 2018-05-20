<%@ Control Language="C#" %>
      <div class="blog_body three">
        <h2><%# Eval("News_Title") %></h2>
		<%# Eval("News_Brief") %>
 		<p></p>
       <p> <a href='<%# Eval("NewsDetail_URL_Full") %>' class="link">Read More </a></p>
      </div>