using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Nexus.Shop
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

        #region Product Variants

        // 获取 Product Variant 信息
        #region Get

        public DataRow Get_Product_Variant(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variants";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Variants(string SortOrder = "Variant_Name", string SortDirection = "ASC")
        {
            string Table_Name = "NexusShop_Product_Variants";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Variant_Name";
            }
            else
            {
                SortOrder = string.Format("{0} {1}", SortOrder, SortDirection);
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_Product_Variant_Spliter(string Variant_SpliterID)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            string Filter = "Variant_SpliterID = " + DataEval.QuoteText(Variant_SpliterID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Variant_Spliters(string Product_VariantID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Product_Variant_Property (string Variant_PropertyID)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Variant_PropertyID = " + DataEval.QuoteText(Variant_PropertyID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Variant_Properties(string Product_VariantID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Product_Variant_Properties_BySpliterID(string Variant_SpliterID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Variant_SpliterID = " + DataEval.QuoteText(Variant_SpliterID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Product_Variant_Property_Option(string OptionID)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            string Filter = "OptionID = " + DataEval.QuoteText(OptionID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Variant_Property_Options(string Variant_PropertyID, string SortOrder = "SortOrder", string IsActive = "ALL")
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            string Filter = "Variant_PropertyID = " + DataEval.QuoteText(Variant_PropertyID);

            if (IsActive != "ALL")
            {
                Filter += " AND "
                    + "IsActive = " + IsActive;
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Customer_Product(string Table_Name, string ProductID)
        {
            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public bool Chk_Product_Variant(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variants";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            return chk_Exist(Table_Name, Filter);

        }

        public int Count_Variant_Spliter(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            return chk_Count(Table_Name, Filter);

        }

        public bool Chk_Variant_Spliter_usage(string Variant_SpliterID)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Variant_SpliterID = " + DataEval.QuoteText(Variant_SpliterID);

            return chk_Exist(Table_Name, Filter);

        }

        public int Count_Variant_Property(string Variant_SpliterID)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Variant_SpliterID = " + DataEval.QuoteText(Variant_SpliterID);

            return chk_Count(Table_Name, Filter);

        }

        public int Count_Variant_Property_Option(string Variant_PropertyID)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            string Filter = "Variant_PropertyID = " + DataEval.QuoteText(Variant_PropertyID);

            return chk_Count(Table_Name, Filter);

        }

        #endregion

        // 添加 Product Variant 信息
        #region Add

        public void Add_Product_Variant(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variants";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Product_Variant_Spliter (e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            Insert_Data_Field(Table_Name, UpdateData);
        }


        public void Add_Product_Variant_Property (e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Product_Variant_Property_Option (e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Product_Detail(List<e2Data> UpdateData, string Table_Name)
        {
            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 更新 Product Variant 信息
        #region Edit

        public void Edit_Product_Variant(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variants";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Product_Variant_Spliter(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        public void Edit_Product_Variant_Property(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Product_Variant_Property_Option(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Product_Detail(List<e2Data> UpdateData, string Table_Name)
        {
            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        #endregion

        // 删除 Product Variant 信息
        #region Remove

        public void Remove_Product_Variant(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variants";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Variant_Spliter(string Variant_SpliterID)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            string Filter = "Variant_SpliterID = " + DataEval.QuoteText(Variant_SpliterID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Variant_Spliter_ByVariantID(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variant_Spliters";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            Delete_DataRows(Table_Name, Filter);
        }


        public void Remove_Product_Variant_Property(string Variant_PropertyID)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Variant_PropertyID = " + DataEval.QuoteText(Variant_PropertyID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Variant_Property_ByVariantID(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Variant_Properties";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            Delete_DataRows(Table_Name, Filter);
        }


        public void Remove_Product_Variant_Property_Option(string OptionID)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            string Filter = "OptionID = " + DataEval.QuoteText(OptionID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Variant_Property_Option_ByPropertyID(string Variant_PropertyID)
        {
            string Table_Name = "NexusShop_Product_Variant_Property_Options";

            string Filter = "Variant_PropertyID = " + DataEval.QuoteText(Variant_PropertyID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Detail(string ProductID, string Table_Name)
        {

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }


        #endregion

        #endregion

        #region Product Attribute

        // 获取 Product Attribute 信息
        #region Get

        public DataRow Get_Product_Attribute_Type(string Attribute_TypeID)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            string Filter = "Attribute_TypeID = " + DataEval.QuoteText(Attribute_TypeID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Attribute_Types(string Product_VariantID, string SortOrder = "Attribute_Name")
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Attribute_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Product_AttributeIndex(string Attribute_IndexID)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            string Filter = "Attribute_IndexID = " + DataEval.QuoteText(Attribute_IndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_AttributeIndexes(string ProductID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Product_AttributeIndexes(string ProductID, bool isView, string SortOrder = "SortOrder")
        {
            string Table_Name = "view_NexusShop_Product_AttributeIndex_List";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Product_Attribute(string AttributeID)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            string Filter = "AttributeID = " + DataEval.QuoteText(AttributeID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Product_Attribute_ByIndexID(string Attribute_IndexID)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            string Filter = "Attribute_IndexID = " + DataEval.QuoteText(Attribute_IndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Attributes(string Attribute_IndexID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_Attributes";

            string Filter = "Attribute_IndexID = " + DataEval.QuoteText(Attribute_IndexID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public bool Chk_Attribute_usage(string Attribute_TypeID)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            string Filter = "Attribute_TypeID = " + DataEval.QuoteText(Attribute_TypeID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Attribute_type(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            return chk_Exist(Table_Name, Filter);

        }

        #endregion

        // 添加 Product Attribute 信息
        #region Add

        public void Add_Product_Attribute_Type(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Product_AttributeIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            Insert_Data_Field(Table_Name, UpdateData);
        }


        public void Add_Product_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 更新 Product Attribute 信息
        #region Edit

        public void Edit_Product_Attribute_Type(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Product_AttributeIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        public void Edit_Product_Attribute(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        #endregion

        // 删除 Product Attribute 信息
        #region Remove

        public void Remove_Product_Attribute_Type(string Attribute_TypeID)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            string Filter = "Attribute_TypeID = " + DataEval.QuoteText(Attribute_TypeID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Attribute_Type_ByVariantID(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Product_Attribute_Types";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_AttributeIndex(string Attribute_IndexID)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            string Filter = "Attribute_IndexID = " + DataEval.QuoteText(Attribute_IndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_AttributeIndex_ByProductID(string ProductID)
        {
            string Table_Name = "NexusShop_Product_AttributeIndex";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }


        public void Remove_Product_Attribute(string AttributeID)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            string Filter = "AttributeID = " + DataEval.QuoteText(AttributeID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Attribute_ByIndexID(string Attribute_IndexID)
        {
            string Table_Name = "NexusShop_Product_Attributes";

            string Filter = "Attribute_IndexID = " + DataEval.QuoteText(Attribute_IndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion

        #endregion

        #region Products
        // 获取 Products 信息
        #region Get

        public DataRow Get_Manufacturer(string ManufacturerID)
        {
            string Table_Name = "NexusShop_Manufacturers";

            string Filter = "ManufacturerID = " + DataEval.QuoteText(ManufacturerID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Manufacturers(string SortOrder = "Name", string IsActive = "ALL")
        {
            string Table_Name = "NexusShop_Manufacturers";

            string Filter = "";

            if (IsActive != "ALL")
            {
                Filter += "IsActive = " + IsActive;
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_ProductIndex(string Product_IndexID)
        {
            string Table_Name = "NexusShop_ProductIndex";

            string Filter = "Product_IndexID = " + DataEval.QuoteText(Product_IndexID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_ProductIndexes(string SortOrder = "LastUpdate_Date DESC")
        {
            string Table_Name = "NexusShop_ProductIndex";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "LastUpdate_Date DESC";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataSet Get_ProductIndexes(string Title, string SortOrder = "LastUpdate_Date", string Direction = "ASC")
        {
            string Table_Name = "view_NexusShop_ProductIndex_List";

            string Filter = "";

            if (!DataEval.IsEmptyQuery(Title))
            {
                Filter += "Title Like " + DataEval.QuoteTextLike(Title);
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "LastUpdate_Date DESC";
            }
            else
            {
                if (!DataEval.IsEmptyQuery(Direction))
                {
                    SortOrder += " " + Direction;
                }
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataRow Get_Product(string ProductID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Products(string SortOrder = "Product_Title")
        {
            string Table_Name = "NexusShop_Products";

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Product_Title";
            }

            return Show_Items(Table_Name, null, null, SortOrder, -1);
        }

        public DataSet Get_Products(string Product_IndexID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "Product_IndexID = " + DataEval.QuoteText(Product_IndexID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_ProductTag_Mapping(string ProductID)
        {
            string Table_Name = "NexusShop_ProductTag_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            return Show_Items(Table_Name, null, Filter, null, -1);
        }

        public DataRow Get_Product_Mapping(string Product_MappingID)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "Product_MappingID = " + Product_MappingID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }


        public DataSet Get_Product_Mappings(string ProductID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Product_Mappings(string ProductID, bool isView, string SortOrder = "Category_Name")
        {
            string Table_Name = "view_NexusShop_Product_Cateogries";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Category_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }


        public DataRow Get_WebPage(string WebPageID)
        {
            string Table_Name = "NexusShop_WebPages";

            string Filter = "WebPageID = " + DataEval.QuoteText(WebPageID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_WebPages(string ProductID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_WebPages";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_WebMedium(string WebMediaID)
        {
            string Table_Name = "NexusShop_WebMedia";

            string Filter = "WebMediaID = " + DataEval.QuoteText(WebMediaID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_WebMedia(string ProductID, string SortOrder = "SortOrder")
        {
            string Table_Name = "NexusShop_WebMedia";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "SortOrder";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public bool Chk_Product_Variant_usage(string Product_VariantID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);

            return chk_Exist(Table_Name, Filter);

        }

        public bool Chk_Manufacturer_usage(string ManufacturerID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "ManufacturerID = " + DataEval.QuoteText(ManufacturerID);

            return chk_Exist(Table_Name, Filter);

        }

        public int Count_Product_ByProductIndex(string Product_IndexID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "Product_IndexID = " + DataEval.QuoteText(Product_IndexID);

            return chk_Count(Table_Name, Filter);

        }

        public bool Chk_Product_Mapping(string ProductID, string CategoryID)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Filter += " AND "
                + "CategoryID = " + DataEval.QuoteText(CategoryID);

            return chk_Exist(Table_Name, Filter);
        }

        public int Count_Product_Mapping(string ProductID)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            return chk_Count(Table_Name, Filter);

        }

        #endregion

        // 添加 Products 信息
        #region Add

        public void Add_Manufacturer(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Manufacturers";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_ProductIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_ProductIndex";

            Insert_Data_Field(Table_Name, UpdateData);
        }


        public void Add_Product(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Products";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_ProductTag_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_ProductTag_Mapping";
            
            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_Product_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_WebPage(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_WebPages";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        public void Add_WebMedia(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_WebMedia";

            Insert_Data_Field(Table_Name, UpdateData);
        }


        #endregion

        // 更新 Products 信息
        #region Edit

        public void Edit_Manufacturer(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Manufacturers";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_ProductIndex(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_ProductIndex";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }


        public void Edit_Product(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Products";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_ProductTag_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_ProductTag_Mapping";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_Product_Mapping(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            Update_Data_Field(Table_Name, UpdateData);
        }

        public void Edit_WebPage(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_WebPages";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        public void Edit_WebMedia(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_WebMedia";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        #endregion

        // 删除 Products 信息
        #region Remove

        public void Remove_Manufacturer(string ManufacturerID)
        {
            string Table_Name = "NexusShop_Manufacturers";

            string Filter = "ManufacturerID = " + DataEval.QuoteText(ManufacturerID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ProductIndex(string Product_IndexID)
        {
            string Table_Name = "NexusShop_ProductIndex";

            string Filter = "Product_IndexID = " + DataEval.QuoteText(Product_IndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product(string ProductID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_ByIndexID(string Product_IndexID)
        {
            string Table_Name = "NexusShop_Products";

            string Filter = "Product_IndexID = " + DataEval.QuoteText(Product_IndexID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ProducTag_Mapping(string ProductTag_MappingID)
        {
            string Table_Name = "NexusShop_ProductTag_Mapping";

            string Filter = "ProductTag_MappingID = " + DataEval.QuoteText(ProductTag_MappingID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_ProducTag_Mapping_ByProductID(string ProductID)
        {
            string Table_Name = "NexusShop_ProductTag_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Mapping(string Product_MappingID)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "Product_MappingID = " + DataEval.QuoteText(Product_MappingID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_Product_Mapping_ByProductID(string ProductID)
        {
            string Table_Name = "NexusShop_Product_Mapping";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_WebPage(string WebPageID)
        {
            string Table_Name = "NexusShop_WebPages";

            string Filter = "WebPageID = " + DataEval.QuoteText(WebPageID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_WebPage_ByProductID(string ProductID)
        {
            string Table_Name = "NexusShop_WebPages";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_WebMedia(string WebMediaID)
        {
            string Table_Name = "NexusShop_WebMedia";

            string Filter = "WebMediaID = " + DataEval.QuoteText(WebMediaID);

            Delete_DataRows(Table_Name, Filter);
        }

        public void Remove_WebMedia_ByProductID(string ProductID)
        {
            string Table_Name = "NexusShop_WebMedia";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            Delete_DataRows(Table_Name, Filter);
        }

        #endregion


        #endregion

        #region Product Search

        public DataRow Get_Product_Search(string ProductID)
        {
            string Table_Name = "View_NexusShop_Product_List";

            string Filter = "ProductID = " + DataEval.QuoteText(ProductID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Product_Search(
            string Search_Field,
            string Keyword,
            string Product_VariantID,
            string CategoryID,
            string ManufacturerID,
            string IsActive = "ALL",
            string Index_IsActive = "ALL",
            string SortOrder = "Product_Title",
            string Direction = "ASC",
            int PageNum = 1,
            int PageSize = -1)
        {
            string Table_Name = "View_NexusShop_Product_List";

            string Filter = "";

            if (!DataEval.IsEmptyQuery(Search_Field) && !DataEval.IsEmptyQuery(Keyword))
            {
                if (Search_Field == "Both_Title")
                {
                    Filter += "("
                        + "Title LIKE " + DataEval.QuoteTextLike(Keyword)
                        + " OR "
                        + "Product_Title LIKE " + DataEval.QuoteTextLike(Keyword)
                        + ")";
                }
                else
                {
                    Filter += Search_Field + " LIKE " + DataEval.QuoteTextLike(Keyword);
                }
            }

            if (!DataEval.IsNegativeQuery(Product_VariantID))
            {
                if (!DataEval.IsEmptyQuery(Filter))
                    Filter += " AND ";

                Filter += "Product_VariantID = " + DataEval.QuoteText(Product_VariantID);
            }

            if (!DataEval.IsNegativeQuery(CategoryID))
            {
                if (!DataEval.IsEmptyQuery(Filter))
                    Filter += " AND ";

                Filter += "CategoryID = " + DataEval.QuoteText(CategoryID);
            }


            if (!DataEval.IsNegativeQuery(ManufacturerID))
            {
                if (!DataEval.IsEmptyQuery(Filter))
                    Filter += " AND ";

                Filter += "ManufacturerID = " + DataEval.QuoteText(ManufacturerID);
            }

            if (IsActive != "ALL")
            {
                if (!DataEval.IsEmptyQuery(Filter))
                    Filter += " AND ";

                Filter += "IsActive = " + IsActive;
            }

            if (Index_IsActive != "ALL")
            {
                if (!DataEval.IsEmptyQuery(Filter))
                    Filter += " AND ";

                Filter += "Index_IsActive = " + Index_IsActive;
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Product_Title";
            }
            else
            {
                if (!DataEval.IsEmptyQuery(Direction))
                {
                    SortOrder += " " + Direction;
                }
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, PageNum, PageSize);
        }


        #endregion

        #region Misc

        #region Currency

        // 获取 Currency 信息
        #region Get

        public DataRow Get_Currency(string CurrencyID)
        {
            string Table_Name = "NexusShop_Currencies";

            string Filter = "CurrencyID = " + DataEval.QuoteText(CurrencyID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Currencies(string SortOrder = "Currency_Name", string IsActive = "ALL")
        {
            string Table_Name = "NexusShop_Currencies";

            string Filter = "";

            if (IsActive != "ALL")
            {
                Filter += "IsActive = " + IsActive;
            }

            if (DataEval.IsEmptyQuery(SortOrder))
            {
                SortOrder = "Currency_Name";
            }

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataRow Get_Currency_Rate(string RateID)
        {
            string Table_Name = "NexusShop_Currency_Rate";

            string Filter = "RateID = " + RateID;

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataRow Get_Currency_Rate(string Origin_CurrencyID, string Target_CurrencyID)
        {
            string Table_Name = "NexusShop_Currency_Rate";

            string Filter = "Origin_CurrencyID = " + DataEval.QuoteText(Origin_CurrencyID)
                + " AND "
                + "Target_CurrencyID = " + DataEval.QuoteText(Target_CurrencyID);

            return Show_ItemRow(Table_Name, null, Filter, null);
        }

        public DataSet Get_Currency_OriginRates(string CurrencyID, string SortOrder = "")
        {
            string Table_Name = "NexusShop_Currency_Rate";

            string Filter = "Origin_CurrencyID = " + DataEval.QuoteText(CurrencyID);

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        public DataSet Get_Currency_TargetRates(string CurrencyID, string SortOrder = "")
        {
            string Table_Name = "NexusShop_Currency_Rate";

            string Filter = "Target_CurrencyID = " + DataEval.QuoteText(CurrencyID);

            return Show_Items(Table_Name, null, Filter, SortOrder, -1);
        }

        #endregion

        // 添加 Currency 信息
        #region Add

        public string Add_Currency(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Currencies";

            return Insert_Data_Field_returnID(Table_Name, UpdateData);
        }

        // 添加 Currency Rate 信息
        public void Add_Currency_Rate(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Currency_Rate";

            Insert_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        // 修改 Currency 信息
        #region Edit
        public void Edit_Currency(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Currencies";

            Update_Data_Field_StringID(Table_Name, UpdateData);
        }

        // 修改 Currency Rate 信息
        public void Edit_Currency_Rate(e2Data[] UpdateData)
        {
            string Table_Name = "NexusShop_Currency_Rate";

            Update_Data_Field(Table_Name, UpdateData);
        }

        #endregion

        #endregion

        #endregion
    }
}
