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

    public partial class App_AdminCP_SiteAdmin_Pages_PageCommand_Live : System.Web.UI.UserControl
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

        // Create Button Click Event
        private static readonly object CreatePageEventClick = new object();

        [Category("Action")]
        [Description("Raised Command Clicked event")]
        public event EventHandler CreatePageClick
        {
            add
            {
                Events.AddHandler(CreatePageEventClick, value);
            }
            remove
            {
                Events.RemoveHandler(CreatePageEventClick, value);
            }
        }

        protected void OnCreatePageClick(object sender, EventArgs e)
        {
            EventHandler CreatePageClickHandler = (EventHandler)Events[CreatePageEventClick];

            if (CreatePageClickHandler != null)
                CreatePageClickHandler(sender, e);

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
            droplist_Live_Folders.DataSource = myPageMgr.Get_Page_Categories();
            droplist_Live_Folders.DataTextField = "Name";
            droplist_Live_Folders.DataValueField = "Page_CategoryID";
            droplist_Live_Folders.DataBind();

        }

        public void PageIndex_Selected()
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {
                PageMgr myPageMgr = new PageMgr();
                PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

                lbl_PageName.Text = myPageIndex.Page_Name;
            }
            else
            {
                lbl_PageName.Text = "Page unselected";
            }

        }

        protected void btn_Live_Delete_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {

                if (Chk_PageIndexID())
                {

                    PageMgr myPageMgr = new PageMgr();

                    e2Data[] UpdateData = {
                                          new e2Data("PageIndexID", _pageindexid),
                                          new e2Data("Parent_PageIndexID", "-1"),
                                          new e2Data("Page_CategoryID", "4")
                                      };

                    myPageMgr.Edit_PageIndex(UpdateData);

                    OnClick(sender, e);
                }
            }
        }

        protected void btn_Live_Duplicate_Click(object sender, EventArgs e)
        {
            if (!DataEval.IsEmptyQuery(_pageindexid))
            {
                PageMgr myPageMgr = new PageMgr();

                myPageMgr.Duplicate_PageIndex(_pageindexid);

                OnClick(sender, e);
            }
        }

        protected void btn_Live_SetHomePage_Click(object sender, EventArgs e)
        {

            if (!DataEval.IsEmptyQuery(_pageindexid))
            {

                Phrases.PhraseMgr myPhraseMgr = new Phrases.PhraseMgr();

                e2Data[] UpdateData = {
                                          new e2Data("VarName", "NexusCore_HomepageID"),
                                          new e2Data("PhraseValue", _pageindexid)
                                      };

                myPhraseMgr.Edit_Phrase(UpdateData);

                OnClick(sender, e);
            }
        }

        protected void btn_Live_Move_Click(object sender, EventArgs e)
        {

            if (!DataEval.IsEmptyQuery(_pageindexid))
            {

                PageMgr myPageMgr = new PageMgr();

                if (Chk_PageIndexID())
                {


                    switch (droplist_Live_Folders.SelectedValue)
                    {
                        case "1":
                            // move to active folder
                            e2Data[] UpdateData_Active = {
                                                               new e2Data("PageIndexID", _pageindexid),
                                                               new e2Data("Page_CategoryID", "1")
                                                            };

                            myPageMgr.Edit_PageIndex(UpdateData_Active);

                            break;
                        case "2":
                            // move to inactive folder
                            e2Data[] UpdateData_InActive = {
                                                               new e2Data("PageIndexID", _pageindexid),
                                                               new e2Data("Page_CategoryID", "2")
                                                            };

                            myPageMgr.Edit_PageIndex(UpdateData_InActive);

                            break;
                        default:
                            e2Data[] UpdateData_Default = {
                                                              new e2Data("PageIndexID", _pageindexid),
                                                              new e2Data("Parent_PageIndexID", "-1"),
                                                              new e2Data("Page_CategoryID", droplist_Live_Folders.SelectedValue)
                                                          };                                                      

                            myPageMgr.Edit_PageIndex(UpdateData_Default);
                            break;
                    }

                    OnClick(sender, e);
                }
            }
        }

        private bool Chk_PageIndexID()
        {
            PageMgr myPageMgr = new PageMgr();
            if (myPageMgr.Count_Child_PageIndex(_pageindexid, "1,2") > 0)
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected page has child(s) page. <br/> Please move them before apply this action.</h4>", "Action failed!");
                return false;
            }

            if (Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_HomepageID") == _pageindexid)
            {
                Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected page has been set Homepage. <br/> Please reset your homepage before apply this action.</h4>", "Action failed!");
                return false;
            }

            return true;
        }

        protected void btn_CreatePage_Click(object sender, EventArgs e)
        {
            OnCreatePageClick(sender, e);
        }
}
}