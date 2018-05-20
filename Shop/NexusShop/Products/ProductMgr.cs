using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;

namespace Nexus.Shop.Product
{

    [DataObject(true)]
    public class ProductMgr
    {
        public ProductMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get and Chk

        public Manufacturer Get_Manufacturer(string ManufacturerID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Manufacturer(myDP.Get_Manufacturer(ManufacturerID));
        }

        public List<Manufacturer> Get_Manufacturers(string SortOrder = "Name", string IsActive = "ALL")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Manufacturers(SortOrder, IsActive);

            List<Manufacturer> list = new List<Manufacturer>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Manufacturer(myDR));
            }

            return list;

        }

        public ProductIndex Get_ProductIndex(string Product_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new ProductIndex(myDP.Get_ProductIndex(Product_IndexID));
        }

        public List<ProductIndex> Get_ProductIndexes(string SortOrder = "LastUpdate_Date DESC")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_ProductIndexes(SortOrder);

            List<ProductIndex> list = new List<ProductIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new ProductIndex(myDR));
            }

            return list;

        }

        public List<ProductIndex> Get_ProductIndexes(string Title, string SortOrder = "LastUpdate_Date", string Direction = "ASC")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_ProductIndexes(Title, SortOrder, Direction);

            List<ProductIndex> list = new List<ProductIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new ProductIndex(myDR, true));
            }

            return list;

        }


        public Product Get_Product(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Product(myDP.Get_Product(ProductID));
        }

        public List<Product> Get_Products(string SortOrder = "Product_Title")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Products(SortOrder);

            List<Product> list = new List<Product>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product(myDR));
            }

            return list;

        }

        public List<Product> Get_Products(string Product_IndexID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Products(Product_IndexID, SortOrder);

            List<Product> list = new List<Product>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product(myDR));
            }

            return list;

        }

        public List<ProductTag_Mapping> Get_ProductTag_Mapping(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_ProductTag_Mapping(ProductID);

            List<ProductTag_Mapping> list = new List<ProductTag_Mapping>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new ProductTag_Mapping(myDR));
            }

            return list;

        }

        public Product_Mapping Get_Product_Mapping(string Product_MappingID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Product_Mapping(myDP.Get_Product_Mapping(Product_MappingID));
        }

        public List<Product_Mapping> Get_Product_Mappings(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Mappings(ProductID);

            List<Product_Mapping> list = new List<Product_Mapping>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product_Mapping(myDR));
            }

            return list;

        }

        public List<Product_Mapping> Get_Product_Mappings(string ProductID, bool isView)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Mappings(ProductID, isView);

            List<Product_Mapping> list = new List<Product_Mapping>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product_Mapping(myDR, isView));
            }

            return list;

        }



        public WebPage Get_WebPage(string WebPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new WebPage(myDP.Get_WebPage(WebPageID));
        }

        public List<WebPage> Get_WebPages(string ProductID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_WebPages(ProductID, SortOrder);

            List<WebPage> list = new List<WebPage>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new WebPage(myDR));
            }

            return list;

        }

        public WebMedia Get_WebMedium(string WebMediaID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new WebMedia(myDP.Get_WebMedium(WebMediaID));
        }

        public List<WebMedia> Get_WebMedia(string ProductID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_WebMedia(ProductID, SortOrder);

            List<WebMedia> list = new List<WebMedia>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new WebMedia(myDR));
            }

            return list;

        }

        public bool Chk_Product_Variant_usage(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Product_Variant_usage(Product_VariantID);
        }

        public bool Chk_Manufacturer_usage(string ManufacturerID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Manufacturer_usage(ManufacturerID);
        }

        public int Count_Product_ByProductIndex(string Product_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Product_ByProductIndex(Product_IndexID);

        }

        public bool Chk_Product_Mapping(string ProductID, string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Product_Mapping(ProductID, CategoryID);
        }

        public int Count_Product_Mapping(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Product_Mapping(ProductID);

        }


        #endregion

        #region Add

        public void Add_Manufacturer(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Manufacturer(UpdateData);
        }

        public void Add_ProductIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_ProductIndex(UpdateData);
        }

        public void Add_Product(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product(UpdateData);
        }

        public void Add_ProductTag_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_ProductTag_Mapping(UpdateData);
        }

        public void Add_Product_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Mapping(UpdateData);
        }

        public void Add_WebPage(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_WebPage(UpdateData);
        }

        public void Add_WebMedia(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_WebMedia(UpdateData);
        }



        #endregion

        #region Edit

        public void Edit_Manufacturer(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Manufacturer(UpdateData);
        }

        public void Edit_ProductIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_ProductIndex(UpdateData);
        }

        public void Edit_Product(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product(UpdateData);
        }

        public void Edit_ProductTag_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_ProductTag_Mapping(UpdateData);
        }

        public void Edit_Product_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Mapping(UpdateData);
        }

        public void Edit_WebPage(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_WebPage(UpdateData);
        }

        public void Edit_WebMedia(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_WebMedia(UpdateData);
        }



        #endregion

        #region Remove

        public void Remove_Manufacturer(string ManufacturerID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Manufacturer(ManufacturerID);
        }

        public void Remove_ProductIndex(string Product_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ProductIndex(Product_IndexID);
        }

        public void Remove_Product(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product(ProductID);
        }

        public void Remove_Product_ByIndexID(string Product_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_ByIndexID(Product_IndexID);
        }

        public void Remove_ProducTag_Mapping(string ProductTag_MappingID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ProducTag_Mapping(ProductTag_MappingID);
        }

        public void Remove_ProducTag_Mapping_ByProductID(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_ProducTag_Mapping_ByProductID(ProductID);
        }

        public void Remove_Product_Mapping(string Product_MappingID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Mapping(Product_MappingID);
        }

        public void Remove_Product_Mapping_ByProductID(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Mapping_ByProductID(ProductID);
        }

        public void Remove_WebPage(string WebPageID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_WebPage(WebPageID);
        }

        public void Remove_WebPage_ByProductID(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_WebPage_ByProductID(ProductID);
        }

        public void Remove_WebMedia(string WebMediaID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_WebMedia(WebMediaID);
        }

        public void Remove_WebMedia_ByProductID(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_WebMedia_ByProductID(ProductID);
        }



        #endregion
    }

    [DataObject(true)]
    public class ProductSearchMgr
    {
        public ProductSearchMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Product_Search Get_Product_Search(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Product_Search(myDP.Get_Product_Search(ProductID));
        }

        public List<Product_Search> Get_Product_Search(
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
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Search(
                Search_Field,
                Keyword,
                Product_VariantID,
                CategoryID,
                ManufacturerID,
                IsActive,
                Index_IsActive,
                SortOrder,
                Direction,
                PageNum,
                PageSize);

            List<Product_Search> list = new List<Product_Search>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product_Search(myDR));
            }

            return list;

        }

        public List<Product_Search> Get_Product_Search(
            string Search_Field,
            string Keyword,
            string Product_VariantID,
            string CategoryID,
            string ManufacturerID,
            string IsActive,
            string Index_IsActive,
            string SortOrder,
            string Direction,
            int PageNum,
            int PageSize,
            string Target_Currencyid,
            string ItemDetailURL
            )
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Search(
                Search_Field,
                Keyword,
                Product_VariantID,
                CategoryID,
                ManufacturerID,
                IsActive,
                Index_IsActive,
                SortOrder,
                Direction,
                PageNum,
                PageSize);

            List<Product_Search> list = new List<Product_Search>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product_Search(myDR, Target_Currencyid, ItemDetailURL));
            }

            return list;

        }

    }

}
