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

    public partial class App_AdminCP_SiteAdmin_Pages_PageProperties : System.Web.UI.UserControl
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

                iframeButtons_Reset();
            }


        }

        private void Control_Init()
        {
        }

        private void iframeButtons_Reset()
        {
            // Reset Button
            btn_PageShow.CssClass = "nexusCore_pagePreview_btn";
            btn_Property.CssClass = "nexusCore_property_btn";
            btn_MetaTag.CssClass = "nexusCore_metatag_btn";
            btn_Privacy.CssClass = "nexusCore_privacy_btn";
            btn_Version.CssClass = "nexusCore_version_btn";

            // Init Button
            if (RadPageView_Property.Selected)
                btn_Property.CssClass = "nexusCore_property_btn_selected";
            if (RadPageView_MetaTag.Selected)
                btn_MetaTag.CssClass = "nexusCore_metatag_btn_selected";
            if (RadPageView_Privacy.Selected)
                btn_Privacy.CssClass = "nexusCore_privacy_btn_selected";
            if (RadPageView_Version.Selected)
                btn_Version.CssClass = "nexusCore_version_btn_selected";

        }

        private void Refresh()
        {

            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            switch (myPageIndex.Page_Type)
            {
                case Page_Type.Normal_Page:
                    btn_MetaTag.Visible = true;
                    btn_Version.Visible = true;
                    break;

                case Page_Type.Category:
                    if (RadPageView_Version.Selected || RadPageView_MetaTag.Selected)
                    {
                        RadMultiPage_Editor.SelectedIndex = RadPageView_Property.Index;
                        iframeButtons_Reset();
                    }

                    btn_MetaTag.Visible = false;
                    btn_Version.Visible = false;
                    break;

                case Page_Type.Internal_Page_Pointer:
                    if (RadPageView_Version.Selected || RadPageView_MetaTag.Selected || RadPageView_Privacy.Selected)
                    {
                        RadMultiPage_Editor.SelectedIndex = RadPageView_Property.Index;
                        iframeButtons_Reset();
                    }

                    btn_MetaTag.Visible = false;
                    btn_Version.Visible = false;
                    btn_Privacy.Visible = false;

                    break;

                case Page_Type.External_Link:
                    if (RadPageView_Version.Selected || RadPageView_MetaTag.Selected || RadPageView_Privacy.Selected)
                    {
                        RadMultiPage_Editor.SelectedIndex = RadPageView_Property.Index;
                        iframeButtons_Reset();
                    }

                    btn_MetaTag.Visible = false;
                    btn_Version.Visible = false;
                    btn_Privacy.Visible = false;

                    break;
                default:

                    break;
            }

            // Page Property
            PageProperty_Show.PageIndexID = _pageindexid;
            // Page MetaTag
            PageMetaTag_Show.PageIndexID = _pageindexid;
            // Page Privacy
            PagePrivacy_Show.PageIndexID = _pageindexid;
            // Page Version
            PageVersion_Show.PageIndexID = _pageindexid;

        }

        protected void btn_PageShow_Command(object sender, CommandEventArgs e)
        {
            // Show Page Properties
            Response.Redirect(string.Format("Pages.aspx?PageIndexID={0}&PageLink=Disable", _pageindexid));
        }
        protected void btn_Property_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Property.Index;
            iframeButtons_Reset();
        }

        protected void btn_MetaTag_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_MetaTag.Index;
            iframeButtons_Reset();
        }

        protected void btn_Privacy_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Privacy.Index;
            iframeButtons_Reset();
        }

        protected void btn_Version_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Version.Index;
            iframeButtons_Reset();
        }

    }
}