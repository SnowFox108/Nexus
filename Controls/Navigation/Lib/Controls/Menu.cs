using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core.URLrewriter;

namespace Nexus.Controls.Navigation.Lib
{
    public class Menu
    {
        private string _pageindexid;
        private string _page_categoryid;
        private string _menu_title;
        private string _page_name;
        private string _sortorder;

        private string _navigateurl;

        public string PageIndexID { get { return _pageindexid; } }
        public string Page_CategoryID { get { return _page_categoryid; } }
        public string Menu_Title { get { return _menu_title; } }
        public string Page_Name { get { return _page_name; } }
        public string SortOrder { get { return _sortorder; } }

        public string NavigateUrl { get { return _navigateurl; } }

        public Menu(DataRow myDR)
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
                _sortorder = myDR["SortOrder"].ToString();

                UrlMgr myUrlMgr = new UrlMgr();
                _navigateurl = myUrlMgr.Get_PageIndex_PageURL(_pageindexid);
            }

        }
    }

    public class MenuMgr
    {
        public MenuMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public List<Menu> Get_Menu(string PageIndexID, bool DisplaySameLevel, bool DisplayCategory)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Menu(PageIndexID, DisplaySameLevel, DisplayCategory);

            List<Menu> list = new List<Menu>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Menu(myDR));
            }

            return list;

        }

    }
}
