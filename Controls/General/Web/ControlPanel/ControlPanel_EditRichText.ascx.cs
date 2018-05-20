using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Core.Phrases;

namespace Nexus.Controls.General.ControlPanel
{
    public partial class EditRichText : System.Web.UI.UserControl
    {
        private string _itemid;
        private string _source_categoryid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _itemid = ViewState["ItemID"].ToString();
                    _source_categoryid = ViewState["Source_CategoryID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Init_Form();
                Reset_Form();
                Control_Init();
            }

        }

        private void Control_Init()
        {
            if (!DataEval.IsEmptyQuery(Request["ItemID"]))
            {

                Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();
                Lib.RichText myRichText = myRichTextMgr.Get_RichText_Content(Request["ItemID"]);

                tbx_DisplayName.Text = myRichText.Display_Name;
                RadEditor_TextContent.Content = myRichText.RichText_Content;
                CategoryTree_Menu.Selected_CategoryID = myRichText.CategoryID;

                _itemid = myRichText.RichTextID;
                ViewState["ItemID"] = _itemid;
                _source_categoryid = myRichText.CategoryID;
                ViewState["Source_CategoryID"] = _source_categoryid;

            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Init_Form()
        {

            RadEditor_TextContent.Content = "";
            RadEditor_TextContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";

            File_Images();
            File_Media();
        }

        private void Reset_Form()
        {

            // Default Setting
            tbx_DisplayName.Text = "";
            RadEditor_TextContent.Content = "";

            CategoryTree_Menu.UnSelectItems();
            CategoryTree_Menu.LoadCategoryRoot();

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

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_Menu.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.RichTextMgr myRichTextMgr = new Lib.RichTextMgr();

                e2Data[] UpdateData = {
                                          new e2Data("RichTextID", _itemid),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("RichText_Content", RadEditor_TextContent.Content),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                myRichTextMgr.Edit_RichText_Content(UpdateData);

                // Switch Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Move_ComponentInCategory_Item(_source_categoryid, CategoryTree_Menu.Selected_CategoryID, "A2E21E10-FF09-4D3F-9D70-DF9376FCF8B7");

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }
    }
}