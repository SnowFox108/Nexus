using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_AdminCP_SiteAdmin_Templates_TemplateList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect(string.Format("Templates.aspx?MasterPageIndexID={0}", e.CommandArgument.ToString()));
    }
}