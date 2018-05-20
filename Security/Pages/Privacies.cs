using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nexus.Security.Pages
{
    // Page Privacy URL class
    public class Page_PrivacyURL
    {

        private string _privacyid;
        private string _pageindexid;
        private string _returnurl;

        public string PrivacyID { get { return _privacyid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string ReturnURL { get { return _returnurl; } }

        public Page_PrivacyURL(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _privacyid = myDR["PrivacyID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _returnurl = myDR["ReturnURL"].ToString();

            }
        }

    }

    // Page Privacy class
    public class Page_Privacy
    {

        private string _privacyid;
        private string _pageindexid;
        private string _usergroupid;
        private bool _allow_view;
        private bool _allow_create;
        private bool _allow_modify;
        private bool _allow_delete;
        private bool _allow_rollback;
        private bool _allow_changepermissions;
        private bool _allow_approve;
        private bool _allow_publish;
        private bool _allow_designmode;

        public string PrivacyID { get { return _privacyid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string UserGroupID { get { return _usergroupid; } }
        public bool Allow_View { get { return _allow_view; } }
        public bool Allow_Create { get { return _allow_create; } }
        public bool Allow_Modify { get { return _allow_modify; } }
        public bool Allow_Delete { get { return _allow_delete; } }
        public bool Allow_Rollback { get { return _allow_rollback; } }
        public bool Allow_ChangePermissions { get { return _allow_changepermissions; } }
        public bool Allow_Approve { get { return _allow_approve; } }
        public bool Allow_Publish { get { return _allow_publish; } }
        public bool Allow_DesignMode { get { return _allow_designmode; } }

        public Page_Privacy(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _privacyid = myDR["PrivacyID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _usergroupid = myDR["UserGroupID"].ToString();
                _allow_view = (bool)myDR["Allow_View"];
                _allow_create = (bool)myDR["Allow_Create"];
                _allow_modify = (bool)myDR["Allow_Modify"];
                _allow_delete = (bool)myDR["Allow_Delete"];
                _allow_rollback = (bool)myDR["Allow_Rollback"];
                _allow_changepermissions = (bool)myDR["Allow_ChangePermissions"];
                _allow_approve = (bool)myDR["Allow_Approve"];
                _allow_publish = (bool)myDR["Allow_Publish"];
                _allow_designmode = (bool)myDR["Allow_DesignMode"];

            }
        }

    }

    public class Page_Privacy_Full
    {

        private string _privacyid;
        private string _pageindexid;
        private string _usergroupid;
        private string _usergroup_name;
        private string _usergroup_description;
        private bool _allow_view;
        private bool _allow_create;
        private bool _allow_modify;
        private bool _allow_delete;
        private bool _allow_rollback;
        private bool _allow_changepermissions;
        private bool _allow_approve;
        private bool _allow_publish;
        private bool _allow_designmode;

        public string PrivacyID { get { return _privacyid; } }
        public string PageIndexID { get { return _pageindexid; } }
        public string UserGroupID { get { return _usergroupid; } }
        public string UserGroup_Name { get { return _usergroup_name; } }
        public string UserGroup_Description { get { return _usergroup_description; } }
        public bool Allow_View { get { return _allow_view; } }
        public bool Allow_Create { get { return _allow_create; } }
        public bool Allow_Modify { get { return _allow_modify; } }
        public bool Allow_Delete { get { return _allow_delete; } }
        public bool Allow_Rollback { get { return _allow_rollback; } }
        public bool Allow_ChangePermissions { get { return _allow_changepermissions; } }
        public bool Allow_Approve { get { return _allow_approve; } }
        public bool Allow_Publish { get { return _allow_publish; } }
        public bool Allow_DesignMode { get { return _allow_designmode; } }

        public Page_Privacy_Full(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _privacyid = myDR["PrivacyID"].ToString();
                _pageindexid = myDR["PageIndexID"].ToString();
                _usergroupid = myDR["UserGroupID"].ToString();
                _usergroup_name = myDR["UserGroup_Name"].ToString();
                _usergroup_description = myDR["UserGroup_Description"].ToString();
                _allow_view = (bool)myDR["Allow_View"];
                _allow_create = (bool)myDR["Allow_Create"];
                _allow_modify = (bool)myDR["Allow_Modify"];
                _allow_delete = (bool)myDR["Allow_Delete"];
                _allow_rollback = (bool)myDR["Allow_Rollback"];
                _allow_changepermissions = (bool)myDR["Allow_ChangePermissions"];
                _allow_approve = (bool)myDR["Allow_Approve"];
                _allow_publish = (bool)myDR["Allow_Publish"];
                _allow_designmode = (bool)myDR["Allow_DesignMode"];

            }
        }

    }

    // Page Index class
    public class PageIndex
    {

        private string _pageindexid;
        private string _parent_pageindexid;
        private string _page_categoryid;
        private string _page_name;
        private string _sortorder;

        public string PageIndexID { get { return _pageindexid; } }
        public string Parent_PageIndexID { get { return _parent_pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Page_Name { get { return _page_name; } }
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
                _page_name = myDR["Page_Name"].ToString();
                _sortorder = myDR["SortOrder"].ToString();

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

}
