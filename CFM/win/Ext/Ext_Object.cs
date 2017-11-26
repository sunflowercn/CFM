using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Ext
{
    public static class Ext_Object
    {
        public static string ToString2(this object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }
    }
}
