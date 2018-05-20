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

    public partial class WebView : System.Web.UI.UserControl
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
            else
            {
                Control_PreInit();
            }

            Control_Init();

        }

        private void Control_PreInit()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusPhotoID"]))
            {
                // Add View Count
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                Lib.Photo myPhoto = myPhotoMgr.Get_Photo(Request["NexusPhotoID"]);

                int _view_count = Convert.ToInt32(myPhoto.View_Count) + 1;

                e2Data[] UpdateData_Item = {
                                               new e2Data("PhotoID", myPhoto.PhotoID),
                                               new e2Data("View_Count", _view_count.ToString())
                                           };

                myPhotoMgr.Edit_Photo(UpdateData_Item);
            }

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

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    hlink_Edit_Item.Enabled = false;
                }

                Lib.Photo myPhoto;

                // Init Comment Form
                if (!DataEval.IsEmptyQuery(Request["NexusPhotoID"]))
                {

                    Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                    myPhoto = myPhotoMgr.Get_Photo(Request["NexusPhotoID"], _displayid);

                    if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                    {
                        hlink_Edit_Item.Visible = true;

                        hlink_Edit_Item.Attributes["href"] = "#";
                        hlink_Edit_Item.Attributes["onclick"] = string.Format(
                            "return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusPhotoID={1}');",
                            "43D902AF-A0DC-4036-BC46-C98EC84B6698",
                            myPhoto.PhotoID);

                    }
                    else
                    {
                        hlink_Edit_Item.Visible = false;
                    }

                    // Page Title
                    if (_ispagetitle)
                        Page.Title = myPhoto.Photo_Title;


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

                    FormView_ItemDetail.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);

                    List<Lib.Photo> myPhotos = new List<Lib.Photo>();
                    myPhotos.Add(myPhoto);

                    try
                    {
                        FormView_ItemDetail.DataSource = myPhotos;
                        FormView_ItemDetail.DataKeyNames = new string[] { "PhotoID" };
                        FormView_ItemDetail.DataBind();

                    }
                    catch
                    {
                        // Load Template Failed
                    }

                }
                else
                {
                    // No Post ID
                    hlink_Edit_Item.Visible = false;
                }


            }

        }

    }
}