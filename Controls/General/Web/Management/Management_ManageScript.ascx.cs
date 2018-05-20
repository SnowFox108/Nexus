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

namespace Nexus.Controls.General.Management
{
    public partial class ManageScript : System.Web.UI.UserControl
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
            myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&ItemID={1}');", "1DADE160-91DF-44E1-9ECB-9E790059978B", myItemID.Value);
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

                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                ListView_ItemList.DataSource = myScriptMgr.Get_Scripts(_category_selected, null);
                ListView_ItemList.DataKeyNames = new string[] { "ScriptID" };
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

                        Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                        Lib.Script myScript = myScriptMgr.Get_Script_Content(hidden_ItemID.Value);

                        if (myScript.CategoryID != CategoryTree_MoveTo.Selected_CategoryID)
                        {

                            e2Data[] UpdateData = {
                                                      new e2Data("ScriptID", myScript.ScriptID),
                                                      new e2Data("CategoryID", CategoryTree_MoveTo.Selected_CategoryID)
                                                   };

                            myScriptMgr.Edit_Script_Content(UpdateData);

                            // Switch Category
                            CategoryMgr myCategoryMgr = new CategoryMgr();
                            myCategoryMgr.Move_ComponentInCategory_Item(myScript.CategoryID, CategoryTree_MoveTo.Selected_CategoryID, "076A591E-1BFE-47A7-8B40-D6621C7D3DF9");
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
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");

                        Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                        Lib.Script myScript = myScriptMgr.Get_Script_Content(hidden_ItemID.Value);

                        // Remove from Database
                        myScriptMgr.Remove_Script_Content(hidden_ItemID.Value);

                        // Remove Item from Category
                        CategoryMgr myCategoryMgr = new CategoryMgr();
                        myCategoryMgr.Delete_ComponentInCategory_Item(myScript.CategoryID, "076A591E-1BFE-47A7-8B40-D6621C7D3DF9");

                    }
                }

                Control_Init();
            }
        }
    }
}