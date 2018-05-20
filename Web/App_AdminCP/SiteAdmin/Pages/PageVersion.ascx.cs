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
using Nexus.Core.Templates;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PageVersion : System.Web.UI.UserControl
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
                }
            }


        }

        private void Control_Init()
        {
            PageMgr myPageMgr = new PageMgr();
            ListView_PageVersion.DataSource = myPageMgr.Get_Pages(_pageindexid);
            ListView_PageVersion.DataBind();
        }

        protected void ListView_PageVersion_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_PageVersion.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();

        }

        protected void lbtn_PageActive_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                PageMgr myPageMgr = new PageMgr();
                myPageMgr.Reset_Page_Active(_pageindexid);

                e2Data[] UpdateData = {
                                          new e2Data("PageID", e.CommandArgument.ToString()),
                                          new e2Data("IsActive", "1")
                                      };
                myPageMgr.Edit_Page(UpdateData);

                Control_Init();
            }
        }

    }

}