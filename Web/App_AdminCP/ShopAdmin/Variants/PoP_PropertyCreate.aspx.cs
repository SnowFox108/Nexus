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

    public partial class App_AdminCP_ShopAdmin_Variants_PoP_PropertyCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_FillData();
            }
        }

        private void Control_FillData()
        {
            #region Create Variant

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
            droplist_InputOption.DataSource = myVariantTypes;
            droplist_InputOption.DataTextField = "Name";
            droplist_InputOption.DataValueField = "Value";
            droplist_InputOption.DataBind();

            // Set Default value
            droplist_InputOption.SelectedIndex = 0;

            tbx_Property_Name.Text = "";
            tbx_Default_Value.Text = "";
            tbx_Tooltips.Text = "";
            chkbox_IsRequired.Checked = false;
            chkbox_IsFilter.Checked = false;
            chkbox_IsSort.Checked = false;
            tbx_Field_Name.Text = "";

            #endregion

        }

        protected void btn_CreateProperty_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                string Variant_SpliterID = Request["Variant_SpliterID"];

                if (!DataEval.IsEmptyQuery(Variant_SpliterID))
                {

                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                    Variant_Spliter myVariant_Spliter = myProductVariantMgr.Get_Product_Variant_Spliter(Variant_SpliterID);

                    string Variant_PropertyID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                    e2Data[] UpdateData = {
                                              new e2Data("Variant_PropertyID", Variant_PropertyID),
                                              new e2Data("Product_VariantID", myVariant_Spliter.Product_VariantID),
                                              new e2Data("Variant_SpliterID", myVariant_Spliter.Variant_SpliterID),
                                              new e2Data("Property_Name", tbx_Property_Name.Text),
                                              new e2Data("Input_Option", droplist_InputOption.SelectedValue),
                                              new e2Data("Default_Value", tbx_Default_Value.Text),
                                              new e2Data("Tooltips", tbx_Tooltips.Text),
                                              new e2Data("IsRequired", chkbox_IsRequired.Checked.ToString()),
                                              new e2Data("IsFilter", chkbox_IsFilter.Checked.ToString()),
                                              new e2Data("IsSort", chkbox_IsSort.Checked.ToString()),
                                              new e2Data("SortOrder", (myProductVariantMgr.Count_Variant_Property(myVariant_Spliter.Variant_SpliterID) + 1).ToString()),
                                              new e2Data("Field_Name", tbx_Field_Name.Text)
                                      };

                    myProductVariantMgr.Add_Product_Variant_Property(UpdateData);

                    Input_Option myInput_Option = (Input_Option)StringEnum.Parse(typeof(Input_Option), droplist_InputOption.SelectedValue, true);

                    switch (myInput_Option)
                    {
                        case Input_Option.TextBox:
                            break;
                        case Input_Option.NumberBox:
                            break;
                        case Input_Option.DropdownList:
                            Create_Property_Options(Variant_PropertyID);
                            break;
                        case Input_Option.RadioButtonList:
                            Create_Property_Options(Variant_PropertyID);
                            break;
                        case Input_Option.DatePicker:
                            break;
                        case Input_Option.CheckBox:
                            break;
                        case Input_Option.CheckBoxList:
                            Create_Property_Options(Variant_PropertyID);
                            break;
                        case Input_Option.ImageURL:
                            break;
                    }

                    btn_Cancel_Click(sender, e);
                }
            }
        }

        private void Create_Property_Options(string Variant_PropertyID)
        {

            string OptionID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            e2Data[] UpdateData = {
                                      new e2Data("OptionID", OptionID),
                                      new e2Data("Variant_PropertyID", Variant_PropertyID),
                                      new e2Data("Option_Name", "Default Name"),
                                      new e2Data("Option_Value", "Default Value"),
                                      new e2Data("SortOrder", "1")
                                  };

            myProductVariantMgr.Add_Product_Variant_Property_Option(UpdateData);

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
        }
    }
}