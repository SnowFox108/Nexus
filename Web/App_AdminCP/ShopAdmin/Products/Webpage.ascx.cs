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

    public partial class App_AdminCP_ShopAdmin_Products_Webpage : System.Web.UI.UserControl
    {

        #region properties

        private string _productid;
        private string _webpageid;

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
                    _webpageid = ViewState["WebPageID"].ToString();

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

            WebPage myWebPage = myProductMgr.Get_WebPages(_productid)[0];

            _webpageid = myWebPage.WebPageID;
            ViewState["WebPageID"] = _webpageid;

            tbx_Meta_Title.Text = myWebPage.Meta_Title;
            tbx_Meta_Keywords.Text = myWebPage.Meta_Keywords;
            tbx_Meta_Description.Text = myWebPage.Meta_Description;

            tbx_Page_Title.Text = myWebPage.Page_Title;
            TextEditor_Overview.Content = myWebPage.Overview;
            TextEditor_Content.Content = myWebPage.Description;

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
                                          new e2Data("WebPageID", _webpageid),
                                          new e2Data("Meta_Title", tbx_Meta_Title.Text),
                                          new e2Data("Meta_Keywords", tbx_Meta_Keywords.Text),
                                          new e2Data("Meta_Description", tbx_Meta_Description.Text),
                                          new e2Data("Page_Title", tbx_Page_Title.Text),
                                          new e2Data("Overview", TextEditor_Overview.Content),
                                          new e2Data("Description", TextEditor_Content.Content)
                                      };

                ProductMgr myProductMgr = new ProductMgr();
                myProductMgr.Edit_WebPage(UpdateData);

                Panel_Updated.Visible = true;
            }

        }
}
}