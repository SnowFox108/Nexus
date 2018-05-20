using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Nexus.Core
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

        #region Global Categories

        #region Get

        public DataRow Get_Category(string CategoryID)
        {
            string Table_Name = "NexusCore_Categories";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Categories(string CategoryID, string SortOrder)
        {
            string Table_Name = "NexusCore_Categories";

            string Filter = "Parent_CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Category_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_ComponentInCategory_Full_ByCategoryID(string CategoryID, string SortOrder)
        {
            string Table_Name = "View_NexusCore_ComponentInCategory_List";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Category_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_ComponentInCategory(string CategoryID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            Filter += " AND "
                + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        public int Count_Child_Category(string CategoryID)
        {
            string Table_Name = "NexusCore_Categories";

            string Filter = "Parent_CategoryID = " + DataEval.QuoteText(CategoryID);

            return chk_Count(Table_Name, Filter);

        }

        public int Sum_CategoryItems(string CategoryID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Column_Name = "Item_Count";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            return chk_Sum(Table_Name, Column_Name, Filter);
        }

        public int Sum_CategoryItems(string CategoryID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Column_Name = "Item_Count";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            if (!DataEval.IsEmptyQuery(Module_ItemID))
            {
                Filter += " AND "
                    + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);
            }

            return chk_Sum(Table_Name, Column_Name, Filter);
        }

        #endregion 

        // 添加 Category 信息
        #region Add

        public void Add_Category(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Categories";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_ComponentInCategory(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 更新 Category 信息
        #region Edit

        public void Edit_Category(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Categories";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_ComponentInCategory(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 删除 Category 信息
        #region Remove

        public void Remove_Category(string CategoryID)
        {
            string Table_Name = "NexusCore_Categories";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInCategory_ByCategoryID(string CategoryID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInCategory_ByCategoryID(string CategoryID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Filter = "CategoryID = " + DataEval.QuoteText(CategoryID);

            Filter += " AND "
                + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInCategory_ByComponentID(string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Filter = "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInCategory_ByModuleID(string ModuleID)
        {
            string Table_Name = "NexusCore_ComponentInCategories";

            string Filter = "ModuleID = " + DataEval.QuoteText(ModuleID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Global PageTags

        #region Get

        public DataRow Get_PageTag(string PageTagID)
        {
            string Table_Name = "NexusCore_PageTags";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_PageTag_ByTagName(string Tag_Name)
        {
            string Table_Name = "NexusCore_PageTags";

            string Filter = "Tag_Name = " + DataEval.QuoteText(Tag_Name);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_PageTags(string SortOrder)
        {
            string Table_Name = "NexusCore_PageTags";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Tag_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataSet Get_ComponentInTag_Full_ByPageTagID(string PageTagID, string SortOrder)
        {
            string Table_Name = "View_NexusCore_ComponentInTag_List";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Tag_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_ComponentInTag(string PageTagID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            Filter += " AND "
                + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_PageTag_Mapping(string PageIndexID, string PageTagID)
        {
            string Table_Name = "NexusCore_PageTag_Mapping";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += " AND "
                + "PageTagID = " + DataEval.QuoteText(PageTagID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        public bool Chk_PageTag(string Tag_Name)
        {
            string Table_Name = "NexusCore_PageTags";

            string Filter = "Tag_Name = " + DataEval.QuoteText(Tag_Name);

            return chk_Exist(Table_Name, Filter);

        }

        public int Sum_PageTagItems(string PageTagID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Column_Name = "Item_Count";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            return chk_Sum(Table_Name, Column_Name, Filter);
        }

        public int Sum_PageTagItems(string PageTagID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Column_Name = "Item_Count";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            if (!DataEval.IsEmptyQuery(Module_ItemID))
            {
                Filter += " AND "
                    + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);
            }

            return chk_Sum(Table_Name, Column_Name, Filter);
        }

        #endregion

        // 添加 Page Tag 信息
        #region Add

        public void Add_PageTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageTags";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_ComponentInTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_PageTag_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageTag_Mapping";

            Insert_Data_Field(Table_Name, UpdateData);

        }

        #endregion

        // 更新 Page Tag 信息
        #region Edit

        public void Edit_PageTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageTags";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_ComponentInTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 删除 Page Tag 信息
        #region Remove

        public void Remove_PageTag(string PageTagID)
        {
            string Table_Name = "NexusCore_PageTags";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInTag_ByPageTagID(string PageTagID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInTag_ByPageTagID(string PageTagID, string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Filter = "PageTagID = " + DataEval.QuoteText(PageTagID);

            Filter += " AND "
                + "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInTag_ByComponentID(string Module_ItemID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Filter = "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ComponentInTag_ByModuleID(string ModuleID)
        {
            string Table_Name = "NexusCore_ComponentInTags";

            string Filter = "ModuleID = " + DataEval.QuoteText(ModuleID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_PageTag_Mapping(string PageTag_MappingID)
        {

            string Table_Name = "NexusCore_PageTag_Mapping";

            string Filter = "PageTag_MappingID = " + PageTag_MappingID;

            Delete_DataRows(Table_Name, Filter);

        }

        #endregion

        #endregion

        #region Modules

        public DataRow Get_Module(string ModuleID)
        {
            string Table_Name = "NexusCore_Modules";

            string Filter = "ModuleID = " + DataEval.QuoteText(ModuleID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Modules(string SortOrder, string Module_Types = "'System Addon', 'Customer Addon'")
        {
            string Table_Name = "NexusCore_Modules";

            string Filter = "Module_Type IN ("
                + Module_Types
                + ")";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Module_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_Component(string ComponentID)
        {
            string Table_Name = "NexusCore_Module_Components";

            string Filter = "ComponentID = " + DataEval.QuoteText(ComponentID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Components(string ModuleID, string Parent_ComponentID, string Component_Type, string SortOrder)
        {
            string Table_Name = "NexusCore_Module_Components";

            string Filter = "ModuleID = " + DataEval.QuoteText(ModuleID);

            if (!DataEval.IsEmptyQuery(Parent_ComponentID))
            {
                Filter += " AND ";
                Filter += "Parent_ComponentID = " + DataEval.QuoteText(Parent_ComponentID);
            }

            if (!DataEval.IsEmptyQuery(Component_Type))
            {
                Filter += " AND ";
                Filter += "Component_Type = " + DataEval.QuoteText(Component_Type);
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Component_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Control(string ControlID)
        {
            string Table_Name = "NexusCore_Component_Controls";

            string Filter = "ControlID = " + DataEval.QuoteText(ControlID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Control(string ComponentID, string Control_Type)
        {
            string Table_Name = "NexusCore_Component_Controls";

            string Filter = "ComponentID = " + DataEval.QuoteText(ComponentID);

            //if (Control_Type != null)
            //{
                Filter += " AND ";
                Filter += "Control_Type = " + DataEval.QuoteText(Control_Type);
            //}

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Controls(string ComponentID, string Control_Type, string SortOrder)
        {
            string Table_Name = "NexusCore_Component_Controls";

            string Filter = "ComponentID = " + DataEval.QuoteText(ComponentID);

            Filter += " AND ";
            Filter += "Control_Type = " + DataEval.QuoteText(Control_Type);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Control_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Module_Item(string Module_ItemID)
        {
            string Table_Name = "NexusCore_Module_Items";

            string Filter = "Module_ItemID = " + DataEval.QuoteText(Module_ItemID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_Module(string ModuleID)
        {
            string Table_Name = "NexusCore_Modules";

            string Filter = "ModuleID = " + DataEval.QuoteText(ModuleID);

            return chk_Exist(Table_Name, Filter);
        }


        #endregion

        #region Template

        public DataRow Get_Template(string TemplateID)
        {
            string Table_Name = "NexusCore_Templates";

            string Filter = "TemplateID = " + DataEval.QuoteText(TemplateID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Templates(string SortOrder)
        {
            string Table_Name = "NexusCore_Templates";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Template_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataSet Get_Template_List(string TemplateID, string ThemeID, string SortOrder)
        {
            string Table_Name = "View_Template_List";

            string Filter = "TemplateID = " + DataEval.QuoteText(TemplateID);

            Filter += " AND "
                + "ThemeID = " + DataEval.QuoteText(ThemeID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "MasterPage_Template_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataRow Get_Template_MasterPage (string Template_MasterPageID)
        {
            string Table_Name = "NexusCore_Template_MasterPages";

            string Filter = "Template_MasterPageID = " + DataEval.QuoteText(Template_MasterPageID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Template_MasterPages (string TemplateID, string SortOrder)
        {
            string Table_Name = "NexusCore_Template_MasterPages";

            string Filter = "TemplateID = " + DataEval.QuoteText(TemplateID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "MasterPage_Template_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Template_MasterPage_Control(string ControlID)
        {
            string Table_Name = "NexusCore_Template_MasterPage_Controls";

            string Filter = "ControlID = " + ControlID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Template_MasterPage_Controls(string Template_MasterPageID, string SortOrder)
        {
            string Table_Name = "NexusCore_Template_MasterPage_Controls";

            string Filter = "Template_MasterPageID = " + DataEval.QuoteText(Template_MasterPageID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Template_MasterPageID";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Theme(string ThemeID)
        {
            string Table_Name = "NexusCore_Themes";

            string Filter = "ThemeID = " + DataEval.QuoteText(ThemeID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Themes(string TemplateID, string SortOrder)
        {
            string Table_Name = "NexusCore_Themes";

            string Filter = "TemplateID = " + DataEval.QuoteText(TemplateID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Theme_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        #endregion

        #region MasterPages

        #region Get and Chk

        public DataRow Get_MasterPageIndex(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPageIndex";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_MasterPage(string MasterPageID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageID = " + DataEval.QuoteText(MasterPageID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_MasterPages(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            string SortOrder = "MasterPage_Version DESC";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_MasterPage_ActiveID(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            Filter += " AND "
                + "IsActive = True";

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_MasterPage_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        public DataSet Get_MasterPage_Controls(string MasterPageID)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            string Filter = "MasterPageID = " + DataEval.QuoteText(MasterPageID);

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_MasterPage_Controls(string MasterPageID, string PlaceHolderID)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            string Filter = "MasterPageID = " + DataEval.QuoteText(MasterPageID)
                + " AND "
                + "PlaceHolderID = " + DataEval.QuoteText(PlaceHolderID);

            string SortOrder = "PlaceHolderID, SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_MasterPage_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        // Get Customer Master Page Drop List
        public DataSet Get_Template_MasterPage_DropList(string SortOrder)
        {
            string Table_Name = "view_Template_Masterpage_DropList";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "MasterPage_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        // Get Customer Master Page List
        public DataSet Get_Template_MasterPage_List(string SortOrder)
        {
            string Table_Name = "view_Template_Masterpage_List";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "MasterPage_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public int Count_MasterPage_Version(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            return chk_Count(Table_Name, Filter);
        }


        #endregion

        #region Add

        // 添加 MasterPage 信息
        public void Add_MasterPageIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPageIndex";

            Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_MasterPage(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPages";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public string Add_MasterPage_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_MasterPage_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Control_Properties";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #region Edit

        // 更新 MasterPage 信息
        public void Edit_MasterPageIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPageIndex";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_MasterPage(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPages";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Reset_MasterPage_Active(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            exe_sqlCMD(string.Format("Update {0} Set IsActive = 0 Where {1}", Table_Name, Filter));
        }

        public void Edit_MasterPage_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_MasterPage_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #region Remove

        // 删除 MasterPage 信息
        public void Remove_MasterPageIndex(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPageIndex";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage(string MasterPageID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageID = " + DataEval.QuoteText(MasterPageID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPages(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPages";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage_Controls(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPage_Controls";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Master Design Mode

        public DataRow Get_MasterPage_Lock(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_MasterPage_Lock(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            return chk_Exist(Table_Name, Filter);
        }

        public DataSet Get_MasterPage_Locks(string SortOrder)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "MasterPage_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_MasterPage_Lock_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_MasterPage_Lock_Controls(string MasterPage_LockID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            string Filter = "MasterPage_LockID = " + MasterPage_LockID;

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataSet Get_MasterPage_Lock_Controls(string MasterPage_LockID, string PlaceHolderID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            string Filter = "MasterPage_LockID = " + MasterPage_LockID
                + " AND "
                + "PlaceHolderID = " + DataEval.QuoteText(PlaceHolderID);

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_MasterPage_Lock_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public string Add_MasterPage_Lock(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public string Add_MasterPage_Lock_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_MasterPage_Lock_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Control_Properties";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新 MasterPage Lock 信息
        public void Edit_MasterPage_Lock(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_MasterPage_Lock_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_MasterPage_Lock_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        // 删除 MasterPage Lock 信息
        public void Remove_MasterPage_Lock(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPage_Locks";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage_Lock_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage_Lock_Controls(string MasterPage_LockID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Controls";

            string Filter = "MasterPage_LockID = " + MasterPage_LockID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_MasterPage_Lock_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_MasterPage_Lock_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #region Toolboxes

        public DataRow Get_Toolbox_Option(string ToolboxID)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Options";

            string Filter = "ToolboxID = " + ToolboxID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Toolbox_Options(string SortOrder)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Options";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Component_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_Toolbox_Group(string GroupID)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Groups";

            string Filter = "GroupID = " + DataEval.QuoteText(GroupID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Toolbox_Groups(string SortOrder)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Groups";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Group_Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_Toolbox_Tool(string Module_ToolID)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Tools";

            string Filter = "Module_ToolID = " + Module_ToolID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Toolbox_Tools(string GroupID, string SortOrder)
        {
            string Table_Name = "NexusCore_Module_Toolbox_Tools";

            string Filter = "GroupID = " + DataEval.QuoteText(GroupID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Tool_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        #endregion

        #region SiteMenu

        public DataRow Get_Menu_Node(string PageIndexID)
        {
            string Table_Name = "View_NexusCore_PageIndex_Menu";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            string SortOrder = "SortOrder";

            return Show_ItemRow(Table_Name, null, Filter, SortOrder);
        }

        public DataSet Get_Menu_Nodes(string Parent_PageIndexID, string CategoryIDs)
        {
            string Table_Name = "View_NexusCore_PageIndex_Menu";

            string Filter = "Parent_PageIndexID = " + DataEval.QuoteText(Parent_PageIndexID);

            //int i = 0;
            Filter += " AND ";

            Filter += "Page_CategoryID IN ("
                + CategoryIDs
                + ")";

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public int Get_Root_Menu_Count()
        {
            string Table_Name = "View_NexusCore_PageIndex_Menu";

            string Filter = "Parent_PageIndexID = " + DataEval.QuoteText("-1");

            return chk_Count(Table_Name, Filter);

        }

        public void Edit_Menu_Nodes(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageIndex";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        #endregion

        #region MetaTag

        #region Page

        public DataSet Get_Page_MetaTags(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }


        public DataSet Get_Page_MetaTags(string PageIndexID, string Meta_Type)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID)
                + " AND "
                + "Meta_Type = " + DataEval.QuoteText(Meta_Type);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataRow Get_Page_MetaTag(string MetaTagID)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            string Filter = "MetaTagID = " + MetaTagID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 添加 Meta 信息
        public void Add_Page_MetaTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新 Meta 信息
        public void Edit_Page_MetaTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        // 删除 Meta 信息
        public void Remove_Page_MetaTag(string MetaTagID)
        {
            string Table_Name = "NexusCore_Page_MetaTags";

            string Filter = "MetaTagID = " + MetaTagID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #region MasterPage

        public DataSet Get_MasterPage_MetaTags(string MasterPageIndexID)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataSet Get_MasterPage_MetaTags(string MasterPageIndexID, string Meta_Type)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            string Filter = "MasterPageIndexID = " + DataEval.QuoteText(MasterPageIndexID)
                + " AND "
                + "Meta_Type = " + DataEval.QuoteText(Meta_Type);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataRow Get_MasterPage_MetaTag(string MetaTagID)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            string Filter = "MetaTagID = " + MetaTagID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        // 添加 Meta 信息
        public void Add_MasterPage_MetaTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新 Meta 信息
        public void Edit_MasterPage_MetaTag(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        // 删除 Meta 信息
        public void Remove_MasterPage_MetaTag(string MetaTagID)
        {
            string Table_Name = "NexusCore_MasterPage_MetaTags";

            string Filter = "MetaTagID = " + MetaTagID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Pages

        #region Get and Chk

        public DataSet Get_Page_Categories()
        {
            string Table_Name = "NexusCore_Page_Categories";

            string SortOrder = "Page_CategoryID";

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataSet Get_PagesIndex_ByName(string Page_Name)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_Name = " + DataEval.QuoteText(Page_Name);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataSet Get_PagesIndex_ByName(string Page_Name, string CategoryIDs)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_Name = " + DataEval.QuoteText(Page_Name);

            Filter += " AND "
                + "Page_CategoryID IN ("
                + CategoryIDs
                + ")";

            return Show_Items(Table_Name, null, Filter, null, -1);
        }


        public DataRow Get_PageIndex(string PageIndexID)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_PagesIndex(string Page_CategoryID, string SortOrder)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_CategoryID = " + Page_CategoryID;

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Page_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_PageIndex_List(string Parent_PageIndexID, string CategoryIDs, string SortOrder)
        {
            string Table_Name = "View_NexusCore_PageIndex_List";

            string Filter = "Page_CategoryID IN ("
                + CategoryIDs
                + ")";

            if (!DataEval.IsEmptyQuery(Parent_PageIndexID))
            {
                Filter += " AND ";
                Filter += "Parent_PageIndexID = " + DataEval.QuoteText(Parent_PageIndexID);
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Child_PageIndex(string PageIndexID, string SortOrder)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_CategoryID = 1";

            Filter += " AND "
                + "Parent_PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += " AND "
                + "Page_Type = " + DataEval.QuoteText(StringEnum.GetStringValue(Pages.Page_Type.Normal_Page));

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_ItemRow(Table_Name, null, Filter, SortOrder);
        }

        public DataSet Get_Child_PageIndex(string PageIndexID, string CategoryIDs, string SortOrder)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_CategoryID IN ("
                + CategoryIDs
                + ")";

            if (!DataEval.IsEmptyQuery(PageIndexID))
            {
                Filter += " AND ";
                Filter += "Parent_PageIndexID = " + DataEval.QuoteText(PageIndexID);
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Page(string PageID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageID = " + DataEval.QuoteText(PageID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Pages(string PageIndexID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += " AND "
                + "IsDelete = 0";

            string SortOrder = "Page_Version DESC";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Page_ActiveID(string PageIndexID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Filter += " AND "
                + "IsActive = True";

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        public DataSet Get_Page_Controls(string PageID)
        {
            string Table_Name = "NexusCore_Page_Controls";

            string Filter = "PageID = " + DataEval.QuoteText(PageID);

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataSet Get_Page_Controls(string PageID, string PlaceHolderID)
        {
            string Table_Name = "NexusCore_Page_Controls";

            string Filter = "PageID = " + DataEval.QuoteText(PageID)
                + " AND "
                + "PlaceHolderID = " + DataEval.QuoteText(PlaceHolderID);

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Page_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public bool Chk_PageIndexID(string PageIndexID)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);
        }

        public bool Chk_PageName(string Page_Name)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_Name = " + DataEval.QuoteText(Page_Name);

            return chk_Exist(Table_Name, Filter);
        }

        public bool Chk_PageName_Live(string Page_Name)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Page_Name = " + DataEval.QuoteText(Page_Name);

            Filter += " AND "
                    + "Page_CategoryID NOT IN ("
                    + "2, 3, 4"
                    + ")";

            return chk_Exist(Table_Name, Filter);
        }

        public int Count_Child_PageIndex(string PageIndexID, string CategoryIDs)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "Parent_PageIndexID = " + DataEval.QuoteText(PageIndexID);

            if (CategoryIDs != "-1")
            {
                Filter += "AND "
                    + "Page_CategoryID IN ("
                    + CategoryIDs
                    + ")";
            }

            return chk_Count(Table_Name, Filter);

        }

        public int Count_Page_Version(string PageIndexID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Count(Table_Name, Filter);
        }

        #endregion

        #region Add

        // 添加 Page 信息
        public void Add_PageIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageIndex";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Pages";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public string Add_Page_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Controls";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_Page_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Control_Properties";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #region Edit

        // 更新 Page 信息
        public void Edit_PageIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_PageIndex";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Pages";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Reset_Page_Active(string PageIndexID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            exe_sqlCMD(string.Format("Update {0} Set IsActive = 0 Where {1}", Table_Name, Filter));
        }

        public void Edit_Page_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Control_Properties";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #region Remove

        // 删除 Page 信息
        public void Remove_PageIndex(string PageIndexID)
        {
            string Table_Name = "NexusCore_PageIndex";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page(string PageID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageID = " + DataEval.QuoteText(PageID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Pages(string PageIndexID)
        {
            string Table_Name = "NexusCore_Pages";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Controls(string PageID)
        {
            string Table_Name = "NexusCore_Page_Controls";

            string Filter = "PageID = " + DataEval.QuoteText(PageID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Pages Design Mode

        public DataRow Get_Page_Lock(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Locks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_Page_Lock(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Locks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);
        }

        public DataSet Get_Page_Locks(string Page_CategoryID, string SortOrder)
        {
            string Table_Name = "NexusCore_Page_Locks";

            string Filter = "Page_CategoryID = " + Page_CategoryID;

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Page_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Page_Lock_Template(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Templates";

            string Filter = "Page_LockID = " + Page_LockID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Lock_Attribute(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Attributes";

            string Filter = "Page_LockID = " + Page_LockID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Lock_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Page_Lock_Controls(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            string Filter = "Page_LockID = " + Page_LockID;

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataSet Get_Page_Lock_Controls(string Page_LockID, string PlaceHolderID)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            string Filter = "Page_LockID = " + Page_LockID
                + " AND "
                + "PlaceHolderID = " + DataEval.QuoteText(PlaceHolderID);

            string SortOrder = "SortOrder";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Page_Lock_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Lock_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public string Add_Page_Lock(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Locks";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_Page_Lock_Template(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Templates";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_Lock_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Attributes";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public string Add_Page_Lock_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        public void Add_Page_Lock_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Control_Properties";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        // 更新 Page Lock 信息
        public void Edit_Page_Lock(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Locks";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_Lock_Template(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Templates";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_Lock_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Attributes";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_Lock_Control(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Page_Lock_Control_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            Update_Data_Field(Table_Name, UpdateData);
        }

        // 删除 Page Lock 信息
        public void Remove_Page_Lock(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Locks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Lock_Template(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Templates";

            string Filter = "Page_LockID = " + Page_LockID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Lock_Attribute(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Attributes";

            string Filter = "Page_LockID = " + Page_LockID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Lock_Control(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Lock_Controls(string Page_LockID)
        {
            string Table_Name = "NexusCore_Page_Lock_Controls";

            string Filter = "Page_LockID = " + Page_LockID;

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Lock_Control_Properties(string Page_ControlID)
        {
            string Table_Name = "NexusCore_Page_Lock_Control_Properties";

            string Filter = "Page_ControlID = " + Page_ControlID;

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

        #region Page Properties

        #region Get

        public DataRow Get_Page_Property(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Props";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Template(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Templates";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_ExtLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_ExtLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_IntLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_IntLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Page_Attribute(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Attributes";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        #endregion

        #region Chk

        public bool Chk_Page_Template(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Templates";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Page_ExtLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_ExtLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Page_IntLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_IntLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Page_Attribute(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Attributes";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            return chk_Exist(Table_Name, Filter);

        }

        #endregion

        // 添加信息
        #region Add

        public void Add_Page_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Props";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_Template(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Templates";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_ExtLink(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_ExtLinks";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_IntLink(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_IntLinks";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Page_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Attributes";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 更新信息
        #region Update

        public void Edit_Page_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Props";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page_Template(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Templates";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page_ExtLink(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_ExtLinks";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page_IntLink(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_IntLinks";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Page_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Page_Attributes";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        #endregion

        // 删除信息
        #region Delete

        public void Remove_Page_Property(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Props";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Template(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Templates";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_ExtLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_ExtLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_IntLink(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_IntLinks";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Page_Attribute(string PageIndexID)
        {
            string Table_Name = "NexusCore_Page_Attributes";

            string Filter = "PageIndexID = " + DataEval.QuoteText(PageIndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Page Categories

        public DataRow Get_Page_Category (string Page_CategoryID)
        {
            string Table_Name = "NexusCore_Page_Categories";

            string Filter = "Page_CategoryID = " + Page_CategoryID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Page_Categories (string SortOrder)
        {
            string Table_Name = "NexusCore_Page_Categories";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Name";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        #endregion

        #region Phrase

        public DataSet Get_Phrases(string FieldName, string SortOrder, string ModuleID)
        {
            string Table_Name = "NexusCore_Phrases";

            string Filter = "FieldName = " + DataEval.QuoteText(FieldName);

           Filter += " AND "
               + "ModuleID = " + DataEval.QuoteText(ModuleID);

            if (DataEval.IsEmptyQuery(SortOrder))
            SortOrder = "VarName";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Phrases(string FieldName, string Language, string SortOrder, string ModuleID)
        {
            string Table_Name = "NexusCore_Phrases";

            string Filter = "FieldName = " + DataEval.QuoteText(FieldName);

            Filter += " AND "
                + "ModuleID = " + DataEval.QuoteText(ModuleID);

            Filter += " AND "
                + "Language = " + DataEval.QuoteText(Language);


            if (DataEval.IsEmptyQuery(SortOrder))
                SortOrder = "VarName";

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataRow Get_Phrase(string VarName)
        {
            string Table_Name = "NexusCore_Phrases";

            string Filter = "VarName = " + DataEval.QuoteText(VarName);

            Filter += " AND "
                + "Language = " + DataEval.QuoteText("0");

            string SortOrder = "VarName";

            return Show_ItemRow(Table_Name, null, Filter, SortOrder);
        }

        public DataRow Get_Phrase(string VarName, string Language)
        {
            string Table_Name = "NexusCore_Phrases";

            string Filter = "VarName = " + DataEval.QuoteText(VarName)
                + " AND "
                + "Language = " + DataEval.QuoteText(Language);

            string SortOrder = "VarName";

            return Show_ItemRow(Table_Name, null, Filter, SortOrder);
        }

        public void Add_Phrase(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Phrases";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_Phrase(e2Data[] UpdateData)
        {
            string Table_Name = "NexusCore_Phrases";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Remove_Phrase(string PhraseID)
        {
            string Table_Name = "NexusCore_Phrases";

            string Filter = "PhraseID = " + PhraseID;

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion
    }
}
