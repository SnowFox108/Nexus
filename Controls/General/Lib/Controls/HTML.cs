using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;


namespace  Nexus.Controls.General.Lib
{
    // HTML base class
    public class HTML
    {
        private string _htmlid;
        private string _categoryid;
        private string _display_name;
        private string _html_content;
        private string _create_date;
        private string _lastupdate_date;
        private string _lastupdate_userid;

        public string HTMLID { get { return _htmlid; } }
        public string CategoryID { get { return _categoryid; } }
        public string Display_Name { get { return _display_name; } }
        public string HTML_Content { get { return _html_content; } }
        public string Create_Date { get { return _create_date; } }
        public string LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public HTML(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _htmlid = myDR["HTMLID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _display_name = myDR["Display_Name"].ToString();
                _html_content = myDR["HTML_Content"].ToString();
                _create_date = myDR["Create_Date"].ToString();
                _lastupdate_date = myDR["LastUpdate_Date"].ToString();
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
            }

        }

        
    }

    public class HTMLMgr
    {
        public HTMLMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public HTML Get_HTML_Content (string HTMLID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new HTML(myDP.Get_HTML_Content(HTMLID));
        }

        public List<HTML> Get_HTMLs(string CategoryID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_HTMLs(CategoryID, SortOrder);

            List<HTML> list = new List<HTML>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new HTML(myDR));
            }

            return list;
        }

        public void Add_HTML_Content(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_HTML_Content(UpdateData);
        }

        public void Edit_HTML_Content(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_HTML_Content(UpdateData);

        }

        public void Remove_HTML_Content(string HTMLID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_HTML_Content(HTMLID);
        }
    }
}
