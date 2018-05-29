using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.CtrlExt
{
    public static class Ext_Control
    {
        public static Image ToImage(this Control ctrl)
        {
            if (ctrl is System.Windows.Forms.DataVisualization.Charting.Chart)
            {

                System.Windows.Forms.DataVisualization.Charting.Chart chart = ctrl as
                     System.Windows.Forms.DataVisualization.Charting.Chart;
                MemoryStream ms = new MemoryStream();
                chart.SaveImage(ms, ImageFormat.Bmp);
                Bitmap bmp1 = new Bitmap(ms);
                return bmp1;
              
            }
            Bitmap bmp = new Bitmap(ctrl.Width,ctrl.Height);      
            ctrl.DrawToBitmap(bmp,ctrl.ClientRectangle);            
            return bmp;
        }
    }
}
