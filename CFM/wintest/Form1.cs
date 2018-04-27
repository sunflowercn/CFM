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
            this.timer1.Start();

            student a = new student { id = Guid.NewGuid(), birthdate = new DateTime(2011, 1, 1), name = "张三" };

            List<student> liststua = new List<student>();
            liststua.Add(a);


            List<student> b = liststua.Clone();

            a.birthdate = new DateTime(9999, 1, 1);
            a.name = "lisi";
            a.id = Guid.NewGuid();
            
        }
        
        bool loading= false;
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(loading)
                return;

            loading=true;
            //this.webBrowser1.Navigate("about:blank");
            this.webBrowser1.Navigate("http://www.baidu.com");

            double usedMemory = 0;
            Process p = Process.GetProcesses().Where(x => x.ProcessName.Contains("进程名")).FirstOrDefault();
            if (p != null)
            {
                p.Refresh();
                string procName = p.ProcessName;
                using (PerformanceCounter pc = new PerformanceCounter("Process", "Working Set - Private", procName))
                {
                    usedMemory = pc.NextValue() / 1024.0 / 1024.0;
                }
            }

            this.listBox1.Items.Add(usedMemory.ToString());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            loading=false;
        }

       

       
    }
}
