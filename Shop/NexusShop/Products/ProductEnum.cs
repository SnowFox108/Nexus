using System;
using System.Collections.Generic;
using System.Text;
using Nexus.Core;

namespace Nexus.Shop.Product
{
    public enum Title_Type
    {
        [StringValue("Not Display")]
        NotDisplay,
        [StringValue("Prefix")]
        Prefix,
        [StringValue("Suffix")]
        Suffix,
        [StringValue("Override")]
        Override
    }

    public enum Media_Type
    {
        [StringValue("Picture")]
        Picture,
        [StringValue("Flash")]
        Flash,
        [StringValue("Youtube")]
        Youtube,
    }

}
