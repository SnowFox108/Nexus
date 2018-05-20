using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using Nexus.Core;

namespace Nexus.Controls.News.Lib
{
    public class NewsMgr
    {

        public NewsMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        #region News Post

        public List<News_Post> Get_News_Posts(string CategoryID, string News_Status, string SortOrder, string Orientation)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Posts(CategoryID, News_Status, SortOrder, Orientation);

            List<News_Post> list = new List<News_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new News_Post(myDR));
            }

            return list;
        }

        public List<News_Post> Get_News_Posts(string CategoryID, string News_Status, string SortOrder, string Orientation, int TotalNumber)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Posts(CategoryID, News_Status, SortOrder, Orientation, TotalNumber);

            List<News_Post> list = new List<News_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new News_Post(myDR));
            }

            return list;
        }

        public List<News_Post> Get_News_Posts(string CategoryID, string News_Status, string SortOrder, string Orientation, int TotalNumber, string NewsDetail_URL)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Posts(CategoryID, News_Status, SortOrder, Orientation, TotalNumber);

            List<News_Post> list = new List<News_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new News_Post(myDR, NewsDetail_URL));
            }

            return list;
        }

        public XmlDocument Get_News_Posts_XML(string CategoryID, string News_Status, string SortOrder, string Orientation, int TotalNumber)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Posts(CategoryID, News_Status, SortOrder, Orientation, TotalNumber);

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.LoadXml(myDS.GetXml());

            return myXmlDocument;

        }


        public News_Post Get_News_Post(string NewsID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new News_Post(myDP.Get_News_Post(NewsID));
        }

        public XmlDocument Get_News_Post_XML(string NewsID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Post_XML(NewsID);

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.LoadXml(myDS.GetXml());

            return myXmlDocument;
        }


        public void Add_News_Post(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_News_Post(UpdateData);
        }

        public void Edit_News_Post(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_News_Post(UpdateData);
        }

        public void Remove_News_Post(string NewsID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_News_Post(NewsID);
        }

        #endregion

        #region News Comment

        public List<News_Comment> Get_News_Comments(string NewsID, string Comment_Approved)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_News_Comments(NewsID, Comment_Approved);

            List<News_Comment> list = new List<News_Comment>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new News_Comment(myDR));
            }

            return list;
        }

        public News_Comment Get_News_Comment(string CommentID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new News_Comment(myDP.Get_News_Comment(CommentID));
        }

        public void Add_News_Comment(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_News_Comment(UpdateData);
        }

        public void Edit_News_Comment(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_News_Comment(UpdateData);
        }

        public void Remove_News_Comment(string CommentID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_News_Comment(CommentID);
        }

        public void Remove_News_Comments(string NewsID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_News_Comments(NewsID);
        }

        #endregion


    }
}
