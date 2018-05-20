using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Ebay.ItemList
{

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myUserControl = Page.LoadControl("~/Management/Management_EbaySetting.ascx");

            //WebView myControl = (WebView)myUserControl;
            //myControl.Ebay_ItemListID = "66749CCC-64BE-46DF-BA27-0BE7C8776FBE";
            //myControl.CategoryID = "\"" + "73B48270-1307-4A74-89E5-52143E82B9A9" + "\"";
            //myControl.Ebay_ItemDetailURL = "/";
            //myControl.SortOrder = "Ebay_Title";
            //myControl.Orientation = "ASC";
            //myControl.ItemTemplate = "Default";
            //myControl.RepeatColumn = 3;
            //myControl.Enable_Pager = true;
            //myControl.NumberPerPage = 12;
            //myControl.TotalNumber = 100;

            PlaceHolder_Control.Controls.Add(myUserControl);
        }
    }
}