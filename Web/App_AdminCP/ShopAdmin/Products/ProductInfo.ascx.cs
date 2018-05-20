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

    public partial class App_AdminCP_ShopAdmin_Products_ProductInfo : System.Web.UI.UserControl
    {
        #region properties

        private string _productid;
        private string _product_variantid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ProductID
        {
            get
            {
                if (_productid == null)
                {
                    return "";
                }
                return _productid;
            }
            set
            {
                _productid = value;
                ViewState["ProductID"] = _productid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                try
                {

                    _productid = ViewState["ProductID"].ToString();
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
                Control_FillData();
                Control_Init();
            }

        }

        public void Control_FillData()
        {
            ProductMgr myProductMgr = new ProductMgr();
            CurrencyMgr myCurrencyMgr = new CurrencyMgr();

            Product.Product myProduct = myProductMgr.Get_Product(_productid);

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

            droplist_Product_ManufacturerID.Items.Clear();
            droplist_Product_ManufacturerID.DataSource = myProductMgr.Get_Manufacturers("Name", true.ToString());
            droplist_Product_ManufacturerID.DataTextField = "Name";
            droplist_Product_ManufacturerID.DataValueField = "ManufacturerID";
            droplist_Product_ManufacturerID.DataBind();
            droplist_Product_ManufacturerID.SelectedIndex = 0;

            tbx_Product_Manufacturer_SKU.Text = "";

            droplist_Product_CurrencyID.Items.Clear();
            droplist_Product_CurrencyID.DataSource = myCurrencyMgr.Get_Currencies("Currency_Name", true.ToString());
            droplist_Product_CurrencyID.DataTextField = "Currency_ShortName";
            droplist_Product_CurrencyID.DataValueField = "CurrencyID";
            droplist_Product_CurrencyID.DataBind();
            droplist_Product_CurrencyID.SelectedIndex = 0;

            RadNumericTextBox_Product_RRP.Text = "0.00";
            chkbox_Product_IsActive.Checked = true;

            // Load Product Data
            rbtn_Product_Title_Type.SelectedValue = myProduct.Title_Type.ToString();
            tbx_Product_Title.Text = myProduct.Product_Title;
            tbx_Product_SKU.Text = myProduct.Product_SKU;
            droplist_Product_ManufacturerID.SelectedValue = myProduct.ManufacturerID;
            tbx_Product_Manufacturer_SKU.Text = myProduct.Manufacturer_SKU;
            droplist_Product_CurrencyID.SelectedValue = myProduct.CurrencyID;
            RadNumericTextBox_Product_RRP.Text = myProduct.RRP_Price.ToString();
            chkbox_Product_IsActive.Checked = myProduct.IsActive;

            _product_variantid = myProduct.Product_VariantID;
            ViewState["Product_VariantID"] = _product_variantid;

            // Load Product Specification

            Panel_Updated.Visible = false;
            Product_Control_Init();

        }

        public void Switch_Panel()
        {
            Panel_Updated.Visible = false;
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
                    _product_variantid,
                    Product_FormMode.Edit,
                    IsPagePostBack,
                    _productid
                    );
            }
        }

        private void Control_Init()
        {

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                ProductMgr myProductMgr = new ProductMgr();

                e2Data[] UpdateData = {
                                          new e2Data("ProductID", _productid),
                                          new e2Data("Product_Title", tbx_Product_Title.Text),
                                          new e2Data("Title_Type", rbtn_Product_Title_Type.SelectedValue),
                                          new e2Data("Product_SKU", tbx_Product_SKU.Text),
                                          new e2Data("ManufacturerID", droplist_Product_ManufacturerID.SelectedValue),
                                          new e2Data("Manufacturer_SKU", tbx_Product_Manufacturer_SKU.Text),
                                          new e2Data("CurrencyID", droplist_Product_CurrencyID.SelectedValue),
                                          new e2Data("RRP_Price", RadNumericTextBox_Product_RRP.Text),
                                          new e2Data("IsActive", chkbox_Product_IsActive.Checked.ToString()),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };
                myProductMgr.Edit_Product(UpdateData);

                // Product Specification
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
                myProductVariantMgr.Edit_Product_Properties(PlaceHolder_Product_Spec, _product_variantid, ProductID);

                Panel_Updated.Visible = true;


            }
        }
    }
}