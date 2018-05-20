using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Nexus.Core;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop.Product
{
    /// <summary>
    /// NexusShop Product Index
    /// </summary>
    public class ProductIndex
    {

        private string _product_indexid;
        private string _title;
        private string _short_description;
        private string _admin_comment;
        private bool _isactive;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;
        private int _product_count;

        public string Product_IndexID { get { return _product_indexid; } }
        public string Title { get { return _title; } }
        public string Short_Description { get { return _short_description; } }
        public string Admin_Comment { get { return _admin_comment; } }
        public bool IsActive { get { return _isactive; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }
        public int Product_Count { get { return _product_count; } }

        public ProductIndex(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _product_indexid = myDR["Product_IndexID"].ToString();
                _title = myDR["Title"].ToString();
                _short_description = myDR["Short_Description"].ToString();
                _admin_comment = myDR["Admin_Comment"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();

            }

        }

        public ProductIndex(DataRow myDR, bool ChildrenCount)
        {
            if (myDR != null)
            {

                _product_indexid = myDR["Product_IndexID"].ToString();
                _title = myDR["Title"].ToString();
                _short_description = myDR["Short_Description"].ToString();
                _admin_comment = myDR["Admin_Comment"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
                _product_count = Convert.ToInt16(myDR["Product_Count"]);

            }

        }

    }

    /// <summary>
    /// NexusShop Product
    /// </summary>
    public class Product
    {

        private string _productid;
        private string _product_indexid;
        private string _product_title;
        private Title_Type _title_type;
        private string _product_sku;
        private string _manufacturerid;
        private string _manufacturer_sku;
        private string _product_variantid;
        private string _webmediaid;
        private string _currencyid;
        private decimal _rrp_price;
        private int _sortorder;
        private bool _isactive;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;


        public string ProductID { get { return _productid; } }
        public string Product_IndexID { get { return _product_indexid; } }
        public string Product_Title { get { return _product_title; } }
        public Title_Type Title_Type { get { return _title_type; } }
        public string Product_SKU { get { return _product_sku; } }
        public string ManufacturerID { get { return _manufacturerid; } }
        public string Manufacturer_SKU { get { return _manufacturer_sku; } }
        public string Product_VariantID { get { return _product_variantid; } }
        public string WebMediaID { get { return _webmediaid; } }
        public string CurrencyID { get { return _currencyid; } }
        public decimal RRP_Price { get { return _rrp_price; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsActive { get { return _isactive; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public Product(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _productid = myDR["ProductID"].ToString();
                _product_indexid = myDR["Product_IndexID"].ToString();
                _product_title = myDR["Product_Title"].ToString();
                _title_type = (Title_Type)StringEnum.Parse(typeof(Title_Type), myDR["Title_Type"].ToString(), true);
                _product_sku = myDR["Product_SKU"].ToString();
                _manufacturerid = myDR["ManufacturerID"].ToString();
                _manufacturer_sku = myDR["Manufacturer_SKU"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _webmediaid = myDR["WebMediaID"].ToString();
                _currencyid = myDR["CurrencyID"].ToString();
                _rrp_price = Convert.ToDecimal(myDR["RRP_Price"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();

            }

        }

    }

    /// <summary>
    /// NexusShop Product Search
    /// </summary>
    public class Product_Search
    {

        #region Product Variant
        private string _product_variantid;
        private string _variant_name;
        private Variant_Type _variant_type;
        private string _table_name;

        public string Product_VariantID { get { return _product_variantid; } }
        public string Variant_Name { get { return _variant_name; } }
        public Variant_Type Variant_Type { get { return _variant_type; } }
        public string Table_Name { get { return _table_name; } }
        #endregion

        #region Product Index
        private string _product_indexid;
        private string _title;
        private string _short_description;
        private string _admin_comment;
        private bool _isactiveindex;

        public string Product_IndexID { get { return _product_indexid; } }
        public string Title { get { return _title; } }
        public string Short_Description { get { return _short_description; } }
        public string Admin_Comment { get { return _admin_comment; } }
        public bool IsActiveIndex { get { return _isactiveindex; } }
        #endregion

        #region Product
        private string _productid;
        private string _product_title;        
        private Title_Type _title_type;
        private string _product_sku;
        private string _manufacturerid;
        private string _manufacturer_sku;
        private string _webmediaid;
        private string _currencyid;
        private decimal _rrp_price;
        private int _sortorder;
        private bool _isactive;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;
        private string _username;


        public string ProductID { get { return _productid; } }
        public string Product_Title { get { return _product_title; } }
        public Title_Type Title_Type { get { return _title_type; } }
        public string Product_SKU { get { return _product_sku; } }
        public string ManufacturerID { get { return _manufacturerid; } }
        public string Manufacturer_SKU { get { return _manufacturer_sku; } }
        public string WebMediaID { get { return _webmediaid; } }
        public string CurrencyID { get { return _currencyid; } }
        public decimal RRP_Price { get { return _rrp_price; } }
        public int SortOrder { get { return _sortorder; } }
        public bool IsActive { get { return _isactive; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }
        public string UserName { get { return _username; } }

        private string _product_full_title;
        public string Product_Full_Title { get { return _product_full_title; } }


        #endregion

        #region Product Mapping
        private string _product_mappingid;
        private string _categoryid;
        private bool _isfeatured;
        private int _category_sortorder;

        public string Product_MappingID { get { return _product_mappingid; } }
        public string CategoryID { get { return _categoryid; } }
        public bool IsFeatured { get { return _isfeatured; } }
        public int Category_SortOrder { get { return _category_sortorder; } }
        #endregion

        #region Product Manufacturer
        private string _manufacturer_name;
        private string _manufacturer_logo;
        private string _manufacturer_url;
        private bool __manufacturer_isactive;

        public string Manufacturer_Name { get { return _manufacturer_name; } }
        public string Manufacturer_Logo { get { return _manufacturer_logo; } }
        public string Manufacturer_URL { get { return _manufacturer_url; } }
        public bool Manufacturer_IsActive { get { return __manufacturer_isactive; } }
        #endregion

        #region Web Media
        private Media_Type _media_type;
        private string _media_value;
        private string _default_photourl;

        public Media_Type Media_Type { get { return _media_type; } }
        public string Media_Value { get { return _media_value; } }
        public string Default_PhotoURL { get { return _default_photourl; } }
        #endregion

        #region Currency
        private string _currency_name;
        private string _currency_shortname;
        private string _currency_webcode;

        public string Currency_Name { get { return _currency_name; } }
        public string Currency_ShortName { get { return _currency_shortname; } }
        public string Currency_WebCode { get { return _currency_webcode; } }
        #endregion

        #region WebUI
        private string _itemdetailurl;
        private string _target_currencyid;
        private string _target_rrp_price;

        public string ItemDetailURL { get { return _itemdetailurl; } }
        public string Target_CurrencyID { get { return _target_currencyid; } }
        public string Target_RRP_Price { get { return _target_rrp_price; } }

        #endregion

        public Product_Search(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {
                // Product Variant
                _product_variantid = myDR["Product_VariantID"].ToString();
                _variant_name = myDR["Variant_Name"].ToString();
                _variant_type = (Variant_Type)StringEnum.Parse(typeof(Variant_Type), myDR["Variant_Type"].ToString(), true);
                _table_name = myDR["Table_Name"].ToString();

                // Product Index
                _product_indexid = myDR["Product_IndexID"].ToString();
                _title = myDR["Title"].ToString();
                _short_description = myDR["Short_Description"].ToString();
                _admin_comment = myDR["Admin_Comment"].ToString();
                _isactiveindex = Convert.ToBoolean(myDR["IsActiveIndex"]);

                // Product
                _productid = myDR["ProductID"].ToString();
                _product_indexid = myDR["Product_IndexID"].ToString();
                _product_title = myDR["Product_Title"].ToString();
                _title_type = (Title_Type)StringEnum.Parse(typeof(Title_Type), myDR["Title_Type"].ToString(), true);
                _product_sku = myDR["Product_SKU"].ToString();
                _manufacturerid = myDR["ManufacturerID"].ToString();
                _manufacturer_sku = myDR["Manufacturer_SKU"].ToString();
                _webmediaid = myDR["WebMediaID"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _currencyid = myDR["CurrencyID"].ToString();
                _rrp_price = Convert.ToDecimal(myDR["RRP_Price"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
                _username = myDR["UserName"].ToString();

                switch (_title_type)
                {
                    case Title_Type.Prefix:
                        _product_full_title = string.Format("{0} {1}", _product_title, _title);
                        break;
                    case Title_Type.Suffix:
                        _product_full_title = string.Format("{0} {1}", _title, _product_title);
                        break;
                    case Title_Type.Override:
                        _product_full_title = _product_title;
                        break;
                    default:
                        _product_full_title = _product_title;
                        break;
                }

                // Product Mapping
                _product_mappingid = myDR["Product_MappingID"].ToString();
                _categoryid = myDR["Product_Title"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);
                _category_sortorder = Convert.ToInt16(myDR["Category_SortOrder"]);

                // Manufacturer
                _manufacturer_name = myDR["Manufacturer_Name"].ToString();
                _manufacturer_logo = myDR["Manufacturer_Logo"].ToString();
                _manufacturer_url = myDR["Manufacturer_URL"].ToString();
                __manufacturer_isactive = Convert.ToBoolean(myDR["Manufacturer_IsActive"]);

                // Web Media
                try
                {
                    _media_type = (Media_Type)StringEnum.Parse(typeof(Media_Type), myDR["Media_Type"].ToString(), true);
                }
                catch
                {
                    _media_type = Media_Type.Picture;
                }

                _media_value = myDR["Media_Value"].ToString();

                switch (_media_type)
                {
                    case Media_Type.Picture:
                        if (DataEval.IsEmptyQuery(_media_value))
                        {
                            _default_photourl = "/App_Control_Style/Nexus_Shop/Images/NoImg.png";
                        }
                        else
                        {
                            _default_photourl = _media_value;
                        }
                        break;
                    case Media_Type.Flash:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;
                    case Media_Type.Youtube:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;

                }

                // Currency
                _currencyid = myDR["CurrencyID"].ToString();
                _currency_name = myDR["Currency_Name"].ToString();
                _currency_shortname = myDR["Currency_ShortName"].ToString();
                _currency_webcode = myDR["Currency_WebCode"].ToString();

            }

        }

        public Product_Search(DataRow myDR, string target_currencyid, string itemdetailurl)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {
                // Product Variant
                _product_variantid = myDR["Product_VariantID"].ToString();
                _variant_name = myDR["Variant_Name"].ToString();
                _variant_type = (Variant_Type)StringEnum.Parse(typeof(Variant_Type), myDR["Variant_Type"].ToString(), true);
                _table_name = myDR["Table_Name"].ToString();

                // Product Index
                _product_indexid = myDR["Product_IndexID"].ToString();
                _title = myDR["Title"].ToString();
                _short_description = myDR["Short_Description"].ToString();
                _admin_comment = myDR["Admin_Comment"].ToString();
                _isactiveindex = Convert.ToBoolean(myDR["IsActiveIndex"]);

                // Product
                _productid = myDR["ProductID"].ToString();
                _product_indexid = myDR["Product_IndexID"].ToString();
                _product_title = myDR["Product_Title"].ToString();
                _title_type = (Title_Type)StringEnum.Parse(typeof(Title_Type), myDR["Title_Type"].ToString(), true);
                _product_sku = myDR["Product_SKU"].ToString();
                _manufacturerid = myDR["ManufacturerID"].ToString();
                _manufacturer_sku = myDR["Manufacturer_SKU"].ToString();
                _webmediaid = myDR["WebMediaID"].ToString();
                _product_variantid = myDR["Product_VariantID"].ToString();
                _currencyid = myDR["CurrencyID"].ToString();
                _rrp_price = Convert.ToDecimal(myDR["RRP_Price"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
                _username = myDR["UserName"].ToString();

                switch (_title_type)
                {
                    case Title_Type.Prefix:
                        _product_full_title = string.Format("{0} {1}", _product_title, _title);
                        break;
                    case Title_Type.Suffix:
                        _product_full_title = string.Format("{0} {1}", _title, _product_title);
                        break;
                    case Title_Type.Override:
                        _product_full_title = _product_title;
                        break;
                    default:
                        _product_full_title = _product_title;
                        break;
                }

                // Product Mapping
                _product_mappingid = myDR["Product_MappingID"].ToString();
                _categoryid = myDR["Product_Title"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);
                _category_sortorder = Convert.ToInt16(myDR["Category_SortOrder"]);

                // Manufacturer
                _manufacturer_name = myDR["Manufacturer_Name"].ToString();
                _manufacturer_logo = myDR["Manufacturer_Logo"].ToString();
                _manufacturer_url = myDR["Manufacturer_URL"].ToString();
                __manufacturer_isactive = Convert.ToBoolean(myDR["Manufacturer_IsActive"]);

                // Web Media
                try
                {
                    _media_type = (Media_Type)StringEnum.Parse(typeof(Media_Type), myDR["Media_Type"].ToString(), true);
                }
                catch
                {
                    _media_type = Media_Type.Picture;
                }

                _media_value = myDR["Media_Value"].ToString();

                switch (_media_type)
                {
                    case Media_Type.Picture:
                        if (DataEval.IsEmptyQuery(_media_value))
                        {
                            _default_photourl = "/App_Control_Style/Nexus_Shop/Images/NoImg.png";
                        }
                        else
                        {
                            _default_photourl = _media_value;
                        }
                        break;
                    case Media_Type.Flash:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;
                    case Media_Type.Youtube:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;

                }

                // Currency
                _currencyid = myDR["CurrencyID"].ToString();
                _currency_name = myDR["Currency_Name"].ToString();
                _currency_shortname = myDR["Currency_ShortName"].ToString();
                _currency_webcode = myDR["Currency_WebCode"].ToString();

                // Web UI
                _itemdetailurl = itemdetailurl;
                _target_currencyid = target_currencyid;

                if (_currencyid == target_currencyid)
                {
                    _target_rrp_price = string.Format("{0}{1:#,##0}", _currency_webcode, _rrp_price);
                } else
                {
                    Misc.CurrencyMgr myCurrencyMgr = new Misc.CurrencyMgr();
                    Misc.Currency myTarget_Currency = myCurrencyMgr.Get_Currency(_target_currencyid);

                    _target_rrp_price = string.Format("{0}{1:#,##0}", myTarget_Currency.Currency_WebCode, myCurrencyMgr.Currency_Converter(
                        Convert.ToDecimal(_rrp_price),
                        _currencyid,
                        _target_currencyid));
                }
            }

        }

    }
    

    /// <summary>
    /// NexusShop Manufacturer
    /// </summary>
    public class Manufacturer
    {

        private string _manufacturerid;
        private string _name;
        private string _logo;
        private string _url;
        private bool _isactive;

        public string ManufacturerID { get { return _manufacturerid; } }
        public string Name { get { return _name; } }
        public string Logo { get { return _logo; } }
        public string URL { get { return _url; } }
        public bool IsActive { get { return _isactive; } }

        public Manufacturer(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _manufacturerid = myDR["ManufacturerID"].ToString();
                _name = myDR["Name"].ToString();
                _logo = myDR["Logo"].ToString();
                _url = myDR["URL"].ToString();
                _isactive = Convert.ToBoolean(myDR["IsActive"]);

            }

        }

    }

    /// <summary>
    /// NexusShop Product Mapping
    /// </summary>
    public class Product_Mapping
    {

        private string _product_mappingid;
        private string _productid;
        private string _categoryid;
        private bool _isfeatured;
        private int _sortorder;

        public string Product_MappingID { get { return _product_mappingid; } }
        public string ProductID { get { return _productid; } }
        public string CategoryID { get { return _categoryid; } }
        public bool IsFeatured { get { return _isfeatured; } }
        public int SortOrder { get { return _sortorder; } }

        // Category
        private string _parent_categoryid;
        private string _category_name;

        public string Parent_CategoryID { get { return _parent_categoryid; } }
        public string Category_Name { get { return _category_name; } }

        public Product_Mapping(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _product_mappingid = myDR["Product_MappingID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);

            }

        }

        public Product_Mapping(DataRow myDR, bool isView)
        {

            if (myDR != null)
            {

                _product_mappingid = myDR["Product_MappingID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);

                _parent_categoryid = myDR["Parent_CategoryID"].ToString();
                _category_name = myDR["Category_Name"].ToString();

            }

        }

    }

    /// <summary>
    /// NexusShop ProductTag Mapping
    /// </summary>
    public class ProductTag_Mapping
    {

        private string _producttag_mappingid;
        private string _productid;
        private string _pagetagid;
        private bool _isfeatured;

        public string ProductTag_MappingID { get { return _producttag_mappingid; } }
        public string ProductID { get { return _productid; } }
        public string PageTagID { get { return _pagetagid; } }
        public bool IsFeatured { get { return _isfeatured; } }

        public ProductTag_Mapping(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _producttag_mappingid = myDR["Product_MappingID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _pagetagid = myDR["PageTagID"].ToString();
                _isfeatured = Convert.ToBoolean(myDR["IsFeatured"]);

            }

        }

    }

    /// <summary>
    /// NexusShop Product WebPage
    /// </summary>
    public class WebPage
    {

        private string _webpageid;
        private string _productid;
        private string _meta_title;
        private string _meta_keywords;
        private string _meta_description;
        private string _page_title;
        private string _overview;
        private string _description;
        private int _sortorder;

        public string WebPageID { get { return _webpageid; } }
        public string ProductID { get { return _productid; } }
        public string Meta_Title { get { return _meta_title; } }
        public string Meta_Keywords { get { return _meta_keywords; } }
        public string Meta_Description { get { return _meta_description; } }
        public string Page_Title { get { return _page_title; } }
        public string Overview { get { return _overview; } }
        public string Description { get { return _description; } }
        public int SortOrder { get { return _sortorder; } }

        public WebPage(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _webpageid = myDR["WebPageID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _meta_title = myDR["Meta_Title"].ToString();
                _meta_keywords = myDR["Meta_Keywords"].ToString();
                _meta_description = myDR["Meta_Description"].ToString();
                _page_title = myDR["Page_Title"].ToString();
                _overview = myDR["Overview"].ToString();
                _description = myDR["Description"].ToString();
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);

            }

        }

    }

    /// <summary>
    /// NexusShop Product WebMedia
    /// </summary>
    public class WebMedia
    {

        private string _webmediaid;
        private string _productid;
        private Media_Type _media_type;
        private string _media_title;
        private string _media_value;
        private string _media_description;
        private int _sortorder;

        public string WebMediaID { get { return _webmediaid; } }
        public string ProductID { get { return _productid; } }
        public Media_Type Media_Type { get { return _media_type; } }
        public string Media_Title { get { return _media_title; } }
        public string Media_Value { get { return _media_value; } }
        public string Media_Description { get { return _media_description; } }
        public int SortOrder { get { return _sortorder; } }

        private string _default_photourl;
        public string Default_PhotoURL { get { return _default_photourl; } }

        public WebMedia(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {

                _webmediaid = myDR["WebMediaID"].ToString();
                _productid = myDR["ProductID"].ToString();
                _media_type = (Media_Type)StringEnum.Parse(typeof(Media_Type), myDR["Media_Type"].ToString(), true);
                _media_title = myDR["Media_Title"].ToString();
                _media_value = myDR["Media_Value"].ToString();
                _media_description = myDR["Media_Description"].ToString();
                _sortorder = Convert.ToInt16(myDR["SortOrder"]);

                switch (_media_type)
                {
                    case Media_Type.Picture:
                        if (DataEval.IsEmptyQuery(_media_value))
                        {
                            _default_photourl = "/App_Control_Style/Nexus_Shop/Images/NoImg.png";
                        }
                        else
                        {
                            _default_photourl = _media_value;
                        }
                        break;
                    case Media_Type.Flash:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;
                    case Media_Type.Youtube:
                        _default_photourl = "/App_Control_Style/Nexus_Shop/Images/Movie.png";
                        break;

                }
            }

        }

    }

}
