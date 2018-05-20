using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.PageTags
{

    /// <summary>
    /// NexusCore PageTags
    /// </summary>
    public class PageTag
    {

        private string _pagetagid;
        private string _tag_name;

        public string PageTageID { get { return _pagetagid; } }
        public string Tag_Name { get { return _tag_name; } }

        public PageTag(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pagetagid = myDR["PageTagID"].ToString();
                _tag_name = myDR["Tag_Name"].ToString();

            }

        }

        public PageTag(string pagetagid, string tag_name)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            _pagetagid = pagetagid;
            _tag_name = tag_name;

        }

    }

    /// <summary>
    /// NexusCore PageTags Full List
    /// </summary>
    public class PageTag_Full
    {

        private string _pagetagid;
        private string _tag_name;

        private string _relationid;
        private string _moduleid;
        private string _module_itemid;
        private int _item_count;

        private string _module_name;
        private string _item_name;


        public string PageTageID { get { return _pagetagid; } }
        public string Tag_Name { get { return _tag_name; } }

        public string RelationID { get { return _relationid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Module_ItemID { get { return _module_itemid; } }
        public int Item_Count { get { return _item_count; } }

        public string Module_Name { get { return _module_name; } }
        public string Item_Name { get { return _item_name; } }

        public PageTag_Full(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pagetagid = myDR["PageTagID"].ToString();
                _tag_name = myDR["Tag_Name"].ToString();

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
    /// NexusCore Component In Tags
    /// </summary>
    public class ComponentInTag
    {

        private string _relationid;
        private string _moduleid;
        private string _module_itemid;
        private string _pagetagid;
        private int _item_count;

        public string RelationID { get { return _relationid; } }
        public string ModuleID { get { return _moduleid; } }
        public string Module_ItemID { get { return _module_itemid; } }
        public string PageTagID { get { return _pagetagid; } }
        public int Item_Count { get { return _item_count; } }

        public ComponentInTag(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _relationid = myDR["RelationID"].ToString();
                _moduleid = myDR["ModuleID"].ToString();
                _module_itemid = myDR["Module_ItemID"].ToString();
                _pagetagid = myDR["PageTagID"].ToString();
                _item_count = Convert.ToInt32(myDR["Item_Count"]);

            }

        }

    }

    /// <summary>
    /// PageTag Mapping for Webpages
    /// </summary>
    public class PageTag_Mapping
    {
        private string _pagetag_mappingid;
        private string _pageindexid;
        private string _pagetagid;
        private bool _isfeatured;

        public string PageTag_MappingID { get { return _pagetag_mappingid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string PageTagID { get { return _pagetagid; } }
        public bool IsFeatured { get { return _isfeatured; } }

        public PageTag_Mapping(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pagetag_mappingid = myDR["PageTag_MappingID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _pagetagid = myDR["PageTagID"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);

            }

        }

    }

}
