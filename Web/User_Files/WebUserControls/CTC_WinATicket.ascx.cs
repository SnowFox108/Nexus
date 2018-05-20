using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_CTC_WinATicket : System.Web.UI.UserControl
{

    public bool IsSubmitted
    {
        get
        {
            object o = ViewState["IsSubmitted"];
            return o == null ? false : (bool)o;
        }
        set
        {
            ViewState["IsSubmitted"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnPreRender(EventArgs e)
    {
        ControlInitialize();
        base.OnPreRender(e);
    }

    private void ControlInitialize()
    {
        if (IsSubmitted)
            mvWinAticket.SetActiveView(viewSubmit);
        else
            mvWinAticket.SetActiveView(viewForm);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string emailContent = string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("TravelCentre_WinATicket_Email"),
                ddlTitle.SelectedValue,
                tbxFirstname.Text,
                tbxLastname.Text,
                tbxPostcode.Text,
                tbxEmail.Text,
                tbxMobile.Text,
                DateTime.Now.ToString());

            Nexus.Core.Email.EmailMgr.SendMail(null,
                "flights@travelcentreclapham.com",
                "service@e2tech.co.uk",
                tbxEmail.Text,
                emailContent,
                "Win A Ticket from Chinese Travel Centre",
                false
                );

            string clientEmailContent = string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("TravelCentre_WinATicket_ClientEmail"),
                ddlTitle.SelectedValue,
                tbxFirstname.Text,
                tbxLastname.Text);

            Nexus.Core.Email.EmailMgr.SendMail(
                "flights@travelcentreclapham.com",
                tbxEmail.Text,
                null,
                null,
                clientEmailContent,
                "Thank for registering your details, you have now entered the draw.",
                true
                );


            IsSubmitted = true;
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = chkAccept.Checked;
    }
}