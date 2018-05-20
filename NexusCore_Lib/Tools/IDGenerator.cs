using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus.Core.Tools
{
    public static class IDGenerator
    {
        public static string Get_New_GUID()
        {
            System.Guid guid = System.Guid.NewGuid();
            return guid.ToString().ToUpper();
        }

        public static string Get_New_GUID_PlainText()
        {
            System.Guid guid = System.Guid.NewGuid();
            return guid.ToString().Replace("-","").ToUpper();
        }

    }
}
