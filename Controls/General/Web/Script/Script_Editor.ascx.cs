using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Pages;
using Nexus.Core.Controls;
using Nexus.Core.Categories;
using Telerik.Web.UI;

namespace Nexus.Controls.General.Script
{

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

        private string _scriptid;

        private string _script_type = "text/javascript";
        private string _script_content = "";

        private bool _isshared = false;
        private string _contentid = "";

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ScriptID
        {
            get
            {
                if (_scriptid == null)
                {
                    return "";
                }
                return _scriptid;
            }
            set
            {
                _scriptid = value;
                ViewState["ScriptID"] = _scriptid;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Script_Type
        {
            get
            {
                return _script_type;
            }
            set
            {
                _script_type = value;
                ViewState["Script_Type"] = _script_type;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Script_Content
        {
            get
            {
                return _script_content;
            }
            set
            {
                _script_content = value;
                ViewState["Script_Content"] = _script_content;
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

                    _scriptid = ViewState["ScriptID"].ToString();
                    _script_type = ViewState["Script_Type"].ToString();
                    _script_content = ViewState["Script_Content"].ToString();
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

            #region Default setting

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.Script_Type));

            //Creates an ArrayList
            ArrayList myScriptTypes = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.Script_Type myScriptType in enumNames)
            {
                myScriptTypes.Add(new { Value = StringEnum.GetStringValue(myScriptType), Name = myScriptType.ToString() });
            }

            //Bind the ArrayList to your DropDownList             
            droplist_Script_Type.DataSource = myScriptTypes;
            droplist_Script_Type.DataTextField = "Name";
            droplist_Script_Type.DataValueField = "Value";
            droplist_Script_Type.DataBind();

            tbx_TextContent.Text = "";

            #endregion

            if (!DataEval.IsEmptyQuery(_scriptid))
            {
                if (_isshared)
                {
                    Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                    Lib.Script myScript = myScriptMgr.Get_Script_Content(_contentid);

                    _script_type = StringEnum.GetStringValue(myScript.Script_Type);
                    ViewState["Script_Type"] = _script_type;

                    _script_content = myScript.Script_Content;
                    ViewState["Script_Content"] = _script_content;

                }

                droplist_Script_Type.SelectedValue = _script_type;
                tbx_TextContent.Text = _script_content;


            }
            else
            {
                if (_isshared)
                {
                    Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                    Lib.Script myScript = myScriptMgr.Get_Script_Content(_contentid);

                    _script_type = StringEnum.GetStringValue(myScript.Script_Type);
                    ViewState["Script_Type"] = _script_type;

                    _script_content = myScript.Script_Content;
                    ViewState["Script_Content"] = _script_content;

                    droplist_Script_Type.SelectedValue = _script_type;
                    tbx_TextContent.Text = _script_content;
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

            Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();

            DateTime nowTime = DateTime.Now;

            // Create New
            string ScriptID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
            Control_Property[] Update_Properties = { };

            #region Update for Control Data

            // Update Extra Database
            if (_isshared)
            {
                e2Data[] UpdateData = {
                                          new e2Data("ScriptID", _contentid),
                                          new e2Data("Script_Type", droplist_Script_Type.SelectedValue),
                                          new e2Data("Script_Content", tbx_TextContent.Text),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myScriptMgr.Edit_Script_Content(UpdateData);
            }


            // Check Control is New
            if (DataEval.IsEmptyQuery(_scriptid))
            {

                // Create Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "ScriptID", ScriptID),
                                                       new Control_Property(_page_controlid, "Script_Type", droplist_Script_Type.SelectedValue),
                                                       new Control_Property(_page_controlid, "Script_Content", tbx_TextContent.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                    };
                Update_Properties = PropertieData;
            }
            else
            {
                // Update Control Property
                Control_Property[] PropertieData = {
                                                       new Control_Property(_page_controlid, "ScriptID", _scriptid),
                                                       new Control_Property(_page_controlid, "Script_Type", droplist_Script_Type.SelectedValue),
                                                       new Control_Property(_page_controlid, "Script_Content", tbx_TextContent.Text),
                                                       new Control_Property(_page_controlid, "IsShared", _isshared.ToString()),
                                                       new Control_Property(_page_controlid, "ContentID", _contentid)
                                                    };
                Update_Properties = PropertieData;

            }

            #endregion

            #region Update for Control Properties

            ControlMgr myControlMgr = new ControlMgr();
            myControlMgr.Update_Control_Properties(_editmode, _scriptid, _page_controlid, Update_Properties);

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
                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();

                GridView_Items.DataSource = myScriptMgr.Get_Scripts(CategoryTree_Menu.Selected_CategoryID, null);
                GridView_Items.DataBind();

            }
        }

        protected void GridView_Items_SelectedIndexChanged(object sender, EventArgs e)
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
                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();

                DateTime nowTime = DateTime.Now;

                string ScriptID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("ScriptID", ScriptID),
                                          new e2Data("CategoryID", CategoryTree_Share.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("Script_Type", droplist_Script_Type.SelectedValue),
                                          new e2Data("Script_Content", tbx_TextContent.Text),
                                          new e2Data("Create_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myScriptMgr.Add_Script_Content(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Share.Selected_CategoryID, "076A591E-1BFE-47A7-8B40-D6621C7D3DF9");

                _isshared = true;
                ViewState["IsShared"] = _isshared;

                _contentid = ScriptID;
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