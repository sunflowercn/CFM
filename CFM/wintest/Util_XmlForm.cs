using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using win.Util;

namespace wintest
{
    public partial class Util_XmlForm : Form
    {
        public Util_XmlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xmlstr = "<items><Item><DepartmentCode>100</DepartmentCode><DepName>门诊处置室</DepName><NextFlag>0</NextFlag></Item><Item><DepartmentCode>97</DepartmentCode><DepName>腔镜室</DepName><NextFlag>0</NextFlag></Item><Item><DepartmentCode>99</DepartmentCode><DepName>眼科门诊</DepName><NextFlag>0</NextFlag></Item></items>";

           

            List<Item> list = Util_Xml.FromXML1<Item>(xmlstr,"Item");

            //List<student> list = new List<student>() { new student { id = Guid.NewGuid(), name = "zhangsa", xh = "s" } };
            //string s= Util_Xml.ToXML(list);
        }
    }

    public class Item
    {
        public string DepartmentCode { get; set; }
        public string DepName { get; set; }
        public string NextFlag { get; set; }
    }
}
