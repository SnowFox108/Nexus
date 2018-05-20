using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Core.Phrases;

namespace Nexus.Controls.Ebay.Management
{
    public partial class EbaySetting : System.Web.UI.UserControl
    {

        bool _isuserinfo = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init_Form();
                Reset_Form();
            }

            Control_Init();

        }

        private void Control_Init()
        {
            Panel_UserInfo.Visible = _isuserinfo;

        }

        private void Init_Form()
        {
            tbx_EbayServerURL.Text = PhraseMgr.Get_Phrase_Value("NexusEbay_Environment_ApiServerUrl");
            tbx_AipToken.Text = PhraseMgr.Get_Phrase_Value("NexusEbay_UserAccount_ApiToken");

            ListItem mySiteCode = new ListItem();
            mySiteCode.Text = PhraseMgr.Get_Phrase_Value("NexusEbay_SiteCode");

            drop_SiteCode.Items.Clear();
            drop_SiteCode.Items.Add(mySiteCode);

            #region Bind Data to droplist
            // Enable user edit mode

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.Ebay_ListType));

            //Creates an ArrayList
            ArrayList myEbay_ListTypes = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.Ebay_ListType myEbay_ListType in enumNames)
            {
                myEbay_ListTypes.Add(new { Value = StringEnum.GetStringValue(myEbay_ListType), Name = myEbay_ListType.ToString() });
            }


            //Bind the ArrayList to your DropDownList             
            droplist_Ebay_ListType.DataSource = myEbay_ListTypes;
            droplist_Ebay_ListType.DataTextField = "Name";
            droplist_Ebay_ListType.DataValueField = "Value";
            droplist_Ebay_ListType.DataBind();
            #endregion

            btn_ShowUserInfo.Visible = true;
            btn_GetUserToken.Visible = false;
            HyperLink_eBayLogin.Visible = false;

        }

        private void Reset_Form()
        {

        }

        protected void btn_ShowUserInfo_Click(object sender, EventArgs e)
        {

            Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

            if (DataEval.IsEmptyQuery(tbx_AipToken.Text))
            {
                string sessionID = myEbayMgr.Generate_UserApiToken();

                if (!DataEval.IsEmptyQuery(sessionID))
                {
                    btn_GetUserToken.CommandArgument = sessionID;
                    btn_GetUserToken.Visible = true;

                    HyperLink_eBayLogin.NavigateUrl = string.Format("{0}&RuName={1}&SessID={2}",
                        PhraseMgr.Get_Phrase_Value("NexusEbay_Environment_SignURL"),
                        PhraseMgr.Get_Phrase_Value("NexusEbay_RuName"),
                        sessionID);
                    HyperLink_eBayLogin.Visible = true;

                    btn_ShowUserInfo.Visible = false;
                }

            }
            else
            {
                lbl_TokenStatus.Text = myEbayMgr.Get_TokenStatus().ToString();

                Lib.Fetch_Ebay_Item myFetech_Ebay_Item = myEbayMgr.Get_MyeBaySellingInfo((Lib.Ebay_ListType)StringEnum.Parse(typeof(Lib.Ebay_ListType), droplist_Ebay_ListType.SelectedValue, true));

                lbl_UserID.Text = myFetech_Ebay_Item.Ebay_UserID;
                lbl_GoodStanding.Text = myFetech_Ebay_Item.Ebay_GoodStanding;
                img_RatingStar.ImageUrl = string.Format("http://p.ebaystatic.com/aw/pics/icon/icon{0}Star_25x25.gif", myFetech_Ebay_Item.Ebay_FeedbackRatingStar);
                lbl_FeedbackScore.Text = myFetech_Ebay_Item.Ebay_FeedbackScore.ToString();
                lbl_FeedbackPositive.Text = myFetech_Ebay_Item.Ebay_FeedbackPositive.ToString();
                lbl_FeedbackNeutral.Text = myFetech_Ebay_Item.Ebay_FeedbackNeutral.ToString();
                lbl_FeedbackNegative.Text = myFetech_Ebay_Item.Ebay_FeedbackNegative.ToString();

                lbl_TotalNumber.Text = myFetech_Ebay_Item.TotalNumber.ToString();
                lbl_EbayListType.Text = droplist_Ebay_ListType.SelectedValue;

                hlink_FetchSelling.Attributes["href"] = "#";
                hlink_FetchSelling.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&Ebay_ListType={1}&Page={2}&TotalItem={3}');",
                    "833B051C-720F-46F5-9B63-4C10FCD7BBC2",
                    droplist_Ebay_ListType.SelectedValue,
                    "1",
                    myFetech_Ebay_Item.TotalNumber);

                _isuserinfo = true;
                Panel_UserInfo.Visible = _isuserinfo;
            }
        }

        protected void btn_GetUserToken_Click(object sender, EventArgs e)
        {
            Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();

            tbx_AipToken.Text = myEbayMgr.Fetch_UserToken(btn_GetUserToken.CommandArgument);

            btn_ShowUserInfo.Visible = true;
            HyperLink_eBayLogin.Visible = false;
            btn_GetUserToken.Visible = false;

        }
    }
}