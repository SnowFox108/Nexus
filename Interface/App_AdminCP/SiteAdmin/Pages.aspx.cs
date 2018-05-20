using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Pages;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page_Controls();
            }
        }

        private void Page_Controls()
        {
            // Switch to page view
            MultiView_Pages.SetActiveView(View_ShowPage);

            // Check _pageindexid
            string _pageindexid = Request["PageIndexID"];
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {
                Active_PageShow_Page(_pageindexid);
            }
            else
            {
                _pageindexid = "-1";
                PageList_Index.Page_CategoryID = "1,2";
                PageList_Index.Control_Init();
                MultiView_Pages.SetActiveView(View_ListPage);
            }

            // Expand the tree node and select the node
            PageMenu_PageIndex.Selected_PageIndexID = _pageindexid;
            PageCommand_Live_PageIndex.PageIndexID = _pageindexid;

            // Init PageMenu List
            PageMenu_PageIndex.Visible = true;
            PageMenuList_PageIndex.Visible = false;

            // Init PageCommand List
            PageCommand_Live_PageIndex.Visible = true;
            PageCommand_Normal_PageIndex.Visible = false;

            // Bind Page Folders
            PageMgr myPageMgr = new PageMgr();
            droplist_PageFolder.DataSource = myPageMgr.Get_Page_Categories();
            droplist_PageFolder.DataTextField = "Name";
            droplist_PageFolder.DataValueField = "Page_CategoryID";
            droplist_PageFolder.DataBind();

        }


        protected void PageMenu_PageIndex_PageIndexSelected(object sender, RadTreeNodeEventArgs e)
        {
            if (PageMenu_PageIndex.Selected_PageIndexID != "-1")
            {
                // Switch to page view
                Active_PageShow_Page(PageMenu_PageIndex.Selected_PageIndexID);
                MultiView_Pages.SetActiveView(View_ShowPage);

            }
            else
            {
                PageList_Index.Page_CategoryID = "1,2";
                PageList_Index.Control_Init();

                MultiView_Pages.SetActiveView(View_ListPage);
            }

            PageCommand_Live_PageIndex.PageIndexID = PageMenu_PageIndex.Selected_PageIndexID;
            PageCommand_Live_PageIndex.PageIndex_Selected();
        }

        protected void PageMenuList_PageIndex_PageIndexSelected(object sender, EventArgs e)
        {

            if (PageMenuList_PageIndex.Selected_PageIndexID != "-1")
            {
                // Switch to page view
                Active_PageShow_Page(PageMenuList_PageIndex.Selected_PageIndexID);
                MultiView_Pages.SetActiveView(View_ShowPage);

            }
            else
            {
                PageList_Index.Page_CategoryID = droplist_PageFolder.SelectedValue;
                PageList_Index.Control_Init();

                MultiView_Pages.SetActiveView(View_ListPage);

            }

            PageCommand_Normal_PageIndex.PageIndexID = PageMenuList_PageIndex.Selected_PageIndexID;
            PageCommand_Normal_PageIndex.PageIndex_Selected();
        }

        private void Active_PageShow_Page(string PageIndexID)
        {
            PageShow_Page.PageIndexID = PageIndexID;
            lbl_PageInfo.Text = "PageID = " + PageIndexID;

        }

        #region Page Command Action

        protected void PageCommand_Live_PageIndex_Click(object sender, EventArgs e)
        {

            PageMenu_PageIndex.LoadRootNodes();

        }

        protected void PageCommand_Live_PageIndex_CreatePageClick(object sender, EventArgs e)
        {
            // Switch to page view
            MultiView_Pages.SetActiveView(View_CreatePage);

            if (DataEval.IsEmptyQuery(PageMenu_PageIndex.Selected_PageIndexID))
            {
                PageCreate_Create.Parent_PageIndexID = "-1";
            }
            else
            {
                PageCreate_Create.Parent_PageIndexID = PageMenu_PageIndex.Selected_PageIndexID;
            }

        }

        protected void PageCommand_Normal_PageIndex_Click(object sender, EventArgs e)
        {
            PageMenuList_PageIndex.Page_CategoryID = droplist_PageFolder.SelectedValue;
            PageMenuList_PageIndex.LoadMenus();
        }

        protected void PageCommand_Normal_PageIndex_DeletePageClick(object sender, EventArgs e)
        {

            //PageShow_Page.PageIndexID = "-1";

            PageList_Index.Page_CategoryID = droplist_PageFolder.SelectedValue;
            PageList_Index.Control_Init();

            PageMenuList_PageIndex.Page_CategoryID = droplist_PageFolder.SelectedValue;
            PageMenuList_PageIndex.LoadMenus();

            MultiView_Pages.SetActiveView(View_ListPage);

        }

        #endregion

        protected void btn_Show_PageCategory_Click(object sender, EventArgs e)
        {
            switch (droplist_PageFolder.SelectedValue)
            {
                case "1":
                    PageMenu_PageIndex.LoadRootNodes();

                    PageCommand_Live_PageIndex.PageIndexID = "-1";
                    PageCommand_Live_PageIndex.PageIndex_Selected();

                    PageMenu_PageIndex.Visible = true;
                    PageMenuList_PageIndex.Visible = false;
                    PageCommand_Live_PageIndex.Visible = true;
                    PageCommand_Normal_PageIndex.Visible = false;

                    // Reset Page List
                    PageList_Index.Page_CategoryID = "1,2";
                    PageList_Index.Control_Init();

                    break;
                default:
                    PageMenuList_PageIndex.Page_CategoryID = droplist_PageFolder.SelectedValue;
                    PageMenuList_PageIndex.LoadMenus();

                    PageCommand_Normal_PageIndex.PageIndexID = "-1";
                    PageCommand_Normal_PageIndex.PageIndex_Selected();

                    PageMenuList_PageIndex.Visible = true;
                    PageMenu_PageIndex.Visible = false;
                    PageCommand_Live_PageIndex.Visible = false;
                    PageCommand_Normal_PageIndex.Visible = true;

                    // Reset Page List
                    PageList_Index.Page_CategoryID = droplist_PageFolder.SelectedValue;
                    PageList_Index.Control_Init();

                    break;
            }

            MultiView_Pages.SetActiveView(View_ListPage);

        }
    }
}