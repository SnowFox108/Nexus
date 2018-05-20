using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Files_WebUserControls_ET_EnquiryFormGeneral : UserControl
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
                CustomValidator_Departure.ErrorMessage = "Your Depature Date is in past";
                args.IsValid = false;
            }
        }
        catch
        {
            CustomValidator_Departure.ErrorMessage = "Please enter a valid Depature date";
            args.IsValid = false;
        }

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var emailContent =
                string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("EverTravel_EnquiryFormGeneral"),
                    string.IsNullOrEmpty(Request["NexusNewsPostID"]) ? "General" : Request["NexusNewsPostID"],
                    HttpContext.Current.Request.Url,
                    tbx_Name.Text,
                    tbx_Code.Text,
                    ((DateTime) RadDatePicker_Departure.SelectedDate).ToShortDateString(),
                    tbx_Mobile.Text,
                    tbx_Email.Text,
                    tbx_Message.Text,
                    DateTime.Now.ToString(CultureInfo.InvariantCulture)
                    );

            Nexus.Core.Email.EmailMgr.SendMail(null,
                "sales@evertravel.co.uk",
                "service@e2tech.co.uk",
                tbx_Email.Text,
                emailContent,
                "An holiday general enquiry from Ever Travel",
                false
                );

            _submitted = true;
            ViewState["Submitted"] = _submitted;

            MultiView_EnquiryForm.SetActiveView(View_Submit);
        }
    }
}