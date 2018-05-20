using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexus.Core.Templates
{
    public enum DockZone_Orientation
    {
        [StringValue("Vertical")]
        Vertical,
        [StringValue("Horizontal")]
        Horizontal,
    }

    public enum Meta_Type
    {
        [StringValue("JavaScript")]
        JavaScript,
        [StringValue("StyleSheet")]
        StyleSheet
    }

}
