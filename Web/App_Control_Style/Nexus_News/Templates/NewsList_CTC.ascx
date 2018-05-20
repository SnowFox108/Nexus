<%@ Control Language="C#" %>
<div class="news_body three">
    <a href='<%# Eval("NewsDetail_URL_Full") %>'><%# Eval("News_Brief") %></a>
    <p></p>
    <a href='<%# Eval("NewsDetail_URL_Full") %>' style="font: 14px Times, serif; color: #004C85;">
        <%# Eval("News_Title") %>
    </a>
    <p></p>
</div>

