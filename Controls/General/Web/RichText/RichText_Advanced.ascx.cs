using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.General.RichText
{

    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _richtextid;
        private string _richtext_content = "";

        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string RichTextID
        {
            get
            {
                return _richtextid;
            }
            set
            {
                _richtextid = value;
                ViewState["RichTextID"] = _richtextid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string RichText_Content
        {
            get
            {
                return _richtext_content;
            }
            set
            {
                _richtext_content = value;
                ViewState["RichText_Content"] = _richtext_content;
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

                    _richtextid = ViewState["RichTextID"].ToString();
                    _richtext_content = ViewState["RichText_Content"].ToString();
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
            if (DataEval.IsEmptyQuery(_richtextid))
            {
                MultiView_Content.SetActiveView(View_New);
            }
            else
            {
                MultiView_Content.SetActiveView(View_Show);

                if (_isshared)
                {
                    Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();
                    Lib.RichText myRichText = myRichTextMgr.Get_RichText_Content(_contentid);

                    Literal_TextContent.Text = myRichText.RichText_Content;
                }
                else
                {
                    Literal_TextContent.Text = _richtext_content;
                }
            }
        }

        public void Refresh()
        {
            Control_Init();
        }
    }
}