using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Nexus.Core.Pages;

namespace Nexus.Core.URLrewriter
{
    /// <summary>
    /// Process request and maps friendly Url to a real Url
    /// </summary>
    public class UrlRewriteModule : IHttpModule
    {
        public UrlRewriteModule()
        {

        }

        public void Init(System.Web.HttpApplication app)
        {
            app.BeginRequest += new EventHandler(Application_BeginRequest);
        }


        private void Application_BeginRequest(object sender, EventArgs e)
        {
            System.Web.HttpApplication app = (System.Web.HttpApplication)sender;

            if (app.Request["PageIndexID"] == null)
            {
                string requestedURL = app.Request.Path.ToLower();
                string realUrl = Get_WebBuilderURL(requestedURL);

                if (!String.IsNullOrEmpty(realUrl))
                {
                    // bind orginal args
                    string args = app.Request.QueryString.ToString();
                    realUrl = Tools.URLParse.Combine_Arg(realUrl, args);

                    app.Context.RewritePath(realUrl, false);
                }
            }

        }

        /// <summary>
        /// Gets the real URL.
        /// </summary>
        /// <param name="requestedUrl">The requested URL.</param>
        /// <returns></returns>
        private string Get_WebBuilderURL(string requestdURL)
        {
            string[] PageNames = requestdURL.Split('/');

            string PageName = PageNames[PageNames.Length -1].Split('.')[0];

            Pages.PageMgr myPageMgr = new Pages.PageMgr();

            if (myPageMgr.Chk_PageName_Live(PageName))
            {
                List<PageIndex> myPageIndexs = myPageMgr.Get_PageIndex_ByName(PageName, "1");

                foreach (PageIndex myPageIndex in myPageIndexs)
                {
                    UrlMgr myUrlMgr = new UrlMgr();
                    string WebBuilderURL = myUrlMgr.Get_PageIndex_URL(myPageIndex.PageIndexID).ToLower() + ".aspx";
                    if (requestdURL == WebBuilderURL)
                    {
                        string _pageindexid = Chk_PageType(myPageIndex);
                        return "~/Default.aspx?PageIndexID=" + _pageindexid;
                    }
                        
                }

            }

            return null;

        }

        private string Chk_PageType(PageIndex myPageIndex)
        {
            PageMgr myPageMgr = new PageMgr();

            switch (myPageIndex.Page_Type)
            {
                case Page_Type.Normal_Page:
                    return myPageIndex.PageIndexID;
                case Page_Type.Category:
                    PageIndex myChild_PageIndex = myPageMgr.Get_Child_PageIndex(myPageIndex.PageIndexID, null);
                    return myChild_PageIndex.PageIndexID;
                case Page_Type.Internal_Page_Pointer:
                    return myPageIndex.PageIndexID;
                case Page_Type.External_Link:
                    return myPageIndex.PageIndexID;
            }

            return myPageIndex.PageIndexID;

        }

        public void Dispose()
        {

        }


    }
}
