using System;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_Default : System.Web.UI.Page
    {

        private Nexus.Core.Pages.Page_Loading_Info myPage_Loading_Info;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            Page_Controls();
        }

        private void Page_Init()
        {

            PageMgr myPageMgr = new PageMgr();
            Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

            // Load Page Properties
            HtmlMeta myKeyword = new HtmlMeta();
            myKeyword.Name = "Keyword";
            myKeyword.Content = myPage_Loading_Info.Page_Keyword;
            this.Header.Controls.Add(myKeyword);

            HtmlMeta myDescription = new HtmlMeta();
            myDescription.Name = "Description";
            myDescription.Content = myPage_Loading_Info.Page_Description;
            this.Header.Controls.Add(myDescription);

            #region Add MetaTags

            #region Global and Page Level

            // Add CSS for Advanced window
            List<Pages.MetaTag> CssFiles = new List<MetaTag>();

            // Load Global CSS
            List<Pages.MetaTag> myGlobalCSS = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.StyleSheet);

            foreach (Pages.MetaTag myMetaTag in myGlobalCSS)
            {
                CssFiles.Add(myMetaTag);
            }

            // Load Page CSS
            List<Pages.MetaTag> myPageCSS = myPageMgr.Get_Page_MetaTags(myPage_Loading_Info.PageIndexID, Pages.Meta_Type.StyleSheet);

            foreach (Pages.MetaTag myMetaTag in myPageCSS)
            {
                CssFiles.Add(myMetaTag);
            }


            foreach (Pages.MetaTag CssFile in CssFiles)
            {
                HtmlLink cssEditor_Link = new HtmlLink();
                cssEditor_Link.Href = CssFile.Meta_Src;
                cssEditor_Link.Attributes.Add("type", "text/css");
                cssEditor_Link.Attributes.Add("rel", "stylesheet");
                Header.Controls.Add(cssEditor_Link);
            }

            // Add Script File for Editor
            List<Pages.MetaTag> Scripts = new List<MetaTag>();

            // Load Global Script
            List<Pages.MetaTag> myGlobalScripts = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.JavaScript);

            foreach (Pages.MetaTag myMetaTag in myGlobalScripts)
            {
                Scripts.Add(myMetaTag);
            }

            // Load Page Script
            List<Pages.MetaTag> myPageScripts = myPageMgr.Get_Page_MetaTags(myPage_Loading_Info.PageIndexID, Pages.Meta_Type.JavaScript);

            foreach (Pages.MetaTag myMetaTag in myPageScripts)
            {
                Scripts.Add(myMetaTag);
            }

            foreach (Pages.MetaTag myScript in Scripts)
            {
                string MapPath = Request.ApplicationPath;

                if (MapPath.EndsWith("/"))
                {
                    MapPath = MapPath.Remove(MapPath.Length - 1) + myScript.Meta_Src;
                }
                else
                {
                    MapPath = MapPath + myScript;
                }

                HtmlGenericControl scriptTag = new HtmlGenericControl("script");
                scriptTag.Attributes.Add("type", "text/javascript");
                scriptTag.Attributes.Add("src", MapPath);
                Header.Controls.Add(scriptTag);
            }

            #endregion

            #region Masterpage Level

            // Load MasterPage CSS
            List<Templates.MetaTag> Master_CssFiles = new List<Templates.MetaTag>();


            List<Templates.MetaTag> myMasterPageCSS = myMasterPageMgr.Get_MasterPage_MetaTags(myPage_Loading_Info.MasterPageIndexID, Templates.Meta_Type.StyleSheet);

            foreach (Templates.MetaTag myMetaTag in myMasterPageCSS)
            {
                Master_CssFiles.Add(myMetaTag);
            }

            foreach (Templates.MetaTag CssFile in Master_CssFiles)
            {
                HtmlLink cssEditor_Link = new HtmlLink();
                cssEditor_Link.Href = CssFile.Meta_Src;
                cssEditor_Link.Attributes.Add("type", "text/css");
                cssEditor_Link.Attributes.Add("rel", "stylesheet");
                Header.Controls.Add(cssEditor_Link);
            }

            // Load MasterPage Scripts
            List<Templates.MetaTag> Master_Scripts = new List<Templates.MetaTag>();


            List<Templates.MetaTag> myMasterPageScripts = myMasterPageMgr.Get_MasterPage_MetaTags(myPage_Loading_Info.MasterPageIndexID, Templates.Meta_Type.JavaScript);

            foreach (Templates.MetaTag myMetaTag in myMasterPageScripts)
            {
                Master_Scripts.Add(myMetaTag);
            }

            foreach (Templates.MetaTag myScript in Master_Scripts)
            {
                string MapPath = Request.ApplicationPath;

                if (MapPath.EndsWith("/"))
                {
                    MapPath = MapPath.Remove(MapPath.Length - 1) + myScript.Meta_Src;
                }
                else
                {
                    MapPath = MapPath + myScript;
                }

                HtmlGenericControl scriptTag = new HtmlGenericControl("script");
                scriptTag.Attributes.Add("type", "text/javascript");
                scriptTag.Attributes.Add("src", MapPath);
                Header.Controls.Add(scriptTag);
            }


            #endregion

            #endregion

            // Add Script Manager
            RadScriptManager myScriptMgr = new RadScriptManager();
            myScriptMgr.ID = "RadScriptManager1";

            HtmlForm myForm = (HtmlForm)Page.Master.FindControl("Form_NexusCore");
            myForm.Controls.Add(myScriptMgr);

        }

        private void Page_Controls()
        {
            // Load MasterPage Control
            Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
            myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myPage_Loading_Info);

            // Load Page Control
            Nexus.Core.Pages.PageMgr myPageMgr = new Nexus.Core.Pages.PageMgr();
            myPageMgr.Load_PageControls_WebView(this.Page, myPage_Loading_Info);
        }

        protected override void OnPreInit(EventArgs e)
        {

            //myPage_Loading_Info = new Nexus.Core.Pages.Page_Loading_Info();

            // Check _pageindexid
            string _pageindexid = Request["PageIndexID"];

            if (DataEval.IsEmptyQuery(_pageindexid))
            {
                // URLrewrite
                _pageindexid = "1";
            }

            // Check PageExist        
            Nexus.Core.Pages.PageMgr myPageMgr = new Nexus.Core.Pages.PageMgr();
            Nexus.Core.Pages.PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            // Check Properties

            // Check Security

            // Load Pages Template
            Nexus.Core.Pages.Page_PropertyMgr myPropertyMgr = new Nexus.Core.Pages.Page_PropertyMgr();

            myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

            // Get MasterPageID
            //_master_pageindexid = myPage_Loading_Info.MasterPageIndexID;

            //this.StyleSheetTheme = myPage_Loading_Info.Theme;
            this.Theme = myPage_Loading_Info.Theme;
            this.MasterPageFile = myPage_Loading_Info.MasterPage_URL;

            this.Title = myPage_Loading_Info.Page_Title;

            base.OnPreInit(e);
        }

    }
}