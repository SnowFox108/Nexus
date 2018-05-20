using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nexus.Core.Tools
{

    public class PoP_ReturnMsg
    {
        string _command;
        string _controlid;
        string _value;

        public string Command
        {
            get { return _command;}
            set { _command = value; }
        }

        public string ControlID
        {
            get { return _controlid; }
            set { _controlid = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public PoP_ReturnMsg ()
        {
        }
    }

    public static class PoPWindows
    {
        public static void ReturnMsg(Control myControl, PoP_ReturnMsg myReturnMsg)
        {
            switch (myReturnMsg.Command)
            {
                case "FileSelector":
                    TextBox myTextBox = (TextBox)myControl.FindControl(myReturnMsg.ControlID);
                    myTextBox.Text = myReturnMsg.Value;
                    break;

            }
        }
    }
}
