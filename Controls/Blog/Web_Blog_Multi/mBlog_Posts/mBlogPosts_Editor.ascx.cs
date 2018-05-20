using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;

namespace Nexus.Controls.Blog.mBlogPosts
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

        private string _blogpostsid;

        private string _postviewurl;
        private bool _showcontent;
        private int _numberperpage;

        private bool _showpublicposts;
        private int _maxnumberposts;
        private string _returnurl;


        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string BlogPostsID
        {
            get
            {
                return _blogpostsid;
            }
            set
            {
                _blogpostsid = value;
                ViewState["BlogPostsID"] = _blogpostsid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PostViewURL
        {
            get
            {
                return _postviewurl;
            }
            set
            {
                _postviewurl = value;
                ViewState["PostViewURL"] = _postviewurl;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool ShowContent
        {
            get
            {
                return _showcontent;
            }
            set
            {
                _showcontent = value;
                ViewState["ShowContent"] = _showcontent;
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
        public bool ShowPublicPosts
        {
            get
            {
                return _showpublicposts;
            }
            set
            {
                _showpublicposts = value;
                ViewState["ShowPublicPosts"] = _showpublicposts;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("10")]
        [Localizable(true)]
        public int MaxNumberPosts
        {
            get
            {
                return _maxnumberposts;
            }
            set
            {
                _maxnumberposts = value;
                ViewState["MaxNumberPosts"] = _maxnumberposts;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
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
                    _blogpostsid = ViewState["BlogPostsID"].ToString();
                    _postviewurl = ViewState["PostViewURL"].ToString();
                    _showcontent = Convert.ToBoolean(ViewState["ShowContent"]);
                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);

                    _showpublicposts = Convert.ToBoolean(ViewState["ShowPublicPosts"]);
                    _maxnumberposts = Convert.ToInt16(ViewState["MaxNumberPosts"]);
                    _returnurl = ViewState["ReturnURL"].ToString();

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

            rbtn_ShowContent.SelectedValue = "True";
            RadNumericTbx_NumPerPage.Value = 10;
            tbx_PostViewURL.Text = "/";

            rbtn_ShowPublicPosts.SelectedValue = "True";
            RadNumericTbx_MaxNumberPosts.Value = 50;
            tbx_ReturnURL.Text = "/";

            #endregion

            if (!DataEval.IsEmptyQuery(_blogpostsid))
            {

                #region Blog Properties

                rbtn_ShowContent.SelectedValue = _showcontent.ToString();
                RadNumericTbx_NumPerPage.Value = _numberperpage;
                tbx_PostViewURL.Text = _postviewurl;

                rbtn_ShowPublicPosts.SelectedValue = _showpublicposts.ToString();
                RadNumericTbx_MaxNumberPosts.Value = _maxnumberposts;
                tbx_ReturnURL.Text = _returnurl;

                #endregion

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            string BlogPostID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Check Control is New
            if (DataEval.IsEmptyQuery(_blogpostsid))
            {

                // The Control Does not have extra table

                // Create Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "BlogPostsID", BlogPostID),
                                                               new Control_Property(_page_controlid, "PostViewURL", tbx_PostViewURL.Text),
                                                               new Control_Property(_page_controlid, "ShowContent", rbtn_ShowContent.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "ShowPublicPosts", rbtn_ShowPublicPosts.SelectedValue),
                                                               new Control_Property(_page_controlid, "MaxNumberPosts", RadNumericTbx_MaxNumberPosts.Value.ToString()),
                                                               new Control_Property(_page_controlid, "ReturnURL", tbx_ReturnURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }
            else
            {
                // The Control Does not have extra table

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                               new Control_Property(_page_controlid, "BlogPostsID", _blogpostsid),
                                                               new Control_Property(_page_controlid, "PostViewURL", tbx_PostViewURL.Text),
                                                               new Control_Property(_page_controlid, "ShowContent", rbtn_ShowContent.SelectedValue),
                                                               new Control_Property(_page_controlid, "NumberPerPage", RadNumericTbx_NumPerPage.Value.ToString()),
                                                               new Control_Property(_page_controlid, "ShowPublicPosts", rbtn_ShowPublicPosts.SelectedValue),
                                                               new Control_Property(_page_controlid, "MaxNumberPosts", RadNumericTbx_MaxNumberPosts.Value.ToString()),
                                                               new Control_Property(_page_controlid, "ReturnURL", tbx_ReturnURL.Text)
                                                    };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _blogpostsid, _page_controlid, Update_Properties);

            #endregion


            // Finish Update Close Window
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

    }
}