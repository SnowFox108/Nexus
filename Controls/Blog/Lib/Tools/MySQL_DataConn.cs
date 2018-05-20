using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Nexus.Core.Pages;

namespace Nexus.Controls.Blog.Lib
{
    public class MySQL_DataConn : e2Tech.MySQL.MySQL_DataProvider
    {
        public MySQL_DataConn(string DataPath)
            : base(DataPath)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region Blog Post

        // 获取Blog Post列表
        public DataSet Get_Blog_Posts(string Ownership_UserID, string Post_Status)
        {
            string Table_Name = "NexusBlog_Posts";

            string Filter = "Ownership_UserID = " + DataEval.QuoteText(Ownership_UserID);

            // Display Blog Group
            Filter += " AND "
                + "BlogGroupID = -1";

            if (Post_Status != "ALL")
            {
                Filter += " AND "
                    + "Post_Status = " + DataEval.QuoteText(Post_Status);
            }

            Filter += " AND "
                + "Post_Date <= " + DataEval.QuoteText(DataEval.DateTimeTypeConvert(DateTime.Now.ToString()));

            string SortOrder = "Post_Date DESC";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_mBlog_Posts(string Ownership_UserID, string Post_Status, int NumberPerPage)
        {
            string Table_Name = "NexusBlog_Posts";

            string Filter = "BlogGroupID = -1";
            

            // Display Users Blog
            if (Ownership_UserID != "ALL")
            {
                Filter += " AND "
                    + "Ownership_UserID = " + DataEval.QuoteText(Ownership_UserID);
            }

            if (Post_Status != "ALL")
            {
                Filter += " AND "
                    + "Post_Status = " + DataEval.QuoteText(Post_Status);
            }

            Filter += " AND "
                + "Post_Date <= " + DataEval.QuoteText(DataEval.DateTimeTypeConvert(DateTime.Now.ToString()));

            string SortOrder = "Post_Date DESC";

            return Show_Items(Table_Name, null, Filter, SortOrder, NumberPerPage);
        }

        // 获取Blog Post内容
        public DataRow Get_Blog_Post(string PostID)
        {
            string Table_Name = "NexusBlog_Posts";

            string Filter = "PostID = " + PostID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Blog_Post_XML(string PostID)
        {
            string Table_Name = "NexusBlog_Posts";

            string Filter = "PostID = " + PostID;

            return Show_Items(Table_Name, null, Filter, null, 1);
        }


        // 添加Post内容
        public void Add_Blog_Post(e2Data[] UpdateData)
        {
            string Table_Name = "NexusBlog_Posts";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新Post内容
        public void Edit_Blog_Post(e2Data[] UpdateData)
        {
            string Table_Name = "NexusBlog_Posts";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除Post内容
        public void Remove_Blog_Post(string PostID)
        {
            string Table_Name = "NexusBlog_Posts";

            string Filter = "PostID = " + PostID;

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

        #region Blog Comment

        // 获取Blog Post列表
        public DataSet Get_Blog_Comments(string PostID, string Comment_Approved)
        {
            string Table_Name = "NexusBlog_Comments";

            string Filter = "PostID = " + PostID;

            if (Comment_Approved != "ALL")
            {
                Filter += " AND "
                    + "Comment_Approved = " + Comment_Approved;
            }

            string SortOrder = "Post_Date";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 获取Blog Comment内容
        public DataRow Get_Blog_Comment(string CommentID)
        {
            string Table_Name = "NexusBlog_Comments";

            string Filter = "CommentID = " + CommentID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 添加Post内容
        public void Add_Blog_Comment(e2Data[] UpdateData)
        {
            string Table_Name = "NexusBlog_Comments";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新Post内容
        public void Edit_Blog_Comment(e2Data[] UpdateData)
        {
            string Table_Name = "NexusBlog_Comments";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除Post内容
        public void Remove_Blog_Comment(string CommentID)
        {
            string Table_Name = "NexusBlog_Comments";

            string Filter = "CommentID = " + CommentID;

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

    }
}
