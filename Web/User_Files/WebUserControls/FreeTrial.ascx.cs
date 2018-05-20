using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_FreeTrial : System.Web.UI.UserControl
{
    private bool _submited = false;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            _submited = Convert.ToBoolean(ViewState["Submited"]);
        }
        else
        {
            ViewState["Submited"] = _submited;
        }

        Control_Init();

    }

    private void Control_Init()
    {
        if (_submited)
            MultiView_EnquiryForm.SetActiveView(View_Submit);
        else
            MultiView_EnquiryForm.SetActiveView(View_Form);
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            string _msg = "_gaq.push(['_trackEvent', '30days', 'Register','','']);";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "trackEvent", _msg, true); 

            DateTime nowTime = DateTime.Now;

            string Email_Content = string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("e2Tech_FreeTrial_Email"),
                tbx_FirstName.Text,
                tbx_LastName.Text,
                tbx_Email.Text,
                tbx_Telephone.Text,
                tbx_Company.Text,
                drop_Employees.SelectedValue,
                tbx_Postcode.Text,
                tbx_Findus.Text,
                nowTime.ToString()
                );

            Nexus.Core.Email.EmailMgr.SendMail(tbx_Email.Text,
                "service@e2tech.co.uk",
                "winsource6@hotmail.com",
                Email_Content,
                "Request Free Trial From e2Tech ID"
                + nowTime.Year.ToString()
                + nowTime.Month.ToString()
                + nowTime.Hour.ToString()
                + nowTime.Minute.ToString()
                );

            _submited = true;
            ViewState["Submited"] = _submited;

            MultiView_EnquiryForm.SetActiveView(View_Submit);
        }


    }
}