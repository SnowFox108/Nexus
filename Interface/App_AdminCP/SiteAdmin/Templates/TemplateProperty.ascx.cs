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
    public partial class App_AdminCP_SiteAdmin_Templates_TemplateProperty : System.Web.UI.UserControl
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

        public void Update_Disable()
        {
            Panel_Updated.Visible = false;
        }

        private void Control_Init()
        {

        }

        #region Data Fill

        private void Control_FillData()
        {

            #region Set Default Setting

            Panel_Updated.Visible = false;

            #region Step 2 General

            // Master Page
            tbx_MasterPage_Name.Text = "";
            tbx_MasterPage_Description.Text = "";
            lbl_Template.Text = "";
            lbl_Masterpage.Text = "";
            Hidden_TemplateID.Value = "";
            #endregion

            #endregion

            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(_masterpageindexid);

            // Master Page
            tbx_MasterPage_Name.Text = myMasterPageIndex.MasterPage_Name;
            tbx_MasterPage_Description.Text = myMasterPageIndex.MasterPage_Description;

            Hidden_TemplateID.Value = myMasterPageIndex.TemplateID;

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template myTemplate = myTemplateMgr.Get_Template(myMasterPageIndex.TemplateID);
            lbl_Template.Text = myTemplate.Template_Name;

            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.MasterPageID);
            lbl_Masterpage.Text = myTemplate_MasterPage.MasterPage_Template_Name;

            droplist_Theme.DataBind();
            droplist_Theme.SelectedValue = myMasterPageIndex.ThemeID;

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));

        }

        #endregion

        protected void droplist_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            MasterPageIndex myMasterPageIndex = myMasterPageMgr.Get_MasterPageIndex(_masterpageindexid);

            TemplateMgr myTemplateMgr = new TemplateMgr();
            Template_MasterPage myTemplate_MasterPage = myTemplateMgr.Get_Template_MasterPage(myMasterPageIndex.MasterPageID);

            ThemeMgr myThemeMgr = new ThemeMgr();
            Theme myTheme = myThemeMgr.Get_Theme(droplist_Theme.SelectedValue);

            Image_Masterpage_Preview.ImageUrl = string.Format("/App_Themes/{0}/{1}.jpg", myTheme.Theme_Code, myTemplate_MasterPage.MasterPage_Template_Name.Replace(" ", ""));
            
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Page Index
                e2Data[] UpdateData = {
                                          new e2Data("MasterPageIndexID", _masterpageindexid),
                                          new e2Data("MasterPage_Name", tbx_MasterPage_Name.Text),
                                          new e2Data("ThemeID", droplist_Theme.SelectedValue),
                                          new e2Data("MasterPage_Description", tbx_MasterPage_Description.Text)
                                      };

                MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                myMasterPageMgr.Edit_MasterPageIndex(UpdateData);

                Panel_Updated.Visible = true;

            }
        }

    }
}