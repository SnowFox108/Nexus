using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Nexus.Core.Tools
{
    public static class AlertMessage
    {
        public static void Show_Alert(System.Web.UI.Page myPage, string msg)
        {
            string _msg = "Sys.Application.add_load(function(){radalert('" 
                + msg
                + "', 350, 100,'Warning');});";

            ScriptManager.RegisterStartupScript(myPage, typeof(Page), "RadAlertScript", _msg, true); 

        }

        public static void Show_Alert(System.Web.UI.Page myPage, string msg, string title)
        {

            string _msg = "Sys.Application.add_load(function(){radalert('"
                + msg
                + "', 350, 100,'"
                + title
                + "');});";

            ScriptManager.RegisterStartupScript(myPage, typeof(Page), "RadAlertScript", _msg, true);

        }

        public static void Show_Alert(System.Web.UI.Page myPage, string msg, string title, int width, int height)
        {
            string _msg = "Sys.Application.add_load(function(){radalert('"
                + msg
                + "', "
                + width.ToString()
                + ", "
                + height.ToString()
                + ",'"
                + title
                + "');});";

            ScriptManager.RegisterStartupScript(myPage, typeof(Page), "RadAlertScript", _msg, true);

        }


    }
}
