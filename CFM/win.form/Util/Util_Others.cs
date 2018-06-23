using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.Util
{
    public class Util_Others
    {
        public static T FindCtrl<T>(Control ctrl) where T : Control
        {
            T r = default(T);
            if (ctrl is T)
            {
                r = (T)ctrl;
            }
            else
            {
                foreach (Control childctrl in ctrl.Controls)
                {

                    if (childctrl.HasChildren)
                    {
                        r = FindCtrl<T>(childctrl);
                    }
                    if (r != null)
                        break;
                }
            }
            return r;
        }
    }
}
