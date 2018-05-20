using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.Categories
{

    /// <summary>
    /// NexusCore Categories
    /// </summary>
    public class Category
    {

        private string _categoryid;
        private string _parent_categoryid;
        private string _category_name;

        public string CategoryID { get { return _categoryid; } }
        public string Parent_CategoryID { get { return _parent_categoryid; } }
        public string Category_Name { get { return _category_name; } }

        public Category(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _categoryid = myDR["CategoryID"].ToString();
                _parent_categoryid = myDR["Parent_CategoryID"].ToString();
                _category_name = myDR["Category_Name"].ToString();

            }

        }

    }

    /// <summary>
    /// NexusCore Categories Full List
    /// </summary>
    public class Category_Full
    {

        private string _categoryid;
        private string _parent_categoryid;
        private string _category_name;

        private string _relationid;
        private string _moduleid;
        private string _module_itemid;
        private int _item_count;

        private string _module_name;
        private string _item_name;


        public string CategoryID { get { return _categoryid; } }
        public string Parent_CategoryID { get { return _parent_categoryid; } }
        public string Category_Name { get { return _category_name; } }

        public string RelationID { get { return _relationid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Module_ItemID { get { return _module_itemid; } }
        public int Item_Count { get { return _item_count; } }

        public string Module_Name { get { return _module_name; } }
        public string Item_Name { get { return _item_name; } }

        public Category_Full(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _categoryid = myDR["CategoryID"].ToString();
                _parent_categoryid = myDR["Parent_CategoryID"].ToString();
                _category_name = myDR["Category_Name"].ToString();

                _relationid = myDR["RelationID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _module_itemid = myDR["Module_ItemID"].ToString();
                _item_count = Convert.ToInt32(myDR["Item_Count"]);

                _module_name = myDR["Module_Name"].ToString();
                _item_name = myDR["Item_Name"].ToString();

            }

        }

    }

    /// <summary>
    /// NexusCore Component In Categories
    /// </summary>
    public class ComponentInCategory
    {

        private string _relationid;
        private string _moduleid;
        private string _module_itemid;
        private string _categoryid;
        private int _item_count;

        public string RelationID { get { return _relationid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Module_ItemID { get { return _module_itemid; } }
        public string CategoryID { get { return _categoryid; } }
        public int Item_Count { get { return _item_count; } }

        public ComponentInCategory(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _relationid = myDR["RelationID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _module_itemid = myDR["Module_ItemID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _item_count = Convert.ToInt32(myDR["Item_Count"]);

            }

        }

    }

}
