using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Phrases;
using Nexus.Core.Pages;
using Nexus.Core.Controls;
using Nexus.Core.Categories;
using Telerik.Web.UI;

namespace Nexus.Controls.General.RichText
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
            else
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            #region Form Default setting

            File_Images();
            File_Media();

            RadEditor_TextContent.Content = "";
            RadEditor_TextContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
            #endregion

            if (!DataEval.IsEmptyQuery(_richtextid))
            {

                if (_isshared)
                {
                    Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();
                    Lib.RichText myRichText = myRichTextMgr.Get_RichText_Content(_contentid);

                    RadEditor_TextContent.Content = myRichText.RichText_Content;
                }
                else
                {
                    RadEditor_TextContent.Content = _richtext_content;
                }
            }
            else
            {
                if (_isshared)
                {
                    Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();
                    Lib.RichText myRichText = myRichTextMgr.Get_RichText_Content(_contentid);

                    RadEditor_TextContent.Content = myRichText.RichText_Content;
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

        private void File_Images()
        {
            RadEditor_TextContent.ImageManager.ViewPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_ViewPaths").Split(',');
            RadEditor_TextContent.ImageManager.UploadPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_UploadPaths").Split(',');
            RadEditor_TextContent.ImageManager.DeletePaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_DeletePaths").Split(',');
            RadEditor_TextContent.ImageManager.SearchPatterns = PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_Types").Split(',');
            RadEditor_TextContent.ImageManager.MaxUploadFileSize = Convert.ToInt32(PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_MaxUploadFileSize"));
        }

        private void File_Media()
        {
            RadEditor_TextContent.MediaManager.ViewPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_ViewPaths").Split(',');
            RadEditor_TextContent.MediaManager.UploadPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_UploadPaths").Split(',');
            RadEditor_TextContent.MediaManager.DeletePaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_DeletePaths").Split(',');
            RadEditor_TextContent.MediaManager.SearchPatterns = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_Types").Split(',');
            RadEditor_TextContent.MediaManager.MaxUploadFileSize = Convert.ToInt32(PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_MaxUploadFileSize"));
        }


        protected void btn_Update_Click(object sender, EventArgs e)
        {

            Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();

            DateTime nowTime = DateTime.Now;

            // Create New
            string RichTextID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };


            #region Update for Control Data

            // Update Extra Database
            if (_isshared)
            {

                e2Data[] UpdateData = {
                                              new e2Data("RichTextID", _contentid),
                                              new e2Data("RichText_Content", RadEditor_TextContent.Content),
                                              new e2Data("LastUpdate_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                           };

                myRichTextMgr.Edit_RichText_Content(UpdateData);
            }

            // Check Control is New
            if (DataEval.IsEmptyQuery(_richtextid))
            {
                // Create Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "RichTextID", RichTextID),
                                                       new Control_Property(_page_controlid, "RichText_Content", RadEditor_TextContent.Content),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                   };
                Update_Properties = PropertieData;
            }
            else
            {

                // Update Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "RichTextID", _richtextid),
                                                       new Control_Property(_page_controlid, "RichText_Content", RadEditor_TextContent.Content),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                   };
                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _richtextid, _page_controlid, Update_Properties);

            #endregion

            // Finish Update Close Window
            //OnFinishUpdate(this, EventArgs.Empty);
            string _finishupdate_script = string.Format("CloseAndRebind({0});", _page_controlid);
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

        }

        protected void RadTabStrip_EditorBar_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (e.Tab.Value)
            {
                case "Default":
                    RadEditor_TextContent.ToolsFile = null;
                    break;
                case "BasicTools":
                    RadEditor_TextContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                    break;
            }
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
                Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();

                GridView_Items.DataSource = myRichTextMgr.Get_RichTexts(CategoryTree_Menu.Selected_CategoryID, null);
                GridView_Items.DataBind();

            }
        }

        protected void GridView_HTML_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isshared = true;
            ViewState["IsShared"] = _isshared;

            _contentid = GridView_Items.SelectedDataKey.Value.ToString();
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

                Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();

                DateTime nowTime = DateTime.Now;

                string RichTextID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("RichTextID", RichTextID),
                                          new e2Data("CategoryID", CategoryTree_Share.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("RichText_Content", RadEditor_TextContent.Content),
                                          new e2Data("Create_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myRichTextMgr.Add_RichText_Content(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Share.Selected_CategoryID, "A2E21E10-FF09-4D3F-9D70-DF9376FCF8B7");

                _isshared = true;
                ViewState["IsShared"] = _isshared;

                _contentid = RichTextID;
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