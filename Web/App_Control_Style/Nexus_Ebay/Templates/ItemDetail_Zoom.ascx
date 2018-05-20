<%@ Control Language="C#" %>
<div class="shopping_detail1">
    <div class="itemdetail">
        <h2>
            Item Infomation</h2>
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
                    Quantity:
                    <%# Eval("Quantity")%>
                </div>
                <div>
                    Sold:
                    <%# Eval("QuantitySold")%>
                </div>
                <div>
                    Page views:
                    <%# Eval("Total_View_Count")%>
                </div>
                <div>
                    End Date:
                    <%# Eval("EndTime")%>
                </div>
                <div class="price">
                    Price:
                    <%# Eval("Currency_Web")%>
                    <%# Eval("CurrentPrice")%>
                </div>
                <div>
                    <a href='<%# Eval("ViewItemURL") %>' target="eBay" class="button buy">Buy on eBay</a>
                </div>
            </div>
        </div>
    </div>
    <div class="clr">
    </div>
</div>
<div class="shopping_detail1">
    <div class="itemdetail">
        <h2>
            Description</h2>
        <div class="ebayitem">
            <div class="description">
                <%# Eval("Item_Description")%>
            </div>
        </div>
    </div>
    <div class="clr">
    </div>
</div>
