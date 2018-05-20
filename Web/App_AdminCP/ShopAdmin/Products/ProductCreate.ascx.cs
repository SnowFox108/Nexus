using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Shop.Product;
using Nexus.Shop.Product.Variant;
using Nexus.Shop.Misc;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Products_ProductCreate : System.Web.UI.UserControl
    {

        #region properties

        private string _categoryid;
        private string _product_indexid;
        private string _edit_mode;
        private string _product_variantid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                if (_categoryid == null)
                {
                    return "";
                }
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Product_IndexID
        {
            get
            {
                if (_product_indexid == null)
                {
                    return "";
                }
                return _product_indexid;
            }
            set
            {
                _product_indexid = value;
                ViewState["Product_IndexID"] = _product_indexid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Edit_Mode
        {
            get
            {
                if (_edit_mode == null)
                {
                    return "";
                }
                return _edit_mode;
            }
            set
            {
                _edit_mode = value;
                ViewState["Edit_Mode"] = _edit_mode;
            }
        }

        #endregion

        #region Events

        // Move and Copy Click Event
        private static readonly object EventCategoryRefreshed = new object();

        [Category("Action")]
        [Description("Raised Category Menu Refresh event")]
        public event EventHandler CategoryRefreshed
        {
            add
            {
                Events.AddHandler(EventCategoryRefreshed, value);
            }
            remove
            {
                Events.RemoveHandler(EventCategoryRefreshed, value);
            }
        }

        protected void OnCategoryRefreshed(object sender, EventArgs e)
        {
            EventHandler CategoryRefreshedHandler = (EventHandler)Events[EventCategoryRefreshed];

            if (CategoryRefreshedHandler != null)
                CategoryRefreshedHandler(sender, e);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _categoryid = ViewState["CategoryID"].ToString();
                    _edit_mode = ViewState["Edit_Mode"].ToString();
                }
                catch
                {
                    // Do nothing
                }

                try
                {
                    _product_indexid = ViewState["Product_IndexID"].ToString();
                }
                catch
                {
                    // Do nothing
                }

                try
                {
                    _product_variantid = ViewState["Product_VariantID"].ToString();
                }
                catch
                {
                    // Do nothing
                }

                Product_Control_Init(true);

            }
            else
            {

                Control_Init();

            }

        }

        private void Control_FillData()
        {
            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
            ProductMgr myProductMgr = new ProductMgr();
            CurrencyMgr myCurrencyMgr = new CurrencyMgr();

            // Step 1 Product Variant
            droplist_Product_VariantID.DataSource = myProductVariantMgr.Get_Product_Variants();
            droplist_Product_VariantID.DataTextField = "Variant_Name";
            droplist_Product_VariantID.DataValueField = "Product_VariantID";
            droplist_Product_VariantID.DataBind();
            droplist_Product_VariantID.SelectedIndex = 0;

            tbx_Filter_ProductIndex_Title.Text = "";
            droplist_Filter_OrderBy.SelectedIndex = 0;
            droplist_Filter_Direction.SelectedIndex = 0;

            lbl_Selected_Product_Index.Text = "Unselected";

            // Step 2 Product Index
            tbx_Index_Title.Text = "";
            tbx_Index_Short_Description.Text = "";
            tbx_Index_Admin_Comment.Text = "";
            chkbox_Index_IsActive.Checked = true;

            // Step 3 Product
            lbl_Product_Index.Text = "";

            #region Product Title Format

            //Gets your enum names and adds it to a string array
            Array enumTitleNames = Enum.GetValues(typeof(Title_Type));

            //Creates an ArrayList
            ArrayList myTitleFormats = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Title_Type myTitle_Type in enumTitleNames)
            {
                myTitleFormats.Add(new
                {
                    Value = myTitle_Type.ToString(),
                    Name = StringEnum.GetStringValue(myTitle_Type)
                });
            }

            //Bind the ArrayList to your DropDownList             
            rbtn_Product_Title_Type.DataSource = myTitleFormats;
            rbtn_Product_Title_Type.DataTextField = "Name";
            rbtn_Product_Title_Type.DataValueField = "Value";
            rbtn_Product_Title_Type.DataBind();

            // Set Default value
            rbtn_Product_Title_Type.SelectedValue = Title_Type.Override.ToString();

            #endregion

            tbx_Product_Title.Text = "";
            tbx_Product_SKU.Text = "";

            droplist_Product_ManufacturerID.DataSource = myProductMgr.Get_Manufacturers("Name", true.ToString());
            droplist_Product_ManufacturerID.DataTextField = "Name";
            droplist_Product_ManufacturerID.DataValueField = "ManufacturerID";
            droplist_Product_ManufacturerID.DataBind();
            droplist_Product_ManufacturerID.SelectedIndex = 0;

            tbx_Product_Manufacturer_SKU.Text = "";

            droplist_Product_CurrencyID.DataSource = myCurrencyMgr.Get_Currencies("Currency_Name", true.ToString());
            droplist_Product_CurrencyID.DataTextField = "Currency_ShortName";
            droplist_Product_CurrencyID.DataValueField = "CurrencyID";
            droplist_Product_CurrencyID.DataBind();
            droplist_Product_CurrencyID.SelectedIndex = 0;

            RadNumericTextBox_Product_RRP.Text = "0.00";
            chkbox_Product_IsActive.Checked = true;
        }

        private void Control_Init()
        {

            switch (_edit_mode)
            {
                case "CreateNew":
                    Control_FillData();
                    ItemList_DataBind();
                    MultiView_CreateProduct.SetActiveView(View_Variant_Select);
                    break;
                case "AddtoExist":
                    if (!DataEval.IsEmptyQuery(_product_indexid))
                    {
                        Control_FillData();
                        ItemList_DataBind();

                        ProductMgr myProductMgr = new ProductMgr();
                        ProductIndex myProductIndex = myProductMgr.Get_ProductIndex(_product_indexid);

                        rbtn_Product_Index_Method.SelectedValue = "AddtoExist";
                        lbl_Selected_Product_Index.Text = myProductIndex.Title;
                        lbl_Product_Index.Text = myProductIndex.Title;

                        Product_Control_Init();

                        MultiView_CreateProduct.SetActiveView(View_Product_Create);
                    }
                    else
                    {
                        Control_FillData();
                        ItemList_DataBind();
                        MultiView_CreateProduct.SetActiveView(View_Variant_Select);
                    }
                    break;
                default:
                    Control_FillData();
                    ItemList_DataBind();
                    MultiView_CreateProduct.SetActiveView(View_Variant_Select);
                    break;
            }

        }

        public void Reset()
        {
            _product_indexid = "-1";

            Control_Init();
        }

        private void ItemList_DataBind()
        {

            ProductMgr myProductMgr = new ProductMgr();

            ListView_ProductIndex_List.DataSource = myProductMgr.Get_ProductIndexes(tbx_Filter_ProductIndex_Title.Text, droplist_Filter_OrderBy.SelectedValue, droplist_Filter_Direction.SelectedValue);
            ListView_ProductIndex_List.DataBind();
        }

        private void Product_Control_Init(bool IsPagePostBack = false)
        {
            if (!DataEval.IsEmptyQuery(_product_variantid))
            {

                if (!IsPagePostBack)
                    PlaceHolder_Product_Spec.Controls.Clear();

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
                myProductVariantMgr.Product_Form_Generator(
                    PlaceHolder_Product_Spec,
                    droplist_Product_VariantID.SelectedValue,
                    Product_FormMode.Create,
                    IsPagePostBack
                    );
            }
        }

        #region Step1 Product Variant

        protected void btn_Search_ProductIndex_Title_Click(object sender, EventArgs e)
        {
            ItemList_DataBind();
        }

        protected void btn_Search_Filter_Click(object sender, EventArgs e)
        {
            ItemList_DataBind();
        }

        protected void lbtn_Select_ProductIndex_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                _product_indexid = e.CommandArgument.ToString();
                ViewState["Product_IndexID"] = _product_indexid;

                ProductMgr myProductMgr = new ProductMgr();
                ProductIndex myProductIndex = myProductMgr.Get_ProductIndex(_product_indexid);

                lbl_Selected_Product_Index.Text = myProductIndex.Title;
                lbl_Product_Index.Text = myProductIndex.Title;
            }
        }


        protected void btn_Step1_to_Step2_Click(object sender, EventArgs e)
        {
            if (rbtn_Product_Index_Method.SelectedValue == "CreateNew")
            {
                // Add new product index
                if (droplist_Product_VariantID.SelectedValue != _product_variantid)
                {
                    _product_variantid = droplist_Product_VariantID.SelectedValue;
                    ViewState["Product_VariantID"] = _product_variantid;

                    Product_Control_Init();
                }

                MultiView_CreateProduct.SetActiveView(View_ProductIndex_Create);

            }
            else
            {

                // Add product to existed product index
                if (!DataEval.IsNegativeQuery(_product_indexid))
                {

                    if (droplist_Product_VariantID.SelectedValue != _product_variantid)
                    {
                        _product_variantid = droplist_Product_VariantID.SelectedValue;
                        ViewState["Product_VariantID"] = _product_variantid;

                        Product_Control_Init();
                    }

                    MultiView_CreateProduct.SetActiveView(View_Product_Create);
                }
                else
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Please select a product index to continue. </h4>", "Action failed!", 450, 150);
                }
            }

        }

        #endregion

        #region Step2 Product Index

        protected void btn_Step2_back_Step1_Click(object sender, EventArgs e)
        {
            MultiView_CreateProduct.SetActiveView(View_Variant_Select);

        }
        protected void btn_Step2_to_Step3_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (rbtn_Product_Index_Method.SelectedValue == "CreateNew")
                {
                    lbl_Product_Index.Text = tbx_Index_Title.Text;
                }

                MultiView_CreateProduct.SetActiveView(View_Product_Create);
            }
        }

        #endregion

        #region Step3 Product Detail

        protected void btn_Step3_back_Step2_Click(object sender, EventArgs e)
        {
            if (rbtn_Product_Index_Method.SelectedValue == "CreateNew")
            {
                // Back to Step2 if CreateNew
                MultiView_CreateProduct.SetActiveView(View_ProductIndex_Create);
            }
            else
            {
                // Back to Step1 if AddtoExist
                MultiView_CreateProduct.SetActiveView(View_Variant_Select);
            }
        }

        protected void btn_Finish_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                ProductMgr myProductMgr = new ProductMgr();

                if (rbtn_Product_Index_Method.SelectedValue == "CreateNew")
                {
                    #region Create New Product Index and Product

                    // Get update time and user
                    string nowTime = DateTime.Now.ToString();
                    string UserID = Security.Users.UserStatus.Current_UserID(this.Page);

                    // Product Index
                    string Product_IndexID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                    e2Data[] UpdateData_Index = {
                                          new e2Data("Product_IndexID", Product_IndexID),
                                          new e2Data("Title", tbx_Index_Title.Text),
                                          new e2Data("Short_Description", tbx_Index_Short_Description.Text),
                                          new e2Data("Admin_Comment", tbx_Index_Admin_Comment.Text),
                                          new e2Data("IsActive", chkbox_Index_IsActive.Checked.ToString()),
                                          new e2Data("Create_Date", nowTime),
                                          new e2Data("LastUpdate_Date", nowTime),
                                          new e2Data("LastUpdate_UserID", UserID)
                                      };

                    myProductMgr.Add_ProductIndex(UpdateData_Index);

                    // Product Basic Infomation
                    string ProductID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                    e2Data[] UpdateData_Product = {
                                          new e2Data("ProductID", ProductID),
                                          new e2Data("Product_IndexID", Product_IndexID),
                                          new e2Data("Product_Title", tbx_Product_Title.Text),
                                          new e2Data("Title_Type", rbtn_Product_Title_Type.SelectedValue),
                                          new e2Data("Product_SKU", tbx_Product_SKU.Text),
                                          new e2Data("ManufacturerID", droplist_Product_ManufacturerID.SelectedValue),
                                          new e2Data("Manufacturer_SKU", tbx_Product_Manufacturer_SKU.Text),
                                          new e2Data("Product_VariantID", droplist_Product_VariantID.SelectedValue),
                                          new e2Data("CurrencyID", droplist_Product_CurrencyID.SelectedValue),
                                          new e2Data("RRP_Price", RadNumericTextBox_Product_RRP.Text),
                                          new e2Data("SortOrder", (myProductMgr.Count_Product_ByProductIndex(Product_IndexID) + 1).ToString()),
                                          new e2Data("IsActive", chkbox_Product_IsActive.Checked.ToString()),
                                          new e2Data("Create_Date", nowTime),
                                          new e2Data("LastUpdate_Date", nowTime),
                                          new e2Data("LastUpdate_UserID", UserID)
                                      };
                    myProductMgr.Add_Product(UpdateData_Product);

                    // Product Specification
                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
                    myProductVariantMgr.Add_Product_Properties(PlaceHolder_Product_Spec, droplist_Product_VariantID.SelectedValue, ProductID);

                    // Add to Product Mapping
                    e2Data[] UpdateData_Mapping = {
                                          new e2Data("ProductID", ProductID),
                                          new e2Data("CategoryID", _categoryid),
                                          new e2Data("IsFeatured", false.ToString()),
                                          new e2Data("SortOrder", "1")
                                      };

                    myProductMgr.Add_Product_Mapping(UpdateData_Mapping);

                    // Add Item to Category
                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Add_ComponentInCategory_Item(
                        _categoryid,
                        "B131F545-F494-447E-8B55-9F24AFADC417");



                    // Add Item Web Content
                    string WebPageID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                    e2Data[] UpdateData_Webpage = {
                                          new e2Data("WebPageID", WebPageID),
                                          new e2Data("ProductID", ProductID),
                                          new e2Data("Meta_Title", tbx_Product_Title.Text),
                                          new e2Data("Page_Title", tbx_Product_Title.Text),
                                          new e2Data("SortOrder", "1")
                                      };

                    myProductMgr.Add_WebPage(UpdateData_Webpage);


                    // Finish all update
                    MultiView_CreateProduct.SetActiveView(View_Product_Complete);

                    #endregion

                }
                else if (rbtn_Product_Index_Method.SelectedValue == "AddtoExist")
                {
                    #region Create Product to existed Product Index

                    // Get update time and user
                    string nowTime = DateTime.Now.ToString();
                    string UserID = Security.Users.UserStatus.Current_UserID(this.Page);

                    // Product Basic Infomation
                    string ProductID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                    e2Data[] UpdateData_Product = {
                                          new e2Data("ProductID", ProductID),
                                          new e2Data("Product_IndexID", _product_indexid),
                                          new e2Data("Product_Title", tbx_Product_Title.Text),
                                          new e2Data("Title_Type", rbtn_Product_Title_Type.SelectedValue),
                                          new e2Data("Product_SKU", tbx_Product_SKU.Text),
                                          new e2Data("ManufacturerID", droplist_Product_ManufacturerID.SelectedValue),
                                          new e2Data("Manufacturer_SKU", tbx_Product_Manufacturer_SKU.Text),
                                          new e2Data("Product_VariantID", droplist_Product_VariantID.SelectedValue),
                                          new e2Data("CurrencyID", droplist_Product_CurrencyID.SelectedValue),
                                          new e2Data("RRP_Price", RadNumericTextBox_Product_RRP.Text),
                                          new e2Data("SortOrder", (myProductMgr.Count_Product_ByProductIndex(Product_IndexID) + 1).ToString()),
                                          new e2Data("IsActive", chkbox_Product_IsActive.Checked.ToString()),
                                          new e2Data("Create_Date", nowTime),
                                          new e2Data("LastUpdate_Date", nowTime),
                                          new e2Data("LastUpdate_UserID", UserID)
                                      };
                    myProductMgr.Add_Product(UpdateData_Product);

                    // Product Specification
                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
                    myProductVariantMgr.Add_Product_Properties(PlaceHolder_Product_Spec, droplist_Product_VariantID.SelectedValue, ProductID);

                    // Add to Product Mapping
                    e2Data[] UpdateData_Mapping = {
                                          new e2Data("ProductID", ProductID),
                                          new e2Data("CategoryID", _categoryid),
                                          new e2Data("IsFeatured", false.ToString()),
                                          new e2Data("SortOrder", "1")
                                      };

                    myProductMgr.Add_Product_Mapping(UpdateData_Mapping);

                    // Add Item to Category
                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Add_ComponentInCategory_Item(
                        _categoryid,
                        "B131F545-F494-447E-8B55-9F24AFADC417");

                    // Finish all update
                    MultiView_CreateProduct.SetActiveView(View_Product_Complete);

                    #endregion

                }

                // Trigger Refresh Event
                OnCategoryRefreshed(sender, e);

            }
        }

        #endregion
    }
}