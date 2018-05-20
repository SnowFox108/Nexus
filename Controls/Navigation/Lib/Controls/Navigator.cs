using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.URLrewriter;


namespace Nexus.Controls.Navigation.Lib
{
    public class Navigator
    {
        private string _pageindexid;
        private string _parent_pageindexid;
        private string _page_categoryid;
        private string _menu_title;
        private string _page_name;
        private Page_Type _page_type;
        private string _sortorder;

        private bool _isonnavigator;
        private string _navigateurl;

        public string PageIndexID { get { return _pageindexid; } }
        public string Parent_PageIndexID { get { return _parent_pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Menu_Title { get { return _menu_title; } }
        public string Page_Name { get { return _page_name; } }
        public Page_Type Page_Type { get { return _page_type; } }
        public string SortOrder { get { return _sortorder; } }
        
        public bool IsOnNavigator { get { return _isonnavigator; } }
        public string NavigateUrl { get { return _navigateurl; } }

        public Navigator(DataRow myDR)
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

                _isonnavigator = (bool)myDR["IsOnNavigator"];

                UrlMgr myUrlMgr = new UrlMgr();
                _navigateurl = myUrlMgr.Get_PageIndex_PageURL(_pageindexid);

            }

        }
    }

    public class NavigatorMgr
    {
        public NavigatorMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public List<Navigator> Get_Navigator(string PageIndexID, string RootPageIndexID)
        {
            List<Navigator> list = new List<Navigator>();
            return Build_Navigator(list, PageIndexID, RootPageIndexID);
        }

        private List<Navigator> Build_Navigator(List<Navigator> list, string PageIndexID, string RootPageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataRow myDR = myDP.Get_Navigator(PageIndexID);

            Navigator myNavigator = new Navigator(myDR);

            if (DataEval.IsEmptyQuery(myNavigator.PageIndexID))
            {
                return list;
            }
            else
            {
                if (myNavigator.PageIndexID == "-1"
                    || myNavigator.Parent_PageIndexID == "-1"
                    || myNavigator.PageIndexID == RootPageIndexID)
                {
                    list.Insert(0, myNavigator);
                    return list;
                }
                else
                {
                    list.Insert(0, myNavigator);
                    return Build_Navigator(list, myNavigator.Parent_PageIndexID, RootPageIndexID);
                }
            }

        }

        public Navigator Get_Navigator_Home(string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataRow myDR = myDP.Get_Navigator(PageIndexID);

            return new Navigator(myDR);
        }
    }
}
