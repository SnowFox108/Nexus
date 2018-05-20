using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Nexus.Core.Pages;

namespace Nexus.Controls.Navigation.Lib
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

        #region Menu

        // 获取Menu内容
        public DataSet Get_Menu(string PageIndexID, bool DisplaySameLevel, bool DisplayCategory)
        {
            string Table_Name = "View_NexusCore_PageIndex_List";

            string Filter = "Page_CategoryID = 1" ;

            // Show Item On Menu Only
            Filter += " AND "
                + "IsOnMenu = true";

            // Menu Level
            if (DisplaySameLevel)
            {
                if (PageIndexID == "-1")
                {
                    Filter += " AND "
                        + "Parent_PageIndexID = " + DataEval.QuoteText(PageIndexID);
                }
                else
                {
                    PageMgr myPageMgr = new PageMgr();
                    PageIndex myPageIndex = myPageMgr.Get_PageIndex(PageIndexID);

                    Filter += " AND "
                        + "Parent_PageIndexID = " + DataEval.QuoteText(myPageIndex.Parent_PageIndexID);
                }
            }
            else
            {
                Filter += " AND "
                    + "Parent_PageIndexID = " + DataEval.QuoteText(PageIndexID);
            }

            // Menu Category
            if (!DisplayCategory)
            {
                Filter += " AND "
                    + "Page_Type != " + DataEval.QuoteText("Category");
            }

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        #endregion

        #region Navigator

        public DataRow Get_Navigator(string PageIndexID)
        {
            string Table_Name = "View_NexusCore_PageIndex_List";

            string Filter = "Page_CategoryID = 1";

            Filter += " AND "
                + "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            string SortOrder = "SortOrder";

            return Show_ItemRow(Table_Name, null, Filter, SortOrder);
        }

        #endregion

    }
}
