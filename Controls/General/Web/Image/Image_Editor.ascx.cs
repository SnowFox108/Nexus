using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.Controls;


namespace Nexus.Controls.General.Image
{
    public partial class Editor : System.Web.UI.UserControl
    {

        #region Basic Properties, Must Have to get control work

        private string _page_controlid;
        private string _editmode;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string EditMode
        {
            get
            {
                if (_editmode == null)
                {
                    return "";
                }
                return _editmode;
            }
            set
            {
                _editmode = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Page_ControlID
        {
            get
            {
                if (_page_controlid == null)
                {
                    return "";
                }
                return _page_controlid;
            }
            set
            {
                _page_controlid = value;
            }
        }

        #endregion

        #region Properties

        private string _imageid;
        private int _height = 100;
        private int _width = 100;
        private int _border = 0;
        private string _imageurl = "";
        private string _alternatetext = "";
        private string _linkurl = "";
        private string _link_target = "";

        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ImageID
        {
            get
            {
                return _imageid;
            }
            set
            {
                _imageid = value;
                ViewState["ImageID"] = _imageid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                ViewState["Height"] = _height;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                ViewState["Width"] = _width;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                ViewState["Border"] = _border;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ImageURL
        {
            get
            {
                return _imageurl;
            }
            set
            {
                _imageurl = value;
                ViewState["ImageURL"] = _imageurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string AlternateText
        {
            get
            {
                return _alternatetext;
            }
            set
            {
                _alternatetext = value;
                ViewState["AlternateText"] = _alternatetext;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LinkURL
        {
            get
            {
                return _linkurl;
            }
            set
            {
                _linkurl = value;
                ViewState["LinkURL"] = _linkurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Link_Target
        {
            get
            {
                return _link_target;
            }
            set
            {
                _link_target = value;
                ViewState["Link_Target"] = _link_target;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsShared
        {
            get
            {
                return _isshared;
            }
            set
            {
                _isshared = value;
                ViewState["IsShared"] = _isshared;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ContentID
        {
            get
            {
                return _contentid;
            }
            set
            {
                _contentid = value;
                ViewState["ContentID"] = _contentid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _imageid = ViewState["ImageID"].ToString();
                    _height = Convert.ToInt32(ViewState["Height"]);
                    _width = Convert.ToInt32(ViewState["Width"]);
                    _border = Convert.ToInt32(ViewState["Border"]);

                    _imageurl = ViewState["ImageURL"].ToString();
                    _alternatetext = ViewState["AlternateText"].ToString();
                    _linkurl = ViewState["LinkURL"].ToString();
                    _link_target = ViewState["Link_Target"].ToString();

                    _isshared = Convert.ToBoolean(ViewState["IsShared"]);
                    _contentid = ViewState["ContentID"].ToString();
                }
                catch
                {
                    // nothing to do
                }

            }
            else
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {

            if (!DataEval.IsEmptyQuery(_imageid))
            {

                #region Image Properties
                RadNumericTbx_Height.Value = _height;
                RadNumericTbx_Width.Value = _width;
                RadNumericTbx_Border.Value = _border;
                #endregion

                if (_isshared)
                {
                    Lib.ImageMgr myImageMgr = new Lib.ImageMgr();
                    Lib.Image myImage = myImageMgr.Get_Image_Content(_contentid);

                    _imageurl = myImage.ImageURL;
                    _alternatetext = myImage.AlternateText;
                    _linkurl = myImage.LinkURL;
                    _link_target = myImage.Link_Target;

                }

                // Image Data
                tbx_ImageURL.Text = _imageurl;
                tbx_AlternateText.Text = _alternatetext;

                // Link Data
                tbx_LinkURL.Text = _linkurl;
                RadComboBox_LinkTarget.Text = _link_target;
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            Lib.ImageMgr myImageMgr = new Lib.ImageMgr();

            DateTime nowTime = DateTime.Now;

            string ImageID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_imageid))
            {
                if (_isshared)
                {
                    e2Data[] UpdateData = {
                                              new e2Data("ImageID", _contentid),
                                              new e2Data("ImageURL", tbx_ImageURL.Text),
                                              new e2Data("AlternateText", tbx_AlternateText.Text),
                                              new e2Data("LinkURL", tbx_LinkURL.Text),
                                              new e2Data("Link_Target", RadComboBox_LinkTarget.Text),
                                              new e2Data("Create_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                          };

                    myImageMgr.Add_Image_Content(UpdateData);
                }

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "ImageID", ImageID),
                                                       new Control_Property(_page_controlid, "Height", RadNumericTbx_Height.Value.ToString()),
                                                       new Control_Property(_page_controlid, "Width", RadNumericTbx_Width.Value.ToString()),
                                                       new Control_Property(_page_controlid, "Border", RadNumericTbx_Border.Value.ToString()),
                                                       new Control_Property(_page_controlid, "ImageURL",  tbx_ImageURL.Text),
                                                       new Control_Property(_page_controlid, "AlternateText",tbx_AlternateText.Text),
                                                       new Control_Property(_page_controlid, "LinkURL", tbx_LinkURL.Text),
                                                       new Control_Property(_page_controlid, "Link_Target", RadComboBox_LinkTarget.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)

                                                    };

                Update_Properties = PropertieData;

            }
            else
            {

                if (_isshared)
                {
                    e2Data[] UpdateData = {
                                              new e2Data("ImageID", _imageid),
                                              new e2Data("ImageURL", tbx_ImageURL.Text),
                                              new e2Data("AlternateText", tbx_AlternateText.Text),
                                              new e2Data("LinkURL", tbx_LinkURL.Text),
                                              new e2Data("Link_Target", RadComboBox_LinkTarget.Text),
                                              new e2Data("LastUpdate_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                          };

                    myImageMgr.Edit_Image_Content(UpdateData);
                }

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "ImageID", _imageid),
                                                       new Control_Property(_page_controlid, "Height", RadNumericTbx_Height.Value.ToString()),
                                                       new Control_Property(_page_controlid, "Width", RadNumericTbx_Width.Value.ToString()),
                                                       new Control_Property(_page_controlid, "Border", RadNumericTbx_Border.Value.ToString()),
                                                       new Control_Property(_page_controlid, "ImageURL",  tbx_ImageURL.Text),
                                                       new Control_Property(_page_controlid, "AlternateText",tbx_AlternateText.Text),
                                                       new Control_Property(_page_controlid, "LinkURL", tbx_LinkURL.Text),
                                                       new Control_Property(_page_controlid, "Link_Target", RadComboBox_LinkTarget.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _imageid, _page_controlid, Update_Properties);

            #endregion

            // Finish Update Close Window
            //OnFinishUpdate(this, EventArgs.Empty);
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

        public void Control_SaveCopy(string Page_ControlID)
        {
            // Save as Draft from Design Mode
        }

        public void Contro_Duplicate(string Page_ControlID)
        {
            // Duplicate a Page
        }


}

}