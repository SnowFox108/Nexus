using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Nexus.Core;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop.Product.Attribute
{
    /// <summary>
    /// NexusShop Product Attribute Types
    /// </summary>
    public class Attribute_Type
    {

        private string _attribute_typeid;
        private string _product_variantid;
        private string _attribute_name;
        private string _description;
        private bool _isactive;

        public string Attribute_TypeID { get { return _attribute_typeid; } }
        public string Product_VariantID { get { return _product_variantid; } }
        public string Attribute_Name { get { return _attribute_name; } }
        public string Description { get { return _description; } }
        public bool IsActive { get { return _isactive; } }

        public Attribute_Type(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _attribute_typeid = myDR["Attribute_TypeID"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _attribute_name = myDR["Attribute_Name"].ToString();
                _description = myDR["Description"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }
    }

    /// <summary>
    /// NexusShop Product Attribute Index
    /// </summary>
    public class AttributeIndex
    {

        private string _attribute_indexid;
        private string _productid;
        private string _attribute_typeid;
        private string _display_text;
        private bool _isrequired;
        private Input_Option _input_option;
        private int _sortorder;
        private bool _isactive;

        public string Attribute_IndexID { get { return _attribute_indexid; } }
        public string ProductID { get { return _productid; } }
        public string Attribute_TypeID { get { return _attribute_typeid; } }
        public string Display_Text { get { return _display_text; } }
        public bool IsRequired { get { return _isrequired; } }
        public Input_Option Input_Option { get { return _input_option; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsActive { get { return _isactive; } }

        private string _attribute_name;
        private string _input_optionname;
        public string Attribute_Name { get { return _attribute_name; } }
        public string Input_OptionName { get { return _input_optionname; } }

        public AttributeIndex(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _attribute_indexid = myDR["Attribute_IndexID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _attribute_typeid = myDR["Attribute_TypeID"].ToString();
                _display_text = myDR["Display_Text"].ToString();
                _isrequired = Convert.ToBoolean(myDR["IsRequired"]);
                _input_option = (Input_Option)StringEnum.Parse(typeof(Input_Option), myDR["Input_OptionID"].ToString(), true);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }

        public AttributeIndex(DataRow myDR, bool isView)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _attribute_indexid = myDR["Attribute_IndexID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _attribute_typeid = myDR["Attribute_TypeID"].ToString();
                _display_text = myDR["Display_Text"].ToString();
                _isrequired = Convert.ToBoolean(myDR["IsRequired"]);
                _input_option = (Input_Option)StringEnum.Parse(typeof(Input_Option), myDR["Input_OptionID"].ToString(), true);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

                _attribute_name = myDR["Attribute_Name"].ToString();
                _input_optionname = _input_option.ToString();

            }

        }

    }

    /// <summary>
    /// NexusShop Product Attribute
    /// </summary>
    public class Product_Attribute
    {

        private string _attributeid;
        private string _attribute_indexid;
        private string _attribute_name;
        private bool _ispreselected;
        private decimal _price_adjustment;
        private decimal _weight_adjustment;
        private int _sortorder;
        private bool _isactive;

        public string AttributeID { get { return _attributeid; } }
        public string Attribute_IndexID { get { return _attribute_indexid; } }
        public string Attribute_Name { get { return _attribute_name; } }
        public bool IsPreSelected { get { return _ispreselected; } }
        public decimal Price_Adjustment { get { return _price_adjustment; } }
        public decimal Weight_Adjustment { get { return _weight_adjustment; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsActive { get { return _isactive; } }

        public Product_Attribute(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _attributeid = myDR["AttributeID"].ToString();
                _attribute_indexid = myDR["Attribute_IndexID"].ToString();
                _attribute_name = myDR["Attribute_Name"].ToString();
                _ispreselected = Convert.ToBoolean(myDR["IsPreSelected"]);
                _price_adjustment = Convert.ToDecimal(myDR["Price_Adjustment"]);
                _weight_adjustment = Convert.ToDecimal(myDR["Weight_Adjustment"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }

    }

}
