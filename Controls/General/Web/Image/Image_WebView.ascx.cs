using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nexus.Controls.General.Image
{
    public partial class WebView : System.Web.UI.UserControl
    {

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

            Control_Init();

        }

        private void Control_Init()
        {

            if (!DataEval.IsEmptyQuery(_imageid))
            {

                HtmlImage myHtmlImage = new HtmlImage();

                if (_isshared)
                {
                    Lib.ImageMgr myImageMgr = new Lib.ImageMgr();
                    Lib.Image myImage = myImageMgr.Get_Image_Content(_contentid);

                    _imageurl = myImage.ImageURL;
                    _alternatetext = myImage.AlternateText;
                    _linkurl = myImage.LinkURL;
                    _link_target = myImage.Link_Target;

                }

                // ImageURL

                myHtmlImage.Src = _imageurl;

                // AlternateText
                myHtmlImage.Alt = _alternatetext;

                // Image Height
                if (_height > 0)
                    myHtmlImage.Height = _height;

                // Image Width
                if (_width > 0)
                    myHtmlImage.Width = _width;

                // Image Border
                myHtmlImage.Border = _border;


                if (Request.QueryString["PageLink"] == "Disable")
                {
                    PlaceHolder_Content.Controls.Add(myHtmlImage);
                }
                else
                {
                    if (!DataEval.IsEmptyQuery(_linkurl))
                    {
                        HtmlGenericControl myLink = new HtmlGenericControl("a");
                        myLink.Attributes.Add("href", _linkurl);

                        if (!DataEval.IsEmptyQuery(_link_target))
                        {
                            myLink.Attributes.Add("target", _link_target);
                        }

                        myLink.Controls.Add(myHtmlImage);
                        PlaceHolder_Content.Controls.Add(myLink);
                    }
                    else
                    {
                        PlaceHolder_Content.Controls.Add(myHtmlImage);
                    }
                }
            }
        }

        public void Refresh()
        {
            Control_Init();
        }

    }
}