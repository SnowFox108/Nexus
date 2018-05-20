// Copy right e2Tech 2005-2009
//
// Dataprovider for MsSQL CE
// version 1.011
// Last Update Date 06 Jan 2010

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Runtime.Serialization;
using System.Transactions;

namespace e2Tech.MsSQLCe
{

    [Serializable]
    public class DataConnException : Exception
    {
        public DataConnException() : base() { }
        public DataConnException(String message) : base(message) { }
        public DataConnException(String message, Exception innerException) : base(message, innerException) { }
        protected DataConnException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class MsSQLCe_DataProvider
    {

        private SqlCeConnection MsSqlConn = new SqlCeConnection();

        private bool using_transaction = true;

        public bool using_Transaction
        {
            set
            {
                using_transaction = value;
            }
        }

        public MsSQLCe_DataProvider(string DataPath)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            MsSqlConn.ConnectionString = DataPath;
        }

        #region 私有函数库

        #region SQL 构造类

        // 显示类
        protected string SQL_Show_Items(string Table_Name, string ReturnColum, string Filter, string GroupBy, string OrderBy, int PageNum, int PageSize)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(GroupBy))
            {
                sqlCMD += " Group By " + GroupBy;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(PageNum) && IsValidNumber(PageSize))
            {
                sqlCMD += " Limit " + (PageNum - 1) * PageSize + "," + PageSize;
            }

            return sqlCMD;
        }

        protected string SQL_Show_Last_Items(string Table_Name, string ReturnColum, string Filter, string GroupBy, string OrderBy, int LastTopRows)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(GroupBy))
            {
                sqlCMD += " Group By " + GroupBy;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(LastTopRows))
            {
                int Total_Rows = chk_Count(Table_Name, Filter);
                int OffSet = Total_Rows - LastTopRows;
                if (OffSet > 0)
                {
                    sqlCMD += " Limit " + OffSet + "," + LastTopRows;
                }
                else
                {
                    sqlCMD += " Limit " + "0" + "," + LastTopRows;
                }
            }

            return sqlCMD;
        }

        #endregion

        #region 显示类

        #region 显示表单全部内容 Show_Items
        // 表单名称，返回项目，过滤名称，排序名称，返回数据数量
        // 返回DataSet表
        protected DataSet Show_Items(string Table_Name, string ReturnColum, string Filter, string OrderBy, int TopRows)
        {
            if (!(IsValidString(ReturnColum)))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(TopRows))
            {
                sqlCMD += " Limit " + TopRows;
            }

            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            return myDataSet;

        }


        #endregion

        #region 显示表单中特别选定项目全部内容 Show_Items * + 分页处理
        // 表单名称，返回项目，过滤名称，排序名称，返回数据页，开始页，页数据量
        // 返回DataSet表
        protected DataSet Show_Items(string Table_Name, string ReturnColum, string Filter, string OrderBy, int PageNum, int PageSize)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(PageNum) && IsValidNumber(PageSize))
            {
                sqlCMD += " Limit " + (PageNum - 1) * PageSize + "," + PageSize;
            }


            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            return myDataSet;
        }

        protected DataSet Show_Items(string Table_Name, string ReturnColum, string Filter, string GroupBy, string OrderBy, int PageNum, int PageSize)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(GroupBy))
            {
                sqlCMD += " Group By " + GroupBy;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(PageNum) && IsValidNumber(PageSize))
            {
                sqlCMD += " Limit " + (PageNum - 1) * PageSize + "," + PageSize;
            }


            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            return myDataSet;
        }

        protected DataSet Show_Last_Items(string Table_Name, string ReturnColum, string Filter, string OrderBy, int LastTopRows)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(LastTopRows))
            {
                int Total_Rows = chk_Count(Table_Name, Filter);
                int OffSet = Total_Rows - LastTopRows;
                if (OffSet > 0)
                {
                    sqlCMD += " Limit " + OffSet + "," + LastTopRows;
                }
                else
                {
                    sqlCMD += " Limit " + "0" + "," + LastTopRows;
                }
            }


            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            return myDataSet;
        }

        protected DataSet Show_Last_Items(string Table_Name, string ReturnColum, string Filter, string GroupBy, string OrderBy, int LastTopRows)
        {

            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(GroupBy))
            {
                sqlCMD += " Group By " + GroupBy;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            if (IsValidNumber(LastTopRows))
            {
                int Total_Rows = chk_Count(Table_Name, Filter);
                int OffSet = Total_Rows - LastTopRows;
                if (OffSet > 0)
                {
                    sqlCMD += " Limit " + OffSet + "," + LastTopRows;
                }
                else
                {
                    sqlCMD += " Limit " + "0" + "," + LastTopRows;
                }
            }


            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            return myDataSet;
        }

        #endregion

        #region 显示表单中特别选定的单一项目数据行 Show_Specify_DataRow
        // 表单名称，查询列名，查询输入值。
        // 返回DataRow 数据行。
        protected DataRow Show_ItemRow(string Table_Name, string ReturnColum, string Filter, string OrderBy)
        {
            if (!IsValidString(ReturnColum))
            {
                ReturnColum = "*";
            }

            string sqlCMD = string.Format("SELECT {0} FROM {1}", ReturnColum, Table_Name);

            if (IsValidString(Filter))
            {
                sqlCMD += " Where " + Filter;
            }

            if (IsValidString(OrderBy))
            {
                sqlCMD += " Order By " + OrderBy;
            }

            SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

            DataSet myDataSet = new DataSet();
            sqlDbAdp.Fill(myDataSet, Table_Name);

            DataRow myRow;
            if (myDataSet.Tables[Table_Name].Rows.Count > 0)
            {
                myRow = myDataSet.Tables[Table_Name].Rows[0];
            }
            else
            {
                myRow = null;
            }

            return myRow;
        }

        #endregion

        #region 检查表中是否存在指定项目chk_Exist

        protected bool chk_Exist(string Table_Name, string Filter)
        {
            string sqlCMD = "SELECT Count(*)"
                + " FROM "
                + Table_Name
                + " WHERE "
                + Filter;

            SqlCeCommand ExeCMD = new SqlCeCommand(sqlCMD, MsSqlConn);

            MsSqlConn.Open();

            Int32 Counter = 0;

            try
            {
                Counter = Convert.ToInt32(ExeCMD.ExecuteScalar());
            }
            catch
            {
                throw new DataConnException(sqlCMD);
            }

            MsSqlConn.Close();

            if (Counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region 检查表中数量指定项目chk_Count
        protected Int32 chk_Count(string Table_Name)
        {
            string sqlCMD = "SELECT Count(*)"
                + " FROM "
                + Table_Name;

            SqlCeCommand ExeCMD = new SqlCeCommand(sqlCMD, MsSqlConn);

            MsSqlConn.Open();

            Int32 Counter = Convert.ToInt32(ExeCMD.ExecuteScalar());

            MsSqlConn.Close();

            return Counter;

        }

        protected Int32 chk_Count(string Table_Name, string Filter)
        {
            string sqlCMD = "SELECT Count(*)"
                + " FROM "
                + Table_Name
                + " WHERE "
                + Filter;

            SqlCeCommand ExeCMD = new SqlCeCommand(sqlCMD, MsSqlConn);

            MsSqlConn.Open();

            Int32 Counter = Convert.ToInt32(ExeCMD.ExecuteScalar());

            MsSqlConn.Close();

            return Counter;

        }

        #endregion

        #region 汇总表单中指定项目chk_Sum
        // 汇总表单中指定项目
        protected Int32 chk_Sum(string Table_Name, string Column_Name, string Filter)
        {
            string sqlCMD = "SELECT sum("
                + Column_Name
                + ")"
                + " FROM "
                + Table_Name
                + " WHERE "
                + Filter;

            SqlCeCommand ExeCMD = new SqlCeCommand(sqlCMD, MsSqlConn);

            MsSqlConn.Open();

            string result = ExeCMD.ExecuteScalar().ToString();

            MsSqlConn.Close();

            try
            {
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }

        }

        // 汇总表单中指定项目
        protected decimal chk_SumDecimal(string Table_Name, string Column_Name, string Filter)
        {
            string sqlCMD = "SELECT sum("
                + Column_Name
                + ")"
                + " FROM "
                + Table_Name
                + " WHERE "
                + Filter;

            SqlCeCommand ExeCMD = new SqlCeCommand(sqlCMD, MsSqlConn);

            MsSqlConn.Open();

            string result = ExeCMD.ExecuteScalar().ToString();

            MsSqlConn.Close();

            try
            {
                return Convert.ToDecimal(result);
            }
            catch
            {
                return 0;
            }

        }

        #endregion

        #endregion

        #region 输入类
        //数据单，表单名称，【更新参数】
        //添加新数据到表单。
        protected void Input_New_Data(DataSet myDataSet, string Table_Name, string[] Parameters)
        {
        }

        #region 添加一条新的数据 Field_DataInsert
        protected void Insert_Data_Field(string Table_Name, string[] Update_Field, string[] Update_Value, object[] DbType)
        {
            string sqlCMD = "SELECT ";

            for (int i = 0; i < Update_Field.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += Update_Field[i];
            }

            sqlCMD += " FROM " + Table_Name;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                    for (int i = 0; i < Update_Field.Length; i++)
                    {
                        newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                    }

                    myDataSet.Tables[Table_Name].Rows.Add(newRow);

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                for (int i = 0; i < Update_Field.Length; i++)
                {
                    newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                }

                myDataSet.Tables[Table_Name].Rows.Add(newRow);

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        #endregion

        #region 添加一条新的数据 Field_DataInsert
        protected void Insert_Data_Field(string Table_Name, e2Data[] UpdateData)
        {
            string sqlCMD = "SELECT ";

            for (int i = 0; i < UpdateData.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += UpdateData[i].FieldName;
            }

            sqlCMD += " FROM " + Table_Name;

            if (using_transaction)
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                    for (int i = 0; i < UpdateData.Length; i++)
                    {
                        newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                    }

                    myDataSet.Tables[Table_Name].Rows.Add(newRow);

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                for (int i = 0; i < UpdateData.Length; i++)
                {
                    newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                }

                myDataSet.Tables[Table_Name].Rows.Add(newRow);

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        #endregion

        #region 添加一条新的数据 Field_DataInsert then Return it's ID
        protected string Insert_Data_Field_returnID(string Table_Name, string[] Update_Field, string[] Update_Value, object[] DbType)
        {
            string sqlCMD = "SELECT ";

            for (int i = 0; i < Update_Field.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += Update_Field[i];
            }

            sqlCMD += " FROM " + Table_Name;

            string lid;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                    for (int i = 0; i < Update_Field.Length; i++)
                    {
                        newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                    }

                    myDataSet.Tables[Table_Name].Rows.Add(newRow);

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    // Get Last Insert ID
                    SqlCeCommand lastId;
                    lastId = new SqlCeCommand();
                    lastId.Connection = MsSqlConn;
                    lastId.CommandText = ("SELECT LAST_INSERT_ID()");


                    try
                    {
                        lid = lastId.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        lid = null;
                    }

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                for (int i = 0; i < Update_Field.Length; i++)
                {
                    newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                }

                myDataSet.Tables[Table_Name].Rows.Add(newRow);

                sqlDbAdp.Update(myDataSet, Table_Name);

                // Get Last Insert ID
                SqlCeCommand lastId;
                lastId = new SqlCeCommand();
                lastId.Connection = MsSqlConn;
                lastId.CommandText = ("SELECT LAST_INSERT_ID()");


                try
                {
                    lid = lastId.ExecuteScalar().ToString();
                }
                catch
                {
                    lid = null;
                }

            }

            return lid;

        }

        #endregion


        #region 添加一条新的数据 Field_DataInsert then Return it's ID
        protected string Insert_Data_Field_returnID(string Table_Name, e2Data[] UpdateData)
        {
            string sqlCMD = "SELECT ";

            for (int i = 0; i < UpdateData.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += UpdateData[i].FieldName;
            }

            sqlCMD += " FROM " + Table_Name;

            string lid;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                    for (int i = 0; i < UpdateData.Length; i++)
                    {
                        newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                    }

                    myDataSet.Tables[Table_Name].Rows.Add(newRow);

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    // Get Last Insert ID
                    SqlCeCommand lastId;
                    lastId = new SqlCeCommand();
                    lastId.Connection = MsSqlConn;
                    lastId.CommandText = ("SELECT LAST_INSERT_ID()");


                    try
                    {
                        lid = lastId.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        lid = null;
                    }

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.FillSchema(myDataSet, SchemaType.Source, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].NewRow();

                for (int i = 0; i < UpdateData.Length; i++)
                {
                    newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                }

                myDataSet.Tables[Table_Name].Rows.Add(newRow);

                sqlDbAdp.Update(myDataSet, Table_Name);

                // Get Last Insert ID
                SqlCeCommand lastId;
                lastId = new SqlCeCommand();
                lastId.Connection = MsSqlConn;
                lastId.CommandText = ("SELECT LAST_INSERT_ID()");


                try
                {
                    lid = lastId.ExecuteScalar().ToString();
                }
                catch
                {
                    lid = null;
                }
            }

            return lid;
        }

        #endregion

        #endregion

        #region 更新类

        #region 更新单条数据 Update_Data_Field

        protected void Update_Data_Field(string Table_Name, string[] Update_Field, string[] Update_Value, object[] DbType)
        {


            string sqlCMD = "SELECT ";

            for (int i = 0; i < Update_Field.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += Update_Field[i];
            }

            sqlCMD += " FROM "
                + Table_Name
                + " WHERE "
                + Update_Field[0]
                + "="
                + Update_Value[0];

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.Fill(myDataSet, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                    for (int i = 0; i < Update_Field.Length; i++)
                    {
                        newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                    }

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.Fill(myDataSet, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                for (int i = 0; i < Update_Field.Length; i++)
                {
                    newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                }

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        protected void Update_Data_Field(string Table_Name, e2Data[] UpdateData)
        {


            string sqlCMD = "SELECT ";

            for (int i = 0; i < UpdateData.Length; i++)
            {
                if (i > 0)
                    sqlCMD += ", ";

                sqlCMD += UpdateData[i].FieldName;
            }

            sqlCMD += " FROM "
                + Table_Name
                + " WHERE "
                + UpdateData[0].FieldName
                + "="
                + UpdateData[0].FieldValue;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.Fill(myDataSet, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                    for (int i = 0; i < UpdateData.Length; i++)
                    {
                        newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                    }

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.Fill(myDataSet, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                for (int i = 0; i < UpdateData.Length; i++)
                {
                    newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                }

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        protected void Update_Data_Field(string Table_Name, string[] Update_Field, string[] Update_Value, object[] DbType, string NameID, string UpdateID)
        {


            string sqlCMD = "SELECT ";

            sqlCMD += NameID;

            for (int i = 0; i < Update_Field.Length; i++)
            {
                sqlCMD += ", ";

                sqlCMD += Update_Field[i];
            }

            sqlCMD += " FROM "
                + Table_Name
                + " WHERE "
                + NameID
                + "="
                + UpdateID;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.Fill(myDataSet, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                    newRow[NameID] = DbTypeConvert(UpdateID, SqlDbType.Int);

                    for (int i = 0; i < Update_Field.Length; i++)
                    {
                        newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                    }

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.Fill(myDataSet, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                newRow[NameID] = DbTypeConvert(UpdateID, SqlDbType.Int);

                for (int i = 0; i < Update_Field.Length; i++)
                {
                    newRow[Update_Field[i]] = DbTypeConvert(Update_Value[i], (SqlDbType)DbType[i]);
                }

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        protected void Update_Data_Field(string Table_Name, e2Data[] UpdateData, string NameID, string UpdateID)
        {


            string sqlCMD = "SELECT ";

            sqlCMD += NameID;

            for (int i = 0; i < UpdateData.Length; i++)
            {
                sqlCMD += ", ";
                sqlCMD += UpdateData[i].FieldName;
            }

            sqlCMD += " FROM "
                + Table_Name
                + " WHERE "
                + NameID
                + "="
                + UpdateID;

            if (using_transaction)
            {

                using (TransactionScope ts = new TransactionScope())
                {

                    SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                    DataSet myDataSet = new DataSet();

                    SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                    sqlDbAdp.Fill(myDataSet, Table_Name);

                    DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                    newRow[NameID] = DbTypeConvert(UpdateID, SqlDbType.Int);

                    for (int i = 0; i < UpdateData.Length; i++)
                    {
                        newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                    }

                    sqlDbAdp.Update(myDataSet, Table_Name);

                    ts.Complete();
                }
            }
            else
            {
                SqlCeDataAdapter sqlDbAdp = new SqlCeDataAdapter(sqlCMD, MsSqlConn);

                DataSet myDataSet = new DataSet();

                SqlCeCommandBuilder myCB = new SqlCeCommandBuilder(sqlDbAdp);

                sqlDbAdp.Fill(myDataSet, Table_Name);

                DataRow newRow = myDataSet.Tables[Table_Name].Rows[0];

                newRow[NameID] = DbTypeConvert(UpdateID, SqlDbType.Int);

                for (int i = 0; i < UpdateData.Length; i++)
                {
                    newRow[UpdateData[i].FieldName] = DbTypeConvert(UpdateData[i].FieldValue, myDataSet.Tables[Table_Name].Columns[UpdateData[i].FieldName].DataType);
                }

                sqlDbAdp.Update(myDataSet, Table_Name);

            }

        }

        #endregion

        #endregion

        #region 删除类

        //删除整个表单。
        protected void Delete_Table(string Table_Name)
        {
            string DelCMD = "DELETE FROM "
                + Table_Name;

            SqlCeCommand DelCommand = new SqlCeCommand(DelCMD, MsSqlConn);
            DelCommand.Connection.Open();
            DelCommand.ExecuteNonQuery();
            MsSqlConn.Close();

        }


        //按条件删除数据
        protected void Delete_DataRows(string Table_Name, string Filter)
        {
            string DelCMD = "DELETE FROM "
                + Table_Name
                + " WHERE "
                + Filter;

            SqlCeCommand DelCommand = new SqlCeCommand(DelCMD, MsSqlConn);
            DelCommand.Connection.Open();
            DelCommand.ExecuteNonQuery();
            MsSqlConn.Close();

        }

        #endregion

        #region 动态更新类
        //按DataGrid绑定数据动态更新数据库。
        protected void Update_DataSet(DataSet myDataSet, string sqlCMD)
        {
        }
        #endregion

        #region 数据格式转换

        private bool IsValidString(string temp)
        {
            if ((temp == "") || (temp == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidNumber(int temp)
        {
            if (temp < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string DbTypeConvert(string UpdateValue, SqlDbType ValueType)
        {

            string updateValue;

            switch (ValueType)
            {
                case SqlDbType.VarChar:
                    updateValue = UpdateValue;
                    break;
                case SqlDbType.Text:
                    updateValue = UpdateValue;
                    break;
                case SqlDbType.Int:
                    updateValue = System.Convert.ToInt32(UpdateValue).ToString();
                    break;
                case SqlDbType.DateTime:
                    updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
                        + "-"
                        + Convert.ToDateTime(UpdateValue).Month.ToString()
                        + "-"
                        + Convert.ToDateTime(UpdateValue).Day.ToString()
                        + " "
                        + Convert.ToDateTime(UpdateValue).Hour.ToString()
                        + ":"
                        + Convert.ToDateTime(UpdateValue).Minute.ToString()
                        + ":"
                        + Convert.ToDateTime(UpdateValue).Second.ToString();
                    break;
                case SqlDbType.Decimal:
                    updateValue = System.Convert.ToDecimal(UpdateValue).ToString();
                    break;
                case SqlDbType.Float:
                    updateValue = System.Convert.ToSingle(UpdateValue).ToString();
                    break;

                default:
                    updateValue = UpdateValue;
                    break;
            }

            return updateValue;

        }

        private string DbTypeConvert(string UpdateValue, Type ValueType)
        {

            string updateValue;

            switch (ValueType.ToString())
            {
                case "System.String":
                    updateValue = UpdateValue;
                    break;

                case "System.Boolean":
                    if (UpdateValue == "1")
                        updateValue = true.ToString();
                    else if (UpdateValue == "0")
                        updateValue = false.ToString();
                    else
                        updateValue = UpdateValue;
                    break;

                case "System.Byte":
                    updateValue = System.Convert.ToByte(UpdateValue).ToString();
                    break;

                case "System.Int16":
                    updateValue = System.Convert.ToInt16(UpdateValue).ToString();
                    break;

                case "System.Int32":
                    updateValue = System.Convert.ToInt32(UpdateValue).ToString();
                    break;

                case "System.Decimal":
                    updateValue = System.Convert.ToDecimal(UpdateValue).ToString();
                    break;

                case "System.Single":
                    updateValue = System.Convert.ToSingle(UpdateValue).ToString();
                    break;

                case "System.Double":
                    updateValue = System.Convert.ToDouble(UpdateValue).ToString();
                    break;

                case "System.DateTime":
                    updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
                        + "-"
                        + Convert.ToDateTime(UpdateValue).Month.ToString()
                        + "-"
                        + Convert.ToDateTime(UpdateValue).Day.ToString()
                        + " "
                        + Convert.ToDateTime(UpdateValue).Hour.ToString()
                        + ":"
                        + Convert.ToDateTime(UpdateValue).Minute.ToString()
                        + ":"
                        + Convert.ToDateTime(UpdateValue).Second.ToString();
                    break;
                default:
                    updateValue = UpdateValue;
                    break;
            }

            return updateValue;

        }


        protected string DateTypeConvert(string UpdateValue)
        {
            string updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
                + "-"
                + Convert.ToDateTime(UpdateValue).Month.ToString()
                + "-"
                + Convert.ToDateTime(UpdateValue).Day.ToString();

            return updateValue;
        }

        protected string DateTimeTypeConvert(string UpdateValue)
        {
            string updateValue = Convert.ToDateTime(UpdateValue).Year.ToString()
                + "-"
                + Convert.ToDateTime(UpdateValue).Month.ToString()
                + "-"
                + Convert.ToDateTime(UpdateValue).Day.ToString()
                + " "
                + Convert.ToDateTime(UpdateValue).Hour.ToString()
                + ":"
                + Convert.ToDateTime(UpdateValue).Minute.ToString()
                + ":"
                + Convert.ToDateTime(UpdateValue).Second.ToString();

            return updateValue;
        }

        #endregion

        #endregion

        #region 公共函数库


        #endregion


    }
}
