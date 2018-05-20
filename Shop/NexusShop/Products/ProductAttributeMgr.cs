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

namespace Nexus.Shop.Product.Attribute
{

    [DataObject(true)]
    public class ProductAttributeMgr
    {

        public ProductAttributeMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get and Chk

        public Attribute_Type Get_Product_Attribute_Type(string Attribute_TypeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Attribute_Type(myDP.Get_Product_Attribute_Type(Attribute_TypeID));
        }

        public List<Attribute_Type> Get_Product_Attribute_Types(string Product_VariantID, string SortOrder = "Attribute_Name")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Attribute_Types(Product_VariantID, SortOrder);

            List<Attribute_Type> list = new List<Attribute_Type>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Attribute_Type(myDR));
            }

            return list;

        }

        public AttributeIndex Get_Product_AttributeIndex(string Attribute_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new AttributeIndex(myDP.Get_Product_AttributeIndex(Attribute_IndexID));
        }

        public List<AttributeIndex> Get_Product_AttributeIndexes(string ProductID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_AttributeIndexes(ProductID, SortOrder);

            List<AttributeIndex> list = new List<AttributeIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new AttributeIndex(myDR));
            }

            return list;

        }

        public List<AttributeIndex> Get_Product_AttributeIndexes(string ProductID, bool isView, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_AttributeIndexes(ProductID, isView, SortOrder);

            List<AttributeIndex> list = new List<AttributeIndex>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new AttributeIndex(myDR, isView));
            }

            return list;

        }


        public Product_Attribute Get_Product_Attribute(string AttributeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Product_Attribute(myDP.Get_Product_Attribute(AttributeID));
        }

        public Product_Attribute Get_Product_Attribute_ByIndexID(string Attribute_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Product_Attribute(myDP.Get_Product_Attribute_ByIndexID(Attribute_IndexID));
        }

        public List<Product_Attribute> Get_Product_Attributes(string Attribute_IndexID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Attributes(Attribute_IndexID, SortOrder);

            List<Product_Attribute> list = new List<Product_Attribute>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Product_Attribute(myDR));
            }

            return list;

        }

        public bool Chk_Attribute_usage(string Attribute_TypeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Attribute_usage(Attribute_TypeID);
        }

        public bool Chk_Attribute_type(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Attribute_type(Product_VariantID);
        }

        #endregion
        
        #region Add

        public void Add_Product_Attribute_Type(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Attribute_Type(UpdateData);
        }

        public void Add_Product_AttributeIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_AttributeIndex(UpdateData);
        }

        public void Add_Product_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Attribute(UpdateData);
        }

        #endregion

        #region Edit

        public void Edit_Product_Attribute_Type(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Attribute_Type(UpdateData);
        }

        public void Edit_Product_AttributeIndex(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_AttributeIndex(UpdateData);
        }

        public void Edit_Product_Attribute(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Attribute(UpdateData);
        }

        #endregion

        #region Remove

        public void Remove_Product_Attribute_Type(string Attribute_TypeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Attribute_Type(Attribute_TypeID);
        }

        public void Remove_Product_Attribute_Type_ByVariantID(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Attribute_Type_ByVariantID(Product_VariantID);
        }

        public void Remove_Product_AttributeIndex(string Attribute_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_AttributeIndex(Attribute_IndexID);
        }

        public void Remove_Product_AttributeIndex_ByProductID(string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_AttributeIndex_ByProductID(ProductID);
        }

        public void Remove_Product_Attribute(string AttributeID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Attribute(AttributeID);
        }

        public void Remove_Product_Attribute_ByIndexID(string Attribute_IndexID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Attribute_ByIndexID(Attribute_IndexID);
        }


        #endregion

    }
}
