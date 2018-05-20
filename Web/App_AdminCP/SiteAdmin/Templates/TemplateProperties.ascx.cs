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

    public partial class App_AdminCP_SiteAdmin_Templates_TemplateProperties : System.Web.UI.UserControl
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
        }

        private void iframeButtons_Reset()
        {
            // Reset Button
            btn_PageShow.CssClass = "nexusCore_masterpagePreview_btn";
            btn_Property.CssClass = "nexusCore_property_btn";
            btn_MetaTag.CssClass = "nexusCore_metatag_btn";
            btn_Version.CssClass = "nexusCore_version_btn";

            // Init Button
            if (RadPageView_Property.Selected)
                btn_Property.CssClass = "nexusCore_property_btn_selected";
            if (RadPageView_MetaTag.Selected)
                btn_MetaTag.CssClass = "nexusCore_metatag_btn_selected";
            if (RadPageView_Version.Selected)
                btn_Version.CssClass = "nexusCore_version_btn_selected";

        }

        private void Refresh()
        {

            // Page Property
            TemplateProperty.MasterPageIndexID = _masterpageindexid;

            // Page MetaTag
            TemplateMetaTag_Show.MasterPageIndexID = _masterpageindexid;

            // Page Version
            TemplateVersion_Show.MasterPageIndexID = _masterpageindexid;

        }

        protected void btn_PageShow_Command(object sender, CommandEventArgs e)
        {
            // Show Page Properties
            Response.Redirect(string.Format("Templates.aspx?MasterPageIndexID={0}&PageLink=Disable", _masterpageindexid));
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

        protected void btn_Version_Click(object sender, EventArgs e)
        {
            RadMultiPage_Editor.SelectedIndex = RadPageView_Version.Index;
            iframeButtons_Reset();
        }

    }
}