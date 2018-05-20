using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Nexus.Core;

namespace Nexus.Shop.Misc
{

    /// <summary>
    /// NexusShop Currency
    /// </summary>
    public class Currency
    {
        private string _currencyid;
        private string _currency_name;
        private string _currency_shortname;
        private string _currency_webcode;
        private string _currency_description;
        private bool _isactive;

        public string CurrencyID { get { return _currencyid; } }
        public string Currency_Name { get { return _currency_name; } }
        public string Currency_ShortName { get { return _currency_shortname; } }
        public string Currency_WebCode { get { return _currency_webcode; } }
        public string Currency_Description { get { return _currency_description; } }
        public bool IsActive { get { return _isactive; } }

        public Currency(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _currencyid = myDR["CurrencyID"].ToString();
                _currency_name = myDR["Currency_Name"].ToString();
                _currency_shortname = myDR["Currency_ShortName"].ToString();
                _currency_webcode = myDR["Currency_WebCode"].ToString();
                _currency_description = myDR["Currency_Description"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }

    }

    /// <summary>
    /// NexusShop Currency Rate
    /// </summary>
    public class Currency_Rate
    {
        private string _rateid;
        private string _origin_currencyid;
        private string _origin_currency_name;
        private string _target_currencyid;
        private string _target_currency_name;
        private decimal _exchange_rate;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;

        public string RateID { get { return _rateid; } }
        public string Origin_CurrencyID { get { return _origin_currencyid; } }
        public string Origin_Currency_Name { get { return _origin_currency_name; } }
        public string Target_CurrencyID { get { return _target_currencyid; } }
        public string Target_Currency_Name { get { return _target_currency_name; } }
        public decimal Exchange_Rate { get { return _exchange_rate; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public Currency_Rate(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _rateid = myDR["RateID"].ToString();
                _origin_currencyid = myDR["Origin_CurrencyID"].ToString();
                _target_currencyid = myDR["Target_CurrencyID"].ToString();
                _exchange_rate = Convert.ToDecimal(myDR["Exchange_Rate"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();

                CurrencyMgr myCurrencyMgr = new CurrencyMgr();

                _origin_currency_name = myCurrencyMgr.Get_Currency(_origin_currencyid).Currency_Name;
                _target_currency_name = myCurrencyMgr.Get_Currency(_target_currencyid).Currency_Name;

            }

        }

    }

}
