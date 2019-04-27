using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.CtrlExt
{
    public static class Ext_Objext
    {
        public static  void ShowMessage(this object obj,string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
