using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_SIH_ContactUs : System.Web.UI.UserControl
{

    public bool IsSubmitted
    {
        get {
            object o = ViewState["IsSubmitted"];
            return (o == null)? false : (bool)o; 
        }
        set { 
            ViewState["IsSubmitted"] = value; 
        }
    }    

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (IsSubmitted)
            mvContactUs.SetActiveView(viewSubmitted);
        else
            mvContactUs.SetActiveView(viewForm);

        base.OnPreRender(e);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        StringBuilder content = new StringBuilder();

        content.Append("姓名: {0}" + Environment.NewLine);
        content.Append("QQ: {1}" + Environment.NewLine);
        content.Append("电话: {2}" + Environment.NewLine);
        content.Append("留言: " + Environment.NewLine);
        content.Append("{3}" + Environment.NewLine);


        //Nexus.Core.Email.EmailMgr.SendMail(null, "eileengu@hotmail.co.uk", null, null,
        //    string.Format(content.ToString(), tbxName.Text, tbxQQ.Text, tbxTel.Text, tbxMsg.Text),
        //    "联系我们", false);
        Nexus.Core.Email.EmailMgr.SendMail("eileengu@hotmail.co.uk", 
            string.Format(content.ToString(), tbxName.Text, tbxQQ.Text, tbxTel.Text, tbxMsg.Text),
            "联系我们");


        IsSubmitted = true;
    }
}