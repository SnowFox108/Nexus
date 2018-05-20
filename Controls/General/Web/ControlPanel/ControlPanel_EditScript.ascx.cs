using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.General.ControlPanel
{
    public partial class EditScript : System.Web.UI.UserControl
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

                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();
                Lib.Script myScript = myScriptMgr.Get_Script_Content(Request["ItemID"]);

                tbx_DisplayName.Text = myScript.Display_Name;

                droplist_Script_Type.SelectedValue = myScript.Script_Type.ToString();
                tbx_TextContent.Text = myScript.Script_Content;
                CategoryTree_Menu.Selected_CategoryID = myScript.CategoryID;

                _itemid = myScript.ScriptID;
                ViewState["ItemID"] = _itemid;
                _source_categoryid = myScript.CategoryID;
                ViewState["Source_CategoryID"] = _source_categoryid;

            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Init_Form()
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

        }

        private void Reset_Form()
        {

            // Default Setting
            tbx_DisplayName.Text = "";
            tbx_TextContent.Text = "";

            CategoryTree_Menu.UnSelectItems();
            CategoryTree_Menu.LoadCategoryRoot();

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
                Lib.ScriptMgr myScriptMgr = new Lib.ScriptMgr();

                e2Data[] UpdateData = {
                                          new e2Data("ScriptID", _itemid),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("Script_Type", droplist_Script_Type.SelectedValue),
                                          new e2Data("Script_Content", tbx_TextContent.Text),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                myScriptMgr.Edit_Script_Content(UpdateData);

                // Switch Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Move_ComponentInCategory_Item(_source_categoryid, CategoryTree_Menu.Selected_CategoryID, "076A591E-1BFE-47A7-8B40-D6621C7D3DF9");

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }
    }
}