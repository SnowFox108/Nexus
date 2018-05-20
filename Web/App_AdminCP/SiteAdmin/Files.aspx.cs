using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
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

    public partial class App_AdminCP_SiteAdmin_Files : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            if (Session["File_Types"] == null)
            {
                Session["File_Types"] = "Images";
                RadTabStrip_Files.SelectedIndex = 0;
                File_Images();
            }
            else
            {
                switch (Session["File_Types"].ToString())
                {
                    case "Images":
                        RadTabStrip_Files.SelectedIndex = 0;
                        File_Images();
                        break;
                    case "Media":
                        RadTabStrip_Files.SelectedIndex = 1;
                        File_Media();
                        break;
                    case "Documents":
                        RadTabStrip_Files.SelectedIndex = 2;
                        File_Documents();
                        break;
                    case "Templates":
                        RadTabStrip_Files.SelectedIndex = 3;
                        File_Templates();
                        break;
                    case "ModuleTemplates":
                        RadTabStrip_Files.SelectedIndex = 4;
                        File_ModuleTemplates();
                        break;
                    case "AllFiles":
                        RadTabStrip_Files.SelectedIndex = 5;
                        File_All();
                        break;
                }
            }
        }

        //private void FillPermissionsTest(string testPhysicalPath)
        //{
        //    try
        //    {
        //        string physicalPathToTestFolder = System.IO.Path.Combine(testPhysicalPath, "TestFolder");
        //        System.IO.DirectoryInfo testDir = System.IO.Directory.CreateDirectory(physicalPathToTestFolder);// Create folder
        //        testDir.GetDirectories();// List folders
        //        string testFilePath = System.IO.Path.Combine(testDir.FullName, "TestFile1.txt");// test file paths
        //        System.IO.File.Create(testFilePath).Close();// Create a file
        //        testDir.GetFiles("*.*");// List files
        //        System.IO.File.OpenRead(testFilePath).Close();// Open a file
        //        //System.IO.File.Delete(testFilePath);// delete the test file
        //        //System.IO.Directory.Delete(physicalPathToTestFolder);// delete the test folder
        //    }
        //    catch (Exception ex)
        //    {// Show the probelm

        //        string message = ex.Message;
        //        string script = string.Format("alert('{0}');", message.Replace("'", @""""));
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "KEY", script, true);
        //    }
        //}

        protected void RadTabStrip_Files_TabClick(object sender, RadTabStripEventArgs e)
        {
            switch (e.Tab.Value)
            {
                case "Images":
                    Session["File_Types"] = "Images";
                    break;
                case "Media":
                    Session["File_Types"] = "Media";
                    break;
                case "Documents":
                    Session["File_Types"] = "Documents";
                    break;
                case "Templates":
                    Session["File_Types"] = "Templates";
                    break;
                case "ModuleTemplates":
                    Session["File_Types"] = "ModuleTemplates";
                    break;
                case "AllFiles":
                    Session["File_Types"] = "AllFiles";
                    break;
            }

            Response.Redirect(Request.Url.ToString());
        }

        private void File_Images()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_MaxUploadFileSize"));
        }

        private void File_Media()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_MaxUploadFileSize"));
        }

        private void File_Documents()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_MaxUploadFileSize"));
        }

        private void File_Templates()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_MaxUploadFileSize"));
        }

        private void File_ModuleTemplates()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_MaxUploadFileSize"));
        }

        private void File_All()
        {
            RadFileExplorer_Files.Configuration.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_ViewPaths").Split(',');
            RadFileExplorer_Files.Configuration.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_UploadPaths").Split(',');
            RadFileExplorer_Files.Configuration.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_DeletePaths").Split(',');
            RadFileExplorer_Files.Configuration.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_Types").Split(',');
            RadFileExplorer_Files.Configuration.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_MaxUploadFileSize"));
        }

    }
}