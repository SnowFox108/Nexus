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
    public partial class App_AdminCP_SiteAdmin_Pages_PageProperty : System.Web.UI.UserControl
    {

        #region properties

        private string _pageindexid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string PageIndexID
        {
            get
            {
                if (_pageindexid == null)
                {
                    return "";
                }
                return _pageindexid;
            }
            set
            {
                _pageindexid = value;
                ViewState["PageIndexID"] = _pageindexid;
                Control_Init();
                Control_FillData();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _pageindexid = ViewState["PageIndexID"].ToString();
            }
            else
            {
                // Set ViewState
                if (_pageindexid == null)
                {
                    ViewState["PageIndexID"] = "";
                }
            }

            Control_Init();
        }

        public void Update_Disable()
        {
            Panel_Updated.Visible = false;
        }

        private void Control_Init()
        {
            // Template
            MasterPageMgr myMasterPageMgr = new MasterPageMgr();

            FormView_Template.DataSource = myMasterPageMgr.Get_Template_MasterPage_DropList(null);
            FormView_Template.DataBind();

        }

        #region Data Fill

        public void Control_FillData()
        {

            #region Set Default Setting

            Panel_Updated.Visible = false;

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

            #endregion

            #endregion


            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            // Page General
            tbx_MenuName.Text = myPageIndex.Menu_Title;
            tbx_PageName.Text = myPageIndex.Page_Name;

            // Page
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Property myPage_Property = myPropertyMgr.Get_Page_Property(_pageindexid);

            rbtn_IsOnMenu.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsOnMenu);
            rbtn_IsOnNavigator.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsOnNavigator);


            switch (myPageIndex.Page_Type)
            {
                case Page_Type.Normal_Page:
                    Panel_PageLink.Visible = false;
                    Panel_HeadContent.Visible = true;
                    Panel_Page_Templates.Visible = true;
                    Panel_Page_URLs.Visible = true;

                    DataFill_Attribute(myPage_Property);
                    DataFill_Template(myPage_Property);
                    DataFill_PageURLs();

                    break;
                case Page_Type.Category:
                    Panel_PageLink.Visible = false;
                    Panel_HeadContent.Visible = true;
                    Panel_Page_Templates.Visible = true;
                    Panel_Page_URLs.Visible = true;

                    DataFill_Attribute(myPage_Property);
                    DataFill_Template(myPage_Property);
                    DataFill_PageURLs();

                    break;
                case Page_Type.Internal_Page_Pointer:
                    lbl_LinkURL.Text = "Pointer PageIndexID";
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;

                    DataFill_IntLink();
                    DataFill_PageURLs();

                    break;
                case Page_Type.External_Link:
                    lbl_LinkURL.Text = "Page URL";
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;

                    DataFill_ExtLink();
                    DataFill_PageURLs();

                    break;
            }


        }

        private void DataFill_ExtLink()
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_ExtLink myPage_ExtLink = myPropertyMgr.Get_Page_ExtLink(_pageindexid);
            tbx_LinkURL.Text = myPage_ExtLink.Page_URL;
            RadComboBox_LinkTarget.Text = myPage_ExtLink.Page_Target;
        }

        private void DataFill_IntLink()
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            Page_IntLink myPage_IntLink = myPropertyMgr.Get_Page_IntLink(_pageindexid);
            tbx_LinkURL.Text = myPage_IntLink.PagePointerID;
            RadComboBox_LinkTarget.Text = myPage_IntLink.Page_Target;
        }

        private void DataFill_Attribute(Page_Property myPage_Property)
        {

            // Head Content
            if (myPage_Property.IsAttribute_Inherited)
            {
                rbtn_IsAttribute_Inherited.SelectedValue = "1";
                Panel_PageAttribute.Enabled = false;
            }
            else
            {
                rbtn_IsAttribute_Inherited.SelectedValue = "0";
                Panel_PageAttribute.Enabled = true;
            }

            //Load Page Attribute

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

            tbx_Page_Title.Text = myPage_Loading_Info.Page_Title;
            tbx_Page_Keyword.Text = myPage_Loading_Info.Page_Keyword;
            tbx_Page_Description.Text = myPage_Loading_Info.Page_Description;


        }

        private void DataFill_Template(Page_Property myPage_Property)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Template
            if (myPage_Property.IsTemplate_Inherited)
            {
                rbtn_IsTemplate_Inherited.SelectedValue = "1";
            }
            else
            {
                rbtn_IsTemplate_Inherited.SelectedValue = "0";
                Panel_Template.Enabled = true;
            }

            // Load Pages Template
            Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

            // Look for Template
            droplist_Template.SelectedValue = myPage_Loading_Info.MasterPageIndexID;
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
            FormView_Template.DataBind();

        }

        private void DataFill_PageURLs()
        {
            // PageURL
            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();
            tbx_PageURL.Text = myUrlMgr.Get_PageIndex_URL(myPageIndex.Parent_PageIndexID)
                + "/"
                + tbx_PageName.Text
                + ".aspx";

        }

        #endregion

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
            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();
            tbx_PageURL.Text = myUrlMgr.Get_PageIndex_URL(myPageIndex.Parent_PageIndexID)
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

                //Load Page Attribute

                Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
                Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);

                tbx_Page_Title.Text = myPage_Loading_Info.Page_Title;
                tbx_Page_Keyword.Text = myPage_Loading_Info.Page_Keyword;
                tbx_Page_Description.Text = myPage_Loading_Info.Page_Description;

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

                // Load Pages Template
                Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();
                Page_Loading_Info myPage_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(_pageindexid);
                Page_Loading_Info myParent_Loading_Info = myPropertyMgr.Get_Page_Loading_Info(myPage_Loading_Info.Parent_PageIndexID);

                // Look for Template
                droplist_Template.SelectedValue = myParent_Loading_Info.MasterPageIndexID;
                FormView_Template.PageIndex = droplist_Template.SelectedIndex;
                FormView_Template.DataBind();

            }
        }

        protected void droplist_Template_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormView_Template.PageIndex = droplist_Template.SelectedIndex;
            FormView_Template.DataBind();
        }

        #region Update Page

        protected void btn_UpdatePage_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                PageMgr myPageMgr = new PageMgr();
                PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

                // Page Index
                e2Data[] UpdateData_PageIndex = {
                                                            new e2Data("PageIndexID", _pageindexid),
                                                            new e2Data("Menu_Title", tbx_MenuName.Text),
                                                            new e2Data("Page_Name", tbx_PageName.Text)
                                                        };

                myPageMgr.Edit_PageIndex(UpdateData_PageIndex);

                // Page Properties
                Edit_Property(_pageindexid);

                switch (myPageIndex.Page_Type)
                {
                    // Create Normal Page
                    case Page_Type.Normal_Page:

                        if (rbtn_IsTemplate_Inherited.SelectedValue == "1")
                            Remove_Template(_pageindexid);
                        else
                            Edit_Template(_pageindexid);


                        if (rbtn_IsAttribute_Inherited.SelectedValue == "1")
                            Remove_Attribute(_pageindexid);
                        else
                            Edit_Attribute(_pageindexid);

                        break;

                    // Create Category
                    case Page_Type.Category:

                        if (rbtn_IsTemplate_Inherited.SelectedValue == "1")
                            Remove_Template(_pageindexid);
                        else
                            Edit_Template(_pageindexid);


                        if (rbtn_IsAttribute_Inherited.SelectedValue == "1")
                            Remove_Attribute(_pageindexid);
                        else
                            Edit_Attribute(_pageindexid);

                        break;

                    case Page_Type.Internal_Page_Pointer:
                        Edit_IntLink(_pageindexid);
                        break;

                    case Page_Type.External_Link:
                        Edit_ExtLink(_pageindexid);
                        break;

                }

                Panel_Updated.Visible = true;

            }

        }

        private void Edit_Property(string PageIndexID)
        {

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("IsOnMenu", rbtn_IsOnMenu.SelectedValue),
                                      new e2Data("IsOnNavigator", rbtn_IsOnNavigator.SelectedValue),
                                      new e2Data("IsAttribute_Inherited", rbtn_IsAttribute_Inherited.SelectedValue),
                                      new e2Data("IsTemplate_Inherited", rbtn_IsTemplate_Inherited.SelectedValue)
                                  };

            myPropertyMgr.Edit_Page_Property(UpdateData);

        }

        private void Edit_Template(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("MasterPageIndexID", droplist_Template.SelectedValue) // Get from Select Template list
                                  };

            if (myPropertyMgr.Chk_Page_Template(PageIndexID))
            {
                myPropertyMgr.Edit_Page_Template(UpdateData);
            }
            else
            {
                myPropertyMgr.Add_Page_Template(UpdateData);
            }
        }

        private void Edit_ExtLink(string PageIndexID)
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

            if (myPropertyMgr.Chk_Page_ExtLink(PageIndexID))
            {
                myPropertyMgr.Edit_Page_ExtLink(UpdateData);
            }
            else
            {
                myPropertyMgr.Add_Page_ExtLink(UpdateData);
            }
        }

        private void Edit_IntLink(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("PagePointerID", tbx_LinkURL.Text.Trim()),
                                      new e2Data("Page_Target", RadComboBox_LinkTarget.Text)
                                  };

            if (myPropertyMgr.Chk_Page_IntLink(PageIndexID))
            {
                myPropertyMgr.Edit_Page_IntLink(UpdateData);
            }
            else
            {
                myPropertyMgr.Add_Page_IntLink(UpdateData);
            }
        }

        private void Edit_Attribute(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Page Index
            e2Data[] UpdateData = {
                                      new e2Data("PageIndexID", PageIndexID),
                                      new e2Data("Page_Title", tbx_Page_Title.Text),
                                      new e2Data("Page_Keyword", tbx_Page_Keyword.Text),
                                      new e2Data("Page_Description", tbx_Page_Description.Text)
                                  };

            if (myPropertyMgr.Chk_Page_Attribute(PageIndexID))
            {
                myPropertyMgr.Edit_Page_Attribute(UpdateData);
            }
            else
            {
                myPropertyMgr.Add_Page_Attribute(UpdateData);
            }
        }

        private void Remove_Template(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            if (myPropertyMgr.Chk_Page_Template(PageIndexID))
            {
                myPropertyMgr.Remove_Page_Template(PageIndexID);
            }

        }

        private void Remove_Attribute(string PageIndexID)
        {
            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            if (myPropertyMgr.Chk_Page_Attribute(PageIndexID))
            {
                myPropertyMgr.Remove_Page_Attribute(PageIndexID);
            }

        }

        #endregion
    }
}