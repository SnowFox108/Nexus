using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Core
{
    public partial class App_AdminCP_UserAdmin_Users_LoginView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control_Init();
        }

        private void Control_Init()
        {

            lbl_UserName.Text = "Logged as: " + Security.Users.UserStatus.Current_UserName(this.Page);

            if (Security.Users.UserStatus.Current_UserID(this.Page) == "0")
            {
                MultiView_Status.SetActiveView(View_Login);
            }
            else
            {
                MultiView_Status.SetActiveView(View_Logout);
            }
        }

        protected void lbtn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App_AdminCP/Login.aspx");
        }

        protected void lbtn_Logout_Click(object sender, EventArgs e)
        {
            Security.Users.UserMgr myUserMgr = new Security.Users.UserMgr();

            myUserMgr.Remove_UserCookie(this.Page);

            Response.Redirect("~/App_AdminCP/Login.aspx?LoginMsg=logout");

        }

    }
}