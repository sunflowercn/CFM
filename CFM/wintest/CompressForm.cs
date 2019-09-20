using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.Util;

namespace wintest
{
    public partial class CompressForm : Form
    {
        public CompressForm()
        {
            InitializeComponent();
        }

        private void button压缩_Click(object sender, EventArgs e)
        {
            this.textBox压缩后.Text = Util_Compress.Compress(this.textBox压缩前.Text);
        }

        private void button解压_Click(object sender, EventArgs e)
        {
            this.textBox压缩前.Text = Util_Compress.Decompress(this.textBox压缩后.Text);
        }
    }
}
