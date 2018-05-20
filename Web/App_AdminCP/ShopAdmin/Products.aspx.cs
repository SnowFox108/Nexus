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

    public partial class App_AdminCP_ShopAdmin_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }

        }

        private void Control_Init()
        {
            lbl_Category_Name.Text = "List All";

            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                CategoryMgr myCategoryMgr = new CategoryMgr();

                lbl_Category_Name.Text = myCategoryMgr.Get_Category(CategoryTree_Menu.Selected_CategoryID).Category_Name;
            }

            ProductList_List.CategoryID = CategoryTree_Menu.Selected_CategoryID;

            MultiView_Product.SetActiveView(View_Product_List);

        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {

            ProductList_List.CategoryID = CategoryTree_Menu.Selected_CategoryID;
            //ProductList_List.ProductEdit_URL = "ProductEditor.aspx";

            MultiView_Product.SetActiveView(View_Product_List);

        }

        protected void ProductList_List_CategoryRefreshed(object sender, EventArgs e)
        {
            CategoryTree_Menu.LoadCategoryRoot();
        }

        protected void btn_Create_Product_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (DataEval.IsNegativeQuery(CategoryTree_Menu.Selected_CategoryID))
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Please select a category to begin. </h4>", "Action failed!");
                }
                else
                {
                    ProductCreate_Create.CategoryID = CategoryTree_Menu.Selected_CategoryID;
                    ProductCreate_Create.Edit_Mode = "CreateNew";
                    ProductCreate_Create.Reset();
                    MultiView_Product.SetActiveView(View_Product_Create);
                }
            }
        }
    }
}