using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nexus.Core;

namespace Nexus.Shop
{
    public partial class App_AdminCP_ShopAdmin_MasterPage_AdminCP_Rad : System.Web.UI.MasterPage
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

                // Software Version
                Nexus.Core.Modules.ModuleMgr myModuleMgr = new Core.Modules.ModuleMgr();
                lbl_Version.Text = string.Format("ver. {0}", myModuleMgr.Get_Module("A72F077B-FF47-4887-B9D7-71EC7DA2246D").Module_Version);

            }

        }
    }
}