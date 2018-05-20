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
                    Control_Init();
                }
            }
        }

        public void Update_Disable()
        {
            Panel_Updated.Visible = false;
        }

        private void Control_Init()
        {

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
            Panel_PageAttribute.Visible = false;
            #endregion

            #region Step 2 More Options

            // Template
            rbtn_IsTemplate_Inherited.SelectedValue = "1";
            Panel_Template.Enabled = false;

            // URL rewrite
            tbx_Page_Name.Text = "";

            // Security
            rbtn_IsPrivacy_Inherited.SelectedValue = "1";
            rbtn_IsSSL.SelectedValue = "0";

            #endregion

            #endregion


            PageMgr myPageMgr = new PageMgr();
            PageIndex myPageIndex = myPageMgr.Get_PageIndex(_pageindexid);

            // Page General
            tbx_MenuName.Text = myPageIndex.Page_Name;

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
                    Panel_Page_Securities.Visible = true;

                    DataFill_Attribute(myPage_Property);
                    DataFill_Template(myPage_Property);
                    DataFill_PageURLs(myPage_Property);
                    DataFill_Security(myPage_Property);

                    break;
                case Page_Type.Category:
                    Panel_PageLink.Visible = false;
                    Panel_HeadContent.Visible = true;
                    Panel_Page_Templates.Visible = true;
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;

                    DataFill_Attribute(myPage_Property);
                    DataFill_Template(myPage_Property);
                    DataFill_PageURLs(myPage_Property);
                    DataFill_Security(myPage_Property);

                    break;
                case Page_Type.Internal_Page_Pointer:
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;

                    DataFill_IntLink();
                    DataFill_PageURLs(myPage_Property);
                    DataFill_Security(myPage_Property);

                    break;
                case Page_Type.External_Link:
                    Panel_PageLink.Visible = true;
                    Panel_HeadContent.Visible = false;
                    Panel_Page_Templates.Visible = false;
                    Panel_Page_URLs.Visible = true;
                    Panel_Page_Securities.Visible = true;

                    DataFill_ExtLink();
                    DataFill_PageURLs(myPage_Property);
                    DataFill_Security(myPage_Property);

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
            tbx_LinkURL.Text = myPage_IntLink.Page_URL;
            RadComboBox_LinkTarget.Text = myPage_IntLink.Page_Target;
        }

        private void DataFill_Attribute(Page_Property myPage_Property)
        {

            Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // Head Content
            if (myPage_Property.IsAttribute_Inherited)
            {
                rbtn_IsAttribute_Inherited.SelectedValue = "1";
            }
            else
            {
                rbtn_IsAttribute_Inherited.SelectedValue = "0";
                Panel_HeadContent.Visible = true;

                Page_Attribute myPage_Attribute = myPropertyMgr.Get_Page_Attribute(_pageindexid);
                tbx_Page_Title.Text = myPage_Attribute.Page_Title;
                tbx_Page_Keyword.Text = myPage_Attribute.Page_Keyword;
                tbx_Page_Description.Text = myPage_Attribute.Page_Description;
            }

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

        private void DataFill_PageURLs(Page_Property myPage_Property)
        {
            //Page_PropertyMgr myPropertyMgr = new Page_PropertyMgr();

            // PageURL
            tbx_Page_Name.Text = tbx_MenuName.Text.Replace(" ", "");
        }

        private void DataFill_Security(Page_Property myPage_Property)
        {
            // Security
            rbtn_IsPrivacy_Inherited.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsPrivacy_Inherited);
            rbtn_IsSSL.SelectedValue = DataEval.Convert_BoolToString(myPage_Property.IsSSL);

        }

        #endregion


        // Page Name Changed
        protected void tbx_MenuName_TextChanged(object sender, EventArgs e)
        {
            // Auto Generate URL rewrite


            tbx_Page_Name.Text = tbx_MenuName.Text.Trim();
        }

        // Inherited Page Atrribute Changed
        protected void rbtn_IsAttribute_Inherited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_IsAttribute_Inherited.SelectedValue == "0")
            {
                Panel_PageAttribute.Visible = true;
            }
            else
            {
                Panel_PageAttribute.Visible = false;
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
                                                            new e2Data("Page_Name", tbx_MenuName.Text)
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
                                      new e2Data("IsPrivacy_Inherited", rbtn_IsPrivacy_Inherited.SelectedValue),
                                      new e2Data("IsAttribute_Inherited", rbtn_IsAttribute_Inherited.SelectedValue),
                                      new e2Data("IsTemplate_Inherited", rbtn_IsTemplate_Inherited.SelectedValue),
                                      new e2Data("IsSSL", rbtn_IsSSL.SelectedValue)
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

            if (!tbx_LinkURL.Text.Trim().StartsWith("http://"))
            {
                tbx_LinkURL.Text = "http://" + tbx_LinkURL.Text.Trim();
            }

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
                                      new e2Data("Page_URL", tbx_LinkURL.Text.Trim()),
                                      new e2Data("Page_Target", RadComboBox_LinkTarget.Text)
                                  };

            if (myPropertyMgr.Chk_Page_IntLink(PageIndexID))
            {
                myPropertyMgr.Edit_Page_IntLink(UpdateData);
            }
            else
            {
                myPropertyMgr.Add_Page_ExtLink(UpdateData);
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