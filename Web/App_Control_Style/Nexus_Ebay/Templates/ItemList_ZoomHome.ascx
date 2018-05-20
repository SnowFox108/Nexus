<%@ Control Language="C#" %>
<td>
    <div class="ebayitem">
        <div class="picture">
            <a href='<%# Eval("ViewItemURL") %>' target="eBay">
                <img style="border: 0px; max-width:140px; max-height: 140px;" alt="<%# Eval("Ebay_Title") %>" title="<%# Eval("Ebay_Title") %>" src='<%# Eval("Item_PicutreURL") %>' />
            </a>
        </div>
        <div class="price1">
            <%# Eval("Currency_Web")%> <%# Eval("CurrentPrice")%>
        </div>
        <div class="price2">
            <a href='<%# Eval("ViewItemURL") %>' target="eBay">Buy from eBay</a>
        </div>
    </div>
</td>
