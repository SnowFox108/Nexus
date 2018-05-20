using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.General.HTML
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _htmlid;
        private string _html_content = "";
        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string HTMLID
        {
            get
            {
                return _htmlid;
            }
            set
            {
                _htmlid = value;
                ViewState["HTMLID"] = _htmlid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string HTML_Content
        {
            get
            {
                return _html_content;
            }
            set
            {
                _html_content = value;
                ViewState["HTML_Content"] = _html_content;
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
                    _htmlid = ViewState["HTMLID"].ToString();
                    _html_content = ViewState["HTML_Content"].ToString();
                    _isshared = Convert.ToBoolean(ViewState["IsShared"]);
                    _contentid = ViewState["ContentID"].ToString();
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
            if (DataEval.IsEmptyQuery(_htmlid))
            {
                MultiView_Content.SetActiveView(View_New);
            }
            else
            {
                MultiView_Content.SetActiveView(View_Show);

                if (_isshared)
                {
                    Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();
                    Lib.HTML myHTML = myHTMLMgr.Get_HTML_Content(_contentid);

                    Literal_TextContent.Text = string.Format("<Pre>{0}</Pre>", Server.HtmlEncode(myHTML.HTML_Content));

                }
                else
                {
                    Literal_TextContent.Text = string.Format("<Pre>{0}</Pre>", Server.HtmlEncode(_html_content));
                }

            }
        }

        public void Refresh()
        {
            Control_Init();
        }

    }
}
