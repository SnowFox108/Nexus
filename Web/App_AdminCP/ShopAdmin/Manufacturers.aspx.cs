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

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Manufacturers : System.Web.UI.Page
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
            tbx_AddMF_Name.Text = "";
            tbx_AddMF_Logo.Text = "";
            tbx_AddMF_URL.Text = "";
            chkbox_AddMF_IsActive.Checked = true;

            tbx_EditMF_Name.Text = "";
            tbx_EditMF_Logo.Text = "";
            tbx_EditMF_URL.Text = "";
            chkbox_EditMF_IsActive.Checked = true;

        }

        private void Control_Init()
        {
            ProductMgr myProductMgr = new ProductMgr();

            GridView_Manufacturers.DataSource = myProductMgr.Get_Manufacturers();
            GridView_Manufacturers.DataBind();

            MultiView_Manufacturer.SetActiveView(View_Add);

        }

        protected void GridView_Product_Variants_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton myDeleteLink = (LinkButton)e.Row.FindControl("lbtn_Delete");

                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete manufactrur \"{0}\" ?');", DataBinder.Eval(e.Row.DataItem, "Name"));
            }

        }

        protected void GridView_Product_Variants_Sorting(object sender, GridViewSortEventArgs e)
        {
            ProductMgr myProductMgr = new ProductMgr();

            GridView_Manufacturers.DataSource = myProductMgr.Get_Manufacturers(e.SortExpression);
            GridView_Manufacturers.DataBind();

        }



        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                Control_FillData();

                ProductMgr myProductMgr = new ProductMgr();

                Manufacturer myManufacturer = myProductMgr.Get_Manufacturer(e.CommandArgument.ToString());

                tbx_EditMF_Name.Text = myManufacturer.Name;
                tbx_EditMF_Logo.Text = myManufacturer.Logo;
                tbx_EditMF_URL.Text = myManufacturer.URL;
                chkbox_EditMF_IsActive.Checked = myManufacturer.IsActive;

                btn_EditMF_Update.CommandArgument = myManufacturer.ManufacturerID;

                MultiView_Manufacturer.SetActiveView(View_Edit);

            }

        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {

            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                if (e.CommandArgument.ToString() == "2394DE12-D859-4D38-B8C7-87E33399820C")
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Sorry you can not delete system default manufacturer.</h4>", "Action failed!");
                }
                else
                {
                    ProductMgr myProductMgr = new ProductMgr();

                    if (myProductMgr.Chk_Manufacturer_usage(e.CommandArgument.ToString()))
                    {
                        Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected manufacturer already used <br /> Please remove them before apply this action.</h4>", "Action failed!");

                    }
                    else
                    {

                        myProductMgr.Remove_Manufacturer(e.CommandArgument.ToString());

                        Control_Init();
                    }
                }
            }


        }

        protected void btn_AddMF_Create_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ManufacturerID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                ProductMgr myProductMgr = new ProductMgr();

                e2Data[] UpdateData = {
                                          new e2Data("ManufacturerID", ManufacturerID),
                                          new e2Data("Name", tbx_AddMF_Name.Text),
                                          new e2Data("Logo", tbx_AddMF_Logo.Text),
                                          new e2Data("URL", tbx_AddMF_URL.Text),
                                          new e2Data("IsActive", chkbox_AddMF_IsActive.Checked.ToString())
                                      };

                myProductMgr.Add_Manufacturer(UpdateData);

                Control_FillData();
                Control_Init();

            }
        }

        protected void btn_EditMF_Update_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductMgr myProductMgr = new ProductMgr();

                e2Data[] UpdateData = {
                                          new e2Data("ManufacturerID", e.CommandArgument.ToString()),
                                          new e2Data("Name", tbx_EditMF_Name.Text),
                                          new e2Data("Logo", tbx_EditMF_Logo.Text),
                                          new e2Data("URL", tbx_EditMF_URL.Text),
                                          new e2Data("IsActive", chkbox_EditMF_IsActive.Checked.ToString())
                                      };

                myProductMgr.Edit_Manufacturer(UpdateData);

                Control_FillData();
                Control_Init();

            }
        }

        protected void btn_EditMF_Cancel_Click(object sender, EventArgs e)
        {
            Control_FillData();
            Control_Init();
        }
    }
}