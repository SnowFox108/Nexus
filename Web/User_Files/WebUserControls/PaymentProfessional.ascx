<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentProfessional.ascx.cs" Inherits="User_Files_WebUserControls_PaymentProfessional" %>
<div class="checkout">
    <table>
        <tr class="header_footer">
            <td colspan="3">
                Professional Package Details:
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
                Design Option 3 with Service Plan SO5 for 1 year
            </td>
            <td style="text-align: right;">
                &pound;1487.00
            </td>
        </tr>
        <tr class="alternativeRow">
            <td>
                Special Offer
            </td>
            <td>
                Discount £400</td>
            <td style="text-align: right;">
                &pound;400.00 
            </td>
        </tr>
        <tr class="header_footer">
            <td>
            </td>
            <td>
            </td>
            <td style="text-align: right;">
                Total: £1087.00
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
                <input name="item_name_1" type="hidden" value="Professional Package" />
                <input name="item_description_1" type="hidden" value="Design Option 3 with Service Plan SO5 for 1 year (with discount)" />
                <input name="item_quantity_1" type="hidden" value="1" />
                <input name="item_price_1" type="hidden" value="1087.0" />
                <input name="item_currency_1" type="hidden" value="GBP" />
                <input name="shopping-cart.items.item-1.digital-content.description" type="hidden"
                    value="Please send us email with your Google checkout invoice number.&#xa;We are setting up your website now and will contact you soon.&#xa;&#xa;At the meantime you can choose template for your website.&#xa;1. Go to our partner website http://www.dreamtemplate.com/&#xa;2. Then send us email the template ID or URL you want to use for your website.&#xa;&#xa;Our Email: service@e2tech.co.uk" />
                <input name="shopping-cart.items.item-1.digital-content.key" type="hidden" value="oBixWpAFKThOv6jQ4wXJo+PB7f1eaIfGAiVmkAEOb1g=" />
                <input name="shopping-cart.items.item-1.digital-content.key.is-encrypted" type="hidden"
                    value="true" />
                <input name="_charset_" type="hidden" value="utf-8" />
                <asp:ImageButton ID="ibtn_GoogleCheckOut" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_google.gif"
                    PostBackUrl="https://checkout.google.com/api/checkout/v2/checkoutForm/Merchant/716905278348518"
                    ImageAlign="Middle" />
                &nbsp;OR
                <input type="hidden" name="cmd" value="_s-xclick">
                <input type="hidden" name="hosted_button_id" value="N8MQAGKXKMVRN">
                <asp:ImageButton ID="ibtn_PayPal" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_paypal.gif"
                    PostBackUrl="https://www.paypal.com/cgi-bin/webscr" ImageAlign="Middle" />
            </td>
        </tr>
    </table>
</div>
