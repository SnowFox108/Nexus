<%@ Control Language="C#" %>
<div>
    <%# Eval("News_Brief") %>    
    <div style="text-align:right; width:95%;"><a href='<%# Eval("NewsDetail_URL_Full") %>' style="font: 14px Times, serif; color: #004C85;">
        Read More
    </a></div>
    <p></p>
</div>