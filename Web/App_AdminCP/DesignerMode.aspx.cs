using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;

namespace Nexus.Core
{

    public partial class App_AdminCP_DesignerMode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel_Redirecting.Visible = true;
            Panel_PageLock_Failed.Visible = false;

            if (!IsPostBack)
            {
                string _pageindexid = Request["PageIndexID"];

                // Lock Page
                if (!DataEval.IsEmptyQuery(_pageindexid))
                {
                    // Page Lock and go
                    DesignerMode(_pageindexid);
                }
                else
                {
                    // Lock Failed
                    LockPage_Failed("Invalid PageID");
                }
            }
        }

        private void DesignerMode(string _pageindexid)
        {

            PageEditorMgr myPageEditorMgr = new PageEditorMgr();

            if (myPageEditorMgr.Chk_Page_Lock(_pageindexid))
            {
                // Page is Locked
                Pages.Page_Lock myPage_Lock = myPageEditorMgr.Get_Page_Lock(_pageindexid);

                if (myPage_Lock.UserID == Security.Users.UserStatus.Current_UserID(this.Page))
                {
                    // It's same user, check if he open same page
                    PageMgr MyPageMgr = new PageMgr();
                    NexusCore_Page myPage = MyPageMgr.Get_Page_ActiveID(_pageindexid);

                    if (myPage_Lock.PageID == myPage.PageID)
                    {

                        // For same user will recover his previous work
                        e2Data[] UpdateData = {
                                                  new e2Data("Page_LockID", myPage_Lock.Page_LockID),
                                                  new e2Data("LockDate", DateTime.Now.ToString())
                                              };

                        myPageEditorMgr.Edit_Page_Lock(UpdateData);

                        Response.Redirect(string.Format("/App_AdminCP/SiteAdmin/PageDesign.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid));
                        return;
                    }
                    else
                    {
                        // For same user but create new session page

                        // Delete Locks
                        myPageEditorMgr.Release_PageLock(_pageindexid);

                        Load_DesignMode(_pageindexid);
                        return;
                    }
                }

                // Page is released over 10min with no actions
                if (DateTime.Now.Subtract(myPage_Lock.LockDate).TotalMinutes > 10)
                {
                    //Tools.AlertMessage.Show_Alert(this.Page, string.Format("<h4>The desgin mode is locked at {0} by other user.<br/> now is realease to you.</h4>", myPage_Lock.LockDate.ToString()), "Page is locked!");

                    // Delete Locks
                    myPageEditorMgr.Release_PageLock(_pageindexid);

                    Load_DesignMode(_pageindexid);
                    return;
                }

                //Tools.AlertMessage.Show_Alert(this.Page, "<h4>The desgin mode is locked <br/> please try again later.</h4>", "Page is locked!");
                LockPage_Failed("Page is locked by other user, please try again later.");
            }
            else
            {
                Load_DesignMode(_pageindexid);
            }

        }

        private void Load_DesignMode(string _pageindexid)
        {
            // Set PageLock
            Pages.PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            myPageEditorMgr.Set_PageLock(this.Page, _pageindexid);

            // Lock done now start to Design Mode
            Response.Redirect(string.Format("/App_AdminCP/SiteAdmin/PageDesign.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid));

        }

        private void LockPage_Failed(string msg)
        {
            lbl_ErrorMsg.Text = "msg";
            Panel_Redirecting.Visible = false;
            Panel_PageLock_Failed.Visible = true;

        }

    }
}