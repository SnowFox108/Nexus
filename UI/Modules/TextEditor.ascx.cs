using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Phrases;
using Telerik.Web.UI;

namespace Nexus.Core.UI
{
    [ValidationPropertyAttribute("Content")]
    public partial class Modules_TextEditor : System.Web.UI.UserControl
    {

        #region Properties

        private bool _enable_editorbar = true;
        private bool _enable_resize = true;
        private string _toolbar_status = "Basic";

        private int _height = 400;
        private int _width = 680;

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("true")]
        [Localizable(true)]
        public bool Enable_EditorBar
        {
            get
            {
                return _enable_editorbar;
            }
            set
            {
                _enable_editorbar = value;
                ViewState["Enable_EditorBar"] = _enable_editorbar;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("true")]
        [Localizable(true)]
        public bool EnableResize
        {
            get
            {
                return _enable_resize;
            }
            set
            {
                _enable_resize = value;
                ViewState["EnableResize"] = _enable_resize;

                RadEditor_TextContent.EnableResize = _enable_resize;
            }
        }


        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("Basic")]
        [Localizable(true)]
        public string Toolbar_Status
        {
            get
            {
                return _toolbar_status;
            }
            set
            {
                _toolbar_status = value;
                ViewState["Toolbar_Status"] = _toolbar_status;

                RadTabStrip_EditorBar.SelectedIndex = RadTabStrip_EditorBar.FindTabByValue(_toolbar_status).Index;
                Set_EditorBar(_toolbar_status);
            }
        }

        [Bindable(true)]
        [Category("Misc")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Content
        {
            get
            {
                return RadEditor_TextContent.Content;
            }
            set
            {
                RadEditor_TextContent.Content = value;
            }
        }

        [Bindable(true)]
        [Category("Misc")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                return RadEditor_TextContent.Text;
            }
            set
            {
                RadEditor_TextContent.Text = value;
            }
        }


        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("400")]
        [Localizable(true)]
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                ViewState["Height"] = _height;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("680")]
        [Localizable(true)]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                ViewState["Width"] = _width;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _enable_editorbar = Convert.ToBoolean(ViewState["Enable_EditorBar"]);
                    _enable_resize = Convert.ToBoolean(ViewState["EnableResize"]);
                    _height = Convert.ToInt32(ViewState["Height"]);
                    _width = Convert.ToInt32(ViewState["Width"]);

                    _toolbar_status = ViewState["Toolbar_Status"].ToString();

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
            File_Images();
            File_Media();
            File_Documents();

            RadTabStrip_EditorBar.Visible = _enable_editorbar;
            RadEditor_TextContent.EnableResize = _enable_resize;

            RadEditor_TextContent.Height = new Unit(_height);
            RadEditor_TextContent.Width = new Unit(_width);

            Set_EditorBar(_toolbar_status);
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

            RadEditor_TextContent.FlashManager.ViewPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_ViewPaths").Split(',');
            RadEditor_TextContent.FlashManager.UploadPaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_UploadPaths").Split(',');
            RadEditor_TextContent.FlashManager.DeletePaths = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_DeletePaths").Split(',');
            RadEditor_TextContent.FlashManager.SearchPatterns = PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_Types").Split(',');
            RadEditor_TextContent.FlashManager.MaxUploadFileSize = Convert.ToInt32(PhraseMgr.Get_Phrase_Value("NexusCore_File_Media_MaxUploadFileSize"));

        }

        private void File_Documents()
        {
            RadEditor_TextContent.DocumentManager.ViewPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_ViewPaths").Split(',');
            RadEditor_TextContent.DocumentManager.UploadPaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_UploadPaths").Split(',');
            RadEditor_TextContent.DocumentManager.DeletePaths = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_DeletePaths").Split(',');
            RadEditor_TextContent.DocumentManager.SearchPatterns = Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_Types").Split(',');
            RadEditor_TextContent.DocumentManager.MaxUploadFileSize = Convert.ToInt32(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Documents_MaxUploadFileSize"));
        }

        protected void RadTabStrip_EditorBar_TabClick(object sender, RadTabStripEventArgs e)
        {
            Set_EditorBar(e.Tab.Value);
        }

        private void Set_EditorBar(string toolbar_status)
        {
            switch (toolbar_status)
            {
                case "Default":
                    RadEditor_TextContent.ToolsFile = null;
                    break;
                case "Basic":
                    RadEditor_TextContent.ToolsFile = "~/App_Data/Editor/BasicTools.xml";
                    break;
            }

        }
}
}