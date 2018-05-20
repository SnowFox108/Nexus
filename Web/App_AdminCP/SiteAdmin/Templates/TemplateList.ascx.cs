using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Templates;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Templates_TemplateList : System.Web.UI.UserControl
    {

        #region Properties

        private string _templateedit_url = "Templates.aspx";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string TemplateEdit_URL
        {
            get
            {
                return _templateedit_url;
            }
            set
            {
                _templateedit_url = value;
                ViewState["TemplateEdit_URL"] = _templateedit_url;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }

        }

        public void Control_Init()
        {
            ListView_MasterPage_List.DataSource = MasterPageMgr.sGet_Template_MasterPage_List(null);
            ListView_MasterPage_List.DataBind();
        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(string.Format("{0}?MasterPageIndexID={1}", _templateedit_url, e.CommandArgument.ToString()));
        }

        protected void lbtn_Duplicate_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                MasterPageMgr myMasterPageMgr = new MasterPageMgr();

                myMasterPageMgr.Duplicate_MasterPageIndex(e.CommandArgument.ToString(), Security.Users.UserStatus.Current_UserID(this.Page));

                Control_Init();
            }
        }
        protected void ListView_MasterPage_List_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_TemplateList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }
    }
}