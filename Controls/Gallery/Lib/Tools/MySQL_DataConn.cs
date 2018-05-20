using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Nexus.Core.Pages;

namespace Nexus.Controls.Gallery.Lib
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

        // 获取Photo Item列表
        public DataSet Get_Photos(string CategoryID, string SortOrder = "SortOrder", string Orientation = "ASC", string IsActive = "ALL", int TotalNumber = -1)
        {
            string Table_Name = "View_NexusPhoto_List";

            string Filter = "CategoryID IN (" + CategoryID
                + ")";

            if (IsActive != "ALL")
            {
                Filter += " AND "
                    + "IsActive = " + IsActive;
            }

            SortOrder = SortOrder + " " + Orientation;

            return Show_Items(Table_Name, null, Filter, SortOrder, TotalNumber);
        }

        // 获取Photo Item内容
        public DataRow Get_Photo(string PhotoID)
        {
            string Table_Name = "NexusPhoto_Items";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 获取Setting Item列表
        public DataSet Get_Photo_Settings(string SortOrder = "SettingID")
        {
            string Table_Name = "NexusPhoto_Settings";

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        // 获取Setting Item内容
        public DataRow Get_Photo_Setting(string DisplayID)
        {
            string Table_Name = "NexusPhoto_Settings";

            string Filter = "DisplayID = " + DataEval.QuoteText(DisplayID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Photo_Setting_byID(string SettingID)
        {
            string Table_Name = "NexusPhoto_Settings";

            string Filter = "SettingID = " + SettingID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Photo_Item_Map(string Item_MapID)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            string Filter = "Item_MapID = " + Item_MapID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_Photo(string PhotoID)
        {
            string Table_Name = "NexusPhoto_Items";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);

            return chk_Exist(Table_Name, Filter);
        }

        public int Count_Photo_Item_Mapping(string PhotoID)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);

            return chk_Count(Table_Name, Filter);
        }

        public bool Chk_Photo_Item_Mapping(string PhotoID, string CategoryID)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);

            Filter += " AND "
                + "CategoryID = " + DataEval.QuoteText(CategoryID);

            return chk_Exist(Table_Name, Filter);
        }

        public bool Chk_Photo_Setting(string DisplayID)
        {
            string Table_Name = "NexusPhoto_Settings";

            string Filter = "DisplayID = " + DataEval.QuoteText(DisplayID);

            return chk_Exist(Table_Name, Filter);
        }


        // 添加Photo Item内容
        public void Add_Photo(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Items";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Photo_Item_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Photo_Setting(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Settings";

            Insert_Data_Field(Table_Name, UpdateData);
        }


        // 更新Photo Item内容
        public void Edit_Photo(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Items";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Photo_Item_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Photo_Setting(e2Data[] UpdateData)
        {
            string Table_Name = "NexusPhoto_Settings";

            Update_Data_Field(Table_Name, UpdateData);
        }

        // 删除Photo Item内容
        public void Remove_Photo(string PhotoID)
        {
            string Table_Name = "NexusPhoto_Items";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);
            
            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Photo_Item_Mapping(string Item_MapID)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            string Filter = "Item_MapID = " + Item_MapID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Photo_Items_Mapping(string PhotoID)
        {
            string Table_Name = "NexusPhoto_Item_Mapping";

            string Filter = "PhotoID = " + DataEval.QuoteText(PhotoID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Photo_Setting(string SettingID)
        {
            string Table_Name = "NexusPhoto_Settings";

            string Filter = "SettingID = " + SettingID;

            Delete_DataRows(Table_Name, Filter);
        }


    }
}
