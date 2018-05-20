using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.Modules
{
    // Module class
    public class Module
    {

        private string _moduleid;
        private string _module_name;
        private string _module_icon;
        private string _module_icon_big;
        private Module_Type _module_type;
        private string _module_version;
        private string _release_date;
        private string _author;
        private string _description;

        public string ModuleID { get { return _moduleid; } }
        public string Module_Name { get { return _module_name; } }
        public string Module_Icon { get { return _module_icon; } }
        public string Module_Icon_Big { get { return _module_icon_big; } }
        public Module_Type Module_Type { get { return _module_type; } }
        public string Module_Version { get { return _module_version; } }
        public string Release_Date { get { return _release_date; } }
        public string Author { get { return _author; } }
        public string Description { get { return _description; } }

        public Module(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _moduleid = myDR["ModuleID"].ToString();
                _module_name = myDR["Module_Name"].ToString();
                _module_icon = myDR["Module_Icon"].ToString() + "24.png";
                _module_icon_big = myDR["Module_Icon"].ToString() + "64.png";
                _module_type = (Module_Type)StringEnum.Parse(typeof(Module_Type), myDR["Module_Type"].ToString(), true);
                _module_version = myDR["Module_Version"].ToString();
                _release_date = myDR["Release_Date"].ToString();
                _author = myDR["Author"].ToString();
                _description = myDR["Description"].ToString();

            }

        }
    }

    // Component class
    public class Component
    {

        private string _componentid;
        private string _parent_componentid;
        private string _moduleid;
        private string _component_name;
        private string _component_icon;
        private string _component_icon_big;
        private Component_Type _component_type;
        private string _component_version;

        public string ComponentID { get { return _componentid; } }
        public string Parent_ComponentID { get { return _parent_componentid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Component_Name { get { return _component_name; } }
        public string Component_Icon { get { return _component_icon; } }
        public string Component_Icon_Big { get { return _component_icon_big; } }
        public Component_Type Component_Type { get { return _component_type; } }
        public string Component_Version { get { return _component_version; } }

        public Component(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _componentid = myDR["ComponentID"].ToString();
                _parent_componentid = myDR["Parent_ComponentID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _component_name = myDR["Component_Name"].ToString();
                _component_icon = myDR["Component_Icon"].ToString() + "24.png";
                _component_icon_big = myDR["Component_Icon"].ToString() + "64.png";
                _component_type = (Component_Type)StringEnum.Parse(typeof(Component_Type), myDR["Component_Type"].ToString(), true);
                _component_version = myDR["Component_Version"].ToString();

            }

        }
    }

    // Control class
    public class Component_Control
    {

        private string _controlid;
        private string _componentid;
        private string _control_name;
        private string _class_name;
        private string _assembly_name;

        public string ControlID { get { return _controlid; } }
        public string ComponentID { get { return _componentid; } }
        public string Control_Name { get { return _control_name; } }
        public string Class_Name { get { return _class_name; } }
        public string Assembly_Name { get { return _assembly_name; } }

        public Component_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _controlid = myDR["ControlID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _control_name = myDR["Control_Name"].ToString();
                _class_name = myDR["Class_Name"].ToString();
                _assembly_name = myDR["Assembly_Name"].ToString();

            }

        }
    }

    // Module Item
    public class Module_Item
    {

        private string _module_itemid;
        private string _moduleid;
        private string _item_name;

        public string Module_ItemID { get { return _module_itemid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Item_Name { get { return _item_name; } }

        public Module_Item(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _module_itemid = myDR["Module_ItemID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _item_name = myDR["Item_Name"].ToString();

            }

        }
    }

    // Installation Logs
    public class Install_Log
    {

        private string _logid;
        private string _installid;
        private string _name;
        private Install_Type _install_type;
        private string _action_name;
        private Install_Action_Type _action_type;
        private string _action_userid;
        private string _result;
        private string _action_date;

        public string LogID { get { return _logid; } }
        public string InstallID { get { return _installid; } }
        public string Name { get { return _name; } }
        public Install_Type Install_Type { get { return _install_type; } }
        public string Action_Name { get { return _action_name; } }
        public Install_Action_Type Action_Type { get { return _action_type; } }
        public string Action_UserID { get { return _action_userid; } }
        public string Result { get { return _result; } }
        public string Action_Date { get { return _action_date; } }

        public Install_Log(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _logid = myDR["LogID"].ToString();
                _installid = myDR["InstallID"].ToString();
                _name = myDR["Name"].ToString();
                _install_type = (Install_Type)StringEnum.Parse(typeof(Install_Type), myDR["Install_Type"].ToString(), true);
                _action_name = myDR["Action_Name"].ToString();
                _action_type = (Install_Action_Type)StringEnum.Parse(typeof(Install_Action_Type), myDR["Action_Type"].ToString(), true);
                _action_userid = myDR["Action_UserID"].ToString();
                _result = myDR["Result"].ToString();
                _action_date = myDR["Action_Date"].ToString();

            }

        }
    }

}
