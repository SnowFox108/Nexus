using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PageList : System.Web.UI.UserControl
    {

        #region Properties

        private string _page_categoryid = "1,2";
        private string _pageedit_url = "Pages.apsx";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Page_CategoryID
        {
            get
            {
                return _page_categoryid;
            }
            set
            {
                _page_categoryid = value;
                ViewState["Page_CategoryID"] = _page_categoryid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageEdit_URL
        {
            get
            {
                return _pageedit_url;
            }
            set
            {
                _pageedit_url = value;
                ViewState["PageEdit_URL"] = _pageedit_url;
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
            ListView_Page_List.DataSource = PageMgr.sGet_PageIndex_FullList("", _page_categoryid, "Page_Name");
            ListView_Page_List.DataBind();
        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            Response.Write("<script>\n");
            Response.Write(string.Format("top.location.replace('{0}?PageIndexID={1}');", _pageedit_url, e.CommandArgument.ToString()));
            Response.Write("\n</script>");
        }

        protected void ListView_Page_List_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_Page_List.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();
        }
    }
}