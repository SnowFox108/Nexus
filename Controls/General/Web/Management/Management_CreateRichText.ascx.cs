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

namespace Nexus.Controls.General.Management
{
    public partial class CreateRichText : System.Web.UI.UserControl
    {
        bool _iscreated = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init_Form();
                Reset_Form();
            }

            Control_Init();
        }

        private void Control_Init()
        {
            if (_iscreated)
            {
                MultiView_CreateItem.SetActiveView(View_Created_Item);
            }
            else
            {
                MultiView_CreateItem.SetActiveView(View_Add_Item);
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

                DateTime nowTime = DateTime.Now;

                string RichTextID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("RichTextID", RichTextID),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("RichText_Content", RadEditor_TextContent.Content),
                                          new e2Data("Create_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myRichTextMgr.Add_RichText_Content(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Menu.Selected_CategoryID, "A2E21E10-FF09-4D3F-9D70-DF9376FCF8B7");

                _iscreated = true;

                Control_Init();

            }
        }

        protected void lbtn_CreateOtherItem_Click(object sender, EventArgs e)
        {
            Reset_Form();
            _iscreated = false;
            Control_Init();
        }
    }
}