using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Nexus.Core.Controls;
using Nexus.Core.Categories;
using Telerik.Web.UI;

namespace Nexus.Controls.General.HTML
{

    [DefaultEvent("FinishUpdate")]
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

        private string _htmlid;
        private string _html_content = "";
        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string HTMLID
        {
            get
            {
                return _htmlid;
            }
            set
            {
                _htmlid = value;
                ViewState["HTMLID"] = _htmlid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string HTML_Content
        {
            get
            {
                return _html_content;
            }
            set
            {
                _html_content = value;
                ViewState["HTML_Content"] = _html_content;
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
                    _htmlid = ViewState["HTMLID"].ToString();
                    _html_content = ViewState["HTML_Content"].ToString();
                    _isshared = Convert.ToBoolean(ViewState["IsShared"]);
                    _contentid = ViewState["ContentID"].ToString();
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

            if (!DataEval.IsEmptyQuery(_htmlid))
            {

                if (_isshared)
                {
                    Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();
                    Lib.HTML myHTML = myHTMLMgr.Get_HTML_Content(_contentid);

                    tbx_TextContent.Text = myHTML.HTML_Content;
                }
                else
                {
                    tbx_TextContent.Text = _html_content;
                }
            }
            else
            {
                if (_isshared)
                {
                    Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();
                    Lib.HTML myHTML = myHTMLMgr.Get_HTML_Content(_contentid);

                    tbx_TextContent.Text = myHTML.HTML_Content;
                }
            }

            Reset_Buttons();
            MultiView_Editor.SetActiveView(View_Editor);

        }

        private void Reset_Buttons()
        {
            lbtn_ShareContent.Visible = false;
            lbtn_BranchContent.Visible = false;
            Panel_Warning.Visible = false;

            if (_isshared)
            {
                lbtn_BranchContent.Visible = true;
                Panel_Warning.Visible = true;
            }
            else
            {
                lbtn_ShareContent.Visible = true;
            }

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

            Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();

            DateTime nowTime = DateTime.Now;

            string HTMLID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Update extra table
            if (_isshared)
            {

                e2Data[] UpdateData = {
                                          new e2Data("HTMLID", _contentid),
                                          new e2Data("HTML_Content", tbx_TextContent.Text),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                myHTMLMgr.Edit_HTML_Content(UpdateData);
            }


            // Check Control is New
            if (DataEval.IsEmptyQuery(_htmlid))
            {

                // Create Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "HTMLID", HTMLID),
                                                       new Control_Property(_page_controlid, "HTML_Content", tbx_TextContent.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                   };

                Update_Properties = PropertieData;
            }
            else
            {

                // Update Page_Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "HTMLID", _htmlid),
                                                       new Control_Property(_page_controlid, "HTML_Content", tbx_TextContent.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                   };

                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _htmlid, _page_controlid, Update_Properties);

            #endregion

            // Finish Update Close Window
            //OnFinishUpdate(this, EventArgs.Empty);
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);


        }

        protected void lbtn_BranchContent_Click(object sender, EventArgs e)
        {
            _isshared = false;
            ViewState["IsShared"] = _isshared;

            _contentid = "";
            ViewState["ContentID"] = _contentid;

            Reset_Buttons();
        }

        #region Select a Content

        protected void lbtn_SelectContent_Click(object sender, EventArgs e)
        {
            CategoryTree_Menu.LoadCategoryRoot();
            CategoryTree_Menu_CategorySelected(sender, null);
            MultiView_Editor.SetActiveView(View_SelectContent);

        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {
            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();

                GridView_HTML_Items.DataSource = myHTMLMgr.Get_HTMLs(CategoryTree_Menu.Selected_CategoryID, null);
                GridView_HTML_Items.DataBind();

            }
        }

        protected void GridView_HTML_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isshared = true;
            ViewState["IsShared"] = _isshared;

            _contentid = GridView_HTML_Items.SelectedDataKey.Value.ToString();
            ViewState["ContentID"] = _contentid;

            Control_Init();
        }

        #endregion

        #region Share a Content

        protected void lbtn_ShareContent_Click(object sender, EventArgs e)
        {
            CategoryTree_Share.LoadCategoryRoot();
            MultiView_Editor.SetActiveView(View_ShareContent);

        }

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_Share.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_ShareContent_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();

                DateTime nowTime = DateTime.Now;

                string HTMLID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("HTMLID", HTMLID),
                                          new e2Data("CategoryID", CategoryTree_Share.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("HTML_Content", tbx_TextContent.Text),
                                          new e2Data("Create_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myHTMLMgr.Add_HTML_Content(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Share.Selected_CategoryID, "B1CD6348-796C-4E92-8C39-5CEF3D600B7C");

                _isshared = true;
                ViewState["IsShared"] = _isshared;

                _contentid = HTMLID;
                ViewState["ContentID"] = _contentid;

                Reset_Buttons();
                MultiView_Editor.SetActiveView(View_Editor);

            }
        }

        #endregion

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_Editor.SetActiveView(View_Editor);
        }

    }

}