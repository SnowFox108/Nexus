using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Login.LoginRefresh
{

    public partial class Advanced : System.Web.UI.UserControl
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
                try
                {
                    _loginrefreshid = ViewState["LoginRefreshID"].ToString();
                    _returnurl = ViewState["ReturnURL"].ToString();
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

            if (DataEval.IsEmptyQuery(_loginrefreshid))
            {
                MultiView_Content.SetActiveView(View_New);

            }
            else
            {
                MultiView_Content.SetActiveView(View_Show);

                lbl_ReturnLink.Text = "Return Link";
            }
        }

    }
}