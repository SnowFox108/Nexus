using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Nexus.Core.PageEditor
{

    public class PageTemplateTemplate : System.Web.UI.ITemplate
    {
        private string _text;
        private string _masterpageid;
        private string _image_url;

        public PageTemplateTemplate(string text, string masterpageid, string image_url)
        {
            _text = text;
            _masterpageid = masterpageid;
            _image_url = image_url;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            // Create Dock Title Bar
            Panel TemplateDiv = new Panel();


            // Create Image
            HtmlGenericControl editBtn = new HtmlGenericControl("Div");

            Panel _iconDiv = new Panel();
            //edit_iconDiv.Height = Unit.Pixel(16);
            //edit_iconDiv.Width = Unit.Pixel(16);
            _iconDiv.Style.Add("background-image", _image_url);
            _iconDiv.Style.Add("background-repeat", "no-repeat");

            TemplateDiv.Controls.Add(_iconDiv);

            // Create Text
            HtmlGenericControl _textDiv = new HtmlGenericControl("Div");
            _textDiv.Controls.Add(new LiteralControl(_text));
            TemplateDiv.Controls.Add(_textDiv);

            container.Controls.Add(TemplateDiv);

        }
    }
}
