using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Core.Templates
{

    #region MetaTags

    public class MetaTag
    {

        private string _metatagid;
        private string _masterpageindexid;
        private Meta_Type _meta_type;
        private string _meta_src;

        public string MetaTagID { get { return _metatagid; } }
        public string MasterPageIndexID { get { return _masterpageindexid; } }
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
                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _meta_type = (Meta_Type)StringEnum.Parse(typeof(Meta_Type), myDR["Meta_Type"].ToString(), true);
                _meta_src = myDR["Meta_Src"].ToString();

            }

        }
    }


    #endregion
    

    // Template
    public class Template
    {

        private string _templateid;
        private string _template_name;
        private string _languagecode;
        private string _template_version;
        private DateTime _release_date;
        private string _author;
        private string _description;

        public string TemplateID { get { return _templateid; } }
        public string Template_Name { get { return _template_name; } }
        public string LanguageCode { get { return _languagecode; } }
        public string Template_Version { get { return _template_version; } }
        public DateTime Release_Date { get { return _release_date; } }
        public string Author { get { return _author; } }
        public string Description { get { return _description; } }

        public Template(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _templateid = myDR["TemplateID"].ToString();
                _template_name = myDR["Template_Name"].ToString();
                _languagecode = myDR["LanguageCode"].ToString();
                _template_version = myDR["Template_Version"].ToString();
                _release_date = Convert.ToDateTime(myDR["Release_Date"]);
                _author = myDR["Author"].ToString();
                _description = myDR["Description"].ToString();

            }
        }
    }

    // Template
    public class Template_List
    {

        private string _templateid;
        private string _template_masterpageid;
        private string _themeid;
        private string _masterpage_template_name;
        private string _masterpage_version;
        private string _theme_name;
        private string _theme_code;

        private string _masterpage_root;
        private string _masterpage_previewurl;
        private string _masterpage_previewurl_big;

        public string TemplateID { get { return _templateid; } }
        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string MasterPage_Template_Name { get { return _masterpage_template_name; } }
        public string ThemeID { get { return _themeid; } }
        public string MasterPage_Version { get { return _masterpage_version; } }
        public string Theme_Name { get { return _theme_name; } }
        public string Theme_Code { get { return _theme_code; } }

        public string MasterPage_Root { get { return _masterpage_root; } }
        public string MasterPage_PreviewURL { get { return _masterpage_previewurl; } }
        public string MasterPage_PreviewURL_Big { get { return _masterpage_previewurl_big; } }

        public Template_List(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _templateid = myDR["TemplateID"].ToString();
                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _themeid = myDR["ThemeID"].ToString();
                _masterpage_template_name = myDR["MasterPage_Template_Name"].ToString();
                _masterpage_version = myDR["MasterPage_Version"].ToString();
                _theme_name = myDR["Theme_Name"].ToString();
                _theme_code = myDR["Theme_Code"].ToString();

                _masterpage_root = string.Format("/App_Themes/{0}/", _theme_code);
                _masterpage_previewurl = _masterpage_root + _masterpage_template_name.Replace(" ", "") + ".jpg";
                _masterpage_previewurl_big = _masterpage_root + _masterpage_template_name.Replace(" ", "") + "800.jpg";

            }
        }
    }

    // Template - MasterPage
    public class Template_MasterPage
    {

        private string _template_masterpageid;
        private string _templateid;
        private string _masterpage_template_name;
        private string _masterpage_version;
        private string _masterpage_url;

        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string TemplateID { get { return _templateid; } }
        public string MasterPage_Template_Name { get { return _masterpage_template_name; } }
        public string MasterPage_Version { get { return _masterpage_version; } }
        public string MasterPage_URL { get { return _masterpage_url; } }

        public Template_MasterPage(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _templateid = myDR["TemplateID"].ToString();
                _masterpage_template_name = myDR["MasterPage_Template_Name"].ToString();
                _masterpage_version = myDR["MasterPage_Version"].ToString();
                _masterpage_url = myDR["MasterPage_URL"].ToString();

            }
        }
    }

    // Template - MasterPage
    public class Template_MasterPage_List
    {

        private string _masterpageindexid;
        private string _masterpage_name;
        private string _templateid;
        private string _template_masterpageid;
        private string _masterpage_template_name;
        private string _themeid;
        private string _theme_name;
        private string _theme_code;
        private string _masterpage_root;
        private string _masterpage_version;
        private string _masterpage_description;

        private string _masterpage_previewurl;
        private int _usagecount;


        public string MasterPageIndexID { get { return _masterpageindexid; } }
        public string MasterPage_Name { get { return _masterpage_name; } }
        public string TemplateID { get { return _templateid; } }
        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string MasterPage_Template_Name { get { return _masterpage_template_name; } }
        public string ThemeID { get { return _themeid; } }
        public string Theme_Name { get { return _theme_name; } }
        public string Theme_Code { get { return _theme_code; } }
        public string MasterPage_Root { get { return _masterpage_root; } }
        public string MasterPage_Version { get { return _masterpage_version; } }
        public string MasterPage_Description { get { return _masterpage_description; } }
        public string MasterPage_PreviewURL { get { return _masterpage_previewurl; } }
        public int UsageCount { get { return _usagecount; } }

        public Template_MasterPage_List(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _masterpage_name = myDR["MasterPage_Name"].ToString();
                _templateid = myDR["TemplateID"].ToString();
                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _masterpage_template_name = myDR["MasterPage_Template_Name"].ToString();
                _themeid = myDR["ThemeID"].ToString();
                _theme_name = myDR["Theme_Name"].ToString();
                _theme_code = myDR["Theme_Code"].ToString();
                _masterpage_version = myDR["MasterPage_Version"].ToString();
                _masterpage_description = myDR["MasterPage_Description"].ToString();

                _masterpage_root = string.Format("/App_Themes/{0}/", _theme_code);

                _masterpage_previewurl = _masterpage_root + _masterpage_template_name.Replace(" ", "") + ".jpg";
                _usagecount = Convert.ToInt32(myDR["UsageCounts"]);
            }
        }

        public Template_MasterPage_List(DataRow myDR, int usagecount)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _masterpage_name = myDR["MasterPage_Name"].ToString();
                _masterpage_description = myDR["MasterPage_Description"].ToString();

                _theme_code = myDR["Theme_Code"].ToString();

                _masterpage_root = string.Format("/App_Themes/{0}/", _theme_code);
                _masterpage_template_name = myDR["MasterPage_Template_Name"].ToString();

                _masterpage_previewurl = _masterpage_root + _masterpage_template_name.Replace(" ", "") + ".jpg";
                _usagecount = usagecount;
            }
        }

    }

    // Template - MasterPage's Controls
    public class Template_MasterPage_Control
    {

        private string _controlid;
        private string _template_masterpageid;
        private string _placeholderid;
        private int _minwidth;
        private int _minheight;
        private DockZone_Orientation _orientation;

        public string ControlID { get { return _controlid; } }
        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string PlaceHolderID { get { return _placeholderid; } }
        public int MinWidth { get { return _minwidth; } }
        public int MinHeight { get { return _minheight; } }
        public DockZone_Orientation Orientation { get { return _orientation; } }

        public Template_MasterPage_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _controlid = myDR["ControlID"].ToString();
                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _placeholderid = myDR["PlaceHolderID"].ToString();
                _minwidth = Convert.ToInt32(myDR["MinWidth"]);
                _minheight = Convert.ToInt32(myDR["MinHeight"]);
                _orientation = (DockZone_Orientation)StringEnum.Parse(typeof(DockZone_Orientation), myDR["Orientation"].ToString(), true);

            }
        }
    }

    // Themes
    public class Theme
    {

        private string _themeid;
        private string _templateid;
        private string _theme_name;
        private string _languagecode;
        private string _theme_version;
        private string _theme_code;
        private DateTime _release_date;
        private string _author;
        private string _description;

        public string ThemeID { get { return _themeid; } }
        public string TemplateID { get { return _templateid; } }
        public string Theme_Name { get { return _theme_name; } }
        public string LanguageCode { get { return _languagecode; } }
        public string Theme_Version { get { return _theme_version; } }
        public string Theme_Code { get { return _theme_code; } }
        public DateTime Release_Date { get { return _release_date; } }
        public string Author { get { return _author; } }
        public string Description { get { return _description; } }

        public Theme(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _themeid = myDR["ThemeID"].ToString();
                _templateid = myDR["TemplateID"].ToString();
                _theme_name = myDR["Theme_Name"].ToString();
                _languagecode = myDR["LanguageCode"].ToString();
                _theme_version = myDR["Theme_Version"].ToString();
                _theme_code = myDR["Theme_Code"].ToString();
                _release_date = Convert.ToDateTime(myDR["Release_Date"]);
                _author = myDR["Author"].ToString();
                _description = myDR["Description"].ToString();

            }
        }
    }

    // MasterPage Index
    public class MasterPageIndex
    {

        private string _masterpageindexid;
        private string _masterpage_name;
        private string _templateid;
        private string _template_masterpageid;
        private string _themeid;
        private string _masterpage_description;

        public string MasterPageIndexID { get { return _masterpageindexid; } }
        public string MasterPage_Name { get { return _masterpage_name; } }
        public string TemplateID { get { return _templateid; } }
        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string ThemeID { get { return _themeid; } }
        public string MasterPage_Description { get { return _masterpage_description; } }

        public MasterPageIndex(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _masterpage_name = myDR["MasterPage_Name"].ToString();
                _templateid = myDR["TemplateID"].ToString();
                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _themeid = myDR["ThemeID"].ToString();
                _masterpage_description = myDR["MasterPage_Description"].ToString();

            }
        }
    }

    // MasterPage Index
    public class NexusCore_MasterPage
    {

        private string _masterpageid;
        private string _masterpageindexid;
        private int _masterpage_version;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;
        private bool _isactive;
        private bool _isdelete;

        public string MasterPageID { get { return _masterpageid; } }
        public string MasterPageIndexID { get { return _masterpageindexid; } }
        public int MasterPage_Version { get { return _masterpage_version; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }
        public bool IsActive { get { return _isactive; } }
        public bool IsDelete { get { return _isdelete; } }

        public NexusCore_MasterPage(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _masterpageid = myDR["MasterPageID"].ToString();
                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _masterpage_version = Convert.ToInt16(myDR["MasterPage_Version"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _isdelete = Convert.ToBoolean(myDR["IsDelete"]);

            }
        }
    }

    // MasterPage Controls
    public class MasterPage_Control
    {

        private string _page_controlid;
        private string _masterpageid;
        private string _placeholderid;
        private string _componentid;
        private int _sortorder;

        public string Page_ControlID { get { return _page_controlid; } }
        public string MasterPageID { get { return _masterpageid; } }
        public string PlaceHolderID { get { return _placeholderid; } }
        public string ComponentID { get { return _componentid; } }
        public int SortOrder { get { return _sortorder; } }

        public MasterPage_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_controlid = myDR["Page_ControlID"].ToString();
                _masterpageid = myDR["MasterPageID"].ToString();
                _placeholderid = myDR["PlaceHolderID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);

            }
        }
    }

    // MasterPage Control Properties
    public class MasterPage_Control_Property
    {

        private string _control_propertyid;
        private string _page_controlid;
        private string _property_name;
        private string _property_value;

        public string Control_PropertyID { get { return _control_propertyid; } }
        public string Page_ControlID { get { return _page_controlid; } }
        public string Property_Name { get { return _property_name; } }
        public string Property_Value { get { return _property_value; } }

        public MasterPage_Control_Property(DataRow myDR)
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

    // Page Locks
    public class MasterPage_Lock
    {

        private string _masterpage_lockid;
        private string _masterpageindexid;
        private string _masterpage_name;
        private string _masterpageid;
        private string _templateid;
        private string _template_masterpageid;
        private string _themeid;
        private string _masterpage_description;

        private string _userid;
        private DateTime _lockdate;
        private bool _isdirty;

        public string MasterPage_LockID { get { return _masterpage_lockid; } }
        public string MasterPageIndexID { get { return _masterpageindexid; } }
        public string MasterPage_Name { get { return _masterpage_name; } }
        public string MasterPageID { get { return _masterpageid; } }
        public string TemplateID { get { return _templateid; } }
        public string Template_MasterPageID { get { return _template_masterpageid; } }
        public string ThemeID { get { return _themeid; } }
        public string MasterPage_Description { get { return _masterpage_description; } }

        public string UserID { get { return _userid; } }
        public DateTime LockDate { get { return _lockdate; } }
        public bool IsDirty { get { return _isdirty; } }

        public MasterPage_Lock(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _masterpage_lockid = myDR["MasterPage_LockID"].ToString();
                _masterpageindexid = myDR["MasterPageIndexID"].ToString();
                _masterpage_name = myDR["MasterPage_Name"].ToString();
                _masterpageid = myDR["MasterPageID"].ToString();
                _templateid = myDR["TemplateID"].ToString();
                _template_masterpageid = myDR["Template_MasterPageID"].ToString();
                _themeid = myDR["ThemeID"].ToString();
                _masterpage_description = myDR["MasterPage_Description"].ToString();

                _userid = myDR["UserID"].ToString();
                _lockdate = Convert.ToDateTime(myDR["LockDate"]);
                _isdirty = Convert.ToBoolean(myDR["IsDirty"]);

            }

        }
    }

    // Page Lock Controls
    public class MasterPage_Lock_Control
    {

        private string _page_controlid;
        private string _masterpage_lockid;
        private string _placeholderid;
        private string _componentid;
        private int _sortorder;
        private bool _isdirty;

        public string Page_ControlID { get { return _page_controlid; } }
        public string MasterPage_LockID { get { return _masterpage_lockid; } }
        public string PlaceHolderID { get { return _placeholderid; } }
        public string ComponentID { get { return _componentid; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsDirty { get { return _isdirty; } }

        public MasterPage_Lock_Control(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _page_controlid = myDR["Page_ControlID"].ToString();
                _masterpage_lockid = myDR["MasterPage_LockID"].ToString();
                _placeholderid = myDR["PlaceHolderID"].ToString();
                _componentid = myDR["ComponentID"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);
                _isdirty = Convert.ToBoolean(myDR["IsDirty"]);

            }
        }
    }

    // Page Control Properties
    public class MasterPage_Lock_Control_Property
    {

        private string _control_propertyid;
        private string _page_controlid;
        private string _property_name;
        private string _property_value;

        public string Control_PropertyID { get { return _control_propertyid; } }
        public string Page_ControlID { get { return _page_controlid; } }
        public string Property_Name { get { return _property_name; } }
        public string Property_Value { get { return _property_value; } }

        public MasterPage_Lock_Control_Property(DataRow myDR)
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

}
