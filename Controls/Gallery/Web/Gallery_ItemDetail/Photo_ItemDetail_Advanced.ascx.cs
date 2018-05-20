using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.Gallery.ItemDetail
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _itemdetailid;
        private string _displayid = "Default";
        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";

        private bool _ispagetitle = true;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ItemDetailID
        {
            get
            {
                return _itemdetailid;
            }
            set
            {
                _itemdetailid = value;
                ViewState["ItemDetailID"] = _itemdetailid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string DisplayID
        {
            get
            {
                return _displayid;
            }
            set
            {
                _displayid = value;
                ViewState["DisplayID"] = _displayid;
            }
        }


        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsPageTitle
        {
            get
            {
                return _ispagetitle;
            }
            set
            {
                _ispagetitle = value;
                ViewState["IsPageTitle"] = _ispagetitle;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string ItemTemplate
        {
            get
            {
                return _itemtemplate;
            }
            set
            {
                _itemtemplate = value;
                ViewState["ItemTemplate"] = _itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ItemTemplateURL
        {
            get
            {
                return _itemtemplateurl;
            }
            set
            {
                _itemtemplateurl = value;
                ViewState["ItemTemplateURL"] = _itemtemplateurl;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _itemdetailid = ViewState["ItemDetailID"].ToString();
                    _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                    _displayid = ViewState["DisplayID"].ToString();
                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();

                }
                catch
                {
                    // nothing to do
                }

            }

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_itemdetailid))
            {
                MultiView_ItemDetail.SetActiveView(View_New);
            }
            else
            {

                MultiView_ItemDetail.SetActiveView(View_Detail);

                Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                switch (_itemtemplate)
                {
                    case "Default":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Gallery/Templates/ItemDetail_Default.ascx";
                        break;
                    case "Custom":
                        myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                        break;
                    default:
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_Gallery/Templates/ItemDetail_Default.ascx";
                        break;
                }

                Literal_ItemTemplate.Text = "Item Template: " + myItemTemplate.ItemTemplatePath + "</br>";

            }

        }

    }
}