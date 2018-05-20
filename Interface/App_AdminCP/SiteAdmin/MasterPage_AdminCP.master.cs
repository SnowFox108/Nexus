using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_MasterPage_AdminCP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

                if (Security.Users.UserStatus.Current_UserID(this.Page) != "0")
                {
                    if (!Security.Users.UserStatus.Validate_UserGroup(this.Page, Security.Users.UserGroup.Administrator))
                    {
                        Response.Redirect("/App_AdminCP/Login.aspx?LoginMsg=invalid");
                    }
                }
                else
                {
                    Response.Redirect("/App_AdminCP/Login.aspx?LoginMsg=sessionexpire");
                }
            }
        }

    }
}