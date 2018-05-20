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

    public partial class App_AdminCP_ShopAdmin_Products_ProductIndex : System.Web.UI.UserControl
    {
        #region properties

        private string _productid;
        private string _product_indexid;

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
        public string Product_IndexID
        {
            get
            {
                if (_product_indexid == null)
                {
                    return "";
                }
                return _product_indexid;
            }
            set
            {
                _product_indexid = value;
                ViewState["Product_IndexID"] = _product_indexid;
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
                    _product_indexid = ViewState["Product_IndexID"].ToString();

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
            ProductMgr myProductMgr = new ProductMgr();

            ProductIndex myProductIndex = myProductMgr.Get_ProductIndex(_product_indexid);

            tbx_Index_Title.Text = myProductIndex.Title;
            tbx_Index_Short_Description.Text = myProductIndex.Short_Description;
            tbx_Index_Admin_Comment.Text = myProductIndex.Admin_Comment;
            chkbox_Index_IsActive.Checked = myProductIndex.IsActive;

            Panel_Updated.Visible = false;
        }

        public void Switch_Panel()
        {
            Panel_Updated.Visible = false;
        }

        private void Control_Init()
        {

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                e2Data[] UpdateData = {
                                          new e2Data("Product_IndexID", _product_indexid),
                                          new e2Data("Title", tbx_Index_Title.Text),
                                          new e2Data("Short_Description", tbx_Index_Short_Description.Text),
                                          new e2Data("Admin_Comment", tbx_Index_Admin_Comment.Text),
                                          new e2Data("IsActive", chkbox_Index_IsActive.Checked.ToString()),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                ProductMgr myProductMgr = new ProductMgr();
                myProductMgr.Edit_ProductIndex(UpdateData);

                Panel_Updated.Visible = true;
            }
        }
    }
}