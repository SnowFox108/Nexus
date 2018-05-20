using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Files_PoP_PagePointerSelector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            if (PageMenu_PageIndex.Selected_PageIndexID != "-1" && !DataEval.IsEmptyQuery(PageMenu_PageIndex.Selected_PageIndexID))
            {
                if (!DataEval.IsEmptyQuery(Request.QueryString["ControlID"]))
                {
                    string arg = "FileSelector"
                    + "^"
                    + Request.QueryString["ControlID"]
                    + "^"
                    + PageMenu_PageIndex.Selected_PageIndexID;

                    // Finish Select Close Window
                    string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText(arg));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

                }

            }
        }
    }
}