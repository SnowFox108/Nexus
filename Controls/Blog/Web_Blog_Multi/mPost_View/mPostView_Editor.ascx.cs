using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Blog.mPostView
{

    public partial class Editor : System.Web.UI.UserControl
    {

        #region Basic Properties, Must Have to get control work

        private string _page_controlid;
        private string _editmode;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string EditMode
        {
            get
            {
                if (_editmode == null)
                {
                    return "";
                }
                return _editmode;
            }
            set
            {
                _editmode = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Page_ControlID
        {
            get
            {
                if (_page_controlid == null)
                {
                    return "";
                }
                return _page_controlid;
            }
            set
            {
                _page_controlid = value;
            }
        }

        #endregion

        #region Properties

        private string _postviewid;

        private bool _ispagetitle = true;
        private bool _isguestcomment = true;
        private int _numberperpage = 10;
        private string _blogpostsurl = "/";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PostViewID
        {
            get
            {
                return _postviewid;
            }
            set
            {
                _postviewid = value;
                ViewState["PostViewID"] = _postviewid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsPageTitle
        {
            get
            {
                return _ispagetitle;
            }
            set
            {
                _ispagetitle = value;
                ViewState["IsPageTitle"] = _ispagetitle;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool IsGuestComment
        {
            get
            {
                return _isguestcomment;
            }
            set
            {
                _isguestcomment = value;
                ViewState["IsGuestComment"] = _isguestcomment;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("10")]
        [Localizable(true)]
        public int NumberPerPage
        {
            get
            {
                return _numberperpage;
            }
            set
            {
                _numberperpage = value;
                ViewState["NumberPerPage"] = _numberperpage;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string BlogPostsURL
        {
            get
            {
                return _blogpostsurl;
            }
            set
            {
                _blogpostsurl = value;
                ViewState["BlogPostsURL"] = _blogpostsurl;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _postviewid = ViewState["PostViewID"].ToString();
                    _ispagetitle = Convert.ToBoolean(ViewState["IsPageTitle"]);
                    _isguestcomment = Convert.ToBoolean(ViewState["IsGuestComment"]);
                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
                    _blogpostsurl = ViewState["BlogPostsURL"].ToString();

                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Control_Init();
            }

        }

        private void Control_Init()
        {

            #region Set Default Setting

            rbtn_IsPageTitle.SelectedValue = "True";
            rbtn_IsGuestComment.SelectedValue = "True";
            RadNumericTbx_NumPerPage.Value = 10;
            tbx_BlogPostsURL.Text = "/";

            #endregion

            if (!DataEval.IsEmptyQuery(_postviewid))
            {

                #region Blog Properties

                rbtn_IsPageTitle.SelectedValue = _ispagetitle.ToString();
                rbtn_IsGuestComment.SelectedValue = _isguestcomment.ToString();
                RadNumericTbx_NumPerPage.Value = _numberperpage;
                tbx_BlogPostsURL.Text = _blogpostsurl;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string PostViewID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_postviewid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "PostViewID", PostViewID),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "BlogPostsURL", tbx_BlogPostsURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "PostViewID", _postviewid),
                                                               new Control_Property(_page_controlid, "IsPageTitle", rbtn_IsPageTitle.SelectedValue),
                                                               new Control_Property(_page_controlid, "IsGuestComment", rbtn_IsGuestComment.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "BlogPostsURL", tbx_BlogPostsURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _postviewid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }


    }
}