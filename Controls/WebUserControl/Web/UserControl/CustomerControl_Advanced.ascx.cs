using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Nexus.Controls.WebUserControls.CustomerControl
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _webusercontrolid;
        private string _path;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string WebUserControlID
        {
            get
            {
                if (_webusercontrolid == null)
                {
                    return "";
                }
                return _webusercontrolid;
            }
            set
            {
                _webusercontrolid = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Path
        {
            get
            {
                if (_path == null)
                {
                    return "";
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Control_Init();
        }

        private void Control_Init()
        {
            if (DataEval.IsEmptyQuery(_webusercontrolid))
            {
                MultiView_Content.SetActiveView(View_New);
            }
            else
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(_path)))
                {
                    Literal_TextContent.Text = string.Format("Customer Control: {0}", _path);
                }
                else
                {
                    Literal_TextContent.Text = string.Format("Customer Control load fialed: {0}", _path);
                }

                MultiView_Content.SetActiveView(View_Show);

            }
        }

    }
}