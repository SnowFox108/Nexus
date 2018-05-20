using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Tools;
using Nexus.Core.URLrewriter;

namespace Nexus.Controls.Login.LoginRefresh
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _loginrefreshid;

        private string _returnurl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LoginRefreshID
        {
            get
            {
                return _loginrefreshid;
            }
            set
            {
                _loginrefreshid = value;
                ViewState["LoginRefreshID"] = _loginrefreshid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("/")]
        [Localizable(true)]
        public string ReturnURL
        {
            get
            {
                return _returnurl;
            }
            set
            {
                _returnurl = value;
                ViewState["ReturnURL"] = _returnurl;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                _loginrefreshid = ViewState["LoginRefreshID"].ToString();
                _returnurl = ViewState["ReturnURL"].ToString();

            }

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_loginrefreshid))
            {
                lbl_ReturnLink.Text = "Return Link";
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    lbl_ReturnLink.Text = "Return Link";
                }
                else
                {
                    string ReturnURL = _returnurl;

                    if (Session["ReturnURL"] != null)
                    {
                        UrlMgr myUrlMgr = new UrlMgr();
                        ReturnURL = myUrlMgr.Get_SEO_Friendly_URL(ReturnURL);
                    }

                    lbl_ReturnLink.Text = "<A href=" + ReturnURL + ">Return Link</A>";

                    string JavaScript = "<script type='text/javascript'>\n"
                        + "<!--\n"
                        + "function exec_refresh()\n"
                        + "{\n"
                        + "window.status = 'Jump to...' + myvar;\n"
                        + "myvar = myvar + ' .';\n"
                        + "var timerID = setTimeout('exec_refresh();', 100);\n"
                        + "if (timeout > 0)\n"
                        + "{\n"
                        + "timeout -= 1;\n"
                        + "}\n"
                        + "else\n"
                        + "{\n"
                        + "clearTimeout(timerID);\n"
                        + "window.status = '';\n"
                        + "window.location = '" + ReturnURL + "';\n"
                        + "}\n"
                        + "}\n"
                        + "var myvar = '';\n"
                        + "var timeout = 20;\n"
                        + "exec_refresh();\n"
                        + "//-->\n"
                        + "</script>\n";

                    Literal_JavaScript.Text = JavaScript;
                }
            }
        }


    }
}