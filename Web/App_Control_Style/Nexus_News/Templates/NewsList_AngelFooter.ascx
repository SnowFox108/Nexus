<%@ Control Language="C#" %>
      <div class="footer_blog1 three">
        <h2><%# Eval("News_Title") %></h2>
		<%# Eval("News_Brief") %>
 		<p></p>
       <p> <a href='<%# Eval("NewsDetail_URL_Full") %>' class="link">Read More </a></p>
      </div>