// Copy right e2Tech 2005-2010
//
// Dataprovider for XML
// version 1.000
// Last Update Date 07 Febuary 2010

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Runtime.Serialization;

namespace e2Tech.XML
{

    [Serializable]
    public class DataConnException : Exception
    {
        public DataConnException() : base() { }
        public DataConnException(String message) : base(message) { }
        public DataConnException(String message, Exception innerException) : base(message, innerException) { }
        protected DataConnException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class XML_DataProvider
    {
        private string XMLConn = "";

        public XML_DataProvider(string DataPath)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            XMLConn = DataPath;
        }

        #region 私有函数库

        #region 显示类

        #region 显示表单全部内容 Show_Items
        // 表单名称，返回项目，过滤名称，排序名称，返回数据数量
        // 返回DataSet表
        protected DataSet Show_Items()
        {

            DataSet myDataSet = new DataSet();

            myDataSet.ReadXml(XMLConn);

            return myDataSet;

        }

        protected DataSet Show_Items(string XPath)
        {

            DataSet myDataSet = new DataSet();

            myDataSet.ReadXml(XMLConn);

            return myDataSet;

        }


        #endregion

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

        #endregion

        #endregion


        #region 公共函数库


        #endregion

    }
}