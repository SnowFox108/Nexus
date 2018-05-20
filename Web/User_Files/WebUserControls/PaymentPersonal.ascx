<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentPersonal.ascx.cs" Inherits="User_Files_WebUserControls_PaymentPersonal" %>
<div class="checkout">
    <table>
        <tr class="header_footer">
            <td colspan="3">
                Personal Package Details:
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
                Design Option 1 with Service Plan SO1 for 1 year
            </td>
            <td style="text-align: right;">
                £118.88
            </td>
        </tr>
        <tr class="alternativeRow">
            <td>
                Special Offer</td>
            <td>
                Discount £59</td>
            <td style="text-align: right;">
                -&pound;59.00
            </td>
        </tr>
        <tr class="header_footer">
            <td>
            </td>
            <td>
            </td>
            <td style="text-align: right;">
                Total: &pound;59.88
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
                <input name="item_name_1" type="hidden" value="Personal Package" />
                <input name="item_description_1" type="hidden" value="Design Option 1 with Service Plan SO1 for 1 year (with discount)" />
                <input name="item_quantity_1" type="hidden" value="1" />
                <input name="item_price_1" type="hidden" value="59.88" />
                <input name="item_currency_1" type="hidden" value="GBP" />
                <input name="shopping-cart.items.item-1.digital-content.description" type="hidden"
                    value="We will setup your website and contact you soon. &#xa;&#xa;At meantime you can start choosing your template.&#xa;1. Go to our partner website http://www.dreamtemplate.com/&#xa;2. Then send us email the template ID or URL you want to use for your website." />
                <input name="shopping-cart.items.item-1.digital-content.key" type="hidden" value="4DM0szWzpBGepo8ooaGBGm2tS+ZDL0QxLn6geUioT8Q=" />
                <input name="shopping-cart.items.item-1.digital-content.key.is-encrypted" type="hidden"
                    value="true" />
                <input name="_charset_" type="hidden" value="utf-8" />
                <asp:ImageButton ID="ibtn_GoogleCheckOut" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_google.gif"
                    PostBackUrl="https://checkout.google.com/api/checkout/v2/checkoutForm/Merchant/716905278348518"
                    ImageAlign="Middle" />
                &nbsp;OR
                <input type="hidden" name="cmd" value="_s-xclick">
                <input type="hidden" name="hosted_button_id" value="6XCNJNMJ6L34Y">
                <asp:ImageButton ID="ibtn_PayPal" runat="server" ImageUrl="/User_Files/Images/Price_Images/buynow_paypal.gif"
                    PostBackUrl="https://www.paypal.com/cgi-bin/webscr" ImageAlign="Middle" />
            </td>
        </tr>
    </table>
</div>
