<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentStarter.ascx.cs"
    Inherits="User_Files_WebUserControls_PaymentStarter" %>
<div class="checkout">
    <table>
        <tr class="header_footer">
            <td colspan="3">
                Starter Package Details:
            </td>
        </tr>
        <tr>
            <th>
                Service Name
            </th>
            <th>
                Description
            </th>
            <th style="text-align: right;">
                Price
            </th>
        </tr>
        <tr>
            <td>
                Web Design
            </td>
            <td>
                Design Option 2 with Service Plan SO4 for 1 year 
            </td>
            <td style="text-align: right;">
                &pound;799.00
            </td>
        </tr>
        <tr class="alternativeRow">
            <td>
                Special Offer
            </td>
            <td>
                Discount £300</td>
            <td style="text-align: right;">
                -&pound;300.00
             </td>
        </tr>
        <tr class="header_footer">
            <td>
            </td>
            <td>
            </td>
            <td style="text-align: right;">
                Total: £499.00
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td style="text-align: right;">
                <p>
                    Choose your secure payment with</p>
                <input name="item_name_1" type="hidden" value="Starter Package" />
                <input name="item_description_1" type="hidden" value="Design Option 2 with Service Plan SO4 for 1 year" />
                <input name="item_quantity_1" type="hidden" value="1" />
                <input name="item_price_1" type="hidden" value="499.0" />
                <input name="item_currency_1" type="hidden" value="GBP" />
                <input name="shopping-cart.items.item-1.digital-content.description" type="hidden"
                    value="Please send us email with your Google checkout invoice number.&#xa;We are setting up your website now and will contact you soon.&#xa;&#xa;At the meantime you can choose template for your website.&#xa;1. Go to our partner website http://www.dreamtemplate.com/&#xa;2. Then send us email the template ID or URL you want to use for your website.&#xa;&#xa;Our Email: service@e2tech.co.uk" />
                <input name="shopping-cart.items.item-1.digital-content.key" type="hidden" value="h8i7RSFGYAfOL4TrQoALeO1bYZLETrfx79uUC2gQYHo=" />
                <input name="shopping-cart.items.item-1.digital-content.key.is-encrypted" type="hidden"
                    value="true" />
                <input name="_charset_" type="hidden" value="utf-8" />
                <asp:ImageButton ID="ibtn_GoogleCheckOut" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_google.gif"
                    PostBackUrl="https://checkout.google.com/api/checkout/v2/checkoutForm/Merchant/716905278348518"
                    ImageAlign="Middle" />
                &nbsp;OR
                <input type="hidden" name="cmd" value="_s-xclick">
                <input type="hidden" name="hosted_button_id" value="YZEDLXQ4BRVFN">
                <asp:ImageButton ID="ibtn_PayPal" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_paypal.gif"
                    PostBackUrl="https://www.paypal.com/cgi-bin/webscr" ImageAlign="Middle" />
            </td>
        </tr>
    </table>
</div>
