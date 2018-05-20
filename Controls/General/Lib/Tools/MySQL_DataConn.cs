using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Nexus.Controls.General.Lib
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

        #region HTML

        // 获取HTML内容
        public DataRow Get_HTML_Content(string HTMLID)
        {
            string Table_Name = "NexusGeneral_HTML";

            string Filter = "HTMLID = " + DataEval.QuoteText(HTMLID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_HTMLs(string CategoryID, string SortOrder)
        {
            string Table_Name = "NexusGeneral_HTML";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Display_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 添加HTML内容
        public void Add_HTML_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_HTML";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新HTML内容
        public void Edit_HTML_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_HTML";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除HTML内容
        public void Remove_HTML_Content(string HTMLID)
        {
            string Table_Name = "NexusGeneral_HTML";

            string Filter = "HTMLID = " + DataEval.QuoteText(HTMLID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #region RichText

        // 获取RichText内容
        public DataRow Get_RichText_Content(string RichTextID)
        {
            string Table_Name = "NexusGeneral_RichTexts";

            string Filter = "RichTextID = " + DataEval.QuoteText(RichTextID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_RichTexts(string CategoryID, string SortOrder)
        {
            string Table_Name = "NexusGeneral_RichTexts";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Display_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 添加RichText内容
        public void Add_RichText_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_RichTexts";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新RichText内容
        public void Edit_RichText_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_RichTexts";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除RichText内容
        public void Remove_RichText_Content(string RichTextID)
        {
            string Table_Name = "NexusGeneral_RichTexts";

            string Filter = "RichTextID = " + DataEval.QuoteText(RichTextID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #region Script

        // 获取Script内容
        public DataRow Get_Script_Content(string ScriptID)
        {
            string Table_Name = "NexusGeneral_Scripts";

            string Filter = "ScriptID = " + DataEval.QuoteText(ScriptID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Scripts(string CategoryID, string SortOrder)
        {
            string Table_Name = "NexusGeneral_Scripts";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Display_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 添加Script内容
        public string Add_Script_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_Scripts";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        // 更新Script内容
        public void Edit_Script_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_Scripts";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除Script内容
        public void Remove_Script_Content(string ScriptID)
        {
            string Table_Name = "NexusGeneral_Scripts";

            string Filter = "ScriptID = " + DataEval.QuoteText(ScriptID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #region Image

        // 获取Image内容
        public DataRow Get_Image_Content(string ImageID)
        {
            string Table_Name = "NexusGeneral_Images";

            string Filter = "ImageID = " + DataEval.QuoteText(ImageID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Images(string CategoryID, string SortOrder)
        {
            string Table_Name = "NexusGeneral_Images";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Display_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        // 添加Image内容
        public string Add_Image_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_Images";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        // 更新Image内容
        public void Edit_Image_Content(e2Data[] UpdateData)
        {
            string Table_Name = "NexusGeneral_Images";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        // 删除Image内容
        public void Remove_Image_Content(string ImageID)
        {
            string Table_Name = "NexusGeneral_Images";

            string Filter = "ImageID = " + DataEval.QuoteText(ImageID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

    }
}
