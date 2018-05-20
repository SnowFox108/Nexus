using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Navigation.Navigator
{
    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _navigatorid;

        private string _rootpageindexid = "-1";
        private bool _displaycategory = true;
        private string _navigatorsign = ">";
        private string _cssclass;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NavigatorID
        {
            get
            {
                return _navigatorid;
            }
            set
            {
                _navigatorid = value;
                ViewState["NavigatorID"] = _navigatorid;
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
        [DefaultValue(">")]
        [Localizable(true)]
        public string NavigatorSign
        {
            get
            {
                return _navigatorsign;
            }
            set
            {
                _navigatorsign = value;
                ViewState["NavigatorSign"] = _navigatorsign;
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
                    _navigatorid = ViewState["NavigatorID"].ToString();
                    _rootpageindexid = ViewState["RootPageIndexID"].ToString();
                    _displaycategory = Convert.ToBoolean(ViewState["DisplayCategory"]);
                    _navigatorsign = ViewState["NavigatorSign"].ToString();
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

            if (DataEval.IsEmptyQuery(_navigatorid))
            {
                MultiView_Content.SetActiveView(View_New);
            }
            else
            {

                MultiView_Content.SetActiveView(View_Show);

                Lib.NavigatorMgr myNavigatorMgr = new Lib.NavigatorMgr();

                string _pageindexid;

                _pageindexid = Request.QueryString["PageIndexID"];

                if (_pageindexid == null)
                    _pageindexid = "-1";

                // Navigator Item

                List<Lib.Navigator> myNavigator = myNavigatorMgr.Get_Navigator(_pageindexid, _rootpageindexid);

                // Add Homepage Link
                if (_rootpageindexid == "-1" || DataEval.IsEmptyQuery(_rootpageindexid))
                {
                    HyperLink hlink_HomePage = new HyperLink();
                    hlink_HomePage.Text = "HomePage";

                    if (Request.QueryString["PageLink"] != "Disable")
                    {
                        hlink_HomePage.NavigateUrl = "/Default.aspx";
                    }

                    PlaceHolder_Navigator.Controls.Add(hlink_HomePage);
                }
                else
                {
                    Lib.Navigator HomeNavigator = myNavigatorMgr.Get_Navigator_Home(_rootpageindexid);

                    HyperLink hlink_HomePage = new HyperLink();
                    hlink_HomePage.Text = HomeNavigator.Page_Name;

                    if (Request.QueryString["PageLink"] != "Disable")
                    {
                        hlink_HomePage.NavigateUrl = HomeNavigator.NavigateUrl;
                    }

                    PlaceHolder_Navigator.Controls.Add(hlink_HomePage);

                }

                // Add Navigator Link
                for (int i = 0; i < myNavigator.Count - 1; i++)
                {
                    if (_displaycategory)
                    {
                        if (myNavigator[i].IsOnNavigator)
                        {
                            // Add Navigator Sign
                            PlaceHolder_Navigator.Controls.Add(new LiteralControl(_navigatorsign));

                            // Add Navigator Link
                            HyperLink hlink_PageLink = new HyperLink();
                            hlink_PageLink.Text = myNavigator[i].Page_Name;

                            if (Request.QueryString["PageLink"] != "Disable")
                            {
                                hlink_PageLink.NavigateUrl = myNavigator[i].NavigateUrl;
                            }

                            PlaceHolder_Navigator.Controls.Add(hlink_PageLink);

                        }
                    }
                    else
                    {
                        if (myNavigator[i].Page_Type != Core.Pages.Page_Type.Category)
                        {
                            if (myNavigator[i].IsOnNavigator)
                            {
                                // Add Navigator Sign
                                PlaceHolder_Navigator.Controls.Add(new LiteralControl(_navigatorsign));

                                // Add Navigator Link
                                HyperLink hlink_PageLink = new HyperLink();
                                hlink_PageLink.Text = myNavigator[i].Page_Name;

                                if (Request.QueryString["PageLink"] != "Disable")
                                {
                                    hlink_PageLink.NavigateUrl = myNavigator[i].NavigateUrl;
                                }

                                PlaceHolder_Navigator.Controls.Add(hlink_PageLink);

                            }
                        }
                    }
                }

                // Add Page Name
                if (myNavigator.Count > 0)
                {
                    // Add Navigator Sign
                    PlaceHolder_Navigator.Controls.Add(new LiteralControl(_navigatorsign));

                    // Add Current Page Name
                    Literal literal_PageName = new Literal();
                    literal_PageName.Text = myNavigator[myNavigator.Count - 1].Page_Name;

                    PlaceHolder_Navigator.Controls.Add(literal_PageName);
                }

                if (_cssclass != "Blank")
                {
                    Panel_Navigator.CssClass = _cssclass;
                }

            }

        }

    }
}