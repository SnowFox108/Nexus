using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class User_Files_WebUserControls_CTC_EnquiryForm_CN : System.Web.UI.UserControl
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

        Control_Inti();
    }

    private void Form_Init()
    {

        // OfferType
        if (string.IsNullOrEmpty(Request["NexusNewsPostID"]))
        {
            lbl_OfferType.Text = "General";
        }
        else
        {
            lbl_OfferType.Text = Request["NexusNewsPostID"];
        }

        RadDatePicker_Departure.SelectedDate = DateTime.Today;
        RadDatePicker_ReturnDate.SelectedDate = DateTime.Today.AddDays(7);

        //Passengers();

    }

    private void Control_Inti()
    {
        if (_submitted)
        {
            MultiView_EnquiryForm.SetActiveView(View_Submit);
        }
        else
        {
            MultiView_EnquiryForm.SetActiveView(View_Form);
            Passengers();
        }
    }
    protected void droplist_NoPassenger_SelectedIndexChanged(object sender, EventArgs e)
    {
        PlaceHolder_Passenger.Controls.Clear();
        Passengers();
    }

    private void Passengers()
    {

        int NumPassenger = Convert.ToInt16(droplist_NoPassenger.SelectedValue);

        Table myTable = new Table();

        for (int i = 0; i <= NumPassenger; i++)
        {
            if (i == 0)
            {
                TableRow headerRow = new TableRow();
                TableHeaderCell headerNo = new TableHeaderCell();
                TableHeaderCell headerTitle = new TableHeaderCell();
                headerTitle.Text = "頭銜";
                TableHeaderCell headerFirstName = new TableHeaderCell();
                headerFirstName.Text = "名";
                TableHeaderCell headerLastName = new TableHeaderCell();
                headerLastName.Text = "姓";
                TableHeaderCell headerDateofBirth = new TableHeaderCell();
                headerDateofBirth.Text = "出生日期";

                headerRow.Cells.Add(headerNo);
                headerRow.Cells.Add(headerTitle);
                headerRow.Cells.Add(headerFirstName);
                headerRow.Cells.Add(headerLastName);
                headerRow.Cells.Add(headerDateofBirth);

                myTable.Rows.Add(headerRow);
                continue;
            }

            TableRow dataRow = new TableRow();
            TableCell dataNo = new TableCell();
            dataNo.Text = i.ToString();

            TableCell dataTitle = new TableCell();
            DropDownList _droplist_Title = new DropDownList();
            _droplist_Title.ID = "droplist_Title" + i.ToString();
            _droplist_Title.Items.Add("Mr");
            _droplist_Title.Items.Add("Mrs");
            _droplist_Title.Items.Add("Mstr");
            _droplist_Title.Items.Add("Miss");
            _droplist_Title.Width = new Unit(50);
            dataTitle.Controls.Add(_droplist_Title);

            TableCell dataFirstName = new TableCell();
            TextBox _tbx_FirstName = new TextBox();
            _tbx_FirstName.ID = "tbx_Firstname" + i.ToString();
            _tbx_FirstName.MaxLength = 50;
            _tbx_FirstName.Width = new Unit(50);
            dataFirstName.Controls.Add(_tbx_FirstName);

            TableCell dataLastName = new TableCell();
            TextBox _tbx_Lastname = new TextBox();
            _tbx_Lastname.ID = "tbx_LastName" + i.ToString();
            _tbx_Lastname.MaxLength = 50;
            _tbx_Lastname.Width = new Unit(50);
            dataLastName.Controls.Add(_tbx_Lastname);

            TableCell dataDateofBirth = new TableCell();
            RadDatePicker _RadDatePicker_DateofBirth = new RadDatePicker();
            _RadDatePicker_DateofBirth.ID = "RadDatePicker_DateofBirth" + i.ToString();
            _RadDatePicker_DateofBirth.SelectedDate = DateTime.Today;
            _RadDatePicker_DateofBirth.Width = new Unit(90);
            dataDateofBirth.Controls.Add(_RadDatePicker_DateofBirth);

            dataRow.Cells.Add(dataNo);
            dataRow.Cells.Add(dataTitle);
            dataRow.Cells.Add(dataFirstName);
            dataRow.Cells.Add(dataLastName);
            dataRow.Cells.Add(dataDateofBirth);

            myTable.Rows.Add(dataRow);

        }

        PlaceHolder_Passenger.Controls.Add(myTable);
    }

    protected void CustomValidator_Departure_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        DateTime _DepatureDate;

        try
        {
            _DepatureDate = (DateTime)RadDatePicker_Departure.SelectedDate;

            if (_DepatureDate < DateTime.Today)
            {
                CustomValidator_Departure.ErrorMessage = "您的離境日期已經過期";
                args.IsValid = false;
            }
        }
        catch
        {
            CustomValidator_Departure.ErrorMessage = "請填寫一個有效的離境日期";
            args.IsValid = false;
        }

    }
    protected void CustomValidator_ReturnDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        DateTime _ReturnDate;

        try
        {
            _ReturnDate = (DateTime)RadDatePicker_ReturnDate.SelectedDate;

            if (_ReturnDate < DateTime.Today)
            {
                CustomValidator_ReturnDate.ErrorMessage = "您的回程日期已經過期";
                args.IsValid = false;
            }

        }
        catch
        {
            CustomValidator_ReturnDate.ErrorMessage = "請填寫一個有效的回程日期";
            args.IsValid = false;
        }

        try
        {

            _ReturnDate = (DateTime)RadDatePicker_ReturnDate.SelectedDate;

            if (_ReturnDate < (DateTime)RadDatePicker_Departure.SelectedDate)
            {
                CustomValidator_ReturnDate.ErrorMessage = "您的回程日期比離境日期要早";
                args.IsValid = false;
            }
        }
        catch
        {
            args.IsValid = false;
        }

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            int NumPassenger = Convert.ToInt16(droplist_NoPassenger.SelectedValue);

            string _Passengers = "--------------------" + Environment.NewLine;

            for (int i = 1; i <= NumPassenger; i++)
            {

                DropDownList _droplist_Title = (DropDownList)PlaceHolder_Passenger.FindControl("droplist_Title" + i.ToString());
                TextBox _tbx_FirstName = (TextBox)PlaceHolder_Passenger.FindControl("tbx_FirstName" + i.ToString());
                TextBox _tbx_LastName = (TextBox)PlaceHolder_Passenger.FindControl("tbx_LastName" + i.ToString());
                RadDatePicker _RadDatePicker_DateofBirth = (RadDatePicker)PlaceHolder_Passenger.FindControl("RadDatePicker_DateofBirth" + i.ToString());

                _Passengers += "Passenger " + i.ToString() + Environment.NewLine;
                _Passengers += "Title: " + _droplist_Title.SelectedValue + Environment.NewLine;
                _Passengers += "FirstName: " + _tbx_FirstName.Text + Environment.NewLine;
                _Passengers += "LastName: " + _tbx_LastName.Text + Environment.NewLine;
                _Passengers += "Date of Birth: " + ((DateTime)_RadDatePicker_DateofBirth.SelectedDate).ToShortDateString() + Environment.NewLine + Environment.NewLine;

            }

            _Passengers += "--------------------" + Environment.NewLine;

            string Email_Content = string.Format(Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("TravelCentre_EnquiryForm_Email"),
                tbx_Destination.Text,
                ((DateTime)RadDatePicker_Departure.SelectedDate).ToShortDateString(),
                ((DateTime)RadDatePicker_ReturnDate.SelectedDate).ToShortDateString(),
                droplist_NoPassenger.SelectedValue,
                _Passengers,
                tbx_Mobile.Text,
                tbx_Email.Text,
                tbx_Message.Text,
                lbl_OfferType.Text,
                "Chinese Website",
                DateTime.Now.ToString()
                );

            Nexus.Core.Email.EmailMgr.SendMail(null,
                "sales@chinesetravelcentre.com",
                "service@e2tech.co.uk",
                tbx_Email.Text,
                Email_Content,
                "An Enquiry from Chinese Travel Centre",
                false
                );

            _submitted = true;
            ViewState["Submitted"] = _submitted;

            MultiView_EnquiryForm.SetActiveView(View_Submit);

        }
    }
}