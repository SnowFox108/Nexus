using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Nexus.Core;

namespace Nexus.Shop.Product.Variant
{
    /// <summary>
    /// NexusShop Product Variant
    /// </summary>
    public class Variant
    {

        private string _product_variantid;
        private string _variant_name;
        private Variant_Type _variant_type;
        private string _table_name;

        public string Product_VariantID { get { return _product_variantid; } }
        public string Variant_Name { get { return _variant_name; } }
        public Variant_Type Variant_Type { get { return _variant_type; } }
        public string Table_Name { get { return _table_name; } }

        public Variant(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _product_variantid = myDR["Product_VariantID"].ToString();
                _variant_name = myDR["Variant_Name"].ToString();
                _variant_type = (Variant_Type)StringEnum.Parse(typeof(Variant_Type), myDR["Variant_Type"].ToString(), true);
                _table_name = myDR["Table_Name"].ToString();


            }

        }

    }

    /// <summary>
    /// NexusShop Product Variant Spliter
    /// </summary>
    public class Variant_Spliter
    {

        private string _variant_spliterid;
        private string _product_variantid;
        private string _spliter_name;
        private int _sortorder;

        public string Variant_SpliterID { get { return _variant_spliterid; } }
        public string Product_VariantID { get { return _product_variantid; } }
        public string Spliter_Name { get { return _spliter_name; } }
        public int SortOrder { get { return _sortorder; } }

        public Variant_Spliter(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _variant_spliterid = myDR["Variant_SpliterID"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _spliter_name = myDR["Spliter_Name"].ToString();
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);


            }

        }

    }

    /// <summary>
    /// NexusShop Product Variant Property
    /// </summary>
    public class Variant_Property
    {

        private string _variant_propertyid;
        private string _product_variantid;
        private string _variant_spliterid;
        private string _property_name;
        private Input_Option _input_option;
        private string _default_value;
        private string _tooltips;
        private bool _isrequired;
        private bool _isfilter;
        private bool _issort;
        private int _sortorder;
        private string _field_name;

        public string Variant_PropertyID { get { return _variant_propertyid; } }
        public string Product_VariantID { get { return _product_variantid; } }
        public string Variant_SpliterID { get { return _variant_spliterid; } }
        public string Property_Name { get { return _property_name; } }
        public Input_Option Input_Option { get { return _input_option; } }
        public string Default_Value { get { return _default_value; } }
        public string Tooltips { get { return _tooltips; } }
        public bool IsRequired { get { return _isrequired; } }
        public bool IsFilter { get { return _isfilter; } }
        public bool IsSort { get { return _issort; } }
        public int SortOrder { get { return _sortorder; } }
        public string Field_Name { get { return _field_name; } }

        public Variant_Property(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _variant_propertyid = myDR["Variant_PropertyID"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _variant_spliterid = myDR["Variant_SpliterID"].ToString();
                _property_name = myDR["Property_Name"].ToString();
                _input_option = (Input_Option)StringEnum.Parse(typeof(Input_Option), myDR["Input_Option"].ToString(), true);
                _default_value = myDR["Default_Value"].ToString();
                _tooltips = myDR["Tooltips"].ToString();
                _isrequired = Convert.ToBoolean(myDR["IsRequired"]);
                _isfilter = Convert.ToBoolean(myDR["IsFilter"]);
                _issort = Convert.ToBoolean(myDR["IsSort"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _field_name = myDR["Field_Name"].ToString();

            }

        }

    }

    /// <summary>
    /// NexusShop Product Variant Property Option
    /// </summary>
    public class Property_Option
    {

        private string _optionid;
        private string _variant_propertyid;
        private string _option_name;
        private string _option_value;
        private int _sortorder;
        private bool _isactive;

        public string OptionID { get { return _optionid; } }
        public string Variant_PropertyID { get { return _variant_propertyid; } }
        public string Option_Name { get { return _option_name; } }
        public string Option_Value { get { return _option_value; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsActive { get { return _isactive; } }

        public Property_Option(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _optionid = myDR["OptionID"].ToString();
                _variant_propertyid = myDR["Variant_PropertyID"].ToString();
                _option_name = myDR["Option_Name"].ToString();
                _option_value = myDR["Option_Value"].ToString();
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }

    }

    //public class Input_Option
    //{

    //    private string _input_optionid;
    //    private string _option_name;
    //    private int _sortorder;

    //    public string Input_OptionID { get { return _input_optionid; } }
    //    public string Option_Name { get { return _option_name; } }
    //    public int SortOrder { get { return _sortorder; } }

    //    public Input_Option(DataRow myDR)
    //    {
    //        //
    //        //TODO: 在此处添加构造函数逻辑
    //        //

    //        if (myDR != null)
    //        {

    //            _input_optionid = myDR["Input_OptionID"].ToString();
    //            _option_name = myDR["Option_Name"].ToString();
    //            _sortorder = Convert.ToInt16(myDR["SortOrder"]);

    //        }

    //    }

    //}


}
