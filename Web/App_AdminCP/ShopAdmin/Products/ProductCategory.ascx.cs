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

    public partial class App_AdminCP_ShopAdmin_Products_ProductCategory : System.Web.UI.UserControl
    {
        #region properties

        private string _productid;

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

        public void Control_FillData()
        {

        }

        private void Control_Init()
        {
            ProductMgr myProductMgr = new ProductMgr();
            ListView_Product_Category.DataSource = myProductMgr.Get_Product_Mappings(_productid, true);
            ListView_Product_Category.DataBind();

            CategoryTree_Product.LoadCategoryRoot();
        }

        protected void ListView_Product_Category_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                LinkButton myDeleteLink = (LinkButton)e.Item.FindControl("lbtn_Delete");

                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to remove from \"{0}\" category?');", DataBinder.Eval(e.Item.DataItem, "Category_Name"));

            }
        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsNegativeQuery(CategoryTree_Product.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Add_Cateogry_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                ProductMgr myProductMgr = new ProductMgr();

                if (myProductMgr.Chk_Product_Mapping(_productid, CategoryTree_Product.Selected_CategoryID))
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Your product is already been under this category.</h4>", "Action failed!");
                }
                else
                {
                    // Add to Product Mapping
                    e2Data[] UpdateData_Mapping = {
                                          new e2Data("ProductID", _productid),
                                          new e2Data("CategoryID", CategoryTree_Product.Selected_CategoryID),
                                          new e2Data("IsFeatured", false.ToString()),
                                          new e2Data("SortOrder", "1")
                                      };

                    myProductMgr.Add_Product_Mapping(UpdateData_Mapping);

                    // Add Item to Category
                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Add_ComponentInCategory_Item(
                        CategoryTree_Product.Selected_CategoryID,
                        "B131F545-F494-447E-8B55-9F24AFADC417");

                    Control_Init();
                }

            }
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductMgr myProductMgr = new ProductMgr();

                int count = myProductMgr.Count_Product_Mapping(_productid);

                if (myProductMgr.Count_Product_Mapping(_productid) <= 1)
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Your product need to be under at least one category.</h4>", "Action failed!");

                }
                else
                {

                    // Remove Product from mapping
                    myProductMgr.Remove_Product_Mapping(e.CommandArgument.ToString());

                    Product_Mapping myProduct_Mapping = myProductMgr.Get_Product_Mapping(e.CommandArgument.ToString());

                    // Remove Item from Category
                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Delete_ComponentInCategory_Item(
                        myProduct_Mapping.CategoryID,
                        "B131F545-F494-447E-8B55-9F24AFADC417");

                    Control_Init();
                }
            }
        }

    }
}