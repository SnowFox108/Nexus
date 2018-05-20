using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class App_AdminCP_SiteAdmin_Pages_PageShow : System.Web.UI.UserControl
    {

        #region properties

        private string _pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageIndexID
        {
            get
            {
                if (_pageindexid == null)
                {
                    return "";
                }
                return _pageindexid;
            }
            set
            {
                _pageindexid = value;
                ViewState["PageIndexID"] = _pageindexid;
                Refresh();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _pageindexid = ViewState["PageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_pageindexid == null)
                {
                    ViewState["PageIndexID"] = "";
                    Control_Init();
                }
            }

        }

        private void Control_Init()
        {

            // Button operating
            btn_DesignMode_Basic.CommandArgument = null;
            btn_DesignMode_Advanced.CommandArgument = null;
            btn_DesignMode_Basic.Visible = false;
            btn_DesignMode_Advanced.Visible = false;

            // Property
            RadTabStrip_Page.Tabs[0].Visible = false;
            RadTabStrip_Page.Tabs[1].Visible = false;
            RadTabStrip_Page.Tabs[2].Visible = false;
            RadTabStrip_Page.Tabs[3].Visible = false;

            //else
            //{
            //    iframe_PageEditor_Basic.Attributes["src"] = string.Format("Pages/Default.aspx?PageIndexID={0}", _pageindexid);
            //    iframe_PageEditor_Advanced.Attributes["src"] = string.Format("Pages/Advanced.aspx?PageIndexID={0}", _pageindexid);

            //    // Button operating
            //    btn_DesignMode_Basic.CommandArgument = _pageindexid;
            //    btn_DesignMode_Advanced.CommandArgument = _pageindexid;
            //    btn_DesignMode_Basic.Visible = true;
            //    btn_DesignMode_Advanced.Visible = true;

            //}

        }

        private void Load_DesignMode()
        {
            // Set PageLock
            Pages.PageEditorMgr myPageEditorMgr = new PageEditorMgr();
            myPageEditorMgr.Set_PageLock(this.Page, _pageindexid);

            // Lock done now start to Design Mode
            Response.Redirect(string.Format("PageDesign.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid));

        }

        protected void btn_DesignMode_Click(object sender, CommandEventArgs e)
        {

            if (e.CommandArgument != null)
            {
                string _pageindexid = e.CommandArgument.ToString();

                PageEditorMgr myPageEditorMgr = new PageEditorMgr();

                if (myPageEditorMgr.Chk_Page_Lock(_pageindexid))
                {
                    // Page is Locked
                    Pages.Page_Lock myPage_Lock = myPageEditorMgr.Get_Page_Lock(_pageindexid);

                    if (myPage_Lock.UserID == Security.Users.UserStatus.Current_UserID(this.Page))
                    {
                        // For same user will recover his previous work
                        e2Data[] UpdateData = {
                                                  new e2Data("Page_LockID", myPage_Lock.Page_LockID),
                                                  new e2Data("LockDate", DateTime.Now.ToString())
                                              };

                        myPageEditorMgr.Edit_Page_Lock(UpdateData);

                        Response.Redirect(string.Format("PageDesign.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid));
                        return;
                    }

                    // Page is released over 10min with no actions
                    if (DateTime.Now.Subtract(myPage_Lock.LockDate).TotalMinutes > 10)
                    {
                        //Tools.AlertMessage.Show_Alert(this.Page, string.Format("<h4>The desgin mode is locked at {0} by other user.<br/> now is realease to you.</h4>", myPage_Lock.LockDate.ToString()), "Page is locked!");

                        // Delete Locks
                        myPageEditorMgr.Release_PageLock(_pageindexid);

                        Load_DesignMode();
                        return;
                    }

                    Tools.AlertMessage.Show_Alert(this.Page, "<h4>The desgin mode is locked <br/> please try again later.</h4>", "Page is locked!");

                }
                else
                {
                    Load_DesignMode();
                }
            }
        }


        private void Refresh()
        {

            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            switch (myPageIndex.Page_Type)
            {
                case Page_Type.Normal_Page:
                    iframe_PageEditor_Basic.Attributes["src"] = string.Format("Pages/Default.aspx?PageIndexID={0}&PageLink=Disable", myPageIndex.PageIndexID);
                    iframe_PageEditor_Advanced.Attributes["src"] = string.Format("Pages/Advanced.aspx?PageIndexID={0}&PageLink=Disable", myPageIndex.PageIndexID);

                    // Button operating
                    btn_DesignMode_Basic.CommandArgument = myPageIndex.PageIndexID;
                    btn_DesignMode_Advanced.CommandArgument = myPageIndex.PageIndexID;
                    btn_DesignMode_Basic.Visible = true;
                    btn_DesignMode_Advanced.Visible = true;

                    // Property
                    RadTabStrip_Page.Tabs[0].Visible = true;
                    RadTabStrip_Page.Tabs[1].Visible = true;
                    RadTabStrip_Page.Tabs[2].Visible = true;
                    RadTabStrip_Page.Tabs[3].Visible = false;

                    break;

                case Page_Type.Category:
                    iframe_PageEditor_Basic.Attributes["src"] = string.Format("Pages/Category.aspx?PageIndexID={0}&PageLink=Disable", myPageIndex.PageIndexID);
                    iframe_PageEditor_Advanced.Attributes["src"] = string.Format("Pages/Category.aspx?PageIndexID={0}&PageLink=Disable", myPageIndex.PageIndexID);

                    // Button operating
                    btn_DesignMode_Basic.CommandArgument = null;
                    btn_DesignMode_Advanced.CommandArgument = null;
                    btn_DesignMode_Basic.Visible = false;
                    btn_DesignMode_Advanced.Visible = false;

                    // Property
                    RadTabStrip_Page.Tabs[0].Visible = true;
                    RadTabStrip_Page.Tabs[1].Visible = true;
                    RadTabStrip_Page.Tabs[2].Visible = true;
                    RadTabStrip_Page.Tabs[3].Visible = false;

                    break;

                default:
                    iframe_PageEditor_Basic.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", myPageIndex.PageIndexID);
                    iframe_PageEditor_Advanced.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", myPageIndex.PageIndexID);

                    // Button operating
                    btn_DesignMode_Basic.CommandArgument = null;
                    btn_DesignMode_Advanced.CommandArgument = null;
                    btn_DesignMode_Basic.Visible = false;
                    btn_DesignMode_Advanced.Visible = false;

                    // Property
                    RadTabStrip_Page.Tabs[0].Visible = false;
                    RadTabStrip_Page.Tabs[1].Visible = false;
                    RadTabStrip_Page.Tabs[2].Visible = false;
                    RadTabStrip_Page.Tabs[3].Visible = false;

                    break;
            }

            // Page Property
            PageProperty_Show.PageIndexID = _pageindexid;

        }

        protected void RadTabStrip_Page_TabClick(object sender, RadTabStripEventArgs e)
        {
            switch (RadTabStrip_Page.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    PageProperty_Show.Update_Disable();
                    PageProperty_Show.Control_FillData();
                    break;
                case 3:
                    break;
            }
        }
}

}