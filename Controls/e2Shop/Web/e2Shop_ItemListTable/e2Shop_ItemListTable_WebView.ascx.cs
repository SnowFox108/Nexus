using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Shop.Product;

namespace Nexus.Shop
{

    public partial class ItemListTable_WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _e2shop_itemlistid;

        private string _categoryid = "";
        private string _itemdetailurl = "/";
        private string _sortorder = "Product_Title";
        private string _orientation = "ASC";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private string _pagertype = "disable";

        private int _repeatcolumn = 3;
        private int _numberperpage = 12;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string e2Shop_ItemListID
        {
            get
            {
                return _e2shop_itemlistid;
            }
            set
            {
                _e2shop_itemlistid = value;
                ViewState["e2Shop_ItemListID"] = _e2shop_itemlistid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string ItemDetailURL
        {
            get
            {
                return _itemdetailurl;
            }
            set
            {
                _itemdetailurl = value;
                ViewState["ItemDetailURL"] = _itemdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Product_Title")]
        [Localizable(true)]
        public string SortOrder
        {
            get
            {
                return _sortorder;
            }
            set
            {
                _sortorder = value;
                ViewState["SortOrder"] = _sortorder;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("ASC")]
        [Localizable(true)]
        public string Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                ViewState["Orientation"] = _orientation;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string ItemTemplate
        {
            get
            {
                return _itemtemplate;
            }
            set
            {
                _itemtemplate = value;
                ViewState["ItemTemplate"] = _itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ItemTemplateURL
        {
            get
            {
                return _itemtemplateurl;
            }
            set
            {
                _itemtemplateurl = value;
                ViewState["ItemTemplateURL"] = _itemtemplateurl;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("3")]
        [Localizable(true)]
        public int RepeatColumn
        {
            get
            {
                return _repeatcolumn;
            }
            set
            {
                _repeatcolumn = value;
                ViewState["RepeatColumn"] = _repeatcolumn;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("disable")]
        [Localizable(true)]
        public string PagerType
        {
            get
            {
                return _pagertype;
            }
            set
            {
                _pagertype = value;
                ViewState["PagerType"] = _pagertype;
            }
        }


        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("12")]
        [Localizable(true)]
        public int NumberPerPage
        {
            get
            {
                return _numberperpage;
            }
            set
            {
                _numberperpage = value;
                ViewState["NumberPerPage"] = _numberperpage;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _e2shop_itemlistid = ViewState["e2Shop_ItemListID"].ToString();
                _categoryid = ViewState["CategoryID"].ToString();
                _itemdetailurl = ViewState["ItemDetailURL"].ToString();
                _sortorder = ViewState["SortOrder"].ToString();
                _orientation = ViewState["Orientation"].ToString();

                _itemtemplate = ViewState["ItemTemplate"].ToString();
                _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                _pagertype = ViewState["PagerType"].ToString();

                _repeatcolumn = Convert.ToInt16(ViewState["RepeatColumn"]);
                _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
            }
            catch
            {
                // nothing to do
            }

            Control_Init();
        }

        private void Control_Init()
        {

            if (!DataEval.IsEmptyQuery(_e2shop_itemlistid))
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_e2Shop_ItemList.Enabled = false;
                    Panel_PagerTop.Enabled = false;
                    Panel_PagerBottom.Enabled = false;
                }

                #region Get client request

                int pagenum;
                if (DataEval.IsEmptyQuery(Request.QueryString["PageNum"]))
                {
                    pagenum = 1;
                }
                else
                {
                    pagenum = Convert.ToInt16(Request.QueryString["PageNum"]);
                }



                #endregion


                // Init List View
                ListView_e2Shop_ItemList.GroupItemCount = _repeatcolumn;

                ProductSearchMgr myProductSearchMgr = new ProductSearchMgr();

                ListView_e2Shop_ItemList.DataSource = myProductSearchMgr.Get_Product_Search(
                    "",
                    "",
                    "",
                    _categoryid,
                    "",
                    true.ToString(),
                    true.ToString(),
                    _sortorder,
                    _orientation,
                    pagenum,
                    _numberperpage);

                ListView_e2Shop_ItemList.DataKeyNames = new string[] { "Ebay_ItemID" };

                Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                switch (_itemtemplate)
                {
                    case "Default":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Default.ascx";
                        break;
                    case "Custom":
                        myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                        break;
                    default:
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Default.ascx";
                        break;
                }

                myItemTemplate.Set_Separator("");
                myItemTemplate.Set_DataEmpty("");

                ListView_e2Shop_ItemList.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);
                ListView_e2Shop_ItemList.AlternatingItemTemplate = Page.LoadTemplate(myItemTemplate.AltPath);

                if (!DataEval.IsEmptyQuery(myItemTemplate.Separator))
                    ListView_e2Shop_ItemList.ItemSeparatorTemplate = Page.LoadTemplate(myItemTemplate.Separator);

                if (!DataEval.IsEmptyQuery(myItemTemplate.DataEmpty))
                    ListView_e2Shop_ItemList.EmptyDataTemplate = Page.LoadTemplate(myItemTemplate.DataEmpty);

                try
                {
                    ListView_e2Shop_ItemList.DataBind();
                }
                catch
                {
                    // Load Template Failed
                }

                DataPager_e2Shop_ItemList.PageSize = _numberperpage;

            }

        }

        protected void ListView_e2Shop_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_e2Shop_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();

        }

    }
}