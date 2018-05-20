using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Core.Phrases;

namespace Nexus.Controls.Ebay.Management
{

    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_GetUserToken.Visible = false;
            }

        }

        protected void btn_LinkeBay_Click(object sender, EventArgs e)
        {

            Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

            string sessionID = myEbayMgr.Generate_UserApiToken();

            HyperLink1.NavigateUrl = string.Format("{0}&RuName={1}&SessID={2}",
                PhraseMgr.Get_Phrase_Value("NexusEbay_Environment_SignURL"),
                PhraseMgr.Get_Phrase_Value("NexusEbay_RuName"),
                sessionID);


            if (!DataEval.IsEmptyQuery(sessionID))
            {
                btn_GetUserToken.CommandArgument = sessionID;
                btn_GetUserToken.Visible = true;
            }

        }

        protected void btn_GetUserToken_Click(object sender, EventArgs e)
        {
            Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

            myEbayMgr.Fetch_UserToken(btn_GetUserToken.CommandArgument);

            lbl_Msg.Text = "You have succusefully linked your eBay account to the system. Now click Ebay setting again to continue.";

        }

    }
}