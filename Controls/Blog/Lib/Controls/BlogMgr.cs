using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using Nexus.Core;


namespace Nexus.Controls.Blog.Lib
{

    public class BlogMgr
    {

        public BlogMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        #region Blog Post

        public List<Blog_Post> Get_Blog_Posts(string Onwership_UserID, string Post_Status)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Blog_Posts(Onwership_UserID, Post_Status);

            List<Blog_Post> list = new List<Blog_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Blog_Post(myDR));
            }

            return list;
        }

        public List<Blog_Post> Get_Blog_Posts(string Onwership_UserID, string Post_Status, string Post_View_URL)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Blog_Posts(Onwership_UserID, Post_Status);

            List<Blog_Post> list = new List<Blog_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Blog_Post(myDR, Post_View_URL));
            }

            return list;
        }

        public XmlDocument Get_Blog_Posts_XML(string Onwership_UserID, string Post_Status)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Blog_Posts(Onwership_UserID, Post_Status);

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.LoadXml(myDS.GetXml());

            return myXmlDocument;

        }

        public List<Blog_Post> Get_mBlog_Posts(string Onwership_UserID, string Post_Status, int NumberPerPage)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_mBlog_Posts(Onwership_UserID, Post_Status, NumberPerPage);

            List<Blog_Post> list = new List<Blog_Post>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Blog_Post(myDR));
            }

            return list;
        }

        public Blog_Post Get_Blog_Post(string PostID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Blog_Post(myDP.Get_Blog_Post(PostID));
        }

        public XmlDocument Get_Blog_Post_XML(string PostID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Blog_Post_XML(PostID);

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.LoadXml(myDS.GetXml());

            return myXmlDocument;
        }


        public void Add_Blog_Post(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Blog_Post(UpdateData);
        }

        public void Edit_Blog_Post(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Blog_Post(UpdateData);
        }

        public void Remove_Blog_Post(string PostID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Blog_Post(PostID);
        }

        #endregion

        #region Blog Comment

        public List<Blog_Comment> Get_Blog_Comments(string PostID, string Comment_Approved)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Blog_Comments(PostID, Comment_Approved);

            List<Blog_Comment> list = new List<Blog_Comment>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Blog_Comment(myDR));
            }

            return list;
        }

        public Blog_Comment Get_Blog_Comment(string CommentID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Blog_Comment(myDP.Get_Blog_Comment(CommentID));
        }

        public void Add_Blog_Comment(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Blog_Comment(UpdateData);
        }

        public void Edit_Blog_Comment(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Blog_Comment(UpdateData);
        }

        public void Remove_Blog_Comment(string CommentID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Blog_Comment(CommentID);
        }


        #endregion
    }
}
