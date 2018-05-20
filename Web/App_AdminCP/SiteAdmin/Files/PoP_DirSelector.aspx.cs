using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;

namespace Nexus.Core
{

    public partial class App_AdminCP_SiteAdmin_Files_PoP_DirSelector : System.Web.UI.Page
    {

        private string _file_types;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRootNodes();
            }
        }

        private void LoadRootNodes()
        {
            string[] startFolders;

            if (DataEval.IsEmptyQuery(Request.QueryString["FileTypes"]))
            {
                _file_types = "Images";
                startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_ViewPaths").Split(',');
            }
            else
            {
                _file_types = Request.QueryString["FileTypes"];

                switch (_file_types)
                {
                    case "Images":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_ViewPaths").Split(',');
                        break;
                    case "Media":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_ViewPaths").Split(',');
                        break;
                    case "Documents":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_ViewPaths").Split(',');
                        break;
                    case "Templates":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Templates_ViewPaths").Split(',');
                        break;
                    case "ModuleTemplates":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_ControlTemplates_ViewPaths").Split(',');
                        break;
                    case "AllFiles":
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_All_ViewPaths").Split(',');
                        break;
                    default:
                        _file_types = "Images";
                        startFolders = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_ViewPaths").Split(',');
                        break;

                }
            }

            // Remove all Node before add new one
            RadTreeView_DirSelector.Nodes.Clear();

            foreach (string startFolder in startFolders)
            {
                RadTreeNode rootNode = new RadTreeNode();
                rootNode.Text = Path.GetFileName(startFolder);
                rootNode.Value = startFolder.Substring(1);
                rootNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                rootNode.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/category.gif";
                RadTreeView_DirSelector.Nodes.Add(rootNode);

            }


        }

        private void BindTreeToDirectory(string virtualPath, RadTreeNode parentNode)
        {
            string physicalPath = Server.MapPath(virtualPath);
            string[] directories = Directory.GetDirectories(physicalPath);
            foreach (string directory in directories)
            {
                RadTreeNode node = new RadTreeNode(Path.GetFileName(directory));
                node.Value = virtualPath + "/" + Path.GetFileName(directory);
                node.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/category.gif";
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                parentNode.Nodes.Add(node);
            }
        }

        protected void RadTreeView_DirSelector_NodeExpand(object sender, RadTreeNodeEventArgs e)
        {
            BindTreeToDirectory(e.Node.Value, e.Node);

        }

        protected void RadTreeView_DirSelector_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            btn_Select.CommandArgument = e.Node.Value;
        } 

        protected void btn_Select_Command(object sender, CommandEventArgs e)
        {
            string _folderurl = e.CommandArgument.ToString();

            if (!DataEval.IsEmptyQuery(_folderurl) && _folderurl != "~/")
            {
                if (!DataEval.IsEmptyQuery(Request.QueryString["ControlID"]))
                {
                    string arg = "FileSelector"
                    + "^"
                    + Request.QueryString["ControlID"] 
                    + "^" 
                    + _folderurl;

                    // Finish Select Close Window
                    string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText(arg));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);
                }
            }
        }

    }
}