<%@ Control Language="C#" %>
<td>
    <div class="ebayitem">
        <div class="picture">
            <img style="border: 0px; max-width: 140px; max-height: 140px;" alt="<%# Eval("Ebay_Title") %>"
                title="<%# Eval("Ebay_Title") %>" src='<%# Eval("Item_PicutreURL") %>' />
        </div>
        <div class="content">
            <div class="title">
                <%# Eval("Ebay_Title") %>
            </div>
            <div>
                Quantity: <%# Eval("Quantity")%></div>
            <div>
                Endind Date: <%# Eval("EndTime")%></div>
            <div class="price">
                Price:
                <%# Eval("Currency_Web")%>
                <%# Eval("CurrentPrice")%>
            </div>
        </div>
        <div>
            <a href='<%# Eval("ViewItemURL") %>' target="eBay" class="button buy">Buy on eBay</a>
            <a href='<%# Eval("Ebay_ItemDetailURL_Full") %>' class="button">View Info</a>
        </div>
    </div>
</td>
