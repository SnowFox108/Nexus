using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_MailTest : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Nexus.Core.Email.EmailMgr.SendMail(tbx_Mail.Text, "service@e2tech.co.uk", tbx_Msg.Text, "SMTP Testing Email");
            
            lbl_Msg.Text = "Email has been sent to " + tbx_Mail.Text;
        }
    }
}