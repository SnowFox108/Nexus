using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Navigation.Menu
{
    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _menuid;

        private bool _isstatic;
        private string _rootpageindexid;
        private bool _displaysamelevel;
        private bool _displaycategory;
        private string _orientation;
        private string _skin;
        private string _cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string MenuID
        {
            get
            {
                return _menuid;
            }
            set
            {
                _menuid = value;
                ViewState["MenuID"] = _menuid;
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
        [Category("Layout")]
        [DefaultValue("HorizontalBottom")]
        [Localizable(true)]
        public string Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                ViewState["Orientation"] = _orientation;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string Skin
        {
            get
            {
                return _skin;
            }
            set
            {
                _skin = value;
                ViewState["Skin"] = _skin;
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


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _menuid = ViewState["MenuID"].ToString();
                    _isstatic = Convert.ToBoolean(ViewState["IsStatic"]);
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaysamelevel = Convert.ToBoolean(ViewState["DisplaySameLevel"]);
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _orientation = ViewState["Orientation"].ToString();
                    _skin = ViewState["Skin"].ToString();
                    _cssclass = ViewState["CssClass"].ToString();
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

            if (DataEval.IsEmptyQuery(_menuid))
            {
                MultiView_Content.SetActiveView(View_New);
            }
            else
            {

                MultiView_Content.SetActiveView(View_Show);

                Lib.MenuMgr myMenuMgr = new Lib.MenuMgr();

                string _pageindexid;

                if (_isstatic)
                    _pageindexid = _rootpageindexid;
                else
                    _pageindexid = Request.QueryString["PageIndexID"];

                if (_pageindexid == null)
                    _pageindexid = "-1";

                List<Lib.Menu> myMenus = myMenuMgr.Get_Menu(_pageindexid, _displaysamelevel, _displaycategory);
                RadTabStrip_Menu.DataSource = myMenus;
                RadTabStrip_Menu.DataTextField = "Page_Name";

                if (Request.QueryString["PageLink"] != "Disable")
                {
                    RadTabStrip_Menu.DataNavigateUrlField = "NavigateUrl";
                }

                RadTabStrip_Menu.DataBind();

                #region Look for selected Page

                Lib.NavigatorMgr myNavigatorMgr = new Lib.NavigatorMgr();
                List<Lib.Navigator> myNavigators = myNavigatorMgr.Get_Navigator(_pageindexid, _rootpageindexid);

                for (int i = 0; i < myMenus.Count; i++)
                {
                    foreach (Lib.Navigator myNavigator in myNavigators)
                    {
                        if (myMenus[i].PageIndexID == myNavigator.PageIndexID)
                            RadTabStrip_Menu.SelectedIndex = i;
                    }
                }

                #endregion

                switch (_orientation)
                {
                    case "HorizontalBottom":
                        RadTabStrip_Menu.Orientation = Telerik.Web.UI.TabStripOrientation.HorizontalBottom;
                        break;

                    case "HorizontalTop":
                        RadTabStrip_Menu.Orientation = Telerik.Web.UI.TabStripOrientation.HorizontalTop;
                        break;

                    case "VerticalLeft":
                        RadTabStrip_Menu.Orientation = Telerik.Web.UI.TabStripOrientation.VerticalLeft;
                        break;

                    case "VerticalRight":
                        RadTabStrip_Menu.Orientation = Telerik.Web.UI.TabStripOrientation.VerticalRight;
                        break;
                }

                if (_skin == "Customer")
                {
                    RadTabStrip_Menu.EnableEmbeddedSkins = false;

                    if (!DataEval.IsEmptyQuery(_cssclass))
                        RadTabStrip_Menu.CssClass = _cssclass;
                }
                else
                {
                    RadTabStrip_Menu.Skin = _skin;
                }
            }

        }
    }
}