using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core.Pages;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Files_PoP_FileSelector : System.Web.UI.Page
    {

        private string _filetypes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_Init();
            }
        }

        private void Control_Init()
        {
            if (DataEval.IsEmptyQuery(Request.QueryString["FileTypes"]))
            {
                _filetypes = "Images";
                File_Images();
            }
            else
            {
                _filetypes = Request.QueryString["FileTypes"];

                switch (_filetypes)
                {
                    case "Images":
                        File_Images();
                        break;
                    case "Media":
                        File_Media();
                        break;
                    case "Documents":
                        File_Documents();
                        break;
                    case "Templates":
                        File_Templates();
                        break;
                    case "ModuleTemplates":
                        File_ModuleTemplates();
                        break;
                    case "AllFiles":
                        File_All();
                        break;
                    default:
                        _filetypes = "Images";
                        File_Images();
                        break;

                }
            }
        }

        protected void RadAjaxManager_FileSelector_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string _fileurl = e.Argument;

            switch (_filetypes)
            {
                case "Images":
                    break;
                case "Media":
                    break;
                case "Documents":
                    break;
                case "Templates":
                    break;
                case "ModuleTemplates":
                    _fileurl = "~" + _fileurl;
                    break;
                case "AllFiles":
                    break;
                default:
                    break;
            }

            if (!DataEval.IsEmptyQuery(Request.QueryString["ControlID"]))
            {
                string arg = "FileSelector"
                    + "^"
                    + Request.QueryString["ControlID"] 
                    + "^"
                    + _fileurl;

                // Finish Select Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText(arg));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
            }

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