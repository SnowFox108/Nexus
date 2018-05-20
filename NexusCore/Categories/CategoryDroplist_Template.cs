using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace Nexus.Core.Categories
{
    public class CategoryDroplist_Template : System.Web.UI.ITemplate
    {
        private string _root_categoryid = "-1";
        private string _selected_categoryid;

        public CategoryDroplist_Template(string root_categoryid, string selected_categoryid)
        {
            _root_categoryid = root_categoryid;
            _selected_categoryid = selected_categoryid;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {

            // Remove all Node before add new one
            RadTreeView RadTreeView_Category = new RadTreeView();

            RadTreeView_Category.DataBinding += new EventHandler(this.RadTreeView_DataBinding);

            container.Controls.Add(RadTreeView_Category);
        }

        private void RadTreeView_DataBinding(object sender, EventArgs e)
        {
            RadTreeView RadTreeView_Category = (RadTreeView)sender;

            RadTreeNode rootnode = new RadTreeNode();
            rootnode.Text = "All Categories";
            rootnode.Value = _root_categoryid;
            rootnode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            rootnode.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/All_category.gif";
            rootnode.Expanded = true;
            RadTreeView_Category.Nodes.Add(rootnode);

            CategoryMgr myCategoryMgr = new CategoryMgr();
            List<Category> myCategories = myCategoryMgr.Get_Categories(_root_categoryid);

            foreach (Category myCategory in myCategories)
            {
                int Component_Count = myCategoryMgr.Sum_CategoryItems(myCategory.CategoryID);

                RadTreeNode node = new RadTreeNode();
                node.Text = myCategory.Category_Name
                    + " ("
                    + Component_Count.ToString()
                    + ")";
                node.Value = myCategory.CategoryID;
                node.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/folder.gif";

                RadTreeView_Category.Nodes.Add(node);

            }


        }

        private void LoadCategoryNode(RadTreeNode MyNode)
        {
            CategoryMgr myCategoryMgr = new CategoryMgr();
            List<Category> myCategories = myCategoryMgr.Get_Categories(MyNode.Value);

            foreach (Category myCategory in myCategories)
            {
                int Component_Count = myCategoryMgr.Sum_CategoryItems(myCategory.CategoryID);

                RadTreeNode node = new RadTreeNode();
                node.Text = myCategory.Category_Name
                    + " ("
                    + Component_Count.ToString()
                    + ")";
                node.Value = myCategory.CategoryID;
                node.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/folder.gif";

                MyNode.Nodes.Add(node);
                LoadCategoryNode(node);
            }
        }        

    }
}
