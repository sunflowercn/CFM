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
using win.Inherit;
using win.Util;
using win;
using win.form.Inherit;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using win.Ext;
using win.Tester;
using System.Threading;

namespace wintest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private List<int> list;
        private void Form1_Load(object sender, EventArgs e)
        {
            list = this.InitList();
           
        }
   
       

        private void button1_Click(object sender, EventArgs e)
        {
            TimeTester tt = new TimeTester();

            long ss = tt.SpendTime;
        }

        private void PerformanceCompare()
        {
            int a10000 = 0;
            int a30000 = 0;
            int a50000 = 0;

            using (TimeTester me = new TimeTester())
            {
                a10000 = this.list.Count(p => p < 10000);
                a30000 = this.list.Count(p => p < 30000);
                a50000 = this.list.Count(p => p < 50000);
            }

            using (TimeTester me = new TimeTester())
            {
                foreach (var item in list)
                {
                    if (item < 10000)
                    {
                        a10000++;
                        a30000++;
                        a50000++;
                    }
                    else if (item < 30000)
                    {
                        a30000++;
                        a50000++;
                    }
                    else
                    {
                        a50000++;
                    }

                }
            }
        }     
        private List<int> InitList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 50000; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
