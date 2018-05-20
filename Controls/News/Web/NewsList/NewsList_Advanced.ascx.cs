using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;

namespace Nexus.Controls.News.NewsList
{
    public partial class Advanced : System.Web.UI.UserControl
    {

        #region Properties

        private string _newslistid;

        private string _categoryid = "";
        private string _newsdetailurl = "/";
        private string _sortorder = "News_Date";
        private string _orientation = "DESC";

        private string _itemtemplate = "Default";
        private string _itemtemplateurl = "";
        private bool _enable_pager = true;

        private int _numberperpage = 10;
        private int _totalnumber = 100;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsListID
        {
            get
            {
                return _newslistid;
            }
            set
            {
                _newslistid = value;
                ViewState["NewsListID"] = _newslistid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CategoryID
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                ViewState["CategoryID"] = _categoryid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NewsDetailURL
        {
            get
            {
                return _newsdetailurl;
            }
            set
            {
                _newsdetailurl = value;
                ViewState["NewsDetailURL"] = _newsdetailurl;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string SortOrder
        {
            get
            {
                return _sortorder;
            }
            set
            {
                _sortorder = value;
                ViewState["SortOrder"] = _sortorder;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                ViewState["Orientation"] = _orientation;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("Default")]
        [Localizable(true)]
        public string ItemTemplate
        {
            get
            {
                return _itemtemplate;
            }
            set
            {
                _itemtemplate = value;
                ViewState["ItemTemplate"] = _itemtemplate;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ItemTemplateURL
        {
            get
            {
                return _itemtemplateurl;
            }
            set
            {
                _itemtemplateurl = value;
                ViewState["ItemTemplateURL"] = _itemtemplateurl;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool Enable_Pager
        {
            get
            {
                return _enable_pager;
            }
            set
            {
                _enable_pager = value;
                ViewState["Enable_Pager"] = _enable_pager;
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
        [DefaultValue("100")]
        [Localizable(true)]
        public int TotalNumber
        {
            get
            {
                return _totalnumber;
            }
            set
            {
                _totalnumber = value;
                ViewState["TotalNumber"] = _totalnumber;
            }
        }

        #endregion

        string _news_status_show;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _newslistid = ViewState["NewsListID"].ToString();
                    _categoryid = ViewState["CategoryID"].ToString();
                    _newsdetailurl = ViewState["NewsDetailURL"].ToString();
                    _sortorder = ViewState["SortOrder"].ToString();
                    _orientation = ViewState["Orientation"].ToString();

                    _itemtemplate = ViewState["ItemTemplate"].ToString();
                    _itemtemplateurl = ViewState["ItemTemplateURL"].ToString();
                    _enable_pager = Convert.ToBoolean(ViewState["Enable_Pager"]);

                    _numberperpage = Convert.ToInt16(ViewState["NumberPerPage"]);
                    _totalnumber = Convert.ToInt16(ViewState["TotalNumber"]);
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

            if (DataEval.IsEmptyQuery(_newslistid))
            {
                MultiView_NewsList.SetActiveView(View_New);
            }
            else
            {
                if (Request.QueryString["PageLink"] == "Disable")
                {
                    ListView_NewsList.Enabled = false;
                    btn_NewsStatus_Show.Enabled = false;
                }

                MultiView_NewsList.SetActiveView(View_NewsList);

                #region Bind Data to droplist
                // Enable user edit mode

                //Gets your enum names and adds it to a string array
                Array enumNames = Enum.GetValues(typeof(Lib.News_Status));

                //Creates an ArrayList
                ArrayList myNews_Statuses = new ArrayList();

                //Loop through your string array and poppulates the ArrayList
                foreach (Lib.News_Status myNews_Status in enumNames)
                {
                    myNews_Statuses.Add(new { Value = StringEnum.GetStringValue(myNews_Status), Name = myNews_Status.ToString() });
                }


                //Bind the ArrayList to your DropDownList             
                droplist_NewsStatus_Show.DataSource = myNews_Statuses;
                droplist_NewsStatus_Show.DataTextField = "Name";
                droplist_NewsStatus_Show.DataValueField = "Value";
                droplist_NewsStatus_Show.DataBind();
                #endregion

                if (DataEval.IsEmptyQuery(_news_status_show))
                {
                    _news_status_show = droplist_NewsStatus_Show.SelectedValue;
                }
                else
                {
                    droplist_NewsStatus_Show.SelectedValue = _news_status_show;
                }

                if (Security.Users.UserStatus.Validate_PageAuth_Modify(this.Page))
                {
                    //lbtn_Add_News.Visible = true;
                    droplist_NewsStatus_Show.Visible = true;
                    btn_NewsStatus_Show.Visible = true;
                }
                else
                {
                    //lbtn_Add_News.Visible = false;
                    droplist_NewsStatus_Show.Visible = false;
                    btn_NewsStatus_Show.Visible = false;
                }

                Lib.NewsMgr myNewsMgr = new Lib.NewsMgr();

                ListView_NewsList.DataSource = myNewsMgr.Get_News_Posts(_categoryid, _news_status_show, _sortorder, _orientation, _totalnumber, _newsdetailurl);
                ListView_NewsList.DataKeyNames = new string[] { "NewsID" };

                Core.Tools.AppItemTemplates myItemTemplate = new Core.Tools.AppItemTemplates();

                switch (_itemtemplate)
                {
                    case "Default":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsList_Default.ascx";
                        break;
                    case "TitleOnly":
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsList_TitleOnly.ascx";
                        break;
                    case "Custom":
                        myItemTemplate.ItemTemplatePath = _itemtemplateurl;
                        break;
                    default:
                        myItemTemplate.ItemTemplatePath = "~/App_Control_Style/Nexus_News/Templates/NewsList_Default.ascx";
                        break;
                }

                myItemTemplate.Set_Separator("");
                myItemTemplate.Set_DataEmpty("");

                ListView_NewsList.ItemTemplate = Page.LoadTemplate(myItemTemplate.ItemTemplatePath);
                ListView_NewsList.AlternatingItemTemplate = Page.LoadTemplate(myItemTemplate.AltPath);

                if (!DataEval.IsEmptyQuery(myItemTemplate.Separator))
                    ListView_NewsList.ItemSeparatorTemplate = Page.LoadTemplate(myItemTemplate.Separator);

                if (!DataEval.IsEmptyQuery(myItemTemplate.DataEmpty))
                    ListView_NewsList.EmptyDataTemplate = Page.LoadTemplate(myItemTemplate.DataEmpty);

                try
                {

                    ListView_NewsList.DataBind();
                }
                catch
                {
                    // Load Template Failed
                }

                DataPager_NewsList.PageSize = _numberperpage;
                DataPager_NewsList.Visible = _enable_pager;

            }

        }

    }
}