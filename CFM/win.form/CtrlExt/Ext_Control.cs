using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.CtrlExt
{
    public static class Ext_Control
    {
        public static Image ToImage(this Control ctrl)
        {               
            Bitmap bmp = new Bitmap(ctrl.Width,ctrl.Height);
            ctrl.DrawToBitmap(bmp,new Rectangle(0,0,ctrl.Width,ctrl.Height));
            return bmp;
        }
    }
}
