using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sites_Fly2Mauritius_Controls_FlightSearchEngine : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void Form_Init()
    {
        RadDatePicker_DepartureDate.SelectedDate = DateTime.Today;
        RadDatePicker_DepartureDate.MinDate = DateTime.Today;

        RadDatePicker_ReturnDate.SelectedDate = DateTime.Today.AddDays(2);
        RadDatePicker_ReturnDate.MinDate = DateTime.Today;
    }

    protected void CustomValidator_DepartureDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        DateTime departureDate;

        try
        {
            departureDate = (DateTime)RadDatePicker_DepartureDate.SelectedDate;

            if (departureDate < DateTime.Today)
            {
                CustomValidator_DepartureDate.ErrorMessage = "Your Departure Date is in past";
                args.IsValid = false;
            }
        }
        catch
        {
            CustomValidator_DepartureDate.ErrorMessage = "Please enter a valid Departure date";
            args.IsValid = false;
        }
    }

    protected void CustomValidator_ReturnDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        DateTime departureDate;
        DateTime returnDate;

        try
        {
            departureDate = (DateTime)RadDatePicker_DepartureDate.SelectedDate;
            returnDate = (DateTime)RadDatePicker_ReturnDate.SelectedDate;

            if (returnDate < DateTime.Today)
            {
                CustomValidator_ReturnDate.ErrorMessage = "Your Departure Date is in past";
                args.IsValid = false;
            }
            if (returnDate < departureDate)
            {
                CustomValidator_ReturnDate.ErrorMessage = "Your Return Date is earlier than Departure Date";
                args.IsValid = false;
            }
        }
        catch
        {
            CustomValidator_ReturnDate.ErrorMessage = "Please enter a valid Return date";
            args.IsValid = false;
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var departureDate = (DateTime) RadDatePicker_DepartureDate.SelectedDate;
            var returnDate = (DateTime) RadDatePicker_ReturnDate.SelectedDate;

            var path =
                string.Format(
                    "http://bookings.fly2mauritius.com/Flights.aspx?depIATA={0}&destIATA={1}&depdate={2}&retdate={3}&adult={4}&child={5}&infant={6}&class={7}"
                    , ddlFromAirport.SelectedValue
                    , ddlToAirport.SelectedValue
                    , GetFormatDate(departureDate)
                    , GetFormatDate(returnDate)
                    , ddlAdutls.SelectedValue
                    , ddlChildren.SelectedValue
                    , ddlInfants.SelectedValue
                    , ddlClass.SelectedValue);

            Response.Redirect(path);
        }
    }

    private string GetFormatDate(DateTime date)
    {
        return string.Format("{0}-{1}-{2}", date.Day, date.Month, date.Year);
    }
}