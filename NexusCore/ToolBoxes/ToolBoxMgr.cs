using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Nexus.Core.ToolBoxes
{
    public class ToolBoxMgr
    {

        public ToolBoxMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Toolbox_Option Get_Toolbox_Option(string ToolboxID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Toolbox_Option(myDP.Get_Toolbox_Option(ToolboxID));
        }

        public List<Toolbox_Option> Get_Toolbox_Options(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Toolbox_Options(SortOrder);

            List<Toolbox_Option> list = new List<Toolbox_Option>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Toolbox_Option(myDR));
            }

            return list;

        }

        public Toolbox_Group Get_Toolbox_Group(string GroupID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Toolbox_Group(myDP.Get_Toolbox_Group(GroupID));
        }

        public List<Toolbox_Group> Get_Toolbox_Groups(string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Toolbox_Groups(SortOrder);

            List<Toolbox_Group> list = new List<Toolbox_Group>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Toolbox_Group(myDR));
            }

            return list;

        }

        public Toolbox_Tool Get_Toolbox_Tool(string ToolID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Toolbox_Tool(myDP.Get_Toolbox_Tool(ToolID));
        }

        public List<Toolbox_Tool> Get_Toolbox_Tools(string GroupID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Toolbox_Tools(GroupID, SortOrder);

            List<Toolbox_Tool> list = new List<Toolbox_Tool>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Toolbox_Tool(myDR));
            }

            return list;

        }


        #region Tool Box Tree
        // Get Groups
        public void Load_Toolbox_Group(RadTreeView myTreeView)
        {
            List<Toolbox_Group> myToolbox_Groups = Get_Toolbox_Groups(null);

            foreach (Toolbox_Group myToolbox_Group in myToolbox_Groups)
            {
                Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                Modules.Module myModule = myModuleMgr.Get_Module(myToolbox_Group.ModuleID);

                RadTreeNode rootnode = new RadTreeNode();
                rootnode.Text = myToolbox_Group.Group_Name;
                rootnode.Value = myToolbox_Group.GroupID;
                rootnode.ImageUrl = myModule.Module_Icon;
                rootnode.Expanded = myToolbox_Group.IsOpened;
                rootnode.AllowDrag = false;

                Load_Toolbox_Component(rootnode);

                myTreeView.Nodes.Add(rootnode);

            }
        }

        // Get Tools Component
        public void Load_Toolbox_Component(RadTreeNode eNode)
        {
            List<Toolbox_Tool> myToolbox_Tools = Get_Toolbox_Tools(eNode.Value, null);

            foreach (Toolbox_Tool myToolbox_Tool in myToolbox_Tools)
            {
                Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                Modules.Component myComponent = myModuleMgr.Get_Component(myToolbox_Tool.ComponentID);

                RadTreeNode node = new RadTreeNode();
                node.Text = myToolbox_Tool.Tool_Name;
                node.Value = myToolbox_Tool.ComponentID;
                node.ImageUrl = myComponent.Component_Icon;
                node.Expanded = false;

                eNode.Nodes.Add(node);
            }

        }

        public void Load_Toolbox_Component(RadTreeNodeEventArgs eNode)
        {
            List<Toolbox_Tool> myToolbox_Tools = Get_Toolbox_Tools(eNode.Node.Value, null);

            foreach (Toolbox_Tool myToolbox_Tool in myToolbox_Tools)
            {
                Modules.ModuleMgr myModuleMgr = new Nexus.Core.Modules.ModuleMgr();
                Modules.Component myComponent = myModuleMgr.Get_Component(myToolbox_Tool.ComponentID);

                RadTreeNode node = new RadTreeNode();
                node.Text = myToolbox_Tool.Tool_Name;
                node.Value = myToolbox_Tool.ComponentID;
                node.ImageUrl = myComponent.Component_Icon;
                node.Expanded = false;

                eNode.Node.Nodes.Add(node);
            }

        }

        #endregion

    }
}
