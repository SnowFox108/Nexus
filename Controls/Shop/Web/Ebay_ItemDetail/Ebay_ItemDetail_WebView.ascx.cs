using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Ebay.ItemDetail
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _ebay_itemdetailid;
        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";

        private bool _ispagetitle = true;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Ebay_ItemDetailID
        {
            get
            {
                return _ebay_itemdetailid;
            }
            set
            {
                _ebay_itemdetailid = value;
                ViewState["Ebay_ItemDetailID"] = _ebay_itemdetailid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsPageTitle
        {
            get
            {
                return _ispagetitle;
            }
            set
            {
                _ispagetitle = value;
                ViewState["IsPageTitle"] = _ispagetitle;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _ebay_itemdetailid = ViewState["Ebay_ItemDetailID"].ToString();
                    _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();

                }
                catch
                {
                    // nothing to do
                }

            }
            else
            {
                Control_PreInit();
            }

            Control_Init();

        }

        private void Control_PreInit()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusEbayItemID"]))
            {
                // Add View Count
                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

                Lib.Ebay_Item myEbay_Item = myEbayMgr.Get_Ebay_Item(Request["NexusEbayItemID"]);

                int _view_count = Convert.ToInt32(myEbay_Item.View_Count) + 1;

                e2Data[] UpdateData_Item = {
                                               new e2Data("Ebay_ItemID", myEbay_Item.Ebay_ItemID),
                                               new e2Data("View_Count", _view_count.ToString())
                                           };

                myEbayMgr.Edit_Ebay_Item(UpdateData_Item);
            }

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_ebay_itemdetailid))
            {
                MultiView_ItemDetail.SetActiveView(View_New);
            }
            else
            {

                MultiView_ItemDetail.SetActiveView(View_Detail);

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    hlink_Edit_Item.Enabled = false;
                }

                Lib.Ebay_Item myEbay_Item;

                // Init Comment Form
                if (!DataEval.IsEmptyQuery(Request["NexusEbayItemID"]))
                {

                    Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

                    myEbay_Item = myEbayMgr.Get_Ebay_Item(Request["NexusEbayItemID"]);

                    if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {
                        hlink_Edit_Item.Visible = true;

                        hlink_Edit_Item.Attributes["href"] = "#";
                        hlink_Edit_Item.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusEbayItemID={1}');", "8BF5ABB9-30D5-429E-8017-A168672AC15F", myEbay_Item.Ebay_ItemID);

                    }
                    else
                    {
                        hlink_Edit_Item.Visible = false;
                    }

                    // Page Title
                    if (_ispagetitle)
                        Page.Title = myEbay_Item.Ebay_Title;

                    // Init Form View
                    if (DataEval.IsEmptyQuery(myEbay_Item.Item_PicutreURL))
                        myEbay_Item.Item_PicutreURL = "/App_Control_Style/Nexus_Ebay/Images/EbaySample.png";

                    // Fillup Post Content
                    //lbl_Price.Text = myEbay_Item.Currency_Web + myEbay_Item.CurrentPrice.ToString();
                    //lbl_Title.Text = myEbay_Item.Ebay_Title;
                    //lbl_SubTitle.Text = myEbay_Item.Ebay_SubTitle;
                    //lbl_QuantityAvailable.Text = myEbay_Item.QuantityAvailable.ToString();
                    //lbl_QuantitySold.Text = myEbay_Item.QuantitySold.ToString();
                    //lbl_TotalView_Count.Text = myEbay_Item.Total_View_Count.ToString();

                    //string[] ItemPicutreURLs = myEbay_Item.Ebay_Picture.Split(new string[] { "||" }, StringSplitOptions.None);

                    //if (DataEval.IsEmptyQuery(ItemPicutreURLs[0]))
                    //    Img_Product.ImageUrl = "/App_Control_Style/Nexus_Ebay/Images/EbaySample.png";
                    //else
                    //    Img_Product.ImageUrl = ItemPicutreURLs[0];

                    //hlink_ViewItemURL.NavigateUrl = myEbay_Item.ViewItemURL;

                    //Literal_Item_Description.Text = myEbay_Item.Item_Description;
                    //Literal_Ebay_Description.Text = myEbay_Item.Ebay_Description;

                }
                else
                {
                    // No Post ID
                    myEbay_Item = new Lib.Ebay_Item();

                    hlink_Edit_Item.Visible = false;
                    myEbay_Item.Item_PicutreURL = "/App_Control_Style/Nexus_Ebay/Images/EbaySample.png";

                }

                Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                switch (_itemtemplate)
                {
                    case "Default":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Ebay/Templates/ItemDetail_Default.ascx";
                        break;
                    case "Custom":
                        myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                        break;
                    default:
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Ebay/Templates/ItemDetail_Default.ascx";
                        break;
                }

                FormView_ItemDetail.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);

                List<Lib.Ebay_Item> myEbay_Items = new List<Lib.Ebay_Item>();
                myEbay_Items.Add(myEbay_Item);

                try
                {
                    FormView_ItemDetail.DataSource = myEbay_Items;
                    FormView_ItemDetail.DataKeyNames = new string[] { "Ebay_ItemID" };
                    FormView_ItemDetail.DataBind();

                }
                catch
                {
                    // Load Template Failed
                }

            }

        }

    }
}