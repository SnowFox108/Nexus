using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nexus.Controls.Navigation.CSS_Menu
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _css_menuid;

        private bool _isstatic = true;
        private string _rootpageindexid = "-1";
        private bool _displaysamelevel = false;
        private bool _displaycategory = true;
        private string _cssclass;
        private string _active_cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CSS_MenuID
        {
            get
            {
                return _css_menuid;
            }
            set
            {
                _css_menuid = value;
                ViewState["CSS_MenuID"] = _css_menuid;
            }
        }


        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool IsStatic
        {
            get
            {
                return _isstatic;
            }
            set
            {
                _isstatic = value;
                ViewState["IsStatic"] = _isstatic;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("-1")]
        [Localizable(true)]
        public string RootPageIndexID
        {
            get
            {
                return _rootpageindexid;
            }
            set
            {
                _rootpageindexid = value;
                ViewState["RootPageIndexID"] = _rootpageindexid;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("False")]
        [Localizable(true)]
        public bool DisplaySameLevel
        {
            get
            {
                return _displaysamelevel;
            }
            set
            {
                _displaysamelevel = value;
                ViewState["DisplaySameLevel"] = _displaysamelevel;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("True")]
        [Localizable(true)]
        public bool DisplayCategory
        {
            get
            {
                return _displaycategory;
            }
            set
            {
                _displaycategory = value;
                ViewState["DisplayCategory"] = _displaycategory;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CssClass
        {
            get
            {
                return _cssclass;
            }
            set
            {
                _cssclass = value;
                ViewState["CssClass"] = _cssclass;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string Active_CssClass
        {
            get
            {
                return _active_cssclass;
            }
            set
            {
                _active_cssclass = value;
                ViewState["Active_CssClass"] = _active_cssclass;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {

                    _css_menuid = ViewState["CSS_MenuID"].ToString();
                    _isstatic = Convert.ToBoolean(ViewState["IsStatic"]);
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaysamelevel = Convert.ToBoolean(ViewState["DisplaySameLevel"]);
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _cssclass = ViewState["CssClass"].ToString();
                    _active_cssclass = ViewState["Active_CssClass"].ToString();

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

            if (!DataEval.IsEmptyQuery(_css_menuid))
            {

                Lib.MenuMgr myMenuMgr = new Lib.MenuMgr();

                string _pageindexid = Request.QueryString["PageIndexID"];

                if (_pageindexid == null)
                    _pageindexid = "-1";

                if (!_isstatic)
                    _rootpageindexid = _pageindexid;


                List<Lib.Menu> myMenus = myMenuMgr.Get_Menu(_rootpageindexid, _displaysamelevel, _displaycategory);

                #region Look for selected Page

                string[] Menu_cssclass = new string[myMenus.Count];

                Lib.NavigatorMgr myNavigatorMgr = new Lib.NavigatorMgr();
                List<Lib.Navigator> myNavigators = myNavigatorMgr.Get_Navigator(_pageindexid, _rootpageindexid);

                for (int i = 0; i < myMenus.Count; i++)
                {
                    bool _isactive = false;
                    foreach (Lib.Navigator myNavigator in myNavigators)
                    {
                        if (myMenus[i].PageIndexID == myNavigator.PageIndexID)
                            _isactive = true;
                    }

                    if (_isactive)
                        Menu_cssclass[i] = _active_cssclass;
                    else
                        Menu_cssclass[i] = _cssclass;
                }

                #endregion

                // Create Menu
                HtmlGenericControl Menu_UL = new HtmlGenericControl("ul");

                int _menu_i = 0;
                foreach (Lib.Menu myMenu in myMenus)
                {
                    HtmlGenericControl Menu_Li = new HtmlGenericControl("li");
                    Menu_Li.Attributes.Add("class", Menu_cssclass[_menu_i]);

                    HyperLink myHyperLink = new HyperLink();
                    myHyperLink.CssClass = Menu_cssclass[_menu_i];

                    myHyperLink.Text = "<span>" + myMenu.Menu_Title + "</span>";
                    myHyperLink.NavigateUrl = myMenu.NavigateUrl;

                    if (Request.QueryString["PageLink"] == "Disable")
                    {
                        myHyperLink.Enabled = false;
                    }

                    Menu_Li.Controls.Add(myHyperLink);
                    Menu_UL.Controls.Add(Menu_Li);

                    _menu_i++;
                }

                PlaceHolder_Menu.Controls.Add(Menu_UL);


            }

        }

    }
}