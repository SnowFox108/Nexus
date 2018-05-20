<%@ Control Language="C#" %>
<td id="Td1" runat="server">
    <div style="text-align: center;">
        <a href='<%# string.Format("{0}?NexusEbayItemID={1}", Eval("Ebay_ItemDetailURL"), Eval("Ebay_ItemID")) %>'>
            <img style="border:0px; width:140px;" alt='<%# Eval("Ebay_Title") %>' src='<%# Eval("Item_PicutreURL") %>' />
        </a>
        <br />
        <%# Eval("Ebay_SubTitle") %>
    </div>
</td>
