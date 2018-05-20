using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Ebay.ItemList
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _ebay_itemlistid;

        private string _categoryid = "";
        private string _ebay_listtype = "ActiveList";
        private string _ebay_itemdetailurl = "/";
        private string _sortorder = "Ebay_Title";
        private string _orientation = "ASC";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _repeatcolumn = 3;
        private int _numberperpage = 12;
        private int _totalnumber = 100;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Ebay_ItemListID
        {
            get
            {
                return _ebay_itemlistid;
            }
            set
            {
                _ebay_itemlistid = value;
                ViewState["Ebay_ItemListID"] = _ebay_itemlistid;
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
        public string Ebay_ItemDetailURL
        {
            get
            {
                return _ebay_itemdetailurl;
            }
            set
            {
                _ebay_itemdetailurl = value;
                ViewState["Ebay_ItemDetailURL"] = _ebay_itemdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Ebay_Title")]
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
        [DefaultValue("true")]
        [Localizable(true)]
        public bool Enable_Pager
        {
            get
            {
                return _enable_pager;
            }
            set
            {
                _enable_pager = value;
                ViewState["Enable_Pager"] = _enable_pager;
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

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("100")]
        [Localizable(true)]
        public int TotalNumber
        {
            get
            {
                return _totalnumber;
            }
            set
            {
                _totalnumber = value;
                ViewState["TotalNumber"] = _totalnumber;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _ebay_itemlistid = ViewState["Ebay_ItemListID"].ToString();
                    _categoryid = ViewState["CategoryID"].ToString();
                    _ebay_itemdetailurl = ViewState["Ebay_ItemDetailURL"].ToString();
                    _sortorder = ViewState["SortOrder"].ToString();
                    _orientation = ViewState["Orientation"].ToString();

                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                    _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);

                    _repeatcolumn = Convert.ToInt16(ViewState["RepeatColumn"]);
                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
                    _totalnumber = Convert.ToInt16(ViewState["TotalNumber"]);
                }
                catch
                {
                    // nothing to do
                }
            }

            Control_Init();

        }

        private void Control_Init()
        {

            if (!DataEval.IsEmptyQuery(_ebay_itemlistid))
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_Ebay_ItemList.Enabled = false;
                }

                // Init List View
                ListView_Ebay_ItemList.GroupItemCount = _repeatcolumn;

                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

                ListView_Ebay_ItemList.DataSource = myEbayMgr.Get_Ebay_Items(_categoryid, _ebay_listtype, _sortorder, _orientation, "1", "1", _totalnumber, _ebay_itemdetailurl);
                ListView_Ebay_ItemList.DataKeyNames = new string[] { "Ebay_ItemID" };

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

                ListView_Ebay_ItemList.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);
                ListView_Ebay_ItemList.AlternatingItemTemplate = Page.LoadTemplate(myItemTemplate.AltPath);

                if (!DataEval.IsEmptyQuery(myItemTemplate.Separator))
                    ListView_Ebay_ItemList.ItemSeparatorTemplate = Page.LoadTemplate(myItemTemplate.Separator);

                if (!DataEval.IsEmptyQuery(myItemTemplate.DataEmpty))
                    ListView_Ebay_ItemList.EmptyDataTemplate = Page.LoadTemplate(myItemTemplate.DataEmpty);

                try
                {
                    ListView_Ebay_ItemList.DataBind();
                }
                catch
                {
                    // Load Template Failed
                }

                DataPager_Ebay_ItemList.PageSize = _numberperpage;
                DataPager_Ebay_ItemList.Visible = _enable_pager;

            }

        }

        //private string Get_ItemTemplatePath(string _path, string _returnpath, string _appex)
        //{
        //    if (_path.Length > 5)
        //    {
        //        string _filename = Path.GetFileNameWithoutExtension(_path);
        //        string _filepath = _path.Substring(0, _path.LastIndexOf("/"));
        //        string _altpath = _filename + _appex + ".ascx";

        //        if (File.Exists(Server.MapPath(_altpath)))
        //        {
        //            _altpath = _filepath + "/" + _altpath;
        //            return _altpath;
        //        }
        //        else
        //        {
        //            return _returnpath;
        //        }
        //    }
        //    else
        //    {
        //        return _returnpath;
        //    }
        //}

        //protected void ListView_Ebay_ItemList_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
            //HiddenField HiddenField_Ebay_ItemID = (HiddenField)e.Item.FindControl("HiddenField_Ebay_ItemID");
            //HiddenField HiddenField_Ebay_Title = (HiddenField)e.Item.FindControl("HiddenField_Ebay_Title");
            //HiddenField HiddenField_Ebay_SubTitle = (HiddenField)e.Item.FindControl("HiddenField_Ebay_SubTitle");
            //HiddenField HiddenField_Ebay_Picture = (HiddenField)e.Item.FindControl("HiddenField_Ebay_Picture");
            //HiddenField HiddenField_Ebay_Gallery = (HiddenField)e.Item.FindControl("HiddenField_Ebay_Gallery");
            //HiddenField HiddenField_Ebay_Description = (HiddenField)e.Item.FindControl("HiddenField_Ebay_Description");
            //HiddenField HiddenField_Item_Description = (HiddenField)e.Item.FindControl("HiddenField_Item_Description");
            //HiddenField HiddenField_Currency_Web = (HiddenField)e.Item.FindControl("HiddenField_Currency_Web");
            //HiddenField HiddenField_CurrentPrice = (HiddenField)e.Item.FindControl("HiddenField_CurrentPrice");
            //HiddenField HiddenField_BuyItNowPrice = (HiddenField)e.Item.FindControl("HiddenField_BuyItNowPrice");
            //HiddenField HiddenField_StartTime = (HiddenField)e.Item.FindControl("HiddenField_StartTime");
            //HiddenField HiddenField_EndTime = (HiddenField)e.Item.FindControl("HiddenField_EndTime");
            //HiddenField HiddenField_QuantityAvailable = (HiddenField)e.Item.FindControl("HiddenField_QuantityAvailable");
            //HiddenField HiddenField_QuantitySold = (HiddenField)e.Item.FindControl("HiddenField_QuantitySold");
            //HiddenField HiddenField_Total_ViewCount = (HiddenField)e.Item.FindControl("HiddenField_Total_ViewCount");
            //HiddenField HiddenField_ViewItemURL = (HiddenField)e.Item.FindControl("HiddenField_ViewItemURL");

            //PlaceHolder PlaceHolder_ItemTemplate = (PlaceHolder)e.Item.FindControl("PlaceHolder_ItemTemplate");

            //string[] ItemPicutreURLs = HiddenField_Ebay_Picture.Value.Split(new string[] { "||" }, StringSplitOptions.None);

            //switch (_itemtemplate)
            //{
            //    case "Default":
            //        Lib.ItemTemplates.Default(
            //            PlaceHolder_ItemTemplate,
            //            HiddenField_Ebay_ItemID.Value,
            //            ItemPicutreURLs[0],
            //            HiddenField_Ebay_Title.Value,
            //            HiddenField_Ebay_SubTitle.Value,
            //            _ebay_itemdetailurl
            //            );
            //        break;
            //}

        //}

        protected void ListView_Ebay_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_Ebay_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();

        }
    }
}