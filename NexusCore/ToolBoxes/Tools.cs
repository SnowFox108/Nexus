using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.ToolBoxes
{
    // Toolbox Options class
    public class Toolbox_Option
    {

        private string _toolboxid;
        private string _moduleid;
        private string _componentid;
        private string _module_name;
        private string _component_name;
        private string _component_version;
        private bool _isactive;

        public string ToolboxID { get { return _toolboxid; } }
        public string ModuleID { get { return _moduleid; } }
        public string ComponentID { get { return _componentid; } }
        public string Module_Name { get { return _module_name; } }
        public string Component_Name { get { return _component_name; } }
        public string Component_Version { get { return _component_version; } }
        public bool IsActive { get { return _isactive; } }

        public Toolbox_Option(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _toolboxid = myDR["ToolboxID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _module_name = myDR["Module_Name"].ToString();
                _component_name = myDR["Component_Name"].ToString();
                _component_version = myDR["Component_Version"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }
    }

    // Toolbox Groups class
    public class Toolbox_Group
    {

        private string _groupid;
        private string _moduleid;
        private string _group_name;
        private bool _isdefault;
        private bool _isopened;

        public string GroupID { get { return _groupid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Group_Name { get { return _group_name; } }
        public bool IsDefault { get { return _isdefault; } }
        public bool IsOpened { get { return _isopened; } }

        public Toolbox_Group(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _groupid = myDR["GroupID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _group_name = myDR["Group_Name"].ToString();
                _isdefault = Convert.ToBoolean(myDR["IsDefault"]);
                _isopened = Convert.ToBoolean(myDR["IsOpened"]);

            }

        }
    }

    // Toolbox Options class
    public class Toolbox_Tool
    {

        private string _toolid;
        private string _componentid;
        private string _groupid;
        private string _tool_name;
        private bool _isactive;

        public string ToolID { get { return _toolid; } }
        public string ComponentID { get { return _componentid; } }
        public string GroupID { get { return _groupid; } }
        public string Tool_Name { get { return _tool_name; } }
        public bool IsActive { get { return _isactive; } }

        public Toolbox_Tool(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _toolid = myDR["ToolID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _groupid = myDR["GroupID"].ToString();
                _tool_name = myDR["Tool_Name"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }
    }

    // Start Menu class
    public class StartMenu
    {

        private string _startmenuid;
        private string _moduleid;
        private string _componentid;
        private string _module_name;
        private int _sortorder;

        public string StartMenuID { get { return _startmenuid; } }
        public string ModuleID { get { return _moduleid; } }
        public string ComponentID { get { return _componentid; } }
        public string Module_Name { get { return _module_name; } }
        public int SortOrder { get { return _sortorder; } }

        public StartMenu(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _startmenuid = myDR["StartMenuID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _module_name = myDR["Module_Name"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);

            }

        }
    }

}
