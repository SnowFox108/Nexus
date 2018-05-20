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

    public partial class App_AdminCP_ShopAdmin_Variants_PoP_SpliterEditor : System.Web.UI.Page
    {

        private string _variant_spliterid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _variant_spliterid = ViewState["Variant_SpliterID"].ToString();
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
            string Variant_SpliterID = Request["Variant_SpliterID"];

            if (!DataEval.IsEmptyQuery(Variant_SpliterID))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                Variant_Spliter myVariant_Spliter = myProductVariantMgr.Get_Product_Variant_Spliter(Variant_SpliterID);

                _variant_spliterid = myVariant_Spliter.Variant_SpliterID;
                ViewState["Variant_SpliterID"] = _variant_spliterid;

                tbx_Spliter_Name.Text = myVariant_Spliter.Spliter_Name;
            }

        }

        protected void btn_UpdateVariant_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                e2Data[] UpdateData = {
                                              new e2Data("Variant_SpliterID", _variant_spliterid),
                                              new e2Data("Spliter_Name", tbx_Spliter_Name.Text)
                                          };

                myProductVariantMgr.Edit_Product_Variant_Spliter(UpdateData);

                btn_Cancel_Click(sender, e);

            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
        }
    }
}