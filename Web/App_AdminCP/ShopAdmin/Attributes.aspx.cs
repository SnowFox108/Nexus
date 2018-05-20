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
using Nexus.Shop.Product;
using Nexus.Shop.Product.Variant;
using Nexus.Shop.Product.Attribute;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Attributes : System.Web.UI.Page
    {

        string _product_variantid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _product_variantid = ViewState["Product_VariantID"].ToString();
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

        private void Control_FillData()
        {

            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            droplist_AddAttribute_VariantID.Items.Clear();

            droplist_AddAttribute_VariantID.DataSource = myProductVariantMgr.Get_Product_Variants();
            droplist_AddAttribute_VariantID.DataTextField = "Variant_Name";
            droplist_AddAttribute_VariantID.DataValueField = "Product_VariantID";
            droplist_AddAttribute_VariantID.DataBind();
            droplist_AddAttribute_VariantID.SelectedIndex = 0;

            tbx_AddAttribute_Name.Text = "";
            tbx_AddAttribute_Description.Text = "";
            chkbox_AddAttribute_IsActive.Checked = true;

            tbx_EditAttribute_Name.Text = "";
            tbx_EditAttribute_Description.Text = "";
            chkbox_EditAttribute_IsActive.Checked = true;


        }

        private void Control_Init()
        {

            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            List<Variant> myVariants = myProductVariantMgr.Get_Product_Variants();

            DataList_VariantList.DataSource = myVariants;
            DataList_VariantList.DataBind();


            if (DataEval.IsEmptyQuery(_product_variantid))
            {
                _product_variantid = myVariants[0].Product_VariantID;
                ViewState["Product_VariantID"] = _product_variantid;
            }

            ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

            GridView_Attributes.DataSource = myProductAttributeMgr.Get_Product_Attribute_Types(_product_variantid);
            GridView_Attributes.DataBind();

            lbl_Variant.Text = myProductVariantMgr.Get_Product_Variant(_product_variantid).Variant_Name;

            MultiView_Attribute.SetActiveView(View_VariantList);

        }

        #region Attribute GridView

        protected void GridView_Attributes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton myDeleteLink = (LinkButton)e.Row.FindControl("lbtn_Delete");

                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete attribute \"{0}\" ?');", DataBinder.Eval(e.Row.DataItem, "Attribute_Name"));
            }

        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                Control_FillData();

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                Attribute_Type myAttribute_Type = myProductAttributeMgr.Get_Product_Attribute_Type(e.CommandArgument.ToString());

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                lbl_editAttribute_VariantID.Text = myProductVariantMgr.Get_Product_Variant(myAttribute_Type.Product_VariantID).Variant_Name;

                tbx_EditAttribute_Name.Text = myAttribute_Type.Attribute_Name;
                tbx_EditAttribute_Description.Text = myAttribute_Type.Description;
                chkbox_EditAttribute_IsActive.Checked = myAttribute_Type.IsActive;

                btn_EditAttribute_Update.CommandArgument = myAttribute_Type.Attribute_TypeID;

                MultiView_Attribute.SetActiveView(View_Edit);

            }

        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                if (myProductAttributeMgr.Chk_Attribute_usage(e.CommandArgument.ToString()))
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected attribute already used <br /> Please remove them before apply this action.</h4>", "Action failed!");

                }
                else
                {

                    myProductAttributeMgr.Remove_Product_Attribute_Type(e.CommandArgument.ToString());

                    Control_Init();
                }

            }
        }

        #endregion

        protected void lbtn_Variant_Select_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                _product_variantid = e.CommandArgument.ToString();
                ViewState["Product_VariantID"] = _product_variantid;

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();
                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                lbl_Variant.Text = myProductVariantMgr.Get_Product_Variant(_product_variantid).Variant_Name;

                GridView_Attributes.DataSource = myProductAttributeMgr.Get_Product_Attribute_Types(_product_variantid);
                GridView_Attributes.DataBind();


            }
        }

        protected void btn_Add_Atrribute_Click(object sender, EventArgs e)
        {
            MultiView_Attribute.SetActiveView(View_Add);
        }


        protected void btn_AddAttribute_Create_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Attribute_TypeID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                e2Data[] UpdateData = {
                                          new e2Data("Attribute_TypeID", Attribute_TypeID),
                                          new e2Data("Product_VariantID", droplist_AddAttribute_VariantID.SelectedValue),
                                          new e2Data("Attribute_Name", tbx_AddAttribute_Name.Text),
                                          new e2Data("Description", tbx_AddAttribute_Description.Text),
                                          new e2Data("IsActive", chkbox_AddAttribute_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Add_Product_Attribute_Type(UpdateData);

                Control_FillData();
                Control_Init();

            }

        }

        protected void btn_EditAttribute_Update_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductAttributeMgr myProductAttributeMgr = new ProductAttributeMgr();

                e2Data[] UpdateData = {
                                          new e2Data("Attribute_TypeID", e.CommandArgument.ToString()),
                                          new e2Data("Attribute_Name", tbx_EditAttribute_Name.Text),
                                          new e2Data("Description", tbx_EditAttribute_Description.Text),
                                          new e2Data("IsActive", chkbox_EditAttribute_IsActive.Checked.ToString())
                                      };

                myProductAttributeMgr.Edit_Product_Attribute_Type(UpdateData);

                Control_FillData();
                Control_Init();

            }

        }

        protected void btn_EditAttribute_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_Attribute.SetActiveView(View_VariantList);
        }

    }
}