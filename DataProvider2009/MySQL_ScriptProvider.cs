// Copy right e2Tech 2005-2010
//
// Dataprovider for MySQL
// version 1.012
// Last Update Date 03 Jan 2010

using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace e2Tech.MySQL
{

    public class MySQL_ScriptProvider
    {
        private MySqlScript MySqlScript = new MySqlScript();
        private MySqlConnection MySqlConn = new MySqlConnection();
        private string MyErrors = "";

        public string Delimiter
        {
            set
            {
                MySqlScript.Delimiter = value;
            }
        }

        public string Query
        {
            set
            {
                MySqlScript.Query = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return MyErrors;
            }
        }

        public MySQL_ScriptProvider(string DataPath)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            MySqlConn.ConnectionString = DataPath;
        }

        public int MySQL_Execute()
        {
            int errorNo = 0;
            try
            {
                MySqlScript.Connection = MySqlConn;
                errorNo = MySqlScript.Execute();
                MyErrors = errorNo.ToString() + " Statement(s) Executed OK";
            }
            catch (Exception e)
            {
                errorNo = -1;
                MyErrors = e.Message;
            }

            MySqlConn.Close();
            return errorNo;

        }

    }
}
