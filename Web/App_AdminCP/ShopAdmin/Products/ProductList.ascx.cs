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

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Products_ProductList : System.Web.UI.UserControl
    {

        #region Properties

        private string _categoryid = "-1";
        private string _productedit_url = "ProductEditor.aspx";
        private string _search_field = "";
        private string _keyword = "";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;

                Control_Init();

            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ProductEdit_URL
        {
            get
            {
                return _productedit_url;
            }
            set
            {
                _productedit_url = value;
                ViewState["ProductEdit_URL"] = _productedit_url;
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
                    _productedit_url = ViewState["ProductEdit_URL"].ToString();
                    _search_field = ViewState["Search_Field"].ToString();
                    _keyword = ViewState["Keyword"].ToString();
                }
                catch
                {
                    // Do nothing
                }
            }
            else
            {

                Control_FillData();
                Control_Init();

            }
        }

        private void Control_FillData()
        {

            // ViewState
            ViewState["CategoryID"] = _categoryid;
            ViewState["ProductEdit_URL"] = _productedit_url;

            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
            ProductMgr myProductMgr = new ProductMgr();

            // Search
            tbx_Search_Product_SKU.Text = "";
            tbx_Search_Manufacturer_SKU.Text = "";
            tbx_Search_Product_Title.Text = "";

            ViewState["Search_Field"] = _search_field;
            ViewState["Keyword"] = _keyword;

            // Filter: Product Variant
            droplist_Filter_Product_Variant.DataSource = myProductVariantMgr.Get_Product_Variants();
            droplist_Filter_Product_Variant.DataTextField = "Variant_Name";
            droplist_Filter_Product_Variant.DataValueField = "Product_VariantID";
            droplist_Filter_Product_Variant.DataBind();

            // Add an empty
            ListItem myEmpty_Product_Variant = new ListItem();
            myEmpty_Product_Variant.Text = "Select a Product Variant";
            myEmpty_Product_Variant.Value = "-1";
            droplist_Filter_Product_Variant.Items.Insert(0, myEmpty_Product_Variant);

            droplist_Filter_Product_Variant.SelectedIndex = 0;

            // Filter: manufacturer

            droplist_Filter_Manufacturer.DataSource = myProductMgr.Get_Manufacturers("Name", true.ToString());
            droplist_Filter_Manufacturer.DataTextField = "Name";
            droplist_Filter_Manufacturer.DataValueField = "ManufacturerID";
            droplist_Filter_Manufacturer.DataBind();

            ListItem myEmpty_Manufacturer = new ListItem();
            myEmpty_Manufacturer.Text = "Select a Manufacturer";
            myEmpty_Manufacturer.Value = "-1";
            droplist_Filter_Manufacturer.Items.Insert(0, myEmpty_Manufacturer);

            droplist_Filter_Manufacturer.SelectedIndex = 0;


        }


        private void Control_Init()
        {
            ItemList_DataBind();
            CategoryTree_MoveTo.LoadCategoryRoot();
            CategoryTree_CopyTo.LoadCategoryRoot();

        }


        #region Filter Search and Sort

        protected void btn_Search_Product_SKU_Click(object sender, EventArgs e)
        {
            _search_field = "Product_SKU";
            ViewState["Search_Field"] = _search_field;

            _keyword = tbx_Search_Product_SKU.Text;
            ViewState["Keyword"] = _keyword;

            ItemList_DataBind();

        }
        protected void btn_Search_Manufacturer_SKU_Click(object sender, EventArgs e)
        {
            _search_field = "Manufacturer_SKU";
            ViewState["Search_Field"] = _search_field;

            _keyword = tbx_Search_Manufacturer_SKU.Text;
            ViewState["Keyword"] = _keyword;

            ItemList_DataBind();

        }
        protected void btn_Search_Product_Title_Click(object sender, EventArgs e)
        {           

            _search_field = RadioButtonList_TitleType.SelectedValue;
            ViewState["Search_Field"] = _search_field;

            _keyword = tbx_Search_Product_Title.Text;
            ViewState["Keyword"] = _keyword;

            ItemList_DataBind();

        }

        protected void btn_Search_Filter_Click(object sender, EventArgs e)
        {
            ItemList_DataBind();
        }

        #endregion

        #region Move, Copy & Active Status

        protected void CustomValidator_Category_Move_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsNegativeQuery(CategoryTree_MoveTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Move_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_Product_List.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_Product_List.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        string ProductID = ListView_Product_List.DataKeys[i].Values["ProductID"].ToString();
                        string Product_MappingID = ListView_Product_List.DataKeys[i].Values["Product_MappingID"].ToString();

                        ProductMgr myProductMgr = new ProductMgr();

                        Product_Mapping myProductMapping = myProductMgr.Get_Product_Mapping(Product_MappingID);

                        if (myProductMapping.CategoryID != CategoryTree_MoveTo.Selected_CategoryID)
                        {

                            if (myProductMgr.Chk_Product_Mapping(ProductID, CategoryTree_MoveTo.Selected_CategoryID))
                            {
                                myProductMgr.Remove_Product_Mapping(Product_MappingID);

                                // Delete item from Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Delete_ComponentInCategory_Item(myProductMapping.CategoryID, "B131F545-F494-447E-8B55-9F24AFADC417");

                            }
                            else
                            {
                                e2Data[] UpdateData = {
                                                          new e2Data("Product_MappingID", myProductMapping.Product_MappingID),
                                                          new e2Data("CategoryID", CategoryTree_MoveTo.Selected_CategoryID)
                                                      };

                                myProductMgr.Edit_Product_Mapping(UpdateData);

                                // Switch Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Move_ComponentInCategory_Item(myProductMapping.CategoryID, CategoryTree_MoveTo.Selected_CategoryID, "B131F545-F494-447E-8B55-9F24AFADC417");
                            }
                        }

                    }
                }

                // Refresh List view after action.
                Control_Init();

                // Trigger Refresh Event
                OnCategoryRefreshed(sender, e);

            }
        }

        protected void CustomValidator_Category_Copy_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsNegativeQuery(CategoryTree_CopyTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Copy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_Product_List.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_Product_List.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        string ProductID = ListView_Product_List.DataKeys[i].Values["ProductID"].ToString();
                        string Product_MappingID = ListView_Product_List.DataKeys[i].Values["Product_MappingID"].ToString();

                        ProductMgr myProductMgr = new ProductMgr();

                        Product_Mapping myProductMapping = myProductMgr.Get_Product_Mapping(Product_MappingID);

                        if (myProductMapping.CategoryID != CategoryTree_CopyTo.Selected_CategoryID)
                        {

                            e2Data[] UpdateData = {
                                                      new e2Data("ProductID", ProductID),
                                                      new e2Data("CategoryID", CategoryTree_CopyTo.Selected_CategoryID),
                                                      new e2Data("SortOrder", "1")
                                                   };

                            myProductMgr.Add_Product_Mapping(UpdateData);

                            // Add Category
                            CategoryMgr myCategoryMgr = new CategoryMgr();
                            myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_CopyTo.Selected_CategoryID, "B131F545-F494-447E-8B55-9F24AFADC417");
                        }

                    }
                }

                // Refresh List view after action.
                Control_Init();

                // Trigger Refresh Event
                OnCategoryRefreshed(sender, e);

            }

        }

        protected void btn_IsActive_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_Product_List.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_Product_List.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {

                        string ProductID = ListView_Product_List.DataKeys[i].Values["ProductID"].ToString();

                        ProductMgr myProductMgr = new ProductMgr();

                        Product.Product myProduct = myProductMgr.Get_Product(ProductID);

                        e2Data[] UpdateData = {
                                                      new e2Data("ProductID", myProduct.ProductID),
                                                      new e2Data("IsActive", rbtn_IsActive.SelectedValue)
                                                   };

                        myProductMgr.Edit_Product(UpdateData);

                    }
                }

                // Refresh List view after action.
                ItemList_DataBind();

            }

        }

        #endregion

        #region List View

        protected void ListView_Product_List_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item is ListViewDataItem)
            {

                ListViewDataItem myItem = (ListViewDataItem)e.Item;
                string myItemID = ListView_Product_List.DataKeys[myItem.DataItemIndex].Values["ProductID"].ToString();

                HyperLink myEditLink = (HyperLink)e.Item.FindControl("hlink_EditProduct");

                myEditLink.Attributes["href"] = string.Format("{0}?ProductID={1}", _productedit_url, myItemID);

            }

        }

        protected void ListView_Product_List_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_Product_List.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ItemList_DataBind();

        }

        private void ItemList_DataBind()
        {

            ProductSearchMgr myProductSearchMgr = new ProductSearchMgr();

            // List products
            ListView_Product_List.DataSource = myProductSearchMgr.Get_Product_Search(
                _search_field,
                _keyword,
                droplist_Filter_Product_Variant.SelectedValue,
                _categoryid,
                droplist_Filter_Manufacturer.SelectedValue,
                droplist_Filter_IsActive.SelectedValue,
                "ALL",
                droplist_Filter_SortOrder.SelectedValue,
                droplist_Filter_Direction.SelectedValue);

            ListView_Product_List.DataBind();

            CheckBox chk_SelectAll = (CheckBox)ListView_Product_List.FindControl("chkbox_SelectAll");
            if (chk_SelectAll != null)
                chk_SelectAll.Checked = false;
        }

        protected void Chk_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_SelectAll = (CheckBox)sender;

            for (int i = 0; i < ListView_Product_List.Items.Count; i++)
            {
                CheckBox chk_Selected = (CheckBox)ListView_Product_List.Items[i].FindControl("chk_Selected");
                chk_Selected.Checked = chk_SelectAll.Checked;
            }
        }

        #endregion
    }
}