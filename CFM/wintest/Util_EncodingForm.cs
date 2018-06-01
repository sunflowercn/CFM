using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wintest
{
    public partial class Util_EncodingForm : Form
    {
        public Util_EncodingForm()
        {
            InitializeComponent();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            this.label2.Text= win.Util.Util_Encoding.UnHex(this.textBox1.Text,"gb2312");
        }
    }
}
