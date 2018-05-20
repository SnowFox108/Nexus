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
    public partial class CreateHTML : System.Web.UI.UserControl
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
                Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();

                DateTime nowTime = DateTime.Now;

                string HTMLID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                e2Data[] UpdateData = {
                                          new e2Data("HTMLID", HTMLID),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("HTML_Content", tbx_TextContent.Text),
                                          new e2Data("Create_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_Date", nowTime.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                       };

                myHTMLMgr.Add_HTML_Content(UpdateData);

                // Add Item to Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_Menu.Selected_CategoryID, "B1CD6348-796C-4E92-8C39-5CEF3D600B7C");

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