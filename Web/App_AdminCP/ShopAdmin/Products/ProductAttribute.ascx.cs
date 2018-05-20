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
using Nexus.Shop.Product.Attribute;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Products_ProductAttribute : System.Web.UI.UserControl
    {

        #region properties

        private string _productid;
        private string _product_variantid;

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

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Product_VariantID
        {
            get
            {
                if (_product_variantid == null)
                {
                    return "";
                }
                return _product_variantid;
            }
            set
            {
                _product_variantid = value;
                ViewState["Product_VariantID"] = _product_variantid;
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
                    _product_variantid = ViewState["Product_VariantID"].ToString();

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

            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            if (myProductAttributeMgr.Chk_Attribute_type(_product_variantid))
            {

                droplist_Attribute_TypeID.Items.Clear();

                droplist_Attribute_TypeID.DataSource = myProductAttributeMgr.Get_Product_Attribute_Types(_product_variantid);
                droplist_Attribute_TypeID.DataTextField = "Attribute_Name";
                droplist_Attribute_TypeID.DataValueField = "Attribute_TypeID";
                droplist_Attribute_TypeID.DataBind();
                droplist_Attribute_TypeID.SelectedIndex = 0;

                tbx_DisplayText.Text = droplist_Attribute_TypeID.SelectedItem.Text;
                chkbox_IsRequired.Checked = false;

                #region Input Option

                //Gets your enum names and adds it to a string array
                Array enumNames = Enum.GetValues(typeof(Input_Option));

                //Creates an ArrayList
                ArrayList myVariantTypes = new ArrayList();

                //Loop through your string array and poppulates the ArrayList
                foreach (Input_Option myVariant_Type in enumNames)
                {
                    myVariantTypes.Add(new
                    {
                        Value = StringEnum.GetStringValue(myVariant_Type),
                        Name = myVariant_Type.ToString()
                    });
                }

                //Bind the ArrayList to your DropDownList   
                droplist_InputOption.Items.Clear();

                droplist_InputOption.DataSource = myVariantTypes;
                droplist_InputOption.DataTextField = "Name";
                droplist_InputOption.DataValueField = "Value";
                droplist_InputOption.DataBind();

                // Set Default value
                droplist_InputOption.SelectedIndex = 0;

                #endregion

                chkbox_IsActive.Checked = true;

                Panel_Updated.Visible = false;
                btn_Show_AddForm.Enabled = true;
            }
            else
            {
                Panel_Updated.Visible = true;
                btn_Show_AddForm.Enabled = false;
            }

        }

        private void Control_Init()
        {

            RadGrid_Attributes.Rebind();

            MultiView_AttributeForm.SetActiveView(View_Button);
        }

        #region Create & Update Form

        protected void btn_DisplayText_Click(object sender, EventArgs e)
        {
            tbx_DisplayText.Text = droplist_Attribute_TypeID.SelectedItem.Text;
        }

        protected void btn_Show_AddForm_Click(object sender, EventArgs e)
        {
            // Reset Form
            Control_FillData();
            droplist_InputOption.Enabled = true;

            // Reset Buttons
            btn_Add_Attribute.Visible = true;
            btn_Update_Attribute.Visible = false;
            btn_Cancel.Visible = true;

            MultiView_AttributeForm.SetActiveView(View_Form);
        }

        protected void btn_Add_Attribute_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                string Attribute_IndexID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("Attribute_IndexID", Attribute_IndexID),
                                          new e2Data("ProductID", _productid),
                                          new e2Data("Attribute_TypeID", droplist_Attribute_TypeID.SelectedValue),
                                          new e2Data("Display_Text", tbx_DisplayText.Text),
                                          new e2Data("IsRequired", chkbox_IsRequired.Checked.ToString()),
                                          new e2Data("Input_OptionID", droplist_InputOption.SelectedValue),
                                          new e2Data("SortOrder", "0"),
                                          new e2Data("IsActive", chkbox_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Add_Product_AttributeIndex(UpdateData);

                // Create Attribute Options
                string AttributeID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData_Option = {
                                          new e2Data("AttributeID", AttributeID),
                                          new e2Data("Attribute_IndexID", Attribute_IndexID),
                                          new e2Data("Attribute_Name", "Default Option"),
                                          new e2Data("IsPreSelected", true.ToString()),
                                          new e2Data("Price_Adjustment", "0.00"),
                                          new e2Data("Weight_Adjustment", "0.00"),
                                          new e2Data("SortOrder", "1"),
                                          new e2Data("IsActive", true.ToString())
                                      };

                myProductAttributeMgr.Add_Product_Attribute(UpdateData_Option);

                Control_Init();

                MultiView_AttributeForm.SetActiveView(View_Button);

            }
        }

        protected void btn_Update_Attribute_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                e2Data[] UpdateData = {
                                          new e2Data("Attribute_IndexID", e.CommandArgument.ToString()),
                                          new e2Data("Attribute_TypeID", droplist_Attribute_TypeID.SelectedValue),
                                          new e2Data("Display_Text", tbx_DisplayText.Text),
                                          new e2Data("IsRequired", chkbox_IsRequired.Checked.ToString()),
                                          new e2Data("Input_OptionID", droplist_InputOption.SelectedValue),
                                          new e2Data("IsActive", chkbox_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Edit_Product_AttributeIndex(UpdateData);

                Control_Init();

                MultiView_AttributeForm.SetActiveView(View_Button);

            }

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_AttributeForm.SetActiveView(View_Button);
        }

        #endregion

        #region RadGrid Actions

        protected void RadGrid_Attributes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            RadGrid_Attributes.DataSource = myProductAttributeMgr.Get_Product_AttributeIndexes(_productid, true);

        }

        protected void RadGrid_Attributes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("Attribute_IndexID").ToString();

                HyperLink myAddOptionLink = (HyperLink)myItem["TemplateColumn_Actions"].FindControl("hlink_Edit_AttributeOption");
                myAddOptionLink.Attributes["href"] = "#";
                myAddOptionLink.Attributes["onclick"] = string.Format("return Show_ControlManager('Products/PoP_AttributeOptions.aspx?Attribute_IndexID={0}');", myItemID);

            }
        }

        protected void RadGrid_Attributes_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (e.DestDataItem != null
                && string.IsNullOrEmpty(e.HtmlElement)
                && e.DestDataItem.OwnerGridID == RadGrid_Attributes.ClientID)
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                List<AttributeIndex> myAttributeIndexs = myProductAttributeMgr.Get_Product_AttributeIndexes(_productid);

                AttributeIndex draggedAttributeIndex = Get_AttributeIndex_in_List(myAttributeIndexs, e.DraggedItems[0].GetDataKeyValue("Attribute_IndexID").ToString());
                AttributeIndex destAttributeIndex = Get_AttributeIndex_in_List(myAttributeIndexs, e.DestDataItem.GetDataKeyValue("Attribute_IndexID").ToString());

                int destIndex = myAttributeIndexs.IndexOf(destAttributeIndex);

                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    destIndex -= 1;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    destIndex += 1;
                }

                myAttributeIndexs.Remove(draggedAttributeIndex);
                myAttributeIndexs.Insert(destIndex, draggedAttributeIndex);

                foreach (AttributeIndex AttributeIndex in myAttributeIndexs)
                {
                    // Product Variant
                    e2Data[] UpdateData = {
                                                      new e2Data("Attribute_IndexID", AttributeIndex.Attribute_IndexID),
                                                      new e2Data("SortOrder", (myAttributeIndexs.IndexOf(Get_AttributeIndex_in_List(myAttributeIndexs, AttributeIndex.Attribute_IndexID)) + 1).ToString())
                                                  };

                    myProductAttributeMgr.Edit_Product_AttributeIndex(UpdateData);

                }

                RadGrid_Attributes.Rebind();

            }

        }

        private static AttributeIndex Get_AttributeIndex_in_List(IEnumerable<AttributeIndex> list, string attribute_indexid)
        {
            foreach (AttributeIndex myAttributeIndex in list)
            {
                if (myAttributeIndex.Attribute_IndexID == attribute_indexid)
                {
                    return myAttributeIndex;
                }
            }

            return null;
        }

        protected void lbtn_Edit_Attribute_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                AttributeIndex myAttributeIndex = myProductAttributeMgr.Get_Product_AttributeIndex(e.CommandArgument.ToString());

                droplist_Attribute_TypeID.SelectedValue = myAttributeIndex.Attribute_TypeID;
                tbx_DisplayText.Text = myAttributeIndex.Display_Text;
                chkbox_IsRequired.Checked = myAttributeIndex.IsRequired;
                droplist_InputOption.SelectedValue = StringEnum.GetStringValue(myAttributeIndex.Input_Option);
                droplist_InputOption.Enabled = false;
                chkbox_IsActive.Checked = myAttributeIndex.IsActive;

                btn_Add_Attribute.Visible = false;
                btn_Update_Attribute.Visible = true;
                btn_Update_Attribute.CommandArgument = myAttributeIndex.Attribute_IndexID;
                btn_Cancel.Visible = true;

                MultiView_AttributeForm.SetActiveView(View_Form);

            }
        }

        #endregion

    }
}