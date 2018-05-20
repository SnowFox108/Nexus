using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.General.Management
{
    public partial class CreateScript : System.Web.UI.UserControl
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

            #endregion
        }

        private void Reset_Form()
        {

            // Default Setting
            tbx_DisplayName.Text = "";
            tbx_TextContent.Text = "";


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

                DateTime nowTime = DateTime.Now;

                string ScriptID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("ScriptID", ScriptID),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
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
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Menu.Selected_CategoryID, "076A591E-1BFE-47A7-8B40-D6621C7D3DF9");

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