using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Threading;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.Tools;

namespace Nexus.Core.URLrewriter
{
    public class UrlMgr
    {
        public UrlMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public string Get_PageIndex_URL(string PageIndexID)
        {
            List<PageIndex> list = new List<PageIndex>();
            Build_PageIndex_Tree(list, PageIndexID);

            string _url = "";
            foreach (PageIndex myPageIndex in list)
            {
                _url += "/"
                    + myPageIndex.Page_Name;
            }

            return _url;

        }

        public string Get_PageIndex_PageURL(string PageIndexID)
        {
            List<PageIndex> list = new List<PageIndex>();
            Build_PageIndex_Tree(list, PageIndexID);

            string _url = "";
            foreach (PageIndex myPageIndex in list)
            {
                _url += "/"
                    + myPageIndex.Page_Name;
            }

            return _url + ".aspx";

        }

        public List<PageIndex> Get_PageIndex_Tree(string PageIndexID)
        {
            List<PageIndex> list = new List<PageIndex>();
            return Build_PageIndex_Tree(list, PageIndexID);
        }

        private List<PageIndex> Build_PageIndex_Tree(List<PageIndex> list, string PageIndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataRow myDR = myDP.Get_PageIndex(PageIndexID);

            PageIndex myPageIndex = new PageIndex(myDR);

            if (DataEval.IsEmptyQuery(myPageIndex.PageIndexID))
            {
                return list;
            }
            else
            {
                if (myPageIndex.PageIndexID == "-1"
                    || myPageIndex.Parent_PageIndexID == "-1")
                {
                    list.Insert(0, myPageIndex);
                    return list;
                }
                else
                {
                    list.Insert(0, myPageIndex);
                    return Build_PageIndex_Tree(list, myPageIndex.Parent_PageIndexID);
                }
            }

        }

        /// <summary>
        /// Convert Page URL to SEO friendly URL without pageindexid
        /// </summary>
        /// <param name="OriginalURL">Request.URL</param>
        /// <returns></returns>
        public string Get_SEO_Friendly_URL(string OriginalURL)
        {
            string ReturnURL;

            string _pageindexid = URLParse.Get_ArgValue(OriginalURL, "PageIndexID");

            if (_pageindexid != null)
            {
                UrlMgr myUrlMgr = new UrlMgr();
                ReturnURL = myUrlMgr.Get_PageIndex_PageURL(_pageindexid);

                OriginalURL = URLParse.Remove_Arg(ReturnURL, "PageIndexID");

                if (!DataEval.IsEmptyQuery(URLParse.Get_Arg(OriginalURL)))
                {
                    ReturnURL += "?" + URLParse.Get_Arg(OriginalURL);
                    ReturnURL = URLParse.Remove_Arg(ReturnURL, "PageIndexID");
                }
            }
            else
            {
                ReturnURL = OriginalURL;
            }

            return ReturnURL;
        }

    }
}
