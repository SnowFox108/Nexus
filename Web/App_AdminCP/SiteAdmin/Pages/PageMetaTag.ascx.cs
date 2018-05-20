using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Pages;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PageMetaTag : System.Web.UI.UserControl
    {

        #region properties

        private string _pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageIndexID
        {
            get
            {
                if (_pageindexid == null)
                {
                    return "";
                }
                return _pageindexid;
            }
            set
            {
                _pageindexid = value;
                ViewState["PageIndexID"] = _pageindexid;
                Control_Init();
                Control_FillData();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _pageindexid = ViewState["PageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_pageindexid == null)
                {
                    ViewState["PageIndexID"] = "";
                    Control_Init();
                }
            }
        }

        private void Control_Init()
        {

        }

        #region Data Fill

        public void Control_FillData()
        {

            #region Set Default Setting

            tbx_ScriptURL.Text = "";
            tbx_UpdateScriptURL.Text = "";
            Panel_Update_Script.Visible = false;

            tbx_CSSURL.Text = "";
            tbx_UpdateCSSURL.Text = "";
            Panel_Update_CSS.Visible = false;

            #endregion

            // Script
            PageMgr myPageMgr = new PageMgr();

            GridView_GlobalScripts.DataSource = myPageMgr.Get_Page_MetaTags("-1", Meta_Type.JavaScript);
            GridView_GlobalScripts.DataBind();

            GridView_Scripts.DataSource = myPageMgr.Get_Page_MetaTags(_pageindexid, Meta_Type.JavaScript);
            GridView_Scripts.DataBind();

            // CSS
            GridView_GlobalCSS.DataSource = myPageMgr.Get_Page_MetaTags("-1", Meta_Type.StyleSheet);
            GridView_GlobalCSS.DataBind();

            GridView_CSS.DataSource = myPageMgr.Get_Page_MetaTags(_pageindexid, Meta_Type.StyleSheet);
            GridView_CSS.DataBind();

        }

        #endregion

        #region Scripts

        protected void btn_AddScript_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PageMgr myPageMgr = new PageMgr();

                // Add New Script
                e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.JavaScript)),
                                      new e2Data("Meta_Src", tbx_ScriptURL.Text)
                                   };

                myPageMgr.Add_Page_MetaTag(UpdateData);

                tbx_ScriptURL.Text = "";

                Control_FillData();
            }

        }

        protected void lbtn_Script_Edit_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();
            MetaTag myMetaTag = myPageMgr.Get_Page_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateScriptURL.Text = myMetaTag.Meta_Src;
            btn_UpdateScript.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_Script.Visible = true;

        }

        protected void lbtn_Script_Delete_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();

            // Delete Role
            myPageMgr.Remove_Page_MetaTag(e.CommandArgument.ToString());

            // Update Script List
            Control_FillData();

        }

        protected void btn_UpdateScript_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {

                e2Data[] UpdateData = {
                                      new e2Data("MetaTagID", e.CommandArgument.ToString()),
                                      new e2Data("Meta_Src", tbx_UpdateScriptURL.Text)
                                   };

                PageMgr myPageMgr = new PageMgr();
                myPageMgr.Edit_Page_MetaTag(UpdateData);

                tbx_UpdateScriptURL.Text = "";

                // Update Script List
                Control_FillData();
            }

        }

        #endregion

        #region CSS

        protected void btn_AddCSS_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PageMgr myPageMgr = new PageMgr();

                // Add New CSS
                e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", _pageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.StyleSheet)),
                                      new e2Data("Meta_Src", tbx_CSSURL.Text)
                                   };

                myPageMgr.Add_Page_MetaTag(UpdateData);

                tbx_CSSURL.Text = "";

                Control_FillData();
            }

        }

        protected void lbtn_CSS_Edit_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();
            MetaTag myMetaTag = myPageMgr.Get_Page_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateCSSURL.Text = myMetaTag.Meta_Src;
            btn_UpdateCSS.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_CSS.Visible = true;

        }

        protected void lbtn_CSS_Delete_Command(object sender, CommandEventArgs e)
        {
            PageMgr myPageMgr = new PageMgr();

            // Delete CSS
            myPageMgr.Remove_Page_MetaTag(e.CommandArgument.ToString());

            // Update Script List
            Control_FillData();

        }

        protected void btn_UpdateCSS_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {

                e2Data[] UpdateData = {
                                      new e2Data("MetaTagID", e.CommandArgument.ToString()),
                                      new e2Data("Meta_Src", tbx_UpdateCSSURL.Text)
                                   };

                PageMgr myPageMgr = new PageMgr();
                myPageMgr.Edit_Page_MetaTag(UpdateData);

                tbx_UpdateCSSURL.Text = "";

                // Update Script List
                Control_FillData();
            }

        }

        #endregion

    }
}