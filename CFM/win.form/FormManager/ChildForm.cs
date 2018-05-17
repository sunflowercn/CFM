using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.FormManager
{
    public partial class ChildForm : Form
    {
        private bool sharePage;
        public ChildForm()
        {
            InitializeComponent();
        }

        public void OnClose()
        {
            if (sharePage)
                this.Hide();
            else
                this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {                      
            base.OnLoad(e);
        }
    }
}
