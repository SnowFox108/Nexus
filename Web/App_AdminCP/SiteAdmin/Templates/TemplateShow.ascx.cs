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

                iframeButtons_Reset();

            }

        }

        private void Control_Init()
        {

            // Button operating
            btn_DesignMode.CommandArgument = null;
            btn_DesignMode.Visible = false;

        }

        private void iframeButtons_Reset()
        {
            // Reset Button            
            btn_Preview.CssClass = "nexusCore_preview_btn";
            btn_Modify.CssClass = "nexusCore_modify_btn";
            btn_DesignMode.CssClass = "nexusCore_designerMode_btn";
            btn_Property.CssClass = "nexusCore_properties_btn";

            //// Init Button
            if (RadPageView_Basic.Selected)
                btn_Preview.CssClass = "nexusCore_preview_btn_selected";
            if (RadPageView_Advanced.Selected)
                btn_Modify.CssClass = "nexusCore_modify_btn_selected";
        }

        private void Refresh()
        {

            if (!DataEval.IsEmptyQuery(_masterpageindexid))
            {
                iframe_PageEditor_Basic.Attributes["src"] = string.Format("Templates/Default.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid);
                iframe_PageEditor_Advanced.Attributes["src"] = string.Format("Templates/Advanced.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid);

                // Button operating
                btn_DesignMode.CommandArgument = _masterpageindexid;
                btn_DesignMode.Visible = true;

                // Property
                btn_Preview.Visible = true;
                btn_Modify.Visible = true;

            }
            else
            {

                iframe_PageEditor_Basic.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", _masterpageindexid);
                iframe_PageEditor_Advanced.Attributes["src"] = string.Format("/Homepage.aspx?PageIndexID={0}ThisIsDefault", _masterpageindexid);

                // Button operating
                btn_DesignMode.CommandArgument = null;
                btn_DesignMode.Visible = false;

                // Property
                btn_Preview.Visible = false;
                btn_Modify.Visible = false;

            }

            //// Page Property
            //TemplateProperty.MasterPageIndexID = _masterpageindexid;

        }

        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Basic.Index;
            iframeButtons_Reset();
        }

        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Advanced.Index;
            iframeButtons_Reset();
        }

        protected void btn_Property_Command(object sender, CommandEventArgs e)
        {
            // Show Page Properties
            Response.Redirect(string.Format("TemplateProperties.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid));
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