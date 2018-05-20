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

    public partial class App_AdminCP_SiteAdmin_Pages_PageCommand_Normal : System.Web.UI.UserControl
    {

        #region Properties

        private string _pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageIndexID
        {
            get
            {
                return _pageindexid;
            }
            set
            {
                _pageindexid = value;
                ViewState["PageIndexID"] = _pageindexid;
            }
        }

        #endregion

        #region Events

        // Button Click Event
        private static readonly object EventClick = new object();

        [Category("Action")]
        [Description("Raised Command Clicked event")]
        public event EventHandler Click
        {
            add
            {
                Events.AddHandler(EventClick, value);
            }
            remove
            {
                Events.RemoveHandler(EventClick, value);
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            EventHandler ClickHandler = (EventHandler)Events[EventClick];

            if (ClickHandler != null)
                ClickHandler(sender, e);

        }

        // Delete Button Click Event
        private static readonly object DeletePageEventClick = new object();

        [Category("Action")]
        [Description("Raised Command Clicked event")]
        public event EventHandler DeletePageClick
        {
            add
            {
                Events.AddHandler(DeletePageEventClick, value);
            }
            remove
            {
                Events.RemoveHandler(DeletePageEventClick, value);
            }
        }

        protected void OnDeletePageClick(object sender, EventArgs e)
        {
            EventHandler DeletePageClickHandler = (EventHandler)Events[DeletePageEventClick];

            if (DeletePageClickHandler != null)
                DeletePageClickHandler(sender, e);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageIndex_Selected();
                Control_Init();
            }
            else
            {
                if (ViewState["PageIndexID"] != null)
                    _pageindexid = ViewState["PageIndexID"].ToString();
            }

        }

        private void Control_Init()
        {
            // Bind Page Folders
            PageMgr myPageMgr = new PageMgr();
            droplist_Normal_Folders.DataSource = myPageMgr.Get_Page_Categories();
            droplist_Normal_Folders.DataTextField = "Name";
            droplist_Normal_Folders.DataValueField = "Page_CategoryID";
            droplist_Normal_Folders.DataBind();

        }

        public void PageIndex_Selected()
        {
            if (!DataEval.IsEmptyQuery(_pageindexid) && _pageindexid != "-1")
            {
                PageMgr myPageMgr = new PageMgr();
                PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

                lbl_PageName.Text = myPageIndex.Menu_Title;

                // Create Client Delete Confirm
                btn_Normal_Delete.OnClientClick = string.Format("return confirm('Are you sure you want to delete page \"{0}\" ?');", myPageIndex.Menu_Title);

            }
            else
            {
                lbl_PageName.Text = "Unselected";
            }

        }

        protected void btn_Normal_Delete_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {
                PageMgr myPageMgr = new PageMgr();
                Page_PropertyMgr myPage_PropertyMgr = new Page_PropertyMgr();

                PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

                switch (myPageIndex.Page_Type)
                {
                    case Page_Type.Normal_Page:
                        myPageMgr.Delete_PageIndex(_pageindexid);
                        break;
                    case Page_Type.Category:
                        myPageMgr.Delete_PageIndex(_pageindexid);
                        break;
                    case Page_Type.Internal_Page_Pointer:
                        myPage_PropertyMgr.Remove_Page_IntLink(_pageindexid);
                        myPageMgr.Remove_PageIndex(_pageindexid);
                        break;
                    case Page_Type.External_Link:
                        myPage_PropertyMgr.Remove_Page_ExtLink(_pageindexid);
                        myPageMgr.Remove_PageIndex(_pageindexid);
                        break;
                }

                OnDeletePageClick(sender, e);
            }

        }
        protected void btn_Normal_Duplicate_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {
                PageMgr myPageMgr = new PageMgr();

                myPageMgr.Duplicate_PageIndex(_pageindexid, Security.Users.UserStatus.Current_UserID(this.Page));

                OnClick(sender, e);
            }
        }
        protected void btn_Normal_Move_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {

                PageMgr myPageMgr = new PageMgr();

                PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

                switch (droplist_Normal_Folders.SelectedValue)
                {
                    case "1":
                        // move to active folder
                        if (myPageIndex.Page_CategoryID == "2")
                        {
                            e2Data[] UpdateData_Active = {
                                                               new e2Data("PageIndexID", _pageindexid),
                                                               new e2Data("Page_CategoryID", "1")
                                                            };

                            myPageMgr.Edit_PageIndex(UpdateData_Active);
                        }
                        else
                        {
                            SiteMenu mySiteMenu = new SiteMenu();
                            mySiteMenu.Reset_Menu_RootOrder();

                            int Count_Child = myPageMgr.Count_Child_PageIndex("-1", "1,2") + 1;

                            e2Data[] UpdateData_Active = {
                                                             new e2Data("PageIndexID", _pageindexid),
                                                             new e2Data("Parent_PageIndexID", "-1"),
                                                             new e2Data("Page_CategoryID", "1"),
                                                             new e2Data("SortOrder", Count_Child.ToString())
                                                         };

                            myPageMgr.Edit_PageIndex(UpdateData_Active);
                        }
                        break;
                    default:
                        e2Data[] UpdateData_Default = {
                                                          new e2Data("PageIndexID", _pageindexid),
                                                          new e2Data("Page_CategoryID", droplist_Normal_Folders.SelectedValue)
                                                       };

                        myPageMgr.Edit_PageIndex(UpdateData_Default);
                        break;
                }

                OnClick(sender, e);
            }
        }
    }
}