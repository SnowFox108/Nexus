<%@ Control Language="C#" %>
<h1>
    <%# Eval("Ebay_Title") %></h1>
<h3>
    <%# Eval("Ebay_SubTitle") %></h3>
<div>
    <table>
        <tr>
            <td>
                <img alt='<%# Eval("Ebay_Title") %>' src='<%# Eval("Item_PicutreURL") %>' />
            </td>
            <td>
                <h3>
                    Price:
                    <%# Eval("Currency_Web")%><%# Eval("CurrentPrice")%></h3>
                <br />
                Quantity Available:<%# Eval("QuantityAvailable")%><br />
                Quantity Sold:<%# Eval("QuantitySold")%><br />
                Number of People Interested:
                <%# Eval("Total_View_Count")%><br />
                <a href='<%# Eval("ViewItemURL")%>' target="MyEbay">Buy this product from Ebay</a>
            </td>
        </tr>
    </table>
</div>
<div>
    <%# Eval("Item_Description")%>
</div>
<div>
    <%# Eval("Ebay_Description")%>
</div>
