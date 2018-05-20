using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexus.Core.Controls
{
    // Page Control Properties
    public class Control_Property
    {

        private string _page_controlid;
        private string _property_name;
        private string _property_value;

        public string Page_ControlID { get { return _page_controlid; } }
        public string Property_Name { get { return _property_name; } }
        public string Property_Value { get { return _property_value; } }

        public Control_Property(string page_controlid, string property_name, string property_value)
        {
            _page_controlid = page_controlid;
            _property_name = property_name;
            _property_value = property_value;
        }
    }

}
