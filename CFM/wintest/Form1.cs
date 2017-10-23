using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.CtrlExt;

namespace wintest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<student> list = new List<student>();
            list.Add(new student() { id = 1, name = "zhang" });
            list.Add(new student() { id = 2, name = "li" });
            this.comboBox1.DataBind(list, "id", "name", 1);
            
        }
    }
}
