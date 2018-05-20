using System;
using System.Collections;
using System.Collections.Generic;
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

    public partial class App_AdminCP_SiteAdmin_Templates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page_Controls();
            }

        }

        private void Page_Controls()
        {
            // Switch to page view
            MultiView_Templates.SetActiveView(View_ShowTemplate);

            // Check _pageindexid
            string _masterpageindexid = Request["MasterPageIndexID"];
            if (!DataEval.IsEmptyQuery(_masterpageindexid))
            {
                TemplateShow_MasterPage.MasterPageIndexID = _masterpageindexid;
                MultiView_Templates.SetActiveView(View_ShowTemplate);
            }
            else
            {
                MultiView_Templates.SetActiveView(View_ListTemplate);
            }

        }

        protected void lbnt_Template_Select_Command(object sender, CommandEventArgs e)
        {
            TemplateShow_MasterPage.MasterPageIndexID = e.CommandArgument.ToString();
            MultiView_Templates.SetActiveView(View_ShowTemplate);
        }

        #region Create MasterPage

        protected void btn_CreateTemplate_Click(object sender, EventArgs e)
        {
            // Switch to page view
            MultiView_Templates.SetActiveView(View_CreateTemplate);
        }

        #endregion

        protected void btn_Template_Alllist_Click(object sender, EventArgs e)
        {
            MultiView_Templates.SetActiveView(View_ListTemplate);
        }
    }
}