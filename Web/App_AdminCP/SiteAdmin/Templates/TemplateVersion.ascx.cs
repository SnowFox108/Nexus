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

    public partial class App_AdminCP_SiteAdmin_Templates_TemplateVersion : System.Web.UI.UserControl
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
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            ListView_PageVersion.DataSource = myMasterPageMgr.Get_MasterPages(_masterpageindexid);
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
                MasterPageMgr myMasterPageMgr = new MasterPageMgr();
                myMasterPageMgr.Reset_MasterPage_Active(_masterpageindexid);

                e2Data[] UpdateData = {
                                          new e2Data("MasterPageID", e.CommandArgument.ToString()),
                                          new e2Data("IsActive", "1")
                                      };
                myMasterPageMgr.Edit_MasterPage(UpdateData);

                Control_Init();
            }
        }

    }
}