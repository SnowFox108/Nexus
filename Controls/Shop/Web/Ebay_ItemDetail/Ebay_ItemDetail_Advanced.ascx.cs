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

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _ebay_itemdetailid;

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _ebay_itemdetailid = ViewState["Ebay_ItemDetailID"].ToString();
                    _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
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

                // Fillup Post Content
                Img_Product.ImageUrl = "/App_Control_Style/Nexus_Ebay/Images/EbaySample.png";
                lbl_Title.Text = "Ebay Item Title...";
                lbl_SubTitle.Text = "Ebay Item Subtitle...";
                lbl_QuantityAvailable.Text = "0";
                lbl_QuantitySold.Text = "0";
                lbl_TotalView_Count.Text = "0";

                Literal_Item_Description.Text = "<p>Your Local Description...</p>";
                Literal_Ebay_Description.Text = "<p>Your Ebay Description...</p>";

            }

        }

    }
}