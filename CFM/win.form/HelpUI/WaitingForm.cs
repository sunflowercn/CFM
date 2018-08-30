using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.HelpUI
{
    public partial class WaitingForm : Form
    {
        public WaitingForm(string Info=null)
        {
            InitializeComponent();
            if (Info != null)
                this.label1.Text = Info;

            this.Width = this.label1.Width + 20;  
        }

    }
}
