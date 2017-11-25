using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.form.CtrlExt;

namespace wintest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listViewEx1.EnableSort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(Guid));
            dt.Columns.Add("name");

            DataRow dr = dt.NewRow();
            dr[0] = Guid.NewGuid();
            dr[1] = "zhangsan";
            dt.Rows.Add(dr);

            this.comboBox1.DataBind(dt, "id", "name");

            MessageBox.Show(this.comboBox1.SelectedValue.ToString());
        }

        private void BindListView()
        {
            //List<student> list = new List<student>();
            //list.Add(new student() { id = Guid.NewGuid(),xh=1, name = "zhang" });
            //list.Add(new student() { id = Guid.NewGuid(),xh=2, name = "li" });

            //this.listViewEx1.Items.Clear();
            //foreach (var item in list)
            //{
            //    ListViewItem lvi = new ListViewItem(item.id.ToString());
            //    lvi.SubItems.Add(item.name);
            //    this.listViewEx1.Items.Add(lvi);
            //}
        }
    
    }
}
