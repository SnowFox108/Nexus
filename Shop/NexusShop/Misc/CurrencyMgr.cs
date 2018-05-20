using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;

namespace Nexus.Shop.Misc
{

    [DataObject(true)]
    public class CurrencyMgr
    {

        public CurrencyMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get & Chk

        public Currency Get_Currency(string CurrencyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            if (DataEval.IsEmptyQuery (CurrencyID))
            {
                CurrencyID = "69669DE1-974A-41D6-8F36-7F853586B609";
            }

            return new Currency(myDP.Get_Currency(CurrencyID));
        }

        public List<Currency> Get_Currencies(string SortOrder = "Currency_Name", string IsActive = "ALL")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Currencies(SortOrder, IsActive);

            List<Currency> list = new List<Currency>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Currency(myDR));
            }

            return list;

        }

        public Currency_Rate Get_Currency_Rate(string RateID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Currency_Rate(myDP.Get_Currency_Rate(RateID));

        }


        public Currency_Rate Get_Currency_Rate(string Origin_CurrencyID, string Target_CurrencyID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Currency_Rate(myDP.Get_Currency_Rate(Origin_CurrencyID, Target_CurrencyID));

        }

        public List<Currency_Rate> Get_Currency_OriginRates(string CurrencyID, string SortOrder = "")
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Currency_OriginRates(CurrencyID, SortOrder);

            List<Currency_Rate> list = new List<Currency_Rate>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Currency_Rate(myDR));
            }

            return list;

        }

        public List<Currency_Rate> Get_Currency_TargetRates(string CurrencyID, string SortOrder = "")
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Currency_TargetRates(CurrencyID, SortOrder);

            List<Currency_Rate> list = new List<Currency_Rate>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Currency_Rate(myDR));
            }

            return list;

        }

        #endregion

        #region Add

        public void Add_Currency(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Currency(UpdateData);
        }

        public void Add_Currency_Rate(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Currency_Rate(UpdateData);
        }

        #endregion

        #region Edit

        public void Edit_Currency(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Currency(UpdateData);
        }

        public void Edit_Currency_Rate(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Currency_Rate(UpdateData);
        }


        #endregion

        #region Function

        // 汇率工具
        public decimal Currency_Converter(decimal Price, string Origin_CurrencyID, string Target_CurrencyID)
        {
            Currency_Rate myCurrency_Rate = Get_Currency_Rate(Origin_CurrencyID, Target_CurrencyID);

            return Price * myCurrency_Rate.Exchange_Rate;
        }

        #endregion


    }
}
