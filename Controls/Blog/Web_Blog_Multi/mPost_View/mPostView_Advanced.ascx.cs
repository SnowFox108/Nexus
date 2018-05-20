using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Controls.Blog.mPostView
{

    public partial class Advanced : System.Web.UI.UserControl
    {

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

            Control_Init();

        }

        private void Control_Init()
        {

            if (DataEval.IsEmptyQuery(_postviewid))
            {
                MultiView_PostView.SetActiveView(View_New);
            }
            else
            {

                if (Request.QueryString["PageLink"] == "Disable")
                {
                    lbtn_Edit_Post.Enabled = false;
                    btn_PostComment.Enabled = false;
                }


                MultiView_PostView.SetActiveView(View_Post);

                // Init Comment Form
                RadEditor_Comment.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                RadEditor_Comment.EditModes = Telerik.Web.UI.EditModes.Design | Telerik.Web.UI.EditModes.Preview;


                // Fillup Post Content
                lbl_Title.Text = "Demo Title...";
                lbl_Post_Date.Text = DateTime.Now.ToShortDateString();
                lbl_UserName.Text = "Demo User Name";
                Literal_Content.Text = "<p>Demo Content...</p>";
                lbl_Post_ModifyDate.Text = DateTime.Now.ToString();
                lbl_Comment_Count.Text = "0";

                // Add Social button
                PlaceHolder_SocialNetwork.Controls.Clear();

                HyperLink myHyperLink = new HyperLink();
                myHyperLink.ImageUrl = "~/App_Control_Style/Nexus_mBlog/SocialBookmark/Facebook_24.png";

                PlaceHolder_SocialNetwork.Controls.Add(myHyperLink);

            }

        }

    }
}