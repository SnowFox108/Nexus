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
using Nexus.Core.Templates;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Templates_DesignPreview : System.Web.UI.Page
    {

        private MasterPageIndex myMasterPageIndex;
        private Page_Loading_Info myPage_Loading_Info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            Page_Controls();

        }

        private void Page_Init()
        {

            // Load Page Properties
            HtmlMeta myDescription = new HtmlMeta();
            myDescription.Name = "Description";
            myDescription.Content = myMasterPageIndex.MasterPage_Description;
            this.Header.Controls.Add(myDescription);

            #region Add MetaTags

            PageMgr myPageMgr = new PageMgr();
            Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

            #region Global and Page Level

            // Add CSS for Advanced window
            List<Pages.MetaTag> CssFiles = new List<Pages.MetaTag>();

            // Load Global CSS
            List<Pages.MetaTag> myGlobalCSS = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.StyleSheet);

            foreach (Pages.MetaTag myMetaTag in myGlobalCSS)
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
            List<Pages.MetaTag> Scripts = new List<Pages.MetaTag>();

            // Load Global Script
            List<Pages.MetaTag> myGlobalScripts = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.JavaScript);

            foreach (Pages.MetaTag myMetaTag in myGlobalScripts)
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
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myPage_Loading_Info);
        }

        protected override void OnPreInit(EventArgs e)
        {

            //myPage_Loading_Info = new Nexus.Core.Pages.Page_Loading_Info();

            // Check _pageindexid
            string _masterpageindexid = Request["MasterPageIndexID"];

            if (DataEval.IsEmptyQuery(_masterpageindexid))
            {
                // URLrewrite
                _masterpageindexid = "1";
            }

            // Check MasterPage Exist        
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(_masterpageindexid);

            // Get MasterPage Loading Info
            Nexus.Core.Pages.Page_PropertyMgr myPropertyMgr = new Nexus.Core.Pages.Page_PropertyMgr();
            myPage_Loading_Info = myPropertyMgr.Get_MasterPage_Loading_Info(_masterpageindexid);

            // Get Master PageID
            if (!DataEval.IsEmptyQuery(Request["MasterPageID"]))
            {
                myPage_Loading_Info.MasterPageID = Request["MasterPageID"];
            }

            // Check Properties

            // Check Security

            // Apply Them and MasterPage
            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(myMasterPageIndex.ThemeID);
            this.Theme = myTheme.Theme_Code;

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.Template_MasterPageID);
            this.MasterPageFile = myTemplate_MasterPage.MasterPage_URL;

            this.Title = myMasterPageIndex.MasterPage_Name;

            base.OnPreInit(e);
        }

    }
}