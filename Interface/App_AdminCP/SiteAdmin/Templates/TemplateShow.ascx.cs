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
using Nexus.Core.Templates;

namespace Nexus.Core
{
    public partial class App_AdminCP_SiteAdmin_Templates_TemplateShow : System.Web.UI.UserControl
    {

        #region properties

        private string _masterpageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string MasterPageIndexID
        {
            get
            {
                if (_masterpageindexid == null)
                {
                    return "";
                }
                return _masterpageindexid;
            }
            set
            {
                _masterpageindexid = value;
                ViewState["MasterPageIndexID"] = _masterpageindexid;
                Refresh();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _masterpageindexid = ViewState["MasterPageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_masterpageindexid == null)
                {
                    ViewState["MasterPageIndexID"] = "";
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

        }

        private void Refresh()
        {

            if (!DataEval.IsEmptyQuery(_masterpageindexid))
            {
                iframe_PageEditor_Basic.Attributes["src"] = string.Format("Templates/Default.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid);
                iframe_PageEditor_Advanced.Attributes["src"] = string.Format("Templates/Advanced.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid);

                // Button operating
                btn_DesignMode_Basic.CommandArgument = _masterpageindexid;
                btn_DesignMode_Advanced.CommandArgument = _masterpageindexid;
                btn_DesignMode_Basic.Visible = true;
                btn_DesignMode_Advanced.Visible = true;

                // Property
                RadTabStrip_Page.Tabs[0].Visible = true;
                RadTabStrip_Page.Tabs[1].Visible = true;
                RadTabStrip_Page.Tabs[2].Visible = true;

            }
            else
            {

                iframe_PageEditor_Basic.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", _masterpageindexid);
                iframe_PageEditor_Advanced.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", _masterpageindexid);

                // Button operating
                btn_DesignMode_Basic.CommandArgument = null;
                btn_DesignMode_Advanced.CommandArgument = null;
                btn_DesignMode_Basic.Visible = false;
                btn_DesignMode_Advanced.Visible = false;

                // Property
                RadTabStrip_Page.Tabs[0].Visible = false;
                RadTabStrip_Page.Tabs[1].Visible = false;
                RadTabStrip_Page.Tabs[2].Visible = false;

            }

            // Page Property
            TemplateProperty.MasterPageIndexID = _masterpageindexid;

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
                    //PageProperty_Show.Update_Disable();
                    break;
            }
        }

        protected void btn_DesignMode_Click(object sender, CommandEventArgs e)
        {

            if (e.CommandArgument != null)
            {
                string _masterpageindexid = e.CommandArgument.ToString();

                MasterPageEditorMgr myMasterPageEditorMgr = new MasterPageEditorMgr();

                if (myMasterPageEditorMgr.Chk_MasterPage_Lock(_masterpageindexid))
                {
                    // Page is Locked
                    MasterPage_Lock myMasterPage_Lock = myMasterPageEditorMgr.Get_MasterPage_Lock(_masterpageindexid);

                    if (myMasterPage_Lock.UserID == Security.Users.UserStatus.Current_UserID(this.Page))
                    {
                        // For same user will recover his previous work
                        e2Data[] UpdateData = {
                                                  new e2Data("MasterPage_LockID", myMasterPage_Lock.MasterPage_LockID),
                                                  new e2Data("LockDate", DateTime.Now.ToString())
                                              };

                        myMasterPageEditorMgr.Edit_MasterPage_Lock(UpdateData);

                        Response.Redirect(string.Format("TemplateDesign.aspx?MasterPageIndexID={0}", _masterpageindexid));
                        return;
                    }

                    // Page is released over 10min with no actions
                    if (DateTime.Now.Subtract(myMasterPage_Lock.LockDate).TotalMinutes > 10)
                    {
                        //Tools.AlertMessage.Show_Alert(this.Page, string.Format("<h4>The desgin mode is locked at {0} by other user.<br/> now is realease to you.</h4>", myPage_Lock.LockDate.ToString()), "Page is locked!");

                        // Delete Locks
                        myMasterPageEditorMgr.Release_MasterPageLock(_masterpageindexid);

                        Load_DesignMode();
                        return;
                    }

                    Tools.AlertMessage.Show_Alert(this.Page, "<h4>The desgin mode is locked <br/> please try again later.</h4>", "Template is locked!");

                }
                else
                {
                    Load_DesignMode();
                }
            }
        }

        private void Load_DesignMode()
        {
            // Set PageLock
            MasterPageEditorMgr myPageEditorMgr = new MasterPageEditorMgr();
            myPageEditorMgr.Set_MasterPageLock(this.Page, _masterpageindexid);

            // Lock done now start to Design Mode
            Response.Redirect(string.Format("TemplateDesign.aspx?MasterPageIndexID={0}", _masterpageindexid));

        }

    }
}