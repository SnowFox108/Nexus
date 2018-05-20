using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Shop.Product;
using Nexus.Shop.Product.Attribute;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Products_PoP_AttributeOptions : System.Web.UI.Page
    {

        private string _attribute_indexid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _attribute_indexid = ViewState["Attribute_IndexID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Control_FillData();
                Control_Init();
            }

        }

        #region Form Init

        public void Control_FillData()
        {

            _attribute_indexid = Request["Attribute_IndexID"];

            if (!DataEval.IsEmptyQuery(_attribute_indexid))
            {
                ViewState["Attribute_IndexID"] = _attribute_indexid;

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                AttributeIndex myAttributeIndex = myProductAttributeMgr.Get_Product_AttributeIndex(_attribute_indexid);

                lbl_AttributeName.Text = myAttributeIndex.Display_Text;

                switch (myAttributeIndex.Input_Option)
                {
                    case Input_Option.TextBox:
                        Display_Form();
                        break;
                    case Input_Option.NumberBox:
                        Display_Form();
                        break;
                    case Input_Option.DropdownList:
                        Display_Input_Options();
                        break;
                    case Input_Option.RadioButtonList:
                        Display_Input_Options();
                        break;
                    case Input_Option.DatePicker:
                        Display_Form();
                        break;
                    case Input_Option.CheckBox:
                        Display_Form();
                        break;
                    case Input_Option.CheckBoxList:
                        Display_Input_Options();
                        break;
                    case Input_Option.ImageURL:
                        Display_Form();
                        break;
                }

                Panel_Updated.Visible = false;


            }


        }

        private void Control_Init()
        {
            RadGrid_Options.Rebind();
        }

        private void Display_Form()
        {
            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            Product_Attribute myProduct_Attribute = myProductAttributeMgr.Get_Product_Attribute_ByIndexID(_attribute_indexid);

            tbx_AttributeName.Text = myProduct_Attribute.Attribute_Name;
            chkbox_IsPreSelected.Checked = myProduct_Attribute.IsPreSelected;
            RadNumericTextBox_PriceAdjustment.Text = myProduct_Attribute.Price_Adjustment.ToString();
            RadNumericTextBox_WeightAdjustment.Text = myProduct_Attribute.Weight_Adjustment.ToString();
            chkbox_IsActive.Checked = myProduct_Attribute.IsActive;
            chkbox_IsActive.Enabled = false;

            btn_Add_Option.Visible = false;
            btn_Update_Option.Visible = true;
            btn_Update_Option.CommandArgument = myProduct_Attribute.AttributeID;

            btn_Cancel.Visible = false;
            btn_CloseWindow.Visible = true;

            MultiView_OptionForm.SetActiveView(View_Form);
            Panel_Input_Options.Visible = false;

        }

        private void Display_Input_Options()
        {

            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            Reset_Form();

            btn_CloseWindow.Visible = false;

            MultiView_OptionForm.SetActiveView(View_Button);
            Panel_Input_Options.Visible = true;

            RadGrid_Options.Rebind();

        }

        private void Reset_Form()
        {
            tbx_AttributeName.Text = "";
            chkbox_IsPreSelected.Checked = false;
            RadNumericTextBox_PriceAdjustment.Text = "0.00";
            RadNumericTextBox_WeightAdjustment.Text = "0.00";
            chkbox_IsActive.Checked = true;
            chkbox_IsActive.Enabled = true;

        }

        #endregion

        #region Create & Update Form

        protected void btn_Show_AddForm_Click(object sender, EventArgs e)
        {
            Reset_Form();

            btn_Add_Option.Visible = true;
            btn_Update_Option.Visible = false;
            btn_Cancel.Visible = true;
            btn_CloseWindow.Visible = false;

            MultiView_OptionForm.SetActiveView(View_Form);

        }

        protected void btn_Add_Option_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                // Create Attribute Options
                string AttributeID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("AttributeID", AttributeID),
                                          new e2Data("Attribute_IndexID", _attribute_indexid),
                                          new e2Data("Attribute_Name", tbx_AttributeName.Text),
                                          new e2Data("IsPreSelected", chkbox_IsPreSelected.Checked.ToString()),
                                          new e2Data("Price_Adjustment", RadNumericTextBox_PriceAdjustment.Text),
                                          new e2Data("Weight_Adjustment", RadNumericTextBox_WeightAdjustment.Text),
                                          new e2Data("SortOrder", "0"),
                                          new e2Data("IsActive", chkbox_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Add_Product_Attribute(UpdateData);

                Control_Init();

                MultiView_OptionForm.SetActiveView(View_Button);

            }

        }

        protected void btn_Update_Option_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                e2Data[] UpdateData = {
                                          new e2Data("AttributeID", e.CommandArgument.ToString()),
                                          new e2Data("Attribute_Name", tbx_AttributeName.Text),
                                          new e2Data("IsPreSelected", chkbox_IsPreSelected.Checked.ToString()),
                                          new e2Data("Price_Adjustment", RadNumericTextBox_PriceAdjustment.Text),
                                          new e2Data("Weight_Adjustment", RadNumericTextBox_WeightAdjustment.Text),
                                          new e2Data("IsActive", chkbox_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Edit_Product_Attribute(UpdateData);

                Control_Init();

                // Check Update Type
                AttributeIndex myAttributeIndex = myProductAttributeMgr.Get_Product_AttributeIndex(_attribute_indexid);

                switch (myAttributeIndex.Input_Option)
                {
                    case Input_Option.TextBox:
                        Panel_Updated.Visible = true;
                        break;
                    case Input_Option.NumberBox:
                        Panel_Updated.Visible = true;
                        break;
                    case Input_Option.DropdownList:
                        MultiView_OptionForm.SetActiveView(View_Button);
                        break;
                    case Input_Option.RadioButtonList:
                        MultiView_OptionForm.SetActiveView(View_Button);
                        break;
                    case Input_Option.DatePicker:
                        Panel_Updated.Visible = true;
                        break;
                    case Input_Option.CheckBox:
                        Panel_Updated.Visible = true;
                        break;
                    case Input_Option.CheckBoxList:
                        MultiView_OptionForm.SetActiveView(View_Button);
                        break;
                    case Input_Option.ImageURL:
                        Panel_Updated.Visible = true;
                        break;
                }


            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_OptionForm.SetActiveView(View_Button);
        }

        protected void btn_CloseWindow_Click(object sender, EventArgs e)
        {
            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
        }

        #endregion

        #region RadGrid Actions

        protected void RadGrid_Options_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            RadGrid_Options.DataSource = myProductAttributeMgr.Get_Product_Attributes(_attribute_indexid);

        }

        protected void RadGrid_Options_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("AttributeID").ToString();

                LinkButton myDeleteLink = (LinkButton)myItem["TemplateColumn_Actions"].FindControl("lbtn_Delete_Option");
                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete option \"{0}\" ?');", DataBinder.Eval(myItem.DataItem, "Attribute_Name"));

            }
        }

        protected void RadGrid_Options_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (e.DestDataItem != null
                && string.IsNullOrEmpty(e.HtmlElement)
                && e.DestDataItem.OwnerGridID == RadGrid_Options.ClientID)
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                List<Product_Attribute> myProduct_Attributes = myProductAttributeMgr.Get_Product_Attributes(_attribute_indexid);

                Product_Attribute draggedAttribute = Get_Attribute_in_List(myProduct_Attributes, e.DraggedItems[0].GetDataKeyValue("AttributeID").ToString());
                Product_Attribute destAttribute = Get_Attribute_in_List(myProduct_Attributes, e.DestDataItem.GetDataKeyValue("AttributeID").ToString());

                int destIndex = myProduct_Attributes.IndexOf(destAttribute);

                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    destIndex -= 1;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    destIndex += 1;
                }

                myProduct_Attributes.Remove(draggedAttribute);
                myProduct_Attributes.Insert(destIndex, draggedAttribute);

                foreach (Product_Attribute myAttribute in myProduct_Attributes)
                {
                    // Product Variant
                    e2Data[] UpdateData = {
                                                      new e2Data("AttributeID", myAttribute.AttributeID),
                                                      new e2Data("SortOrder", (myProduct_Attributes.IndexOf(Get_Attribute_in_List(myProduct_Attributes, myAttribute.AttributeID)) + 1).ToString())
                                                  };

                    myProductAttributeMgr.Edit_Product_Attribute(UpdateData);

                }

                RadGrid_Options.Rebind();

            }

        }

        private static Product_Attribute Get_Attribute_in_List(IEnumerable<Product_Attribute> list, string attributeid)
        {
            foreach (Product_Attribute myProduct_Attribute in list)
            {
                if (myProduct_Attribute.AttributeID == attributeid)
                {
                    return myProduct_Attribute;
                }
            }

            return null;
        }

        protected void lbtn_Edit_Option_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                Product_Attribute myProduct_Attribute = myProductAttributeMgr.Get_Product_Attribute(e.CommandArgument.ToString());

                tbx_AttributeName.Text = myProduct_Attribute.Attribute_Name;
                chkbox_IsPreSelected.Checked = myProduct_Attribute.IsPreSelected;
                RadNumericTextBox_PriceAdjustment.Text = myProduct_Attribute.Price_Adjustment.ToString();
                RadNumericTextBox_WeightAdjustment.Text = myProduct_Attribute.Weight_Adjustment.ToString();
                chkbox_IsActive.Checked = myProduct_Attribute.IsActive;
                chkbox_IsActive.Enabled = true;

                btn_Add_Option.Visible = false;
                btn_Update_Option.Visible = true;
                btn_Update_Option.CommandArgument = myProduct_Attribute.AttributeID;

                btn_Cancel.Visible = true;
                btn_CloseWindow.Visible = false;

                MultiView_OptionForm.SetActiveView(View_Form);

            }
        }


        protected void lbtn_Delete_Option_Command(object sender, CommandEventArgs e)
        {

            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                myProductAttributeMgr.Remove_Product_Attribute(e.CommandArgument.ToString());

                Control_Init();

            }

        }

        #endregion


    }
}