using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Telerik.Web.UI;

namespace Nexus.Controls.News.Management
{

    public partial class ManageNews : System.Web.UI.UserControl
    {

        private string _category_selected;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                try
                {
                    _category_selected = ViewState["Category_Selected"].ToString();
                }
                catch
                {
                    // do nothing;
                }

                RadTabStrip_Commands.Visible = true;
            }
            else
            {
                Control_PreInit();
                Control_Init();
            }

        }

        private void Control_PreInit()
        {

            RadTabStrip_Commands.Visible = false;
        }

        private void Control_Init()
        {
            NewsList_DataBind();
            CategoryTree_Menu.LoadCategoryRoot();
            CategoryTree_MoveTo.LoadCategoryRoot();

        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {
            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                _category_selected = CategoryTree_Menu.Selected_CategoryID;
                ViewState["Category_Selected"] = _category_selected;

                NewsList_DataBind();

                foreach (RadTab myRadTab in RadTabStrip_Commands.Tabs)
                {
                    myRadTab.Selected = false;
                }

                foreach (RadPageView myPageView in RadMultiPage_Actions.PageViews)
                {
                    myPageView.Selected = false;
                }
            }
        }

        protected void ListView_NewsList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HiddenField myNewsID = (HiddenField)e.Item.FindControl("Hidden_NewsID");
            HyperLink myEditLink = (HyperLink)e.Item.FindControl("hlink_Edit");

            myEditLink.Attributes["href"] = "#";
            myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusNewsPostID={1}');", "60B08E61-40DA-4989-B401-81B75A619F85", myNewsID.Value);
        }

        protected void ListView_NewsList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_NewsList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            NewsList_DataBind();
        }

        private void NewsList_DataBind()
        {
            if (!DataEval.IsEmptyQuery(_category_selected))
            {
                RadTabStrip_Commands.Visible = true;

                Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();
                ListView_NewsList.DataSource = myNewsMgr.Get_News_Posts(_category_selected, "ALL", "News_Date", "DESC");
                ListView_NewsList.DataKeyNames = new string[] { "NewsID" };
                ListView_NewsList.DataBind();

                CheckBox chk_SelectAll = (CheckBox)ListView_NewsList.FindControl("chk_SelectAll");
                if (chk_SelectAll != null)
                    chk_SelectAll.Checked = false;
            }
        }

        protected void Chk_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_SelectAll = (CheckBox)sender;

            for (int i = 0; i < ListView_NewsList.Items.Count; i++)
            {
                CheckBox chk_Selected = (CheckBox)ListView_NewsList.Items[i].FindControl("chk_Selected");
                chk_Selected.Checked = chk_SelectAll.Checked;
            }
        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_MoveTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Move_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_NewsList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_NewsList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_NewsID = (HiddenField)ListView_NewsList.Items[i].FindControl("Hidden_NewsID");

                        Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();
                        Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(hidden_NewsID.Value);

                        if (myNews_Post.CategoryID != CategoryTree_MoveTo.Selected_CategoryID)
                        {

                            e2Data[] UpdateData = {
                                                      new e2Data("NewsID", myNews_Post.NewsID),
                                                      new e2Data("CategoryID", CategoryTree_MoveTo.Selected_CategoryID)
                                                   };

                            myNewsMgr.Edit_News_Post(UpdateData);

                            // Switch Category
                            CategoryMgr myCategoryMgr = new CategoryMgr();
                            myCategoryMgr.Move_ComponentInCategory_Item(myNews_Post.CategoryID, CategoryTree_MoveTo.Selected_CategoryID, "3A79BF21-D0DF-4825-BFB2-7F6738C12BA7");
                        }

                    }
                }

                Control_Init();
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_NewsList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_NewsList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_NewsID = (HiddenField)ListView_NewsList.Items[i].FindControl("Hidden_NewsID");

                        Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();
                        Lib.News_Post myNews_Post = myNewsMgr.Get_News_Post(hidden_NewsID.Value);

                        // Remove from Database
                        myNewsMgr.Remove_News_Comments(hidden_NewsID.Value);
                        myNewsMgr.Remove_News_Post(hidden_NewsID.Value);

                        // Remove Item from Category
                        CategoryMgr myCategoryMgr = new CategoryMgr();
                        myCategoryMgr.Delete_ComponentInCategory_Item(myNews_Post.CategoryID, "3A79BF21-D0DF-4825-BFB2-7F6738C12BA7");

                    }
                }

                Control_Init();
            }
        }
    }
}