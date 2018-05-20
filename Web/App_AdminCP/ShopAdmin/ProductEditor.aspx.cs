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
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_ProductEditor : System.Web.UI.Page
    {

        #region properties

        private string _productid;

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                try
                {

                    _productid = ViewState["ProductID"].ToString();

                }
                catch
                {
                    // Do nothing
                }

            }
            else
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            _productid = Request["ProductID"];

            if (DataEval.IsNegativeQuery(_productid))
            {
                Response.Redirect("Products.aspx");
            }
            else
            {

                ViewState["ProductID"] = _productid;

                ProductSearchMgr myProductSearchMgr = new ProductSearchMgr();
                Product_Search myProduct_Search = myProductSearchMgr.Get_Product_Search(_productid);

                lbl_Product_Name.Text = string.Format("{0} (ID: {1})", myProduct_Search.Product_Full_Title, myProduct_Search.ProductID);
                img_ItemPicture.ImageUrl = myProduct_Search.Default_PhotoURL;

                ProductIndex_Editor.ProductID = _productid;
                ProductIndex_Editor.Product_IndexID = myProduct_Search.Product_IndexID;

                ProductInfo_Editor.ProductID = _productid;
                
                ProductCategory_Editor.ProductID = _productid;

                ProductAttribute_Editor.ProductID = _productid;
                ProductAttribute_Editor.Product_VariantID = myProduct_Search.Product_VariantID;

                Webpage_Editor.ProductID = _productid;

                Webmedia_Editor.ProductID = _productid;

                MultiView_Product.SetActiveView(View_Index);
                CommandButtons_Reset();
            }
        }

        #region Control Window Event

        protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {

            string[] fields = e.Argument.ToString().Split('^');

            if (fields.Length >= 3)
            {
                Nexus.Core.Tools.PoP_ReturnMsg myReturnMsg = new Nexus.Core.Tools.PoP_ReturnMsg();
                myReturnMsg.Command = fields[0];
                myReturnMsg.ControlID = fields[1];
                myReturnMsg.Value = fields[2];

                Nexus.Core.Tools.PoPWindows.ReturnMsg(Webmedia_Editor, myReturnMsg);
            }

            Referesh_Controls();
        }

        #endregion

        private void CommandButtons_Reset()
        {
            // Reset Button    
            btn_Product_Index.CssClass = "nexusCore_general_btn";
            btn_Product_Info.CssClass = "nexusCore_general_btn";
            btn_Product_Category.CssClass = "nexusCore_general_btn";
            btn_Product_Attribute.CssClass = "nexusCore_general_btn";
            btn_Product_Webpage.CssClass = "nexusCore_general_btn";
            btn_Product_Webmedia.CssClass = "nexusCore_general_btn";


            //// Init Button
            View myActivedView = MultiView_Product.GetActiveView();

            switch (myActivedView.ID)
            {
                case "View_Index":
                    btn_Product_Index.CssClass = "nexusCore_general_btn_selected";
                    break;
                case "View_Info":
                    btn_Product_Info.CssClass = "nexusCore_general_btn_selected";
                    break;
                case "View_Category":
                    btn_Product_Category.CssClass = "nexusCore_general_btn_selected";
                    break;
                case "View_Attribute":
                    btn_Product_Attribute.CssClass = "nexusCore_general_btn_selected";
                    break;
                case "View_Webpage":
                    btn_Product_Webpage.CssClass = "nexusCore_general_btn_selected";
                    break;
                case "View_Webmedia":
                    btn_Product_Webmedia.CssClass = "nexusCore_general_btn_selected";
                    break;
            }

        }

        protected void btn_Product_Index_Click(object sender, EventArgs e)
        {
            ProductIndex_Editor.Switch_Panel();
            MultiView_Product.SetActiveView(View_Index);
            CommandButtons_Reset();
        }

        protected void btn_Product_Info_Click(object sender, EventArgs e)
        {
            ProductInfo_Editor.Switch_Panel();
            MultiView_Product.SetActiveView(View_Info);
            CommandButtons_Reset();
        }

        protected void btn_Product_Category_Click(object sender, EventArgs e)
        {
            MultiView_Product.SetActiveView(View_Category);
            CommandButtons_Reset();
        }

        protected void btn_Product_Attribute_Click(object sender, EventArgs e)
        {
            MultiView_Product.SetActiveView(View_Attribute);
            CommandButtons_Reset();
        }

        protected void btn_Product_Webpage_Click(object sender, EventArgs e)
        {
            Webpage_Editor.Switch_Panel();
            MultiView_Product.SetActiveView(View_Webpage);
            CommandButtons_Reset();
        }

        protected void btn_Product_Webmedia_Click(object sender, EventArgs e)
        {
            MultiView_Product.SetActiveView(View_Webmedia);
            CommandButtons_Reset();
        }

        protected void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void Referesh_Controls()
        {

        }
    }
}