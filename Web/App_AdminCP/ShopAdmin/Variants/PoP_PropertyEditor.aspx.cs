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
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Variants_PoP_PropertyEditor : System.Web.UI.Page
    {

        private string _variant_propertyid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _variant_propertyid = ViewState["Variant_PropertyID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            string Variant_PropertyID = Request["Variant_PropertyID"];

            if (!DataEval.IsEmptyQuery(Variant_PropertyID))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                Variant_Property myVariant_Property = myProductVariantMgr.Get_Product_Variant_Property(Variant_PropertyID);

                _variant_propertyid = myVariant_Property.Variant_PropertyID;
                ViewState["Variant_PropertyID"] = _variant_propertyid;

                // Fill the form
                Panel_Input_Options.Visible = false;
                Panel_Updated.Visible = false;

                tbx_Property_Name.Text = myVariant_Property.Property_Name;
                lbl_InputOption.Text = myVariant_Property.Input_Option.ToString();
                tbx_Default_Value.Text = myVariant_Property.Default_Value;
                tbx_Tooltips.Text = myVariant_Property.Tooltips;
                tbx_Field_Name.Text = myVariant_Property.Field_Name;
                chkbox_IsRequired.Checked = myVariant_Property.IsRequired;
                chkbox_IsFilter.Checked = myVariant_Property.IsFilter;
                chkbox_IsSort.Checked = myVariant_Property.IsSort;

                switch (myVariant_Property.Input_Option)
                {
                    case Input_Option.TextBox:
                        break;
                    case Input_Option.NumberBox:
                        break;
                    case Input_Option.DropdownList:
                        Display_Input_Options();
                        break;
                    case Input_Option.RadioButtonList:
                        Display_Input_Options();
                        break;
                    case Input_Option.DatePicker:
                        break;
                    case Input_Option.CheckBox:
                        break;
                    case Input_Option.CheckBoxList:
                        Display_Input_Options();
                        break;
                    case Input_Option.ImageURL:
                        break;
                }

            }

        }

        private void Display_Input_Options()
        {
            Panel_Input_Options.Visible = true;
            MultiView_InputOption.SetActiveView(View_Add);
            Control_FillData_Option();
            RadGrid_Options.Rebind();
        }

        protected void btn_UpdateProperty_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                e2Data[] UpdateData = {
                                              new e2Data("Variant_PropertyID", _variant_propertyid),
                                              new e2Data("Property_Name", tbx_Property_Name.Text),
                                              new e2Data("Default_Value", tbx_Default_Value.Text),
                                              new e2Data("Tooltips", tbx_Tooltips.Text),
                                              new e2Data("IsRequired", chkbox_IsRequired.Checked.ToString()),
                                              new e2Data("IsFilter", chkbox_IsFilter.Checked.ToString()),
                                              new e2Data("IsSort", chkbox_IsSort.Checked.ToString()),
                                              new e2Data("Field_Name", tbx_Field_Name.Text)
                                      };

                myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                Panel_Updated.Visible = true;
            }

        }
        protected void btn_CloseWindow_Click(object sender, EventArgs e)
        {
            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

        #region Option Events

        protected void RadGrid_Options_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            RadGrid_Options.DataSource = myProductVariantMgr.Get_Product_Variant_Property_Options(_variant_propertyid, "SortOrder");

        }

        protected void RadGrid_Options_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("OptionID").ToString();

                LinkButton myDeleteLink = (LinkButton)myItem["TemplateColumn_Actions"].FindControl("lbtn_DeleteOption");
                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete option \"{0}\" ?');", DataBinder.Eval(myItem.DataItem, "Option_Name"));

            }

        }

        protected void RadGrid_Options_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (e.DestDataItem != null
                && string.IsNullOrEmpty(e.HtmlElement)
                && e.DestDataItem.OwnerGridID == RadGrid_Options.ClientID)
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                Property_Option myProperty_Option = myProductVariantMgr.Get_Product_Variant_Property_Option(e.DestDataItem.GetDataKeyValue("OptionID").ToString());

                List<Property_Option> myProperty_Options = myProductVariantMgr.Get_Product_Variant_Property_Options(myProperty_Option.Variant_PropertyID, "SortOrder");

                Property_Option draggedProperty_Option = Get_Property_Option_in_List(myProperty_Options, e.DraggedItems[0].GetDataKeyValue("OptionID").ToString());
                Property_Option destProperty_Option = Get_Property_Option_in_List(myProperty_Options, e.DestDataItem.GetDataKeyValue("OptionID").ToString());

                int destIndex = myProperty_Options.IndexOf(destProperty_Option);

                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    destIndex -= 1;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    destIndex += 1;
                }

                myProperty_Options.Remove(draggedProperty_Option);
                myProperty_Options.Insert(destIndex, draggedProperty_Option);

                foreach (Property_Option Property_Option in myProperty_Options)
                {
                    // Product Variant
                    e2Data[] UpdateData = {
                                                      new e2Data("OptionID", Property_Option.OptionID),
                                                      new e2Data("SortOrder", (myProperty_Options.IndexOf(Get_Property_Option_in_List(myProperty_Options, Property_Option.OptionID)) + 1).ToString())
                                                  };

                    myProductVariantMgr.Edit_Product_Variant_Property_Option(UpdateData);

                }

                RadGrid_Options.Rebind();

            }

        }

        private static Property_Option Get_Property_Option_in_List(IEnumerable<Property_Option> list, string optionid)
        {
            foreach (Property_Option myProperty_Option in list)
            {
                if (myProperty_Option.OptionID == optionid)
                {
                    return myProperty_Option;
                }
            }

            return null;
        }


        protected void lbtn_EditOption_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                // Load options
                Property_Option myProperty_Option = myProductVariantMgr.Get_Product_Variant_Property_Option(e.CommandArgument.ToString());

                // Need to add code for enable edit value later

                Control_FillData_Option();
                tbx_EditOption_Name.Text = myProperty_Option.Option_Name;
                tbx_EditOption_Value.Text = myProperty_Option.Option_Value;
                chkbox_EditOption_IsActive.Checked = myProperty_Option.IsActive;
                btn_EditOption.CommandArgument = myProperty_Option.OptionID;
                

                MultiView_InputOption.SetActiveView(View_Edit);

            }

        }

        protected void lbtn_DeleteOption_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                // Need to add code for check option usage later

                // Remove Option
                myProductVariantMgr.Remove_Product_Variant_Property_Option(e.CommandArgument.ToString());

                RadGrid_Options.Rebind();
            }

        }

        #endregion

        private void Control_FillData_Option()
        {
            tbx_AddOption_Name.Text = "";
            tbx_AddOption_Value.Text = "";
            chkbox_AddOption_IsActive.Checked = true;

            tbx_EditOption_Name.Text = "";
            tbx_EditOption_Value.Text = "";
            chkbox_EditOption_IsActive.Checked = true;
        }

        protected void btn_AddOption_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                string OptionID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                // Product Variant
                e2Data[] UpdateData = {
                                          new e2Data("OptionID", OptionID),
                                          new e2Data("Variant_PropertyID", _variant_propertyid),
                                          new e2Data("Option_Name", tbx_AddOption_Name.Text),
                                          new e2Data("Option_Value", tbx_AddOption_Value.Text),
                                          new e2Data("SortOrder", (myProductVariantMgr.Count_Variant_Property_Option(_variant_propertyid) + 1).ToString()),
                                          new e2Data("IsActive", chkbox_AddOption_IsActive.Checked.ToString())
                                      };

                myProductVariantMgr.Add_Product_Variant_Property_Option(UpdateData);

                Control_FillData_Option();
                RadGrid_Options.Rebind();
            }
        }

        protected void btn_EditOption_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                // Product Variant
                e2Data[] UpdateData = {
                                          new e2Data("OptionID", e.CommandArgument.ToString()),
                                          new e2Data("Option_Name", tbx_EditOption_Name.Text),
                                          new e2Data("Option_Value", tbx_EditOption_Value.Text),
                                          new e2Data("IsActive", chkbox_EditOption_IsActive.Checked.ToString())
                                      };

                myProductVariantMgr.Edit_Product_Variant_Property_Option(UpdateData);

                Control_FillData_Option();
                RadGrid_Options.Rebind();
                MultiView_InputOption.SetActiveView(View_Add);
            }
            
        }

        protected void btn_EditOption_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_InputOption.SetActiveView(View_Add);
        }
    }
}