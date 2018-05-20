using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexus.Core.Modules
{
    public enum Module_Type
    {
        [StringValue("System Addon")]
        System_Addon,
        [StringValue("System Library")]
        System_Library,
        [StringValue("System Addon Fixed")]
        System_Addon_Fixed,
        [StringValue("System Library Fixed")]
        System_Library_Fixed,
        [StringValue("Customer Addon")]
        Customer_Addon,
        [StringValue("Customer Library")]
        Customer_Library,
    }

    public enum Component_Type
    {
        [StringValue("Addon")]
        Addon,
        [StringValue("Sub Addon")]
        Sub_Addon,
        [StringValue("Template")]
        Template,
        [StringValue("Theme")]
        Theme,
        [StringValue("ControlPanel")]
        ControlPanel,

    }

    public enum Control_Type
    {
        [StringValue("WebView")]
        WebView,
        [StringValue("Advanced")]
        Advanced,
        [StringValue("Editor")]
        Editor,
        [StringValue("Management")]
        Management,
        [StringValue("Wizard")]
        Wizard,
        [StringValue("ControlPanel")]
        ControlPanel,
    }

    public enum Install_Type
    {
        [StringValue("Module")]
        Module,
        [StringValue("Component")]
        Component,
        [StringValue("Template")]
        Template,
        [StringValue("Theme")]
        Theme,

    }

    public enum Install_Action_Type
    {
        [StringValue("Install")]
        Install,
        [StringValue("Upgrade")]
        Upgrade,
        [StringValue("Uninstall")]
        Uninstall,

    }

}
