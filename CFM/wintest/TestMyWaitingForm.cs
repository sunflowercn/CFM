﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using win.form.HelpUI;

namespace wintest
{
    public partial class TestMyWaitingForm : Form
    {
        public TestMyWaitingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MyWaiting mw = new MyWaiting("please wait"))
            {
                Thread.Sleep(3000);
            }
        }
    }
}
