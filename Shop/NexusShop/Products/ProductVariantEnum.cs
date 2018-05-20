using System;
using System.Collections.Generic;
using System.Text;
using Nexus.Core;

namespace Nexus.Shop.Product.Variant
{
    public enum Variant_Type
    {
        [StringValue("General Product")]
        General_Product,
        [StringValue("Gift Card")]
        Gift_Card,
        [StringValue("Limited Download")]
        Limited_Download,
        [StringValue("Unlimited Download")]
        Unlimited_Download,
        [StringValue("Service")]
        Service,
        [StringValue("Subscription")]
        Subscription
    }

    public enum Input_Option
    {
        [StringValue("2F0C8C3F-B0AB-42D4-8511-0A41C6E38D9E")]
        TextBox,
        [StringValue("AC01F392-6909-43BA-B9C7-1FA7905FA1CD")]
        NumberBox,
        [StringValue("157CA53D-8CD7-4C14-A3CF-88DA5BD917E3")]
        DropdownList,
        [StringValue("E571C99C-0FEE-4468-A32A-F2B9D52F9549")]
        RadioButtonList,
        [StringValue("82CEC6BC-59B7-4FB7-B539-F0B5E3EC1211")]
        DatePicker,
        [StringValue("AF6B7F41-5BE8-4C2A-9D24-841798FB0585")]
        CheckBox,
        [StringValue("2C6EB5C1-8F8E-48F0-A9CF-3557B1C4858F")]
        CheckBoxList,
        [StringValue("F5E18E61-45B7-4332-904D-5311F816B3F3")]
        ImageURL
    }

    public enum Product_FormMode
    {
        [StringValue("Create")]
        Create,
        [StringValue("Edit")]
        Edit
    }

}
