using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.Ebay.ControlPanel
{

    public partial class FetchItem : System.Web.UI.UserControl
    {
        private Lib.Ebay_ListType myEbay_ListType;
        private int pagesize = 10;
        private int pagenum;
        private int totalitem;
        private int fetchfrom;
        private int fetchto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                myEbay_ListType = (Lib.Ebay_ListType)Enum.Parse(typeof(Lib.Ebay_ListType), ViewState["Ebay_ListType"].ToString(), true);
                pagenum = Convert.ToInt16(ViewState["PageNum"]);
                totalitem = Convert.ToInt16(ViewState["TotalItem"]);
            }
            else
            {
                Control_Init();
            }

            Show_Progress();
        }

        private void Control_Init()
        {

            myEbay_ListType = (Lib.Ebay_ListType)Enum.Parse(typeof(Lib.Ebay_ListType), Request["Ebay_ListType"], true);
            ViewState["Ebay_ListType"] = myEbay_ListType;

            pagenum = Convert.ToInt16(Request["Page"]);
            ViewState["PageNum"] = pagenum;

            totalitem = Convert.ToInt16(Request["TotalItem"]);
            ViewState["TotalItem"] = totalitem;

            Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
            myEbayMgr.Reset_Local_EbayTable(myEbay_ListType);

        }

        private void Show_Progress()
        {
            fetchfrom = (pagenum - 1) * pagesize + 1;
            fetchto = pagenum * pagesize;

            if (fetchto > totalitem)
                fetchto = totalitem;

            if (fetchfrom > totalitem)
            {
                lbl_FetchInfo.Text = string.Format("Total {0} items are imported from Ebay. Process complete!", fetchto.ToString());
                lbtn_Submit.Visible = true;
            }
            else
            {
                // Show progress bar
                int complete_percent = 500;
                int percent = Convert.ToInt16((Convert.ToDouble(fetchto) / Convert.ToDouble(totalitem)) * complete_percent);
                Panel_Progress.Width = percent;

                percent = Convert.ToInt16((Convert.ToDouble(fetchto) / Convert.ToDouble(totalitem)) * 100);
                lbl_percent.Text = percent.ToString() + "%";

                lbl_FetchInfo.Text = string.Format("Getting Item {0} - {1}, Total {2} Items", fetchfrom, fetchto, totalitem);
                lbtn_Submit.Visible = false;
            }

        }

        protected void Timer_UpdatePanel_Tick(object sender, EventArgs e)
        {
            Timer_UpdatePanel.Enabled = false;

            if (fetchfrom <= totalitem)
            {
                Lib.EbayMgr myEbayMgr = new Lib.EbayMgr();
                myEbayMgr.Fetch_MyeBayItems(myEbay_ListType, pagenum, pagesize, totalitem);
                System.Threading.Thread.Sleep(1000);

                pagenum++;
                ViewState["PageNum"] = pagenum;

                Timer_UpdatePanel.Enabled = true;
            }
            else
            {
                lbl_FetchInfo.Text = string.Format("Total {0} items are imported from Ebay. Process complete!", fetchto.ToString());
                lbtn_Submit.Visible = true;
            }


           //string url = string.Format("/App_AdminCP/SiteAdmin/ControlPanel.aspx?ControlID={0}&Ebay_ListType={1}&Page={2}&TotalItem={3}",
           //     "833B051C-720F-46F5-9B63-4C10FCD7BBC2",
           //     myEbay_ListType.ToString(),
           //     pagenum + 1,
           //     totalitem);

            //Response.Redirect(url);
        }


        private void Page_Init()
        {


        }

        protected void lbtn_Submit_Click(object sender, EventArgs e)
        {
            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
        }

    }
}