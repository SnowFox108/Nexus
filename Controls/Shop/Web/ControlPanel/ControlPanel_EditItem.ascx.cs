using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.Ebay.ControlPanel
{

    public partial class EditItem : System.Web.UI.UserControl
    {

        private string _itemid;
        //private string _source_categoryid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _itemid = ViewState["Ebay_ItemID"].ToString();
                    //_source_categoryid = ViewState["Source_CategoryID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Init_Form();
                Reset_Form();
                Control_Init();
            }

        }

        private void Control_Init()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusEbayItemID"]))
            {
                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                Lib.Ebay_Item myEbay_Item = myEbayMgr.Get_Ebay_Item(Request["NexusEbayItemID"]);

                TextEditor_ItemContent.Content = myEbay_Item.Item_Description;
                //CategoryTree_Menu.Selected_CategoryID = myEbay_Item.CategoryID;
                rbtn_IsActive.SelectedValue = myEbay_Item.IsActive.ToString();

                _itemid = myEbay_Item.Ebay_ItemID;
                ViewState["Ebay_ItemID"] = _itemid;
                //_source_categoryid = myEbay_Item.CategoryID;
                //ViewState["Source_CategoryID"] = _source_categoryid;

            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Init_Form()
        {

        }

        private void Reset_Form()
        {
            // Default Setting
            TextEditor_ItemContent.Content = "";
            //CategoryTree_Menu.UnSelectItems();
            //CategoryTree_Menu.LoadCategoryRoot();
            rbtn_IsActive.SelectedIndex = 0;

        }

        //protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (DataEval.IsEmptyQuery(CategoryTree_Menu.Selected_CategoryID))
        //        args.IsValid = false;
        //}

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

                e2Data[] UpdateData = {
                                               new e2Data("Ebay_ItemID", _itemid),
                                               //new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                               new e2Data("Item_Description", TextEditor_ItemContent.Content),
                                               new e2Data("IsActive", rbtn_IsActive.SelectedValue)
                                      };

                myEbayMgr.Edit_Ebay_Item(UpdateData);

                // Switch Category
                //CategoryMgr myCategoryMgr = new CategoryMgr();
                //myCategoryMgr.Move_ComponentInCategory_Item(_source_categoryid, CategoryTree_Menu.Selected_CategoryID, "707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6");

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }

    }
}