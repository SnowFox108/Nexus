using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;

namespace Nexus.Shop.Product.Variant
{
    [DataObject(true)]
    public class ProductVariantMgr
    {

        public ProductVariantMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Get and Chk

        public Variant Get_Product_Variant(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Variant(myDP.Get_Product_Variant(Product_VariantID));
        }

        public List<Variant> Get_Product_Variants(string SortOrder = "Variant_Name", string SortDirection = "ASC")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Variants(SortOrder);

            List<Variant> list = new List<Variant>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Variant(myDR));
            }

            return list;

        }

        public Variant_Spliter Get_Product_Variant_Spliter(string Variant_SpliterID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Variant_Spliter(myDP.Get_Product_Variant_Spliter(Variant_SpliterID));
        }

        public List<Variant_Spliter> Get_Product_Variant_Spliters(string Product_VariantID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Variant_Spliters(Product_VariantID, SortOrder);

            List<Variant_Spliter> list = new List<Variant_Spliter>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Variant_Spliter(myDR));
            }

            return list;

        }

        public Variant_Property Get_Product_Variant_Property(string Variant_PropertyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Variant_Property(myDP.Get_Product_Variant_Property(Variant_PropertyID));
        }

        public List<Variant_Property> Get_Product_Variant_Properties(string Product_VariantID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Variant_Properties(Product_VariantID, SortOrder);

            List<Variant_Property> list = new List<Variant_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Variant_Property(myDR));
            }

            return list;

        }

        public List<Variant_Property> Get_Product_Variant_Properties_BySpliterID(string Variant_SpliterID, string SortOrder = "SortOrder")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Variant_Properties_BySpliterID(Variant_SpliterID, SortOrder);

            List<Variant_Property> list = new List<Variant_Property>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Variant_Property(myDR));
            }

            return list;

        }

        public Property_Option Get_Product_Variant_Property_Option (string OptionID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Property_Option(myDP.Get_Product_Variant_Property_Option(OptionID));
        }

        public List<Property_Option> Get_Product_Variant_Property_Options(string Variant_PropertyID, string SortOrder = "SortOrder", string IsActive = "ALL")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Product_Variant_Property_Options(Variant_PropertyID, SortOrder, IsActive);

            List<Property_Option> list = new List<Property_Option>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Property_Option(myDR));
            }

            return list;

        }

        public bool Chk_Product_Variant(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Product_Variant(Product_VariantID);
        }

        public int Count_Variant_Spliter(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Variant_Spliter(Product_VariantID);

        }

        public bool Chk_Variant_Spliter_usage(string Variant_SpliterID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Variant_Spliter_usage(Variant_SpliterID);
        }

        public int Count_Variant_Property(string Variant_SpliterID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Variant_Property(Variant_SpliterID);

        }

        public int Count_Variant_Property_Option(string Variant_PropertyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Variant_Property_Option(Variant_PropertyID);

        }

        #endregion

        #region Add

        public void Add_Product_Variant (e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Variant(UpdateData);
        }

        public void Add_Product_Variant_Spliter(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Variant_Spliter(UpdateData);
        }

        public void Add_Product_Variant_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Variant_Property(UpdateData);
        }

        public void Add_Product_Variant_Property_Option(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Variant_Property_Option(UpdateData);
        }

        public void Add_Product_Detail(List<e2Data> UpdateData, string Table_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Product_Detail(UpdateData, Table_Name);
        }

        #endregion

        #region Edit

        public void Edit_Product_Variant(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Variant(UpdateData);
        }

        public void Edit_Product_Variant_Spliter(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Variant_Spliter(UpdateData);
        }

        public void Edit_Product_Variant_Property(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Variant_Property(UpdateData);
        }

        public void Edit_Product_Variant_Property_Option(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Variant_Property_Option(UpdateData);
        }

        public void Edit_Product_Detail(List<e2Data> UpdateData, string Table_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Product_Detail(UpdateData, Table_Name);
        }

        #endregion

        #region Remove

        public void Remove_Product_Variant(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant(Product_VariantID);
        }

        public void Remove_Product_Variant_Spliter (string Variant_SpliterID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Spliter(Variant_SpliterID);
        }

        public void Remove_Product_Variant_Spliter_ByVariantID(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Spliter_ByVariantID(Product_VariantID);
        }

        public void Remove_Product_Variant_Property(string Variant_PropertyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Property(Variant_PropertyID);
        }

        public void Remove_Product_Variant_Property_ByVariantID(string Product_VariantID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Property_ByVariantID(Product_VariantID);
        }

        public void Remove_Product_Variant_Property_Option(string OptionID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Property_Option(OptionID);
        }

        public void Remove_Product_Variant_Property_Option_ByPropertyID(string Variant_PropertyID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Variant_Property_Option_ByPropertyID(Variant_PropertyID);
        }

        public void Remove_Product_Detail(string ProductID, string Table_Name)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Product_Detail(ProductID, Table_Name);
        }

        #endregion

        #region Functions

        #region Get Customer Product Data

        public DataRow Get_Customer_Product(string Table_Name, string ProductID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Get_Customer_Product(Table_Name, ProductID);
        }


        #endregion

        #region Form Generator

        public void Product_Form_Generator(
            PlaceHolder myPlaceHolder,
            string Product_VariantID,
            Product_FormMode myProduct_FormMode,
            bool IsPostBack,
            string ProductID = "",
            int Width = 195
            )
        {
            Variant myVariant = Get_Product_Variant(Product_VariantID);

            if (!DataEval.IsEmptyQuery(myVariant.Table_Name) && myVariant.Table_Name != "None")
            {

                List<Variant_Spliter> myVariant_Spliters = Get_Product_Variant_Spliters(myVariant.Product_VariantID);

                DataRow myProduct = null;

                if (myProduct_FormMode == Product_FormMode.Edit)
                {
                    myProduct = Get_Customer_Product(myVariant.Table_Name, ProductID);
                }

                // Create Form Table
                Table myProduct_FormTable = new Table();
                myProduct_FormTable.ID = "Table_Product_Property";

                foreach (Variant_Spliter myVariant_Spliter in myVariant_Spliters)
                {
                    // Create Product Variant Spliter
                    TableRow mySpliterRow = new TableRow();
                    TableHeaderCell mySpliterTitle = new TableHeaderCell();

                    mySpliterTitle.Controls.Add(new LiteralControl(string.Format("<h4>{0}</h4>", myVariant_Spliter.Spliter_Name)));
                    mySpliterRow.Cells.Add(mySpliterTitle);
                    myProduct_FormTable.Rows.Add(mySpliterRow);

                    List<Variant_Property> myVariant_Properties = Get_Product_Variant_Properties_BySpliterID(myVariant_Spliter.Variant_SpliterID);

                    foreach (Variant_Property myVariant_Property in myVariant_Properties)
                    {
                        // Create Product Property

                        // Create Titile and Infomation Row
                        TableRow myPropertyRow_Info = new TableRow();

                        TableHeaderCell myPropertyTitle = new TableHeaderCell();
                        myPropertyTitle.Controls.Add(new LiteralControl(myVariant_Property.Property_Name));
                        myPropertyRow_Info.Cells.Add(myPropertyTitle);

                        TableCell myPropertyTooltips = new TableCell();
                        myPropertyTooltips.Controls.Add(new LiteralControl(myVariant_Property.Tooltips));
                        myPropertyRow_Info.Cells.Add(myPropertyTooltips);

                        // Add row to table
                        myProduct_FormTable.Rows.Add(myPropertyRow_Info);

                        // Create Control Row
                        TableRow myPropertyRow_Control = new TableRow();

                        TableCell myPropertyEmpty = new TableCell();
                        myPropertyRow_Control.Cells.Add(myPropertyEmpty);

                        TableCell myPropertyControl = new TableCell();

                        if (myProduct_FormMode == Product_FormMode.Create)
                        {
                            #region Create new Form

                            switch (myVariant_Property.Input_Option)
                            {
                                case Input_Option.TextBox:
                                    Control_TextBox(myPropertyControl, myVariant_Property, IsPostBack, Width, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.NumberBox:
                                    Control_NumberBox(myPropertyControl, myVariant_Property, IsPostBack, Width, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.DropdownList:
                                    Control_DropdownList(myPropertyControl, myVariant_Property, IsPostBack, Width, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.RadioButtonList:
                                    Control_RadioButtonList(myPropertyControl, myVariant_Property, IsPostBack, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.DatePicker:
                                    Control_DatePicker(myPropertyControl, myVariant_Property, IsPostBack, Width, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.CheckBox:
                                    Control_CheckBox(myPropertyControl, myVariant_Property, IsPostBack, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.CheckBoxList:
                                    Control_CheckBoxList(myPropertyControl, myVariant_Property, IsPostBack, myVariant_Property.Default_Value);
                                    break;
                                case Input_Option.ImageURL:
                                    Control_ImageURL(myPropertyControl, myVariant_Property, IsPostBack, Width, myVariant_Property.Default_Value);
                                    break;
                            }

                            #endregion
                        }
                        else if (myProduct_FormMode == Product_FormMode.Edit)
                        {
                            #region Read Data to Edit Form

                            switch (myVariant_Property.Input_Option)
                            {
                                case Input_Option.TextBox:
                                    Control_TextBox(myPropertyControl, myVariant_Property, IsPostBack, Width, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.NumberBox:
                                    Control_NumberBox(myPropertyControl, myVariant_Property, IsPostBack, Width, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.DropdownList:
                                    Control_DropdownList(myPropertyControl, myVariant_Property, IsPostBack, Width, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.RadioButtonList:
                                    Control_RadioButtonList(myPropertyControl, myVariant_Property, IsPostBack, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.DatePicker:
                                    Control_DatePicker(myPropertyControl, myVariant_Property, IsPostBack, Width, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.CheckBox:
                                    Control_CheckBox(myPropertyControl, myVariant_Property, IsPostBack, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.CheckBoxList:
                                    Control_CheckBoxList(myPropertyControl, myVariant_Property, IsPostBack, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                                case Input_Option.ImageURL:
                                    Control_ImageURL(myPropertyControl, myVariant_Property, IsPostBack, Width, myProduct[myVariant_Property.Field_Name].ToString());
                                    break;
                            }

                            #endregion
                        }

                        myPropertyRow_Control.Cells.Add(myPropertyControl);

                        // Add row to table
                        myProduct_FormTable.Rows.Add(myPropertyRow_Control);



                    }
                }

                myPlaceHolder.Controls.Add(myProduct_FormTable);
            }

        }

        private void Control_TextBox(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, int Width, string Default_Value)
        {
            TextBox myTextBox = new TextBox();
            myTextBox.ID = myVariant_Property.Variant_PropertyID;
            myTextBox.Width = Unit.Pixel(Width);
            if (!IsPostBack)
            {
                myTextBox.Text = Default_Value;
            }

            myPropertyControl.Controls.Add(myTextBox);
        }

        private void Control_NumberBox(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, int Width, string Default_Value)
        {
            RadNumericTextBox myRadNumericTextBox = new RadNumericTextBox();
            myRadNumericTextBox.ID = myVariant_Property.Variant_PropertyID;
            myRadNumericTextBox.Width = Unit.Pixel(Width);

            if (!IsPostBack)
            {
                myRadNumericTextBox.Text = Default_Value;
            }

            myPropertyControl.Controls.Add(myRadNumericTextBox);
        }

        private void Control_DropdownList(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, int Width, string Default_Value)
        {
            DropDownList myDropdownList = new DropDownList();
            myDropdownList.ID = myVariant_Property.Variant_PropertyID;
            myDropdownList.Width = Unit.Pixel(Width + 5);

            List<Property_Option> myProperty_Options = Get_Product_Variant_Property_Options(
                myVariant_Property.Variant_PropertyID,
                "SortOrder", true.ToString());

            foreach (Property_Option myProperty_Option in myProperty_Options)
            {
                myDropdownList.Items.Add(new ListItem(myProperty_Option.Option_Name, myProperty_Option.Option_Value));
            }

            if (!IsPostBack)
            {
                if (!DataEval.IsEmptyQuery(Default_Value))
                    myDropdownList.SelectedValue = Default_Value;
                else
                    myDropdownList.SelectedIndex = 0;
            }

            myPropertyControl.Controls.Add(myDropdownList);
        }

        private void Control_RadioButtonList(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, string Default_Value)
        {
            RadioButtonList myRadioButtonList = new RadioButtonList();
            myRadioButtonList.ID = myVariant_Property.Variant_PropertyID;

            List<Property_Option> myProperty_Options = Get_Product_Variant_Property_Options(
                myVariant_Property.Variant_PropertyID,
                "SortOrder", true.ToString());

            foreach (Property_Option myProperty_Option in myProperty_Options)
            {
                myRadioButtonList.Items.Add(new ListItem(myProperty_Option.Option_Name, myProperty_Option.Option_Value));
            }

            if (!IsPostBack)
            {
                if (!DataEval.IsEmptyQuery(Default_Value))
                    myRadioButtonList.SelectedValue = Default_Value;
                else
                    myRadioButtonList.SelectedIndex = 0;
            }

            myPropertyControl.Controls.Add(myRadioButtonList);
        }

        private void Control_DatePicker(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, int Width, string Default_Value)
        {
            RadDatePicker myDatePicker = new RadDatePicker();
            myDatePicker.ID = myVariant_Property.Variant_PropertyID;
            myDatePicker.Width = Unit.Pixel(Width);

            if (!IsPostBack)
            {
                if (!DataEval.IsEmptyQuery(Default_Value))
                    myDatePicker.SelectedDate = Convert.ToDateTime(Default_Value);
                else
                    myDatePicker.SelectedDate = DateTime.Today;
            }

            myPropertyControl.Controls.Add(myDatePicker);
        }

        private void Control_CheckBox(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, string Default_Value)
        {
            CheckBox myCheckBox = new CheckBox();
            myCheckBox.ID = myVariant_Property.Variant_PropertyID;
            myCheckBox.Text = myVariant_Property.Property_Name;

            if (!IsPostBack)
            {
                if (!DataEval.IsEmptyQuery(Default_Value))
                    myCheckBox.Checked = Convert.ToBoolean(Default_Value);
                else
                    myCheckBox.Checked = true;
            }

            myPropertyControl.Controls.Add(myCheckBox);
        }

        private void Control_CheckBoxList(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, string Default_Value)
        {
            CheckBoxList myCheckBoxList = new CheckBoxList();
            myCheckBoxList.ID = myVariant_Property.Variant_PropertyID;

            List<Property_Option> myProperty_Options = Get_Product_Variant_Property_Options(
                myVariant_Property.Variant_PropertyID,
                "SortOrder", true.ToString());

            foreach (Property_Option myProperty_Option in myProperty_Options)
            {
                myCheckBoxList.Items.Add(new ListItem(myProperty_Option.Option_Name, myProperty_Option.Option_Value));
            }

            if (!IsPostBack)
            {
                if (!DataEval.IsEmptyQuery(Default_Value))
                    myCheckBoxList.SelectedValue = Default_Value;
            }

            myPropertyControl.Controls.Add(myCheckBoxList);
        }

        private void Control_ImageURL(TableCell myPropertyControl, Variant_Property myVariant_Property, bool IsPostBack, int Width, string Default_Value)
        {
            TextBox myTextBox = new TextBox();
            myTextBox.ID = myVariant_Property.Variant_PropertyID;
            myTextBox.Width = Unit.Pixel(Width);

            if (!IsPostBack)
            {
                myTextBox.Text = Default_Value;
            }

            myPropertyControl.Controls.Add(myTextBox);
        }

        #endregion

        #region Form Data Insert

        public void Add_Product_Properties(PlaceHolder myPlaceHolder, string Product_VariantID, string ProductID)
        {

            Variant myVariant = Get_Product_Variant(Product_VariantID);

            if (!DataEval.IsEmptyQuery(myVariant.Table_Name) && myVariant.Table_Name != "None")
            {
                List<e2Data> UpdateData = new List<e2Data>();

                // Add Product ID
                UpdateData.Add(new e2Data("ProductID", ProductID));

                // Add dynamic data
                List<Variant_Property> myVariant_Properties = Get_Product_Variant_Properties(Product_VariantID);

                // Find Control
                Table myTable = (Table)myPlaceHolder.FindControl("Table_Product_Property");

                foreach (Variant_Property myVariant_Property in myVariant_Properties)
                {
                    Control myControl = myTable.FindControl(myVariant_Property.Variant_PropertyID);

                    if (myControl != null)
                    {
                        UpdateData.Add(new e2Data(myVariant_Property.Field_Name, Get_Control_Value(myControl, myVariant_Property.Input_Option)));
                    }
                }

                Add_Product_Detail(UpdateData, myVariant.Table_Name);

            }
        }

        public void Edit_Product_Properties(PlaceHolder myPlaceHolder, string Product_VariantID, string ProductID)
        {
            Variant myVariant = Get_Product_Variant(Product_VariantID);

            if (!DataEval.IsEmptyQuery(myVariant.Table_Name) && myVariant.Table_Name != "None")
            {
                List<e2Data> UpdateData = new List<e2Data>();

                // Add Product ID
                UpdateData.Add(new e2Data("ProductID", ProductID));

                // Add dynamic data
                List<Variant_Property> myVariant_Properties = Get_Product_Variant_Properties(Product_VariantID);

                // Find Control
                Table myTable = (Table)myPlaceHolder.FindControl("Table_Product_Property");

                foreach (Variant_Property myVariant_Property in myVariant_Properties)
                {
                    Control myControl = myTable.FindControl(myVariant_Property.Variant_PropertyID);

                    if (myControl != null)
                    {
                        UpdateData.Add(new e2Data(myVariant_Property.Field_Name, Get_Control_Value(myControl, myVariant_Property.Input_Option)));
                    }
                }

                Edit_Product_Detail(UpdateData, myVariant.Table_Name);

            }
        }

        private string Get_Control_Value(Control myControl, Input_Option Control_Option)
        {
            switch (Control_Option)
            {
                case Input_Option.TextBox:
                    TextBox myTextBox = (TextBox)myControl;
                    return myTextBox.Text;
                case Input_Option.NumberBox:
                    RadNumericTextBox myRadNumericTextBox = (RadNumericTextBox)myControl;
                    return myRadNumericTextBox.Text;
                case Input_Option.DropdownList:
                    DropDownList myDropDownList = (DropDownList)myControl;
                    return myDropDownList.SelectedValue;
                case Input_Option.RadioButtonList:
                    RadioButtonList myRadioButtonList = (RadioButtonList)myControl;
                    return myRadioButtonList.SelectedValue;
                case Input_Option.DatePicker:
                    RadDatePicker myRadDatePicker = (RadDatePicker)myControl;
                    return myRadDatePicker.SelectedDate.ToString();
                case Input_Option.CheckBox:
                    CheckBox myCheckBox = (CheckBox)myControl;
                    return myCheckBox.Checked.ToString();
                case Input_Option.CheckBoxList:
                    CheckBoxList myCheckBoxList = (CheckBoxList)myControl;
                    string return_value = "";
                    foreach (ListItem myItem in myCheckBoxList.Items)
                    {
                        if (!DataEval.IsEmptyQuery(return_value))
                            return_value += ",";

                        if (myItem.Selected)
                            return_value += myItem.Value;

                    }
                    return return_value;
                case Input_Option.ImageURL:
                    TextBox myImageURL = (TextBox)myControl;
                    return myImageURL.Text;
                default:
                    return null;
            }

        }

        #endregion

        #endregion

    }
}
