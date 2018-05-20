using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nexus.Core;

namespace Nexus.Controls.General.Script
{

    public partial class WebView : System.Web.UI.UserControl
    {

        #region Properties

        private string _scriptid;

        private string _script_type = "text/javascript";
        private string _script_content = "";

        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ScriptID
        {
            get
            {
                if (_scriptid == null)
                {
                    return "";
                }
                return _scriptid;
            }
            set
            {
                _scriptid = value;
                ViewState["ScriptID"] = _scriptid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Script_Type
        {
            get
            {
                return _script_type;
            }
            set
            {
                _script_type = value;
                ViewState["Script_Type"] = _script_type;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Script_Content
        {
            get
            {
                return _script_content;
            }
            set
            {
                _script_content = value;
                ViewState["Script_Content"] = _script_content;
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

                    _scriptid = ViewState["ScriptID"].ToString();
                    _script_type = ViewState["Script_Type"].ToString();
                    _script_content = ViewState["Script_Content"].ToString();
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
            if (_isshared)
            {
                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                Lib.Script myScript = myScriptMgr.Get_Script_Content(_contentid);

                _script_type = StringEnum.GetStringValue(myScript.Script_Type);
                _script_content = myScript.Script_Content;

            }

            HtmlGenericControl myCodeBlock_ScriptTag = new HtmlGenericControl("script");
            myCodeBlock_ScriptTag.Attributes.Add("type", _script_type);

            Literal myCodeBlock_ScriptText = new Literal();
            myCodeBlock_ScriptText.Text = _script_content;

            myCodeBlock_ScriptTag.Controls.Add(myCodeBlock_ScriptText);

            PlaceHolder_Content.Controls.Add(myCodeBlock_ScriptTag);
        }

        public void Refresh()
        {
            Control_Init();
        }

    }

}