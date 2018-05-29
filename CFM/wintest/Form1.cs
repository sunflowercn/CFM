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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using win.form.FormManager;

namespace wintest
{
    public partial class Form1 : ChildForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private List<int> list;
        private void Form1_Load(object sender, EventArgs e)
        {         

            List<string> list = new List<string> { "zhangsan", "lisi" };

            List<string> list1 = new List<string> { "zhang", "lisi2" };

            var ss = list.Where(p => list1.Contains(p));

        

        }
   

       

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void MultThreadTest()
        {
            using (TimeTester tt = new TimeTester(this.Name, "button1_click", LogType.txt))
            {
                Random r = new Random();
                int ss = r.Next(10);
                Thread.Sleep(ss);
            }
        }

        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                result += "%" + Convert.ToString(b[i], 16);
            }
            return result;
        }
        private string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            string[] chars = hs.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        private void PerformanceCompare()
        {
            int a10000 = 0;
            int a30000 = 0;
            int a50000 = 0;

            using (TimeTester me = new TimeTester(this.Name,"per"))
            {
                a10000 = this.list.Count(p => p < 10000);
                a30000 = this.list.Count(p => p < 30000);
                a50000 = this.list.Count(p => p < 50000);
            }

            using (TimeTester me = new TimeTester(this.Name,"per1"))
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
