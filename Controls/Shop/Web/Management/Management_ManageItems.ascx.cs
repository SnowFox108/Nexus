using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Controls.Ebay.Lib;
using Telerik.Web.UI;

namespace Nexus.Controls.Ebay.Management
{

    public partial class ManageItems : System.Web.UI.UserControl
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
            ItemList_DataBind();
            CategoryTree_Menu.LoadCategoryRoot();
            CategoryTree_MoveTo.LoadCategoryRoot();

        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {
            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                _category_selected = CategoryTree_Menu.Selected_CategoryID;
                ViewState["Category_Selected"] = _category_selected;

                ItemList_DataBind();

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

        protected void ListView_ItemList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HiddenField myItemID = (HiddenField)e.Item.FindControl("Hidden_ItemID");
            HyperLink myEditLink = (HyperLink)e.Item.FindControl("hlink_Edit");

            myEditLink.Attributes["href"] = "#";
            myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusEbayItemID={1}');", "8BF5ABB9-30D5-429E-8017-A168672AC15F", myItemID.Value);
        }

        protected void ListView_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ItemList_DataBind();
        }

        private void ItemList_DataBind()
        {
            if (!DataEval.IsEmptyQuery(_category_selected))
            {
                RadTabStrip_Commands.Visible = true;

                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                ListView_ItemList.DataSource = myEbayMgr.Get_Ebay_Items(_category_selected, "ALL", "Ebay_Title", "ASC");
                ListView_ItemList.DataKeyNames = new string[] { "Ebay_ItemID" };
                ListView_ItemList.DataBind();

                CheckBox chk_SelectAll = (CheckBox)ListView_ItemList.FindControl("chk_SelectAll");
                if (chk_SelectAll != null)
                    chk_SelectAll.Checked = false;
            }
        }

        protected void Chk_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_SelectAll = (CheckBox)sender;

            for (int i = 0; i < ListView_ItemList.Items.Count; i++)
            {
                CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                chk_Selected.Checked = chk_SelectAll.Checked;
            }
        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_MoveTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void CustomValidator_Category_Copy_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_CopyTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Move_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");
                        HiddenField hidden_Item_MapID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_Item_MapID");

                        Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                        //Lib.Ebay_Item myEbay_Item = myEbayMgr.Get_Ebay_Item(hidden_ItemID.Value);
                        Ebay_Item_Map myEbay_Item_Map = myEbayMgr.Get_Ebay_Item_Map(hidden_Item_MapID.Value);

                        if (myEbay_Item_Map.CategoryID != CategoryTree_MoveTo.Selected_CategoryID)
                        {

                            if (myEbayMgr.Chk_Ebay_Item_Mapping(hidden_ItemID.Value, CategoryTree_MoveTo.Selected_CategoryID))
                            {
                                myEbayMgr.Remove_Ebay_Item_Mapping(hidden_Item_MapID.Value);

                                // Delete item from Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Delete_ComponentInCategory_Item(myEbay_Item_Map.CategoryID, "707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6");

                            }
                            else
                            {
                                e2Data[] UpdateData = {
                                                          new e2Data("Item_MapID", myEbay_Item_Map.Item_MapID),
                                                          new e2Data("CategoryID", CategoryTree_MoveTo.Selected_CategoryID)
                                                      };

                                myEbayMgr.Edit_Ebay_Item_Mapping(UpdateData);

                                // Switch Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Move_ComponentInCategory_Item(myEbay_Item_Map.CategoryID, CategoryTree_MoveTo.Selected_CategoryID, "707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6");
                            }
                        }

                    }
                }

                Control_Init();
            }
        }

        protected void btn_Copy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");
                        HiddenField hidden_Item_MapID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_Item_MapID");

                        Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                        Ebay_Item_Map myEbay_Item_Map = myEbayMgr.Get_Ebay_Item_Map(hidden_Item_MapID.Value);

                        if (myEbay_Item_Map.CategoryID != CategoryTree_CopyTo.Selected_CategoryID)
                        {

                            e2Data[] UpdateData = {
                                                          new e2Data("Ebay_ItemID", myEbay_Item_Map.Ebay_ItemID),
                                                          new e2Data("CategoryID", CategoryTree_CopyTo.Selected_CategoryID),
                                                          new e2Data("IsFeatured", false.ToString()),
                                                          new e2Data("SortOrder", "1")
                                                      };

                            myEbayMgr.Add_Ebay_Item_Mapping(UpdateData);

                            // Switch Category
                            CategoryMgr myCategoryMgr = new CategoryMgr();
                            myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_CopyTo.Selected_CategoryID, "707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6");
                        }

                    }
                }

                Control_Init();
            }
        }


        protected void btn_IsActive_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");

                        Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                        Lib.Ebay_Item myEbay_Item = myEbayMgr.Get_Ebay_Item(hidden_ItemID.Value);

                        e2Data[] UpdateData = {
                                                      new e2Data("Ebay_ItemID", myEbay_Item.Ebay_ItemID),
                                                      new e2Data("IsActive", rbtn_IsActive.SelectedValue)
                                                   };

                        myEbayMgr.Edit_Ebay_Item(UpdateData);

                    }
                }

                Control_Init();
            }
        }

        protected void lbtn_Update_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                myEbayMgr.Fetch_MyeBayItem(e.CommandArgument.ToString());

                Control_Init();
            }
        }
    }
}