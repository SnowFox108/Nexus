using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Nexus.Core.Pages;

namespace Nexus.Controls.News.Lib
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

        #region News Post

        // 获取News Post列表
        public DataSet Get_News_Posts(string CategoryID, string News_Status, string SortOrder, string Orientation)
        {
            string Table_Name = "NexusNews_Posts";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (News_Status != "ALL")
            {
                Filter += " AND "
                    + "News_Status = " + DataEval.QuoteText(News_Status);
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "News_Date " + Orientation;
            }
            else
            {
                SortOrder = SortOrder + " " + Orientation;
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 获取News Post列表
        public DataSet Get_News_Posts(string CategoryID, string News_Status, string SortOrder, string Orientation, int TotalNumber)
        {
            string Table_Name = "NexusNews_Posts";

            string Filter = "CategoryID IN (" + CategoryID
                + ")";

            if (News_Status != "ALL")
            {
                Filter += " AND "
                    + "News_Status = " + DataEval.QuoteText(News_Status);
            }

            Filter += " AND "
                + "News_Date <= " + DataEval.QuoteText(DataEval.DateTimeTypeConvert(DateTime.Now.ToString()));

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "News_Date " + Orientation;
            }
            else
            {
                SortOrder = SortOrder + " " + Orientation;
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, TotalNumber);
        }

        // 获取News Post内容
        public DataRow Get_News_Post(string NewsID)
        {
            string Table_Name = "NexusNews_Posts";

            string Filter = "NewsID = " + NewsID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_News_Post_XML(string NewsID)
        {
            string Table_Name = "NexusNews_Posts";

            string Filter = "NewsID = " + NewsID;

            return Show_Items(Table_Name, null, Filter, null, 1);
        }


        // 添加Post内容
        public void Add_News_Post(e2Data[] UpdateData)
        {
            string Table_Name = "NexusNews_Posts";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新Post内容
        public void Edit_News_Post(e2Data[] UpdateData)
        {
            string Table_Name = "NexusNews_Posts";

            Update_Data_Field(Table_Name, UpdateData);
        }


        // 删除Post内容
        public void Remove_News_Post(string NewsID)
        {
            string Table_Name = "NexusNews_Posts";

            string Filter = "NewsID = " + NewsID;

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

        #region News Comment

        // 获取News Post列表
        public DataSet Get_News_Comments(string NewsID, string Comment_Approved)
        {
            string Table_Name = "NexusNews_Comments";

            string Filter = "NewsID = " + NewsID;

            if (Comment_Approved != "ALL")
            {
                Filter += " AND "
                    + "Comment_Approved = " + Comment_Approved;
            }

            string SortOrder = "Post_Date";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 获取News Comment内容
        public DataRow Get_News_Comment(string CommentID)
        {
            string Table_Name = "NexusNews_Comments";

            string Filter = "CommentID = " + CommentID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 添加Post内容
        public void Add_News_Comment(e2Data[] UpdateData)
        {
            string Table_Name = "NexusNews_Comments";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新Post内容
        public void Edit_News_Comment(e2Data[] UpdateData)
        {
            string Table_Name = "NexusNews_Comments";

            Update_Data_Field(Table_Name, UpdateData);
        }


        // 删除Comment内容
        public void Remove_News_Comment(string CommentID)
        {
            string Table_Name = "NexusNews_Comments";

            string Filter = "CommentID = " + CommentID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_News_Comments(string NewsID)
        {
            string Table_Name = "NexusNews_Comments";

            string Filter = "NewsID = " + NewsID;

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

    }
}
