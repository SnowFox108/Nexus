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

    public partial class App_AdminCP_ShopAdmin_Variants_Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_FillData();
                Control_Init();
            }

        }

        private void Control_FillData()
        {
            #region Create Variant

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Variant_Type));

            //Creates an ArrayList
            ArrayList myVariantTypes = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Variant_Type myVariant_Type in enumNames)
            {
                myVariantTypes.Add(new 
                { 
                    Value = StringEnum.GetStringValue(myVariant_Type),
                    Name = StringEnum.GetStringValue(myVariant_Type) 
                });
            }

            //Bind the ArrayList to your DropDownList             
            droplist_Variant_Type.DataSource = myVariantTypes;
            droplist_Variant_Type.DataTextField = "Name";
            droplist_Variant_Type.DataValueField = "Value";
            droplist_Variant_Type.DataBind();

            // Set Default value
            droplist_Variant_Type.SelectedIndex = 0;

            tbx_Variant_Name.Text = "";
            tbx_Table_Name.Text = "";

            #endregion

        }

        private void Control_Init()
        {

            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            GridView_Product_Variants.DataSource = myProductVariantMgr.Get_Product_Variants();
            GridView_Product_Variants.DataBind();

        }

        protected void GridView_Product_Variants_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton myDeleteLink = (LinkButton)e.Row.FindControl("lbtn_Delete");

                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete variant \"{0}\" ?');", DataBinder.Eval(e.Row.DataItem, "Variant_Name"));
            }
        }

        protected void GridView_Product_Variants_Sorting(object sender, GridViewSortEventArgs e)
        {
            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            GridView_Product_Variants.DataSource = myProductVariantMgr.Get_Product_Variants(e.SortExpression, e.SortDirection.ToString());
            GridView_Product_Variants.DataBind();

        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Product_VariantID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                e2Data[] UpdateData = {
                                          new e2Data("Product_VariantID", Product_VariantID),
                                          new e2Data("Variant_Name", tbx_Variant_Name.Text),
                                          new e2Data("Variant_Type", droplist_Variant_Type.SelectedValue),
                                          new e2Data("Table_Name", tbx_Table_Name.Text)
                                      };

                myProductVariantMgr.Add_Product_Variant(UpdateData);

                Control_FillData();
                Control_Init();

            }
        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                Response.Redirect(string.Format("Product_Variant.aspx?Product_VariantID={0}", e.CommandArgument.ToString()));
            }
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductMgr myProductMgr = new ProductMgr();

                if (myProductMgr.Chk_Product_Variant_usage(e.CommandArgument.ToString()))
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected product variant already have products <br /> Please delete them before apply this action.</h4>", "Action failed!");

                }
                else
                {
                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                    myProductVariantMgr.Remove_Product_Variant(e.CommandArgument.ToString());

                    Control_Init();
                }
            }
        }

    }
}