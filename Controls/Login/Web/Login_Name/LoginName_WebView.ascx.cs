using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.LoginName
{

    public partial class WebView : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Control_Init();

        }

        private void Control_Init()
        {
            lbl_UserName.Text = Security.Users.UserStatus.Current_UserName(this.Page);
        }

    }
}