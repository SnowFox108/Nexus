using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexus.Core.Pages
{

    public enum Page_Type
    {
        [StringValue("Normal Page")]
        Normal_Page,
        [StringValue("Category")]
        Category,
        [StringValue("Internal Page Pointer")]
        Internal_Page_Pointer,
        [StringValue("External Link")]
        External_Link
    }

    public enum Meta_Type
    {
        [StringValue("JavaScript")]
        JavaScript,
        [StringValue("StyleSheet")]
        StyleSheet
    }

}
