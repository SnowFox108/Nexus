using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core.Pages;
using Nexus.Core.Templates;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Pages_PageCreate : System.Web.UI.UserControl
    {

        #region properties

        private string _parent_pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Parent_PageIndexID
        {
            get
            {
                if (_parent_pageindexid == null)
                {
                    return "";
                }
                return _parent_pageindexid;
            }
            set
            {
                _parent_pageindexid = value;
                ViewState["Parent_PageIndexID"] = _parent_pageindexid;
                Control_Init();
                Control_FillData();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _parent_pageindexid = ViewState["Parent_PageIndexID"].ToString();
                }
                catch
                {
                    // Do nothing
                }
            }
            else
            {
                // Set ViewState
            }

            Control_Init();

        }

        private void Control_FillData()
        {
            #region Set Default Setting

            #region Step 1

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Pages.Page_Type));

            //Creates an ArrayList
            ArrayList myPageTypes = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Pages.Page_Type myPage_Type in enumNames)
            {
                myPageTypes.Add(new { Value = StringEnum.GetStringValue(myPage_Type), Name = StringEnum.GetStringValue(myPage_Type) });
            }

            //Bind the ArrayList to your DropDownList             
            droplist_PageType.DataSource = myPageTypes;
            droplist_PageType.DataTextField = "Name";
            droplist_PageType.DataValueField = "Value";
            droplist_PageType.DataBind();

            // Set Default value
            droplist_PageType.SelectedIndex = 0;
            Panel_PageWizard.Visible = true;

            #endregion

            #region Step 2 General

            // Page URL
            tbx_LinkURL.Text = "";
            RadComboBox_LinkTarget.Text = "";
            Panel_PageLink.Visible = false;

            // Page General
            tbx_MenuName.Text = "";
            rbtn_IsOnMenu.SelectedValue = "1";
            rbtn_IsOnNavigator.SelectedValue = "1";

            rbtn_IsAttribute_Inherited.SelectedValue = "1";

            // Head Content
            tbx_Page_Title.Text = "";
            tbx_Page_Keyword.Text = "";
            tbx_Page_Description.Text = "";
            Panel_PageAttribute.Enabled = false;
            #endregion

            #region Step 2 More Options

            // Template
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();
            droplist_Template.DataSource = myMasterPageMgr.Get_Template_MasterPage_DropList(null);
            droplist_Template.DataTextField = "MasterPage_Name";
            droplist_Template.DataValueField = "MasterPageIndexID";
            droplist_Template.DataBind();

            FormView_Template.DataSource = myMasterPageMgr.Get_Template_MasterPage_DropList(null);
            FormView_Template.DataBind();

            rbtn_IsTemplate_Inherited.SelectedValue = "1";
            Panel_Template.Enabled = false;

            // URL rewrite
            tbx_PageName.Text = "";
            tbx_PageURL.Text = "";

            // Security
            rbtn_IsPrivacy_Inherited.SelectedValue = "1";
            rbtn_IsSSL.SelectedValue = "0";

            #endregion

            // Set Default View
            MultiView_CreatePage.SetActiveView(View_PageType);

            #endregion

        }

        private void Control_Init()
        {
            // Template
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            FormView_Template.DataSource = myMasterPageMgr.Get_Template_MasterPage_DropList(null);
            FormView_Template.DataBind();

        }

        // Choose Page Type reaction
        protected void droplist_PageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page_Type myPage_Type = (Page_Type)StringEnum.Parse(typeof(Page_Type), droplist_PageType.SelectedValue, true);

            switch (myPage_Type)
            {
                case Page_Type.Normal_Page:
                    Panel_PageWizard.Visible = true;
                    break;
                case Page_Type.Category:
                    Panel_PageWizard.Visible = false;
                    break;
                case Page_Type.Internal_Page_Pointer:
                    Panel_PageWizard.Visible = false;
                    break;
                case Page_Type.External_Link:
                    Panel_PageWizard.Visible = false;
                    break;
            }

        }

        // Move to Step 2
        protected void btn_NextStep_Click(object sender, EventArgs e)
        {
            Page_Type myPage_Type = (Page_Type)StringEnum.Parse(typeof(Page_Type), droplist_PageType.SelectedValue, true);

            switch (myPage_Type)
            {
                case Page_Type.Normal_Page:
                    Panel_PageLink.Visible = false;
                    Panel_HeadContent.Visible = true;
                    DataFill_Attribute();
                    Panel_Page_Templates.Visible = true;
                    DataFill_Template();
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;
                    break;
                case Page_Type.Category:
                    Panel_PageLink.Visible = false;
                    Panel_HeadContent.Visible = true;
                    DataFill_Attribute();
                    Panel_Page_Templates.Visible = true;
                    DataFill_Template();
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;
                    break;
                case Page_Type.Internal_Page_Pointer:
                    lbl_LinkURL.Text = "Pointer PageIndexID";
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;
                    break;
                case Page_Type.External_Link:
                    lbl_LinkURL.Text = "Page URL";
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;
                    break;
            }

            // Set View Active
            MultiView_CreatePage.SetActiveView(View_PageOptions);

        }

        private void DataFill_Template()
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_parent_pageindexid);

            // Look for Template
            droplist_Template.SelectedValue = myPage_Loading_Info.MasterPageIndexID;
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
            FormView_Template.DataBind();

        }

        private void DataFill_Attribute()
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_parent_pageindexid);

            // Look for PageAtrribute
            tbx_Page_Title.Text = myPage_Loading_Info.Page_Title;
            tbx_Page_Keyword.Text = myPage_Loading_Info.Page_Keyword;
            tbx_Page_Description.Text = myPage_Loading_Info.Page_Description;
        }

        // Page Name Changed
        protected void tbx_MenuName_TextChanged(object sender, EventArgs e)
        {
            // Auto Generate URL rewrite

            if (DataEval.IsEmptyQuery(tbx_PageName.Text))
            {
                btn_GetPageName_Click(sender, e);
            }
        }

        protected void btn_GetPageName_Click(object sender, EventArgs e)
        {
            tbx_PageName.Text = tbx_MenuName.Text.Replace(" ", "-");
            tbx_PageName_TextChanged(sender, e);
        }

        protected void tbx_PageName_TextChanged(object sender, EventArgs e)
        {
            URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();
            tbx_PageURL.Text = myUrlMgr.Get_PageIndex_URL(_parent_pageindexid)
                + "/"
                + tbx_PageName.Text
                + ".aspx";
        }

        // Inherited Page Atrribute Changed
        protected void rbtn_IsAttribute_Inherited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_IsAttribute_Inherited.SelectedValue == "0")
            {
                Panel_PageAttribute.Enabled = true;
            }
            else
            {
                Panel_PageAttribute.Enabled = false;
                DataFill_Attribute();
            }
        }

        // Inherited Page Template Changed
        protected void rbtn_IsTemplate_Inherited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_IsTemplate_Inherited.SelectedValue == "0")
            {
                Panel_Template.Enabled = true;
            }
            else
            {
                Panel_Template.Enabled = false;
                DataFill_Template();
            }
        }

        protected void droplist_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
            FormView_Template.DataBind();

        }

        // Create Page
        protected void btn_AddPage_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                string Page_SortOrder;
                SiteMenu mySiteMenu = new SiteMenu();

                if (_parent_pageindexid != "-1")
                {
                    Menu_Nodes myParent_Menu_Node = mySiteMenu.Get_Menu_Node(_parent_pageindexid);
                    Page_SortOrder = (myParent_Menu_Node.ChildrenCount + 1).ToString();
                }
                else
                {
                    // Base Parent
                    Page_SortOrder = (mySiteMenu.Get_Root_Menu_Count() + 1).ToString();
                }

                PageMgr myPageMgr = new PageMgr();

                // Page Index
                string PageIndexID = Tools.IDGenerator.Get_New_GUID_PlainText();

                e2Data[] UpdateData_PageIndex = {
                                                    new e2Data("PageIndexID", PageIndexID),
                                                    new e2Data("Parent_PageIndexID", _parent_pageindexid),
                                                    new e2Data("Page_CategoryID", "1"),
                                                    new e2Data("Menu_Title", tbx_MenuName.Text),
                                                    new e2Data("Page_Name", tbx_PageName.Text),
                                                    new e2Data("Page_Type", droplist_PageType.SelectedValue),
                                                    new e2Data("SortOrder", Page_SortOrder)
                                                    };

                myPageMgr.Add_PageIndex(UpdateData_PageIndex);

                // Page Properties
                Add_Property(PageIndexID);

                // URLrewrite
                //string URLrewrite = tbx_Page_Name.Text;

                Page_Type myPage_Type = (Page_Type)StringEnum.Parse(typeof(Page_Type), droplist_PageType.SelectedValue, true);

                switch (myPage_Type)
                {
                    // Create Normal Page
                    case Page_Type.Normal_Page:

                        Add_Page(PageIndexID);

                        if (rbtn_IsTemplate_Inherited.SelectedValue == "0")
                            Add_Template(PageIndexID);

                        if (rbtn_IsAttribute_Inherited.SelectedValue == "0")
                            Add_Attribute(PageIndexID);

                        break;

                    // Create Category
                    case Page_Type.Category:
                        if (rbtn_IsTemplate_Inherited.SelectedValue == "0")
                            Add_Template(PageIndexID);

                        if (rbtn_IsAttribute_Inherited.SelectedValue == "0")
                            Add_Attribute(PageIndexID);

                        break;

                    case Page_Type.Internal_Page_Pointer:
                        Add_IntLink(PageIndexID);
                        break;

                    case Page_Type.External_Link:
                        Add_ExtLink(PageIndexID);
                        break;

                }

                // Finishe Update
                //_pageindexid = PageIndexID;
                //OnFinishUpdate(this, EventArgs.Empty);
                Response.Redirect(string.Format("Pages.aspx?PageIndexID={0}", PageIndexID));

            }

        }

        private void Add_Page(string PageIndexID)
        {
            PageMgr myPageMgr = new PageMgr();

            // Page Index
            string PageID = Tools.IDGenerator.Get_New_GUID_PlainText();
            string NowDate = DateTime.Now.ToString();

            e2Data[] UpdateData = {
                                      new e2Data("PageID", PageID),
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_Version", "1"),
                                      new e2Data("Create_Date", NowDate),
                                      new e2Data("LastUpdate_Date", NowDate),
                                      new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page)),
                                      new e2Data("IsActive", "1"),
                                      new e2Data("IsDelete", "0")
                                  };

            myPageMgr.Add_Page(UpdateData);

        }

        private void Add_Property(string PageIndexID)
        {

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("IsOnMenu", rbtn_IsOnMenu.SelectedValue),
                                      new e2Data("IsOnNavigator", rbtn_IsOnNavigator.SelectedValue),
                                      new e2Data("IsPrivacy_Inherited", rbtn_IsPrivacy_Inherited.SelectedValue),
                                      new e2Data("IsAttribute_Inherited", rbtn_IsAttribute_Inherited.SelectedValue),
                                      new e2Data("IsTemplate_Inherited", rbtn_IsTemplate_Inherited.SelectedValue),
                                      new e2Data("IsSSL", rbtn_IsSSL.SelectedValue)
                                  };

            myPropertyMgr.Add_Page_Property(UpdateData);

        }

        private void Add_Template(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("MasterPageIndexID", droplist_Template.SelectedValue)
                                  };

            myPropertyMgr.Add_Page_Template(UpdateData);
        }

        private void Add_ExtLink(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            //if (!tbx_LinkURL.Text.Trim().StartsWith("http://"))
            //{
            //    tbx_LinkURL.Text = "http://" + tbx_LinkURL.Text.Trim();
            //}

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_URL", tbx_LinkURL.Text),
                                      new e2Data("Page_Target", RadComboBox_LinkTarget.Text)
                                  };

            myPropertyMgr.Add_Page_ExtLink(UpdateData);
        }

        private void Add_IntLink(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("PagePointerID", tbx_LinkURL.Text.Trim()),
                                      new e2Data("Page_Target", RadComboBox_LinkTarget.Text)
                                  };

            myPropertyMgr.Add_Page_IntLink(UpdateData);
        }

        private void Add_Attribute(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_Title", tbx_Page_Title.Text),
                                      new e2Data("Page_Keyword", tbx_Page_Keyword.Text),
                                      new e2Data("Page_Description", tbx_Page_Description.Text)
                                  };

            myPropertyMgr.Add_Page_Attribute(UpdateData);
        }
    }
}