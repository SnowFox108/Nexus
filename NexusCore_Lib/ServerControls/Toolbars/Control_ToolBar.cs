using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nexus.Core.ServerControls
{
    public static class ToolBars
    {
        public static HtmlGenericControl LivePage_ToolBar(string Component_Icon, string Component_Name, string Page_ControlID, string EditMode)
        {
            HtmlGenericControl Control_GeneralDiv = new HtmlGenericControl("Div");
            Control_GeneralDiv.Attributes.Add("ID", "nexusCore_Editor_ToolBar");

            Panel TitlebarDiv = new Panel();
            TitlebarDiv.CssClass = "editor_title_bar";

            #region Control Title

            // Create Control Title
            HtmlGenericControl myTitle = new HtmlGenericControl("Div");
            myTitle.Attributes.Add("class", "editor_title");

            HtmlGenericControl title_UL = new HtmlGenericControl("ul");

            // Create Title Icon
            HtmlGenericControl title_iconLi = new HtmlGenericControl("li");

            Panel title_iconDiv = new Panel();
            title_iconDiv.Height = Unit.Pixel(24);
            title_iconDiv.Width = Unit.Pixel(24);
            title_iconDiv.Style.Add("background-image", Component_Icon);
            title_iconDiv.Style.Add("background-repeat", "no-repeat");

            title_iconLi.Controls.Add(title_iconDiv);

            // Create Title Text
            HtmlGenericControl title_textLi = new HtmlGenericControl("li");

            Panel title_textDiv = new Panel();
            title_textDiv.CssClass = "editor_buttontext";

            title_textDiv.Controls.Add(new LiteralControl(Component_Name));
            title_textLi.Controls.Add(title_textDiv);

            title_UL.Controls.Add(title_iconLi);
            title_UL.Controls.Add(title_textLi);

            myTitle.Controls.Add(title_UL);

            #endregion

            TitlebarDiv.Controls.Add(myTitle);

            #region Control Button

            // Create Command Buttons
            HtmlGenericControl editBtn = new HtmlGenericControl("Div");
            editBtn.Attributes.Add("class", "editor_buttons");

            HtmlGenericControl btn_UL = new HtmlGenericControl("ul");

            // Create Edit Icon
            HtmlGenericControl btn_iconLi = new HtmlGenericControl("li");

            Panel edit_iconDiv = new Panel();
            edit_iconDiv.Height = Unit.Pixel(24);
            edit_iconDiv.Width = Unit.Pixel(24);
            edit_iconDiv.Style.Add("background-image", "/App_Control_Style/NexusCore/Images/edit.png");
            edit_iconDiv.Style.Add("background-repeat", "no-repeat");

            btn_iconLi.Controls.Add(edit_iconDiv);

            // Create Link Buttons
            HtmlGenericControl btn_linkLi = new HtmlGenericControl("li");

            Panel edit_textDiv = new Panel();
            edit_textDiv.CssClass = "editor_buttontext";

            HyperLink HLinkbtn_Edit = new HyperLink();
            //HLinkbtn_Edit.ID = "Hlinkbtn_Edit";
            HLinkbtn_Edit.Attributes["href"] = "#";
            HLinkbtn_Edit.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlManager.aspx?Page_ControlID={0}&EditMode={1}');", Page_ControlID, EditMode);
            HLinkbtn_Edit.Text = "Edit";

            edit_textDiv.Controls.Add(HLinkbtn_Edit);
            btn_linkLi.Controls.Add(edit_textDiv);

            btn_UL.Controls.Add(btn_iconLi);
            btn_UL.Controls.Add(btn_linkLi);

            editBtn.Controls.Add(btn_UL);

            #endregion

            // Add Clear <Br>
            HtmlGenericControl clearBR = new HtmlGenericControl("Div");
            clearBR.Attributes.Add("class", "clear");

            TitlebarDiv.Controls.Add(editBtn);
            TitlebarDiv.Controls.Add(clearBR);

            Control_GeneralDiv.Controls.Add(TitlebarDiv);

            return Control_GeneralDiv;

        }
    }
}
