using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nexus.Core.PageEditor
{

    public class RadDockTemplate : System.Web.UI.ITemplate
    {
        private string _icon;
        private string _title;
        private ServerControls.NC_LinkButton[] _nc_linkbutton;

        public RadDockTemplate(string icon, string title, ServerControls.NC_LinkButton[] nc_linkbutton)
        {
            _icon = icon;
            _title = title;
            _nc_linkbutton = nc_linkbutton;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {

            HtmlGenericControl Control_GeneralDiv = new HtmlGenericControl("Div");
            Control_GeneralDiv.Attributes.Add("ID", "nexusCore_Editor_ToolBar");

            // Create Dock Title Bar
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
            title_iconDiv.Style.Add("background-image", _icon);
            title_iconDiv.Style.Add("background-repeat", "no-repeat");

            title_iconLi.Controls.Add(title_iconDiv);

            // Create Title Text
            HtmlGenericControl title_textLi = new HtmlGenericControl("li");

            Panel title_textDiv = new Panel();
            title_textDiv.CssClass = "editor_buttontext";

            title_textDiv.Controls.Add(new LiteralControl(_title));
            title_textLi.Controls.Add(title_textDiv);

            title_UL.Controls.Add(title_iconLi);
            title_UL.Controls.Add(title_textLi);

            myTitle.Controls.Add(title_UL);

            #endregion

            TitlebarDiv.Controls.Add(myTitle);

            #region Control Buttons

            // Create Command Buttons
            HtmlGenericControl editBtn = new HtmlGenericControl("Div");
            editBtn.Attributes.Add("class", "editor_buttons");

            HtmlGenericControl btn_UL = new HtmlGenericControl("ul");

            foreach (ServerControls.NC_LinkButton myLinkButton in _nc_linkbutton)
            {
                HtmlGenericControl btn_iconLi = new HtmlGenericControl("li");

                Panel edit_iconDiv = new Panel();
                edit_iconDiv.Height = Unit.Pixel(24);
                edit_iconDiv.Width = Unit.Pixel(24);
                edit_iconDiv.Style.Add("background-image", myLinkButton.IconURL);
                edit_iconDiv.Style.Add("background-repeat", "no-repeat");

                btn_iconLi.Controls.Add(edit_iconDiv);

                HtmlGenericControl btn_linkLi = new HtmlGenericControl("li");

                Panel edit_textDiv = new Panel();
                edit_textDiv.CssClass = "editor_buttontext";

                switch (myLinkButton.BtnType.ToString())
                {
                    case "System.Web.UI.WebControls.LinkButton":
                        edit_textDiv.Controls.Add(myLinkButton.LinkBtn);
                        btn_linkLi.Controls.Add(edit_textDiv);
                        break;

                    case "System.Web.UI.WebControls.HyperLink":
                        edit_textDiv.Controls.Add(myLinkButton.HlinkBtn);
                        btn_linkLi.Controls.Add(edit_textDiv);
                        break;
                }

                btn_UL.Controls.Add(btn_iconLi);
                btn_UL.Controls.Add(btn_linkLi);

            }

            editBtn.Controls.Add(btn_UL);

            #endregion

            // Add Clear <Br>
            HtmlGenericControl clearBR = new HtmlGenericControl("Div");
            clearBR.Attributes.Add("class", "clear");

            string clearDiv = "<Div class=\"nexusCore_Editor_clear\"></Div>";

            TitlebarDiv.Controls.Add(editBtn);
            //TitlebarDiv.Controls.Add(clearBR);

            Control_GeneralDiv.Controls.Add(TitlebarDiv);
            //Control_GeneralDiv.Controls.Add(new LiteralControl(clearDiv));

            //container.Controls.Add(clearBR);

            container.Controls.Add(Control_GeneralDiv);
            container.Controls.Add(new LiteralControl(clearDiv));

        }
    }
}
