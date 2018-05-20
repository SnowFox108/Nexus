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
    public partial class Advanced : System.Web.UI.UserControl
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

            if (DataEval.IsEmptyQuery(_ebay_itemlistid))
            {
                MultiView_ItemList.SetActiveView(View_New);

            }
            else
            {
                MultiView_ItemList.SetActiveView(View_ItemList);

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_Ebay_ItemList.Enabled = false;
                }

                // Init List View
                ListView_Ebay_ItemList.GroupItemCount = _repeatcolumn;

                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

                ListView_Ebay_ItemList.DataSource = myEbayMgr.Get_Ebay_Items(_categoryid, _ebay_listtype, _sortorder, _orientation, "1", "1", _totalnumber, _ebay_itemdetailurl);
                ListView_Ebay_ItemList.DataKeyNames = new string[] { "Ebay_ItemID" };

                string _path, _altpath, _separator;
                switch (_itemtemplate)
                {
                    case "Default":                        
                        _path = "~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Default.ascx";
                        break;
                    case "Custom":
                        _path = _itemtemplateurl;
                        break;
                    default:
                        _path = "~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Default.ascx";
                        break;
                }

                _altpath = Get_ItemTemplatePath(_path, _path, "_Alt");
                _separator = Get_ItemTemplatePath(_path,
                    "~/App_Control_Style/Nexus_Ebay/Templates/ItemList_Default_Separator.ascx",
                    "Separator");

                ListView_Ebay_ItemList.ItemTemplate = Page.LoadTemplate(_path);
                ListView_Ebay_ItemList.AlternatingItemTemplate = Page.LoadTemplate(_altpath);
                ListView_Ebay_ItemList.ItemSeparatorTemplate = Page.LoadTemplate(_separator);
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

        private string Get_ItemTemplatePath(string _path, string _returnpath, string _appex)
        {
            if (_path.Length > 5)
            {
                string _filename = Path.GetFileNameWithoutExtension(_path);
                string _filepath = _path.Substring(0, _path.LastIndexOf("/"));
                string _altpath = _filename + _appex + ".ascx";

                if (File.Exists(Server.MapPath(_altpath)))
                {
                    _altpath = _filepath + "/" + _altpath;
                    return _altpath;
                }
                else
                {
                    return _returnpath;
                }
            }
            else
            {
                return _returnpath;
            }
        }

        protected void ListView_Ebay_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_Ebay_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();

        }
    }
}