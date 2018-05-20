using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_ET_EnquiryFormVisa : System.Web.UI.UserControl
{
    private bool _submitted = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (ViewState["Sumbitted"] != null)
                _submitted = Convert.ToBoolean(ViewState["Submitted"]);
        }
        else
        {
            ViewState["Submitted"] = _submitted;
            Form_Init();
        }

        Control_Init();

    }

    private void Form_Init()
    {
        RadDatePicker_Departure.SelectedDate = DateTime.Today;
    }

    private void Control_Init()
    {
        MultiView_EnquiryForm.SetActiveView(_submitted ? View_Submit : View_Form);
    }

    protected void CustomValidator_Departure_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;

        try
        {
            var depatureDate = (DateTime)RadDatePicker_Departure.SelectedDate;

            if (depatureDate < DateTime.Today)
            {
                CustomValidator_Departure.ErrorMessage = "Your Proposed Date of Entry is in past";
                args.IsValid = false;
            }
        }
        catch
        {
            CustomValidator_Departure.ErrorMessage = "Please enter a valid Proposed Date of Entry";
            args.IsValid = false;
        }

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var destination = "";
            switch (Request["PageIndexID"])
            {
                case "700599D64C234252BC7FB9FF99307751":
                    destination = "China";
                    break;
                case "F8FECB33F351466588325C6E7973B99D":
                    destination = "Vietnam";
                    break;
                case "488FD87B95024EE3A559C768CD2793CC":
                    destination = "Australia";
                    break;
                default:
                    destination = "Unknown";
                    break;
            }


            var emailContent =
                string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("EverTravel_EnquiryFormVisa"),
                    destination,
                    tbx_Name.Text,
                    tbx_Mobile.Text,
                    tbx_Email.Text,
                    ((DateTime) RadDatePicker_Departure.SelectedDate).ToShortDateString(),
                    tbx_Message.Text,
                    DateTime.Now.ToString(CultureInfo.InvariantCulture)
                    );

            Nexus.Core.Email.EmailMgr.SendMail(null,
                "sales@evertravel.co.uk",
                "service@e2tech.co.uk",
                tbx_Email.Text,
                emailContent,
                "An Visa enquiry from Ever Travel",
                false
                );

            _submitted = true;
            ViewState["Submitted"] = _submitted;

            MultiView_EnquiryForm.SetActiveView(View_Submit);
        }
    }

}