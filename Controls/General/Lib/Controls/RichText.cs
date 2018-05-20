using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;

namespace  Nexus.Controls.General.Lib
{
    // RichText base class
    public class RichText
    {
        private string _richtextid;
        private string _categoryid;
        private string _display_name;
        private string _richtext_content;
        private string _create_date;
        private string _lastupdate_date;
        private string _lastupdate_userid;

        public string RichTextID { get { return _richtextid; } }
        public string CategoryID { get { return _categoryid; } }
        public string Display_Name { get { return _display_name; } }
        public string RichText_Content { get { return _richtext_content; } }
        public string Create_Date { get { return _create_date; } }
        public string LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public RichText(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _richtextid = myDR["RichTextID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _display_name = myDR["Display_Name"].ToString();
                _richtext_content = myDR["RichText_Content"].ToString();
                _create_date = myDR["Create_Date"].ToString();
                _lastupdate_date = myDR["LastUpdate_Date"].ToString();
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
            }

        }


    }

    public class RichTextMgr
    {
        public RichTextMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public RichText Get_RichText_Content(string RichTextID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new RichText(myDP.Get_RichText_Content(RichTextID));
        }

        public List<RichText> Get_RichTexts(string CategoryID, string SortOrder)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_RichTexts(CategoryID, SortOrder);

            List<RichText> list = new List<RichText>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new RichText(myDR));
            }

            return list;
        }

        public void Add_RichText_Content(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_RichText_Content(UpdateData);
        }

        public void Edit_RichText_Content(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_RichText_Content(UpdateData);

        }

        public void Remove_RichText_Content(string RichTextID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_RichText_Content(RichTextID);
        }
    }
}
