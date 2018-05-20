using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Pages;
using Nexus.Core.Categories;

namespace Nexus.Core
{
    public partial class App_AdminCP_SiteAdmin_Categories : System.Web.UI.Page
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
            MultiView_Category.SetActiveView(View_FirstPage);
        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {
            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                CategoryList_DataBind(CategoryTree_Menu.Selected_CategoryID);

                CategoryCommand_Menu.CategoryID = CategoryTree_Menu.Selected_CategoryID;
                CategoryCommand_Menu.Category_Selected();

                CategoryProperty_Modify.CategoryID = CategoryTree_Menu.Selected_CategoryID;
                CategoryProperty_Modify.Category_Selected();

                MultiView_Category.SetActiveView(View_ListCategory);

            }
            else
            {
                CategoryCommand_Menu.CategoryID = CategoryTree_Menu.Selected_CategoryID;
                CategoryCommand_Menu.Category_Selected();

                //Show Create Category Pannel
                MultiView_Category.SetActiveView(View_FirstPage);
            }
        }

        protected void CategoryCommand_Menu_CreateCategoryClick(object sender, EventArgs e)
        {
            CategoryCreate_New.Control_Init();
            MultiView_Category.SetActiveView(View_CreateCategory);

        }

        protected void CategoryCommand_Menu_DeleteCategoryClick(object sender, EventArgs e)
        {
            CategoryTree_Menu.Selected_CategoryID = "-1";
            CategoryTree_Menu.LoadCategoryRoot();
        }

        protected void CategoryCreate_New_CreateCategoryClick(object sender, EventArgs e)
        {
            CategoryTree_Menu.Selected_CategoryID = CategoryCreate_New.CategoryID;
            CategoryTree_Menu.LoadCategoryRoot();

            CategoryCommand_Menu.CategoryID = CategoryCreate_New.CategoryID;
            CategoryCommand_Menu.Category_Selected();

            CategoryList_DataBind(CategoryCreate_New.CategoryID);

            MultiView_Category.SetActiveView(View_ListCategory);
        }

        private void CategoryList_DataBind(string CategoryID)
        {
            CategoryMgr myCategoryMgr = new CategoryMgr();

            Category myCategory = myCategoryMgr.Get_Category(CategoryID);

            lbl_Category_Name.Text = myCategory.Category_Name;

            GridView_ComponentInCategory.DataSource = myCategoryMgr.Get_ComponentInCategory_Full_ByCategoryID(CategoryID, null);
            GridView_ComponentInCategory.DataBind();

        }

        protected void CategoryProperty_Modify_CategoryClick(object sender, EventArgs e)
        {
            CategoryTree_Menu.LoadCategoryRoot();
            CategoryCommand_Menu.Category_Selected();

            CategoryMgr myCategoryMgr = new CategoryMgr();
            Category myCategory = myCategoryMgr.Get_Category(CategoryTree_Menu.Selected_CategoryID);
            lbl_Category_Name.Text = myCategory.Category_Name;

        }

    }
}