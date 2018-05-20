using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Gallery.ItemList
{

    public partial class WebView : System.Web.UI.UserControl
    {
        #region Properties

        private string _photo_itemlistid;

        private string _categoryid = "";
        private string _photo_itemdetailurl = "/";
        private string _sortorder = "SortOrder";
        private string _orientation = "ASC";
        private string _displayid = "Default";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _numberperpage = 12;
        private int _totalnumber = 100;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Photo_ItemListID
        {
            get
            {
                return _photo_itemlistid;
            }
            set
            {
                _photo_itemlistid = value;
                ViewState["Photo_ItemListID"] = _photo_itemlistid;
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
        public string Photo_ItemDetailURL
        {
            get
            {
                return _photo_itemdetailurl;
            }
            set
            {
                _photo_itemdetailurl = value;
                ViewState["Photo_ItemDetailURL"] = _photo_itemdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("SortOrder")]
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
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string DisplayID
        {
            get
            {
                return _displayid;
            }
            set
            {
                _displayid = value;
                ViewState["DisplayID"] = _displayid;
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
                    _photo_itemlistid = ViewState["Photo_ItemListID"].ToString();
                    _categoryid = ViewState["CategoryID"].ToString();
                    _photo_itemdetailurl = ViewState["Photo_ItemDetailURL"].ToString();
                    _sortorder = ViewState["SortOrder"].ToString();
                    _orientation = ViewState["Orientation"].ToString();
                    _displayid = ViewState["DisplayID"].ToString();

                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                    _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);

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

            // Enable Photo Manger
            if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
            {
                hlink_Edit_Item.Visible = true;

                hlink_Edit_Item.Attributes["href"] = "#";
                hlink_Edit_Item.Attributes["onclick"] = string.Format(
                    "return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}');",
                    "4979A4B0-3F09-4579-9520-90AC64257116"
                    );

            }
            else
            {
                hlink_Edit_Item.Visible = false;
            }

            // Init Control
            if (!DataEval.IsEmptyQuery(_photo_itemlistid))
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_ItemList.Enabled = false;
                    hlink_Edit_Item.Enabled = false;
                }

                // Init List View   
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();


                ListView_ItemList.DataSource = myPhotoMgr.Get_Photos(_categoryid,
                    _sortorder,
                    _orientation,
                    true.ToString(),
                    _totalnumber,
                    _photo_itemdetailurl,
                    _displayid);

                ListView_ItemList.DataKeyNames = new string[] { "PhotoID" };

                Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                switch (_itemtemplate)
                {
                    case "Default":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Gallery/Templates/ItemList_Default.ascx";
                        break;
                    case "Custom":
                        myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                        break;
                    default:
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Gallery/Templates/ItemList_Default.ascx";
                        break;
                }

                myItemTemplate.Set_DataEmpty("");

                ListView_ItemList.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);
                ListView_ItemList.AlternatingItemTemplate = Page.LoadTemplate(myItemTemplate.AltPath);

                if (!DataEval.IsEmptyQuery(myItemTemplate.DataEmpty))
                    ListView_ItemList.EmptyDataTemplate = Page.LoadTemplate(myItemTemplate.DataEmpty);

                try
                {
                    ListView_ItemList.DataBind();
                }
                catch
                {
                    // Load Template Failed
                }

                DataPager_ItemList.PageSize = _numberperpage;
                DataPager_ItemList.Visible = _enable_pager;

            }

        }

        protected void ListView_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Control_Init();

        }

    }
}