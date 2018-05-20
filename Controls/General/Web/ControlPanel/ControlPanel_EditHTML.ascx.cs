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
    public partial class EditHTML : System.Web.UI.UserControl
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
                Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();
                Lib.HTML myHTML = myHTMLMgr.Get_HTML_Content(Request["ItemID"]);

                tbx_DisplayName.Text = myHTML.Display_Name;
                tbx_TextContent.Text = myHTML.HTML_Content;
                CategoryTree_Menu.Selected_CategoryID = myHTML.CategoryID;

                _itemid = myHTML.HTMLID;
                ViewState["ItemID"] = _itemid;
                _source_categoryid = myHTML.CategoryID;
                ViewState["Source_CategoryID"] = _source_categoryid;

            }
            else
            {
                btn_Update.Enabled = false;
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
                Lib.HTMLMgr myHTMLMgr = new Lib.HTMLMgr();

                e2Data[] UpdateData = {
                                          new e2Data("HTMLID", _itemid),
                                          new e2Data("CategoryID", CategoryTree_Menu.Selected_CategoryID),
                                          new e2Data("Display_Name", tbx_DisplayName.Text),
                                          new e2Data("HTML_Content", tbx_TextContent.Text),
                                          new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                          new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                      };

                myHTMLMgr.Edit_HTML_Content(UpdateData);

                // Switch Category
                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Move_ComponentInCategory_Item(_source_categoryid, CategoryTree_Menu.Selected_CategoryID, "B1CD6348-796C-4E92-8C39-5CEF3D600B7C");

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }
    }
}