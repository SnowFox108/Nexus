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
using Nexus.Core.Templates;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Templates_TemplateMetaTag : System.Web.UI.UserControl
    {

        #region properties

        private string _masterpageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string MasterPageIndexID
        {
            get
            {
                if (_masterpageindexid == null)
                {
                    return "";
                }
                return _masterpageindexid;
            }
            set
            {
                _masterpageindexid = value;
                ViewState["MasterPageIndexID"] = _masterpageindexid;
                Control_Init();
                Control_FillData();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _masterpageindexid = ViewState["MasterPageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_masterpageindexid == null)
                {
                    ViewState["MasterPageIndexID"] = "";
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
            Pages.PageMgr myPageMgr = new Pages.PageMgr();
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            GridView_GlobalScripts.DataSource = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.JavaScript);
            GridView_GlobalScripts.DataBind();

            GridView_Scripts.DataSource = myMasterPageMgr.Get_MasterPage_MetaTags(_masterpageindexid, Meta_Type.JavaScript);
            GridView_Scripts.DataBind();

            // CSS
            GridView_GlobalCSS.DataSource = myPageMgr.Get_Page_MetaTags("-1", Pages.Meta_Type.StyleSheet);
            GridView_GlobalCSS.DataBind();

            GridView_CSS.DataSource = myMasterPageMgr.Get_MasterPage_MetaTags(_masterpageindexid, Meta_Type.StyleSheet);
            GridView_CSS.DataBind();

        }

        #endregion

        #region Scripts

        protected void btn_AddScript_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MasterPageMgr myMasterPageMgr = new MasterPageMgr();

                // Add New Script
                e2Data[] UpdateData = {
                                      new e2Data("MasterPageIndexID", _masterpageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.JavaScript)),
                                      new e2Data("Meta_Src", tbx_ScriptURL.Text)
                                   };

                myMasterPageMgr.Add_MasterPage_MetaTag(UpdateData);

                tbx_ScriptURL.Text = "";

                Control_FillData();
            }

        }

        protected void lbtn_Script_Edit_Command(object sender, CommandEventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MetaTag myMetaTag = myMasterPageMgr.Get_MasterPage_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateScriptURL.Text = myMetaTag.Meta_Src;
            btn_UpdateScript.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_Script.Visible = true;

        }

        protected void lbtn_Script_Delete_Command(object sender, CommandEventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            // Delete Role
            myMasterPageMgr.Remove_MasterPage_MetaTag(e.CommandArgument.ToString());

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

                MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                myMasterPageMgr.Edit_MasterPage_MetaTag(UpdateData);

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
                MasterPageMgr myMasterPageMgr = new MasterPageMgr();

                // Add New CSS
                e2Data[] UpdateData = {
                                      new e2Data("MasterPageIndexID", _masterpageindexid),
                                      new e2Data("Meta_Type", StringEnum.GetStringValue(Meta_Type.StyleSheet)),
                                      new e2Data("Meta_Src", tbx_CSSURL.Text)
                                   };

                myMasterPageMgr.Add_MasterPage_MetaTag(UpdateData);

                tbx_CSSURL.Text = "";

                Control_FillData();
            }

        }

        protected void lbtn_CSS_Edit_Command(object sender, CommandEventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MetaTag myMetaTag = myMasterPageMgr.Get_MasterPage_MetaTag(e.CommandArgument.ToString());

            tbx_UpdateCSSURL.Text = myMetaTag.Meta_Src;
            btn_UpdateCSS.CommandArgument = e.CommandArgument.ToString();

            Panel_Update_CSS.Visible = true;

        }

        protected void lbtn_CSS_Delete_Command(object sender, CommandEventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            // Delete CSS
            myMasterPageMgr.Remove_MasterPage_MetaTag(e.CommandArgument.ToString());

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

                MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                myMasterPageMgr.Edit_MasterPage_MetaTag(UpdateData);

                tbx_UpdateCSSURL.Text = "";

                // Update Script List
                Control_FillData();
            }

        }

        #endregion


    }
}