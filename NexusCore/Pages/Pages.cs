using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.Pages
{

    #region MetaTags

    public class MetaTag
    {

        private string _metatagid;
        private string _pageindexid;
        private Meta_Type _meta_type;
        private string _meta_src;

        public string MetaTagID { get { return _metatagid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public Meta_Type Meta_Type { get { return _meta_type; } }
        public string Meta_Src { get { return _meta_src; } }

        public MetaTag(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _metatagid = myDR["MetaTagID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _meta_type = (Meta_Type)StringEnum.Parse(typeof(Meta_Type), myDR["Meta_Type"].ToString(), true);
                _meta_src = myDR["Meta_Src"].ToString();

            }

        }
    }


    #endregion

    #region Basic Class

    // Menu Nodes class
    public class Menu_Nodes
    {
        private string _pageindexid;
        private string _page_categoryid;
        private string _menu_title;
        private string _page_name;
        private Page_Type _page_type;
        private string _sortorder;
        private int _childrencount;

        private string _iconurl;

        public string PageIndexID { get { return _pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Menu_Title { get { return _menu_title; } }
        public string Page_Name { get { return _page_name; } }
        public Page_Type Page_Type { get { return _page_type; } }
        public string SortOrder { get { return _sortorder; } }
        public int ChildrenCount { get { return _childrencount; } }

        public string IconUrl { get { return _iconurl; } }

        public Menu_Nodes(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //


            if (myDR != null)
            {

                _pageindexid = myDR["PageIndexID"].ToString();
                _page_categoryid = myDR["Page_CategoryID"].ToString();
                _menu_title = myDR["Menu_Title"].ToString();
                _page_name = myDR["Page_Name"].ToString();
                _page_type = (Page_Type)StringEnum.Parse(typeof(Page_Type), myDR["Page_Type"].ToString(), true);
                _sortorder = myDR["SortOrder"].ToString();
                _childrencount = Convert.ToInt32(myDR["ChildrenCount"]);

                switch (_page_type)
                {
                    case Page_Type.Normal_Page:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/pages.png";
                        break;

                    case Page_Type.Category:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/category.gif";
                        break;

                    case Page_Type.Internal_Page_Pointer:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/intlink.gif";
                        break;

                    case Page_Type.External_Link:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/extlink.gif";
                        break;

                    default:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/pages.png";
                        break;
                }

                PageEditorMgr myPageEditorMgr = new PageEditorMgr();
                if (myPageEditorMgr.Chk_Page_Lock(_pageindexid))
                {
                    _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/page_lock.gif";
                }
                else
                {
                    string _homepageid = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomepageID");
                    if (_pageindexid == _homepageid)
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/home.gif";

                    if (_page_categoryid == "2")
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/inactive_pages.gif";

                }

            }

        }
    }

    // Page Index class
    public class PageIndex
    {

        private string _pageindexid;
        private string _parent_pageindexid;
        private string _page_categoryid;
        private string _menu_title;
        private string _page_name;
        private Page_Type _page_type;
        private string _sortorder;

        public string PageIndexID { get { return _pageindexid; } }
        public string Parent_PageIndexID { get { return _parent_pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Menu_Title { get { return _menu_title; } }
        public string Page_Name { get { return _page_name; } }
        public Page_Type Page_Type { get { return _page_type; } }
        public string SortOrder { get { return _sortorder; } }

        public PageIndex(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pageindexid = myDR["PageIndexID"].ToString();
                _parent_pageindexid = myDR["Parent_PageIndexID"].ToString();
                _page_categoryid = myDR["Page_CategoryID"].ToString();
                _menu_title = myDR["Menu_Title"].ToString();
                _page_name = myDR["Page_Name"].ToString();
                _page_type = (Page_Type)StringEnum.Parse(typeof(Page_Type), myDR["Page_Type"].ToString(), true);
                _sortorder = myDR["SortOrder"].ToString();

            }

        }
    }

    // Page Index class
    public class PageIndex_Full
    {

        private string _pageindexid;
        private string _parent_pageindexid;
        private string _page_categoryid;
        private string _menu_title;
        private string _page_name;
        private Page_Type _page_type;
        private string _sortorder;

        private int _childrencount;
        private string _iconurl;

        private bool _isonmenu;
        private bool _isonnavigator;
        private bool _isprivacy_inherited;
        private bool _isattribute_inherited;
        private bool _istemplate_inherited;
        private bool _isssl;

        public string PageIndexID { get { return _pageindexid; } }
        public string Parent_PageIndexID { get { return _parent_pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Menu_Title { get { return _menu_title; } }
        public string Page_Name { get { return _page_name; } }
        public Page_Type Page_Type { get { return _page_type; } }
        public string SortOrder { get { return _sortorder; } }

        public int ChildrenCount { get { return _childrencount; } }
        public string IconUrl { get { return _iconurl; } }

        public bool IsOnMenu { get { return _isonmenu; } }
        public bool IsOnNavigator { get { return _isonnavigator; } }
        public bool IsPrivacy_Inherited { get { return _isprivacy_inherited; } }
        public bool IsAttribute_Inherited { get { return _isattribute_inherited; } }
        public bool IsTemplate_Inherited { get { return _istemplate_inherited; } }
        public bool IsSSL { get { return _isssl; } }

        public PageIndex_Full(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pageindexid = myDR["PageIndexID"].ToString();
                _parent_pageindexid = myDR["Parent_PageIndexID"].ToString();
                _page_categoryid = myDR["Page_CategoryID"].ToString();
                _menu_title = myDR["Menu_Title"].ToString();
                _page_name = myDR["Page_Name"].ToString();
                _page_type = (Page_Type)StringEnum.Parse(typeof(Page_Type), myDR["Page_Type"].ToString(), true);
                _sortorder = myDR["SortOrder"].ToString();

                _childrencount = Convert.ToInt32(myDR["ChildrenCount"]);

                switch (_page_type)
                {
                    case Page_Type.Normal_Page:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/pages.png";
                        break;

                    case Page_Type.Category:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/category.gif";
                        break;

                    default:
                        _iconurl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/pages.png";
                        break;
                }

                _isonmenu = (bool)myDR["IsOnMenu"];
                _isonnavigator = (bool)myDR["IsOnNavigator"];
                _isprivacy_inherited = (bool)myDR["IsPrivacy_Inherited"];
                _isattribute_inherited = (bool)myDR["IsAttribute_Inherited"];
                _istemplate_inherited = (bool)myDR["IsTemplate_Inherited"];
                _isssl = (bool)myDR["IsSSL"];

            }

        }
    }

    // Page Index class
    public class NexusCore_Page
    {

        private string _pageid;
        private string _pageindexid;
        private int _page_version;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string  _lastupdate_userid;
        private bool _isactive;
        private bool _isdelete;

        public string PageID { get { return _pageid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public int Page_Version { get { return _page_version; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }
        public bool IsActive { get { return _isactive; } }
        public bool IsDelete { get { return _isdelete; } }

        public NexusCore_Page(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _pageid = myDR["PageID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _page_version = Convert.ToInt16(myDR["Page_Version"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _isdelete = Convert.ToBoolean(myDR["IsDelete"]);

            }

        }
    }

    // Page PageProperty class
    public class Page_Property
    {

        private string _page_propertyid;
        private string _pageindexid;
        private bool _isonmenu;
        private bool _isonnavigator;
        private bool _isprivacy_inherited;
        private bool _isattribute_inherited;
        private bool _istemplate_inherited;
        private bool _isssl;

        public string Page_PropertyID { get { return _page_propertyid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public bool IsOnMenu { get { return _isonmenu; } }
        public bool IsOnNavigator { get { return _isonnavigator; } }
        public bool IsPrivacy_Inherited { get { return _isprivacy_inherited; } }
        public bool IsAttribute_Inherited { get { return _isattribute_inherited; } }
        public bool IsTemplate_Inherited { get { return _istemplate_inherited; } }
        public bool IsSSL { get { return _isssl; } }

        public Page_Property(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_propertyid = myDR["Page_PropertyID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _isonmenu = (bool)myDR["IsOnMenu"];
                _isonnavigator = (bool)myDR["IsOnNavigator"];
                _isprivacy_inherited = (bool)myDR["IsPrivacy_Inherited"];
                _isattribute_inherited = (bool)myDR["IsAttribute_Inherited"];
                _istemplate_inherited = (bool)myDR["IsTemplate_Inherited"];
                _isssl = (bool)myDR["IsSSL"];

            }
        }

    }

    // Page Attibutes
    public class Page_Attribute
    {

        private string _page_attributeid;
        private string _pageindexid;
        private string _page_title;
        private string _page_keyword;
        private string _page_description;

        public string Page_AttributeID { get { return _page_attributeid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string Page_Title { get { return _page_title; } }
        public string Page_Keyword { get { return _page_keyword; } }
        public string Page_Description { get { return _page_description; } }

        public Page_Attribute(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_attributeid = myDR["Page_AttributeID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _page_title = myDR["Page_Title"].ToString();
                _page_keyword = myDR["Page_Keyword"].ToString();
                _page_description = myDR["Page_Description"].ToString();

            }
        }
    }

    // Page Templates
    public class Page_Template
    {

        private string _page_templateid;
        private string _pageindexid;
        private string _masterpageindexid;

        public string Page_TemplateID { get { return _page_templateid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string MasterPageIndexID { get { return _masterpageindexid; } }

        public Page_Template(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_templateid = myDR["Page_TemplateID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _masterpageindexid = myDR["MasterPageIndexID"].ToString();

            }
        }
    }

    // Page Categories
    public class Page_Category
    {

        private string _page_categoryid;
        private string _name;
        private bool _istreeview;

        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Name { get { return _name; } }
        public bool IsTreeView { get { return _istreeview; } }

        public Page_Category(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_categoryid = myDR["Page_CategoryID"].ToString();
                _name = myDR["Name"].ToString();
                _istreeview = Convert.ToBoolean(myDR["IsTreeView"]);

            }

        }
    }

    // Page External Links
    public class Page_ExtLink
    {

        private string _page_linkid;
        private string _pageindexid;
        private string _page_url;
        private string _page_target;

        public string Page_LinkID { get { return _page_linkid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string Page_URL { get { return _page_url; } }
        public string Page_Target { get { return _page_target; } }

        public Page_ExtLink(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_linkid = myDR["Page_LinkID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _page_url = myDR["Page_URL"].ToString();
                _page_target = myDR["Page_Target"].ToString();

            }
        }
    }

    // Page Internal Links
    public class Page_IntLink
    {

        private string _page_linkid;
        private string _pageindexid;
        private string _pagepointerid;
        private string _page_target;

        public string Page_LinkID { get { return _page_linkid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string PagePointerID { get { return _pagepointerid; } }
        public string Page_Target { get { return _page_target; } }

        public Page_IntLink(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_linkid = myDR["Page_LinkID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _pagepointerid = myDR["PagePointerID"].ToString();
                _page_target = myDR["Page_Target"].ToString();

            }
        }
    }

    // Page Controls
    public class Page_Control
    {

        private string _page_controlid;
        private string _pageid;
        private string _placeholderid;
        private string _componentid;
        private int _sortorder;

        public string Page_ControlID { get { return _page_controlid; } }
        public string PageID { get { return _pageid; } }
        public string PlaceHolderID { get { return _placeholderid; } }
        public string ComponentID { get { return _componentid; } }
        public int SortOrder { get { return _sortorder; } }

        public Page_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_controlid = myDR["Page_ControlID"].ToString();
                _pageid = myDR["PageID"].ToString();
                _placeholderid = myDR["PlaceHolderID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);

            }
        }
    }

    // Page Control Properties
    public class Page_Control_Property
    {

        private string _control_propertyid;
        private string _page_controlid;
        private string _property_name;
        private string _property_value;

        public string Control_PropertyID { get { return _control_propertyid; } }
        public string Page_ControlID { get { return _page_controlid; } }
        public string Property_Name { get { return _property_name; } }
        public string Property_Value { get { return _property_value; } }

        public Page_Control_Property(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _control_propertyid = myDR["Control_PropertyID"].ToString();
                _page_controlid = myDR["Page_ControlID"].ToString();
                _property_name = myDR["Property_Name"].ToString();
                _property_value = myDR["Property_Value"].ToString();

            }
        }

        public Page_Control_Property(string page_controlid, string property_name, string property_value)
        {
            _page_controlid = page_controlid;
            _property_name = property_name;
            _property_value = property_value;
        }
    }

    // Page Locks
    public class Page_Lock
    {

        private string _page_lockid;
        private string _pageindexid;
        private string _parent_pageindexid;
        private string _pageid;
        private string _page_categoryid;
        private string _page_name;
        private Page_Type _page_type;
        private string _userid;
        private DateTime _lockdate;
        private bool _isdirty;

        public string Page_LockID { get { return _page_lockid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string Parent_PageIndexID { get { return _parent_pageindexid; } }
        public string PageID { get { return _pageid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Page_Name { get { return _page_name; } }
        public Page_Type Page_Type { get { return _page_type; } }
        public string UserID { get { return _userid; } }
        public DateTime LockDate { get { return _lockdate; } }
        public bool IsDirty { get { return _isdirty; } }

        public Page_Lock(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_lockid = myDR["Page_LockID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _parent_pageindexid = myDR["Parent_PageIndexID"].ToString();
                _pageid = myDR["PageID"].ToString();
                _page_categoryid = myDR["Page_CategoryID"].ToString();
                _page_name = myDR["Page_Name"].ToString();
                _page_type = (Page_Type)StringEnum.Parse(typeof(Page_Type), myDR["Page_Type"].ToString(), true);
                _userid = myDR["UserID"].ToString();
                _lockdate = Convert.ToDateTime(myDR["LockDate"]);
                _isdirty = Convert.ToBoolean(myDR["IsDirty"]);

            }

        }
    }

    // Page Templates
    public class Page_Lock_Template
    {

        private string _page_templateid;
        private string _page_lockid;
        private string _masterpageindexid;
        private bool _istemplate_inherited;
        private string _original_masterpageindexid;

        public string Page_TemplateID { get { return _page_templateid; } }
        public string Page_LockID { get { return _page_lockid; } }
        public string MasterPageIndexID { get { return _masterpageindexid; } }
        public bool IsTemplate_Inherited { get { return _istemplate_inherited; } }
        public string Original_MasterPageIndexID { get { return _original_masterpageindexid; } }

        public Page_Lock_Template(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_templateid = myDR["Page_TemplateID"].ToString();
                _page_lockid = myDR["Page_LockID"].ToString();
                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _istemplate_inherited = (bool)myDR["IsTemplate_Inherited"];
                _original_masterpageindexid = myDR["Original_MasterPageIndexID"].ToString();

            }
        }
    }

    // Page Attibutes
    public class Page_Lock_Attribute
    {

        private string _page_attributeid;
        private string _page_lockid;
        private string _page_title;
        private string _page_keyword;
        private string _page_description;

        public string Page_AttributeID { get { return _page_attributeid; } }
        public string PageIndexID { get { return _page_lockid; } }
        public string Page_Title { get { return _page_title; } }
        public string Page_Keyword { get { return _page_keyword; } }
        public string Page_Description { get { return _page_description; } }

        public Page_Lock_Attribute(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_attributeid = myDR["Page_AttributeID"].ToString();
                _page_lockid = myDR["Page_LockID"].ToString();
                _page_title = myDR["Page_Title"].ToString();
                _page_keyword = myDR["Page_Keyword"].ToString();
                _page_description = myDR["Page_Description"].ToString();

            }
        }
    }

    // Page Lock Controls
    public class Page_Lock_Control
    {

        private string _page_controlid;
        private string _page_lockid;
        private string _placeholderid;
        private string _componentid;
        private int _sortorder;
        private bool _isdirty;

        public string Page_ControlID { get { return _page_controlid; } }
        public string Page_LockID { get { return _page_lockid; } }
        public string PlaceHolderID { get { return _placeholderid; } }
        public string ComponentID { get { return _componentid; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsDirty { get { return _isdirty; } }

        public Page_Lock_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_controlid = myDR["Page_ControlID"].ToString();
                _page_lockid = myDR["Page_LockID"].ToString();
                _placeholderid = myDR["PlaceHolderID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);
                _isdirty = Convert.ToBoolean(myDR["IsDirty"]);

            }
        }
    }

    // Page Control Properties
    public class Page_Lock_Control_Property
    {

        private string _control_propertyid;
        private string _page_controlid;
        private string _property_name;
        private string _property_value;

        public string Control_PropertyID { get { return _control_propertyid; } }
        public string Page_ControlID { get { return _page_controlid; } }
        public string Property_Name { get { return _property_name; } }
        public string Property_Value { get { return _property_value; } }

        public Page_Lock_Control_Property(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _control_propertyid = myDR["Control_PropertyID"].ToString();
                _page_controlid = myDR["Page_ControlID"].ToString();
                _property_name = myDR["Property_Name"].ToString();
                _property_value = myDR["Property_Value"].ToString();

            }
        }
    }

    #endregion

    #region Extend Class

    // Page Attibutes
    public class Page_Loading_Info
    {

        private string _pageindexid;
        private string _parent_pageindexid;
        private string _pageid;
        private string _pagelockid;
        private string _masterpageindexid;
        private string _masterpageid;
        private string _template_masterpageid;
        private string _masterpageurl;
        private string _theme;
        private string _page_title;
        private string _page_keyword;
        private string _page_description;

        public string PageIndexID { 
            get { return _pageindexid; }
            set { _pageindexid = value; }        
        }

        public string Parent_PageIndexID
        {
            get { return _parent_pageindexid; }
            set { _parent_pageindexid = value; }
        }

        public string PageID
        {
            get { return _pageid; }
            set { _pageid = value; }
        }

        public string Page_LockID
        {
            get { return _pagelockid; }
            set { _pagelockid = value; }
        }

        public string MasterPageIndexID
        {
            get { return _masterpageindexid; }
            set { _masterpageindexid = value; }
        }

        public string MasterPageID
        {
            get { return _masterpageid; }
            set { _masterpageid = value; }
        }

        public string Template_MasterPageID
        {
            get { return _template_masterpageid; }
            set { _template_masterpageid = value; }
        }

        public string MasterPage_URL
        {
            get { return _masterpageurl; }
            set { _masterpageurl = value; }
        }

        public string Theme { 
            get { return _theme; }
            set { _theme = value; }
        }

        public string Page_Title { 
            get { return _page_title; }
            set { _page_title = value; }
        }

        public string Page_Keyword {
            get { return _page_keyword; }
            set { _page_keyword = value; }
        }

        public string Page_Description {
            get { return _page_description; }
            set { _page_description = value; }
        }

        public Page_Loading_Info()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
    }

    #endregion
}
