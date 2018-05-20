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
using System.Xml.Linq;
using Telerik.Web.UI;

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

                // Software Version
                lbl_Version.Text = string.Format("ver. {0}", Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Version"));

                SiteMenu_Modules();

            }
        }

        private void SiteMenu_Modules()
        {

                #region Module Login

                // e2Shop
                Modules.ModuleMgr myModuleMgr = new Modules.ModuleMgr();

                if (myModuleMgr.Chk_Module("A72F077B-FF47-4887-B9D7-71EC7DA2246D"))
                {
                    // Add other Product
                    RadMenu_SiteAdminMenu.DataBind();

                    RadMenuItem homeMenuItem = RadMenu_SiteAdminMenu.Items.FindItemByText("Home");

                    if (homeMenuItem != null)
                    {
                        RadMenuItem e2shopMenuItem = new RadMenuItem();
                        e2shopMenuItem.NavigateUrl = "~/App_AdminCP/ShopAdmin/Default.aspx";
                        e2shopMenuItem.Text = "e2Shop";

                        homeMenuItem.Items.Add(e2shopMenuItem);
                    }

                }

                #endregion

        }

    }
}