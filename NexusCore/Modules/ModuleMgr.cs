using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Nexus.Core.Modules
{

    [DataObject(true)]
    public class ModuleMgr
    {
        public ModuleMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Module Get_Module(string ModuleID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Module(myDP.Get_Module(ModuleID));

        }

        public List<Module> Get_Modules(string SortOrder, string Module_Types = "'System Addon', 'Customer Addon'")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Modules(SortOrder, Module_Types);

            List<Module> list = new List<Module>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Module(myDR));
            }

            return list;

        }

        public static List<Module> sGet_Modules(string SortOrder, string Module_Types = "'System Addon', 'Customer Addon'")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Modules(SortOrder, Module_Types);

            List<Module> list = new List<Module>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Module(myDR));
            }

            return list;

        }

        public Component Get_Component(string ComponentID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Component(myDP.Get_Component(ComponentID));

        }

        public List<Component> Get_Components(string ModuleID, string Parent_ComponentID, string SortOrder)
        {
            return sGet_Components(ModuleID, Parent_ComponentID, Component_Type.Addon, SortOrder);
        }

        public List<Component> Get_Components(string ModuleID, string Parent_ComponentID, Component_Type Component_Type, string SortOrder)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Components(ModuleID, Parent_ComponentID, StringEnum.GetStringValue(Component_Type), SortOrder);

            List<Component> list = new List<Component>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Component(myDR));
            }

            return list;

        }

        public static List<Component> sGet_Components(string ModuleID, string Parent_ComponentID, string SortOrder)
        {
            return sGet_Components(ModuleID, Parent_ComponentID, Component_Type.Addon, SortOrder);
        }

        public static List<Component> sGet_Components(string ModuleID, string Parent_ComponentID, Component_Type Component_Type, string SortOrder)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Components(ModuleID, Parent_ComponentID, StringEnum.GetStringValue(Component_Type), SortOrder);

            List<Component> list = new List<Component>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Component(myDR));
            }

            return list;

        }

        public Component_Control Get_Control(string ControlID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Component_Control(myDP.Get_Control(ControlID));

        }

        public Component_Control Get_Control(string ComponentID, Control_Type Control_Type)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Component_Control(myDP.Get_Control(ComponentID, StringEnum.GetStringValue(Control_Type)));

        }

        public List<Component_Control> Get_Controls(string ComponentID, Control_Type Control_Type,  string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Controls(ComponentID, StringEnum.GetStringValue(Control_Type), SortOrder);

            List<Component_Control> list = new List<Component_Control>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Component_Control(myDR));
            }

            return list;

        }

        public Module_Item Get_Module_Item(string Module_ItemID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Module_Item(myDP.Get_Module_Item(Module_ItemID));

        }

        public bool Chk_Module(string ModuleID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Module(ModuleID);

        }

    }
}
