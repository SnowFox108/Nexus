using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_AdminCP_SiteAdmin_Pages_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
    {
        Response.Write("<script>\n");
        Response.Write(string.Format("top.location.replace('../Pages.aspx?PageIndexID={0}');", e.CommandArgument.ToString()));
        Response.Write("\n</script>");
    }

}