using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.HelpUI
{
    public class MyWaiting : IDisposable
    {
        private WaitingForm waitForm;

        public MyWaiting(string Info=null)
        {
            this.waitForm = new WaitingForm(Info);
            this.waitForm.Show();
            Application.DoEvents();
        }

        public void Dispose()
        {
            this.waitForm.Close();
        }
    }
}
