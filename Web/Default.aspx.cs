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
using Nexus.Core.Pages;
using Nexus.Security;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class Default : System.Web.UI.Page
    {

        private string _pageindexid;
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

            // Check Homepage 
            PageMgr myPageMgr = new PageMgr();
            Templates.MasterPageMgr myMasterPageMgr = new Templates.MasterPageMgr();

            if (DataEval.IsEmptyQuery(_pageindexid) || !myPageMgr.Chk_PageIndexID(_pageindexid) || !Convert.ToBoolean(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomeSwitch")))
            {
                return;
            }

            // Load Page Properties
            #region Page Properties

            HtmlMeta myKeyword = new HtmlMeta();
            myKeyword.Name = "Keyword";
            myKeyword.Content = myPage_Loading_Info.Page_Keyword;
            Header.Controls.Add(myKeyword);

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
            List<Pages.MetaTag> myPageCSS = myPageMgr.Get_Page_MetaTags(_pageindexid, Pages.Meta_Type.StyleSheet);

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
            List<Pages.MetaTag> myPageScripts = myPageMgr.Get_Page_MetaTags(_pageindexid, Pages.Meta_Type.JavaScript);

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

            #endregion

            // Add Script Manager
            RadScriptManager myScriptMgr = new RadScriptManager();
            myScriptMgr.ID = "ScriptManager_NexusCore";

            HtmlForm myForm = (HtmlForm)Page.Master.FindControl("Form_NexusCore");
            myForm.Controls.Add(myScriptMgr);

            // Add PlaceHolder
            PlaceHolder myPlaceHolder = new PlaceHolder();
            myPlaceHolder.ID = "PlaceHolder_AdvancedMode";

            #region Add Control Manager Windows
            // Create CodeBlock
            RadScriptBlock myCodeBlock = new RadScriptBlock();

            // Create Script Tag
            HtmlGenericControl myCodeBlock_ScriptTag = new HtmlGenericControl("script");
            myCodeBlock_ScriptTag.Attributes.Add("type", "text/javascript");
            myCodeBlock_ScriptTag.InnerHtml = Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_PageEditor_PoPWindow");
            myCodeBlock.Controls.Add(myCodeBlock_ScriptTag);

            // Create Window Manager
            RadWindowManager myWindowManager = new RadWindowManager();
            myWindowManager.ID = "RadWindowManager_ControlManager";

            // Create RadWindow
            RadWindow myRadWindow = new RadWindow();
            myRadWindow.ID = "RadWindow_ControlManager";
            myRadWindow.Title = "User Control Manager";
            myRadWindow.ReloadOnShow = true;
            myRadWindow.ShowContentDuringLoad = false;
            myRadWindow.Modal = true;
            myRadWindow.Animation = WindowAnimation.Fade;
            myRadWindow.AutoSize = true;
            myRadWindow.Behaviors = WindowBehaviors.Maximize | WindowBehaviors.Close;
            myRadWindow.InitialBehaviors = WindowBehaviors.Resize | WindowBehaviors.Pin;
            //myRadWindow.DestroyOnClose = true;
            myRadWindow.KeepInScreenBounds = true;
            myRadWindow.VisibleStatusbar = false;

            myWindowManager.Windows.Add(myRadWindow);

            // Create AjaxManager
            RadAjaxManager myRadAjaxManager = new RadAjaxManager();
            myRadAjaxManager.ID = "RadAjaxManager_ControlManger";
            myRadAjaxManager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate(RadAjaxManager_AjaxRequest);

            // Add to Place Holder
            myPlaceHolder.Controls.Add(myCodeBlock);
            myPlaceHolder.Controls.Add(myWindowManager);
            myPlaceHolder.Controls.Add(myRadAjaxManager);

            #endregion

            #region Add Warp Controls and Dock Layout

            // Remove inline Controls
            HtmlGenericControl myContentDiv = (HtmlGenericControl)Page.Master.FindControl("pageWrapContainer");
            Page.Master.Controls.Remove(myContentDiv);

            // Create Hidden Update_Panel
            UpdatePanel myUpdatePanel_Docks = new UpdatePanel();
            myUpdatePanel_Docks.ID = "UpdatePanel_Docks";

            // Create myRadAjaxManager Postback Trigger
            PostBackTrigger RadAjaxTrigger = new PostBackTrigger();
            RadAjaxTrigger.ControlID = myRadAjaxManager.ID;
            myUpdatePanel_Docks.Triggers.Add(RadAjaxTrigger);

            // Add inLine Controls back
            myPlaceHolder.Controls.Add(myUpdatePanel_Docks);

            //myUpdatePanel_DockLayout.ContentTemplateContainer.Controls.Add(myDockLayout);

            myPlaceHolder.Controls.Add(myContentDiv);
            myForm.Controls.Add(myPlaceHolder);

            #endregion

            #region Enable Editor Tool Bar

            if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
            {
                // Create Script Tag
                HtmlGenericControl myToolBar_ScriptTag = new HtmlGenericControl("script");
                myToolBar_ScriptTag.Attributes.Add("type", "text/javascript");
                myToolBar_ScriptTag.InnerHtml = Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_LivePage_ToolBar");
                Header.Controls.Add(myToolBar_ScriptTag);

                // Create List of Command
                Panel myLivePageCommand = new Panel();
                myLivePageCommand.CssClass = "nexusCore_slidingOut_toolPanel";

                LinkButton lbtn_LivePage_EnableEditMode = new LinkButton();
                lbtn_LivePage_EnableEditMode.ID = "lbtn_LivePage_EnableEditMode";

                if (Session["isEditMode"] != null)
                {
                    if (Convert.ToBoolean(Session["isEditMode"]))
                        lbtn_LivePage_EnableEditMode.Text = "Disable Edit Mode";
                    else
                        lbtn_LivePage_EnableEditMode.Text = "Enable Edit Mode";
                }
                else
                {
                    lbtn_LivePage_EnableEditMode.Text = "Enable Edit Mode";
                }

                lbtn_LivePage_EnableEditMode.Click += new EventHandler(lbtn_LivePage_EnableEditMode_Click);

                myLivePageCommand.Controls.Add(lbtn_LivePage_EnableEditMode);

                // Add <br>
                myLivePageCommand.Controls.Add(new LiteralControl("<br /><br />"));

                // Edit this page in Desinger Mode
                HtmlAnchor Desinger_Button = new HtmlAnchor();
                Desinger_Button.HRef = string.Format("/App_AdminCP/DesignerMode.aspx?PageIndexID={0}", _pageindexid);
                Desinger_Button.Target = "DesingerMode";
                Desinger_Button.InnerHtml = "Edit in Designer Mode";
                myLivePageCommand.Controls.Add(Desinger_Button);

                // Add <p>
                myLivePageCommand.Controls.Add(new LiteralControl("<p></p>"));

                // Add Software Version
                string _version = string.Format("ver. {0}", Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Version"));
                myLivePageCommand.Controls.Add(new LiteralControl(_version));

                // Create Tool button
                HtmlAnchor myToolBar_Button = new HtmlAnchor();
                myToolBar_Button.Attributes.Add("class", "nexusCore_toolPanel_trigger");
                myToolBar_Button.HRef = "#";
                myToolBar_Button.InnerHtml = "Tools";


                myForm.Controls.Add(myLivePageCommand);
                myForm.Controls.Add(myToolBar_Button);

            }
            else
            {
                if (Session["isEditMode"] != null)
                    Session["isEditMode"] = false;
            }

            #endregion
        }

        private void Page_Controls()
        {

            // Check Homepage 
            PageMgr myPageMgr = new PageMgr();

            if (DataEval.IsEmptyQuery(_pageindexid) || !myPageMgr.Chk_PageIndexID(_pageindexid) || !Convert.ToBoolean(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomeSwitch")))
            {
                Response.Write("<table width=100% height=100%><tr><th>"
                    + "<h1><strong>Thank you for visiting our web site.</strong></h1><p>Please return soon for updates.</p>"
                    + "</th></tr></table>");
                return;
            }

            // Load MasterPage Control
            bool isEditMode;

            if (Session["isEditMode"] != null)
                isEditMode = Convert.ToBoolean(Session["isEditMode"]);
            else
                isEditMode = false;

            Nexus.Core.Templates.MasterPageMgr myMasterPageMgr = new Nexus.Core.Templates.MasterPageMgr();
            myMasterPageMgr.Load_MasterPageControls_WebView(this.Page, myPage_Loading_Info, isEditMode);

            // Load Page Control
            myPageMgr.Load_PageControls_WebView(this.Page, myPage_Loading_Info, isEditMode);
        }

        protected override void OnPreInit(EventArgs e)
        {

            Nexus.Core.Pages.PageMgr myPageMgr = new Nexus.Core.Pages.PageMgr();

            // Check _pageindexid
            _pageindexid = Request["PageIndexID"];

            if (DataEval.IsEmptyQuery(_pageindexid) || !myPageMgr.Chk_PageIndexID(_pageindexid) || !Convert.ToBoolean(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomeSwitch")))
            {
                // PageIndexID not exist go to homepage
                _pageindexid = myPageMgr.Get_Homepage_PageIndexID();

                if (DataEval.IsEmptyQuery(_pageindexid) || !myPageMgr.Chk_PageIndexID(_pageindexid) || !Convert.ToBoolean(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomeSwitch")))
                {
                    return;
                }
                else
                {
                    URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();
                    string realUrl = myUrlMgr.Get_PageIndex_PageURL(_pageindexid);
                    string args = Request.QueryString.ToString();
                    realUrl = Tools.URLParse.Combine_Arg(realUrl, args);

                    Response.Redirect(realUrl);
                }
            }


            // Check Page Types       
            Nexus.Core.Pages.PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            switch (myPageIndex.Page_Type)
            {
                case Page_Type.Normal_Page:
                    Load_Normal_Page(_pageindexid);
                    break;
                case Page_Type.Category:
                    Load_Category(_pageindexid);
                    break;
                case Page_Type.Internal_Page_Pointer:
                    Load_Internal_Page(_pageindexid);
                    break;
                case Page_Type.External_Link:
                    Load_External_Page(_pageindexid);
                    break;
            }

            base.OnPreInit(e);
        }

        #region Control Window Event

        protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {

        }

        #endregion

        #region Load Page Setting

        private void Load_Normal_Page(string PageIndexID)
        {
            // Check Properties

            // Check Security
            if (!Security.Users.UserStatus.Validate_PageAuth_View(this.Page))
            {
                Security.Pages.PrivacyMgr myPrivacyMgr = new Security.Pages.PrivacyMgr();
                string _inherited_pageindexid = myPrivacyMgr.Get_Inherited_Privacy_PageIndexID(PageIndexID);
                Security.Pages.Page_PrivacyURL myPage_PrivacyURL = myPrivacyMgr.Get_Page_PrivacyURL(_inherited_pageindexid);
                Response.Redirect(myPage_PrivacyURL.ReturnURL);
            }

            // Load Pages Template
            Nexus.Core.Pages.Page_PropertyMgr myPropertyMgr = new Nexus.Core.Pages.Page_PropertyMgr();
            myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(PageIndexID);

            // Get MasterPageID
            //_master_pageindexid = myPage_Loading_Info.MasterPageIndexID;

            //this.StyleSheetTheme = myPage_Loading_Info.Theme;
            this.Theme = myPage_Loading_Info.Theme;
            this.MasterPageFile = myPage_Loading_Info.MasterPage_URL;

            this.Title = myPage_Loading_Info.Page_Title;

        }

        private void Load_Category(string PageIndexID)
        {
            PageMgr myPageMgr = new PageMgr();
            PageIndex myChild_PageIndex = myPageMgr.Get_Child_PageIndex(PageIndexID, null);

            Response.Redirect(Nexus.Core.Tools.URLParse.Update_Arg(Request.Url.ToString(), "PageIndexID", myChild_PageIndex.PageIndexID));
        }

        private void Load_Internal_Page(string PageIndexID)
        {
            Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();
            Page_IntLink myPage_IntLink = myPage_PropertyMgr.Get_Page_IntLink(PageIndexID);

            Response.Redirect(Nexus.Core.Tools.URLParse.Update_Arg(Request.Url.ToString(), "PageIndexID", myPage_IntLink.PagePointerID));

        }

        private void Load_External_Page(string PageIndexID)
        {
            Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();
            Page_ExtLink myPage_ExtLink = myPage_PropertyMgr.Get_Page_ExtLink(PageIndexID);

            Response.Redirect(myPage_ExtLink.Page_URL);
        }

        #endregion

        #region Load Live Page Command

        protected void lbtn_LivePage_EnableEditMode_Click(object sender, EventArgs e)
        {
            if (Session["isEditMode"] != null)
            {
                if (Convert.ToBoolean(Session["isEditMode"]))
                    Session["isEditMode"] = false;
                else
                    Session["isEditMode"] = true;
            }
            else
            {
                Session["isEditMode"] = true;
            }

            URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();
            Response.Redirect(myUrlMgr.Get_SEO_Friendly_URL(Request.Url.ToString()));
        }

        #endregion
    }

}