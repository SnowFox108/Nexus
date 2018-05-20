using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PageMenuList : System.Web.UI.UserControl
    {

        #region Properties

        private string _selected_pageindexid;
        private string _page_categoryid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Selected_PageIndexID
        {
            get
            {
                return _selected_pageindexid;
            }
            set
            {
                _selected_pageindexid = value;
                ViewState["Selected_PageIndexID"] = _selected_pageindexid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Page_CategoryID
        {
            get
            {
                return _page_categoryid;
            }
            set
            {
                _page_categoryid = value;
                ViewState["Page_CategoryID"] = _page_categoryid;
            }
        }

        #endregion

        #region Events

        // LinkButton Click Event
        private static readonly object EventPageIndexSelected = new object();

        [Category("Action")]
        [Description("Raised Page Menu Clicked event")]
        public event EventHandler PageIndexSelected
        {
            add
            {
                Events.AddHandler(EventPageIndexSelected, value);
            }
            remove
            {
                Events.RemoveHandler(EventPageIndexSelected, value);
            }
        }

        protected void OnPageIndexSelected(object sender, EventArgs e)
        {
            EventHandler PageIndexSelectedHandler = (EventHandler)Events[EventPageIndexSelected];

            if (PageIndexSelectedHandler != null)
                PageIndexSelectedHandler(sender, e);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            else
            {
                try
                {
                    _selected_pageindexid = ViewState["Selected_PageIndexID"].ToString();
                    _page_categoryid = ViewState["Page_CategoryID"].ToString();
                }
                catch
                {
                }
            }
        }

        public void LoadMenus()
        {
            DataList_PageMenuList.DataSource = PageMgr.sGet_PageIndex_FullList("-1", _page_categoryid, "Page_Name");
            DataList_PageMenuList.DataKeyField = "PageIndexID";
            DataList_PageMenuList.DataBind();
        }

        protected void DataList_PageMenuList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_pageindexid = DataList_PageMenuList.SelectedValue.ToString();
            OnPageIndexSelected(sender, e);
        }
}
}