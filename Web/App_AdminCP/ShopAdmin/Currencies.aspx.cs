using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Shop.Misc;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Currencies : System.Web.UI.Page
    {

        string _currencyid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _currencyid = ViewState["CurrencyID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Control_FillData();
                Control_Init();
            }

        }

        private void Control_FillData()
        {
            tbx_AddCurrency_Name.Text = "";
            tbx_AddCurrency_ShortName.Text = "";
            tbx_AddCurrency_WebCode.Text = "";
            tbx_AddCurrency_Description.Text = "";
            chkbox_AddCurrency_IsActive.Checked = true;

            tbx_EditCurrency_Name.Text = "";
            tbx_EditCurrency_ShortName.Text = "";
            tbx_EditCurrency_WebCode.Text = "";
            tbx_EditCurrency_Description.Text = "";
            chkbox_EditCurrency_IsActive.Checked = true;

            tbx_Exchange_Rate.Text = "";
        }

        private void Control_Init()
        {

            CurrencyMgr myCurrencyMgr = new CurrencyMgr();

            List<Currency> myCurrencies = myCurrencyMgr.Get_Currencies();

            DataList_CurrencyList.DataSource = myCurrencies;
            DataList_CurrencyList.DataBind();

            if (DataEval.IsEmptyQuery(_currencyid))
            {
                _currencyid = myCurrencies[0].CurrencyID;
                ViewState["CurrencyID"] = _currencyid;
            }

            Currency selectCurrency = myCurrencyMgr.Get_Currency(_currencyid);

            GridView_Currency.DataSource = myCurrencyMgr.Get_Currency_OriginRates(selectCurrency.CurrencyID);
            GridView_Currency.DataBind();



            lbl_Currency_Name.Text = string.Format("{0} ({1})", selectCurrency.Currency_Name, selectCurrency.Currency_ShortName);

            MultiView_Currency.SetActiveView(View_CurrencyList);

            Panel_EditExchangeRate.Visible = false;

            #region Create Exchange Rate Table

            // Header
            Literal_ExchangeRate.Text = "<Table class='exchangeRate'> \n"
                + "<tr>\n <td></td> \n";

            foreach (Currency myCurrency in myCurrencies)
            {
                Literal_ExchangeRate.Text += "<td>" + myCurrency.Currency_ShortName + "</td> \n";
            }

            Literal_ExchangeRate.Text += "</tr> \n";

            // Sider
            foreach (Currency myCurrency in myCurrencies)
            {
                Literal_ExchangeRate.Text += "<tr>\n <td>" + myCurrency.Currency_ShortName + "</td> \n";

                List<Currency_Rate> myCurrency_Rates = myCurrencyMgr.Get_Currency_OriginRates(myCurrency.CurrencyID);

                // Body
                foreach (Currency_Rate myCurrency_Rate in myCurrency_Rates)
                {
                    Literal_ExchangeRate.Text += "<td>" + string.Format("{0:f}", myCurrency_Rate.Exchange_Rate) + "</td> \n";
                }

                Literal_ExchangeRate.Text += "</tr> \n";

            }

            // Footer
            Literal_ExchangeRate.Text += "</Table> \n";


            #endregion

        }

        #region GridView & Exchange Rate

        protected void GridView_Currency_Sorting(object sender, GridViewSortEventArgs e)
        {
            CurrencyMgr myCurrencyMgr = new CurrencyMgr();

            GridView_Currency.DataSource = myCurrencyMgr.Get_Currency_OriginRates(_currencyid, e.SortExpression);
            GridView_Currency.DataBind();
            
        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                Currency_Rate myCurrency_Rate = myCurrencyMgr.Get_Currency_Rate(e.CommandArgument.ToString());

                lbl_Origin_Currency.Text = myCurrency_Rate.Origin_Currency_Name;
                lbl_Target_Currency.Text = myCurrency_Rate.Target_Currency_Name;
                tbx_Exchange_Rate.Text = myCurrency_Rate.Exchange_Rate.ToString();
                lbtn_ExchangeRate_Update.CommandArgument = myCurrency_Rate.RateID;

                Panel_EditExchangeRate.Visible = true;

            }
        }

        protected void lbtn_ExchangeRate_Update_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                e2Data[] UpdateData = {
                                          new e2Data("RateID", e.CommandArgument.ToString()),
                                          new e2Data("Exchange_Rate", tbx_Exchange_Rate.Text),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                myCurrencyMgr.Edit_Currency_Rate(UpdateData);

                Control_Init();
            }
        }
        protected void lbtn_ExchangRate_Cancel_Click(object sender, EventArgs e)
        {
            Panel_EditExchangeRate.Visible = false;
        }


        #endregion

        #region Side Actions

        protected void lbtn_Currency_Select_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                _currencyid = e.CommandArgument.ToString();
                ViewState["CurrencyID"] = _currencyid;

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                Currency myCurrency = myCurrencyMgr.Get_Currency(_currencyid);

                lbl_Currency_Name.Text = string.Format("{0} ({1})", myCurrency.Currency_Name, myCurrency.Currency_ShortName);

                GridView_Currency.DataSource = myCurrencyMgr.Get_Currency_OriginRates(_currencyid);
                GridView_Currency.DataBind();

            }

        }

        protected void btn_Add_Currency_Click(object sender, EventArgs e)
        {
            Control_FillData();

            MultiView_Currency.SetActiveView(View_Add);
        }

        protected void btn_Edit_Currency_Click(object sender, EventArgs e)
        {

            if (!DataEval.IsEmptyQuery(_currencyid))
            {
                Control_FillData();

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                Currency myCurrency = myCurrencyMgr.Get_Currency(_currencyid);

                tbx_EditCurrency_Name.Text = myCurrency.Currency_Name;
                tbx_EditCurrency_ShortName.Text = myCurrency.Currency_ShortName;
                tbx_EditCurrency_WebCode.Text = myCurrency.Currency_WebCode;
                tbx_EditCurrency_Description.Text = myCurrency.Currency_Description;
                chkbox_EditCurrency_IsActive.Checked = myCurrency.IsActive;

                btn_EditCurrency_Update.CommandArgument = myCurrency.CurrencyID;

                MultiView_Currency.SetActiveView(View_Edit);
            }

        }

        protected void btn_Add_Currency_Create_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string nowDateTime = DateTime.Now.ToString();
                string UserID = Nexus.Security.Users.UserStatus.Current_UserID(this.Page);

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                List<Currency> myCurrencies = myCurrencyMgr.Get_Currencies();


                // Add Currency
                string CurrencyID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("CurrencyID", CurrencyID),
                                          new e2Data("Currency_Name", tbx_AddCurrency_Name.Text),
                                          new e2Data("Currency_ShortName", tbx_AddCurrency_ShortName.Text),
                                          new e2Data("Currency_WebCode", tbx_AddCurrency_WebCode.Text),
                                          new e2Data("Currency_Description", tbx_AddCurrency_Description.Text),
                                          new e2Data("IsActive", chkbox_AddCurrency_IsActive.Checked.ToString())
                                      };

                myCurrencyMgr.Add_Currency(UpdateData);
                Thread.Sleep(100);

                // Add Currency 1:1 Rate
                e2Data[] UpdateData_SelfRate = {
                                               new e2Data("Origin_CurrencyID", CurrencyID),
                                               new e2Data("Target_CurrencyID", CurrencyID),
                                               new e2Data("Exchange_Rate", "1"),
                                               new e2Data("LastUpdate_Date", nowDateTime),
                                               new e2Data("LastUpdate_UserID", UserID)
                                           };

                myCurrencyMgr.Add_Currency_Rate(UpdateData_SelfRate);
                Thread.Sleep(100);

                // Add All other Currency
                foreach (Currency myCurrency in myCurrencies)
                {
                    e2Data[] UpdateData_Origin = {
                                               new e2Data("Origin_CurrencyID", CurrencyID),
                                               new e2Data("Target_CurrencyID", myCurrency.CurrencyID),
                                               new e2Data("Exchange_Rate", "1"),
                                               new e2Data("LastUpdate_Date", nowDateTime),
                                               new e2Data("LastUpdate_UserID", UserID)
                                             };

                    myCurrencyMgr.Add_Currency_Rate(UpdateData_Origin);
                    Thread.Sleep(100);

                    e2Data[] UpdateData_Target = {
                                               new e2Data("Origin_CurrencyID", myCurrency.CurrencyID),
                                               new e2Data("Target_CurrencyID", CurrencyID),
                                               new e2Data("Exchange_Rate", "1"),
                                               new e2Data("LastUpdate_Date", nowDateTime),
                                               new e2Data("LastUpdate_UserID", UserID)
                                             };

                    myCurrencyMgr.Add_Currency_Rate(UpdateData_Target);
                    Thread.Sleep(100);
                }

                // Finish Update
                Control_FillData();
                Control_Init();

            }

        }

        protected void btn_EditCurrency_Update_Command(object sender, CommandEventArgs e)
        {

            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                e2Data[] UpdateData = {
                                          new e2Data("CurrencyID", e.CommandArgument.ToString()),
                                          new e2Data("Currency_Name", tbx_EditCurrency_Name.Text),
                                          new e2Data("Currency_ShortName", tbx_EditCurrency_ShortName.Text),
                                          new e2Data("Currency_WebCode", tbx_EditCurrency_WebCode.Text),
                                          new e2Data("Currency_Description", tbx_EditCurrency_Description.Text),
                                          new e2Data("IsActive", chkbox_EditCurrency_IsActive.Checked.ToString())
                                      };

                myCurrencyMgr.Edit_Currency(UpdateData);

                Control_FillData();
                Control_Init();

            }

        }

        protected void btn_EditCurrency_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_Currency.SetActiveView(View_CurrencyList);
        }

        #endregion

    }
}