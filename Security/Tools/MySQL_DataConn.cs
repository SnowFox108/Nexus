using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Nexus.Security
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

        #region User Login Control

        // 通过 Email 获得用户信息
        public DataRow Get_UserDetail_ByUserID(string UserID, string IsLockedOut, string IsDelete)
        {
            string Table_Name = "NexusUser_Users";

            string Filter = "UserID = " + DataEval.QuoteText(UserID);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 通过 Email 获得用户信息
        public DataRow Get_UserDetail_ByEmail(string Email, string IsLockedOut, string IsDelete)
        {
            string Table_Name = "NexusUser_Users";

            string Filter = "Email = " + DataEval.QuoteText(Email);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        // 查找已存在客户
        public bool chk_UserByID(string UserID, string IsLockedOut, string IsDelete)
        {
            // Check Users Table
            string Table_Name = "NexusUser_Users";

            string Filter = "UserID = " + DataEval.QuoteText(UserID);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return chk_Exist(Table_Name, Filter);

        }

        // 查找已存在客户
        public bool chk_UserByUserName(string UserName, string IsLockedOut, string IsDelete)
        {
            // Check Users Table
            string Table_Name = "NexusUser_Users";

            string Filter = "UserName = " + DataEval.QuoteText(UserName);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return chk_Exist(Table_Name, Filter);

        }

        // 查找已存在客户
        public bool chk_UserByEmail(string Email, string IsLockedOut, string IsDelete)
        {
            // Check Users Table
            string Table_Name = "NexusUser_Users";

            string Filter = "Email = " + DataEval.QuoteText(Email);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return chk_Exist(Table_Name, Filter);

        }

        // 查找已存在客户
        public bool chk_UserLogin(string Email, string UserPass, string IsLockedOut, string IsDelete)
        {
            // Check Users Table
            string Table_Name = "NexusUser_Users";

            string Filter = "Email = " + DataEval.QuoteText(Email);

            Filter += " AND "
                + "UserPass = " + DataEval.QuoteText(UserPass);

            if (IsLockedOut != "ALL")
            {
                Filter += " AND "
                    + "IsLockedOut = " + IsLockedOut;
            }

            if (IsDelete != "ALL")
            {
                Filter += " AND "
                    + "DeleteMark = " + IsDelete;
            }

            return chk_Exist(Table_Name, Filter);

        }

        // 添加用户基本信息
        public string Add_Users(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_Users";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        // 更新用户基本信息
        public void Edit_Users(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_Users";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #region User Groups

        public DataSet Get_UserGroups(string SortOrder)
        {
            string Table_Name = "NexusUser_UserGroups";

            string Filter = "";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);

        }

        public DataRow Get_UserGroup_ByGroupID(string UserGroupID)
        {
            string Table_Name = "NexusUser_UserGroups";

            string Filter = "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_UserInGroups_ByUserID(string UserID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "UserID = " + DataEval.QuoteText(UserID);

            return Show_Items(Table_Name, null, Filter, null, -1);

        }

        public bool Chk_UserInGroup(string UserID, string UserGroupID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "UserID = " + DataEval.QuoteText(UserID);

            Filter += " AND "
                + "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            return chk_Exist(Table_Name, Filter);
        }

        public void Add_UserGroups(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_UserGroups";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_UserInGroups(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_UserInGroups";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_UserGroups(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_UserGroups";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_UserInGroups(e2Data[] UpdateData)
        {
            string Table_Name = "NexusUser_UserInGroups";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Remove_UserGroups(string UserGroupID)
        {
            string Table_Name = "NexusUser_UserGroups";

            string Filter = "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            Delete_DataRows(Table_Name, Filter);

        }

        public void Remove_UserInGroups(string RelationID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "RelationID = " + RelationID;

            Delete_DataRows(Table_Name, Filter);

        }

        public void Remove_UserInGroups(string UserID, string UserGroupID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "UserID = " + DataEval.QuoteText(UserID)
                + " AND "
                + "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            Delete_DataRows(Table_Name, Filter);

        }

        public void Remove_UserInGroups_ByUserID(string UserID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "UserID = " + DataEval.QuoteText(UserID);

            Delete_DataRows(Table_Name, Filter);

        }

        public void Remove_UserInGroups_ByGroupID(string UserGroupID)
        {
            string Table_Name = "NexusUser_UserInGroups";

            string Filter = "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            Delete_DataRows(Table_Name, Filter);

        }

        #endregion

        #region Page Privacy

        public DataRow Get_Page_PrivacyURL(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_PrivacyURL";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Page_Privacies(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataRow Get_Page_Privacy(string PrivacyID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PrivacyID = " + PrivacyID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Privacy(string PageIndexID, string UserGroupID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += "AND "
                + "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Page_Privacy_FullList(string PageIndexID)
        {
            string Table_Name = "View_NexusCore_Page_Privacy_List";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            string SortOrder = "UserGroup_Name";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Page_Privacy_Full(string PrivacyID)
        {
            string Table_Name = "View_NexusCore_Page_Privacy_List";

            string Filter = "PrivacyID = " + PrivacyID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_PageIndex(string PageIndexID)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Property(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Props";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_Page_Privacy(string PageIndexID, string UserGroupID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += "AND "
                + "UserGroupID = " + DataEval.QuoteText(UserGroupID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Page_PrivacyURL(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_PrivacyURL";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);

        }

        public void Add_Page_PrivacyURL(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_PrivacyURL";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_Privacy(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_PrivacyURL(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_PrivacyURL";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page_Privacy(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Remove_Page_PrivacyURL(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_PrivacyURL";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Privacies(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Privacy(string PrivacyID)
        {
            string Table_Name = "NexusCore_Page_Privacies";

            string Filter = "PrivacyID = " + PrivacyID;

            Delete_DataRows(Table_Name, Filter);
        }



        #endregion
    }
}
