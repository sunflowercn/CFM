using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.form.Parsers;

namespace wintest
{
    public partial class HtmlParserForm : Form
    {
        public HtmlParserForm()
        {
            InitializeComponent();
        }

        private void HtmlParserForm_Load(object sender, EventArgs e)
        {
            DateTime date交易日期 = new DateTime(2019, 1, 8);
            string url = string.Format("http://www.100ppi.com/sf2/day-{0}.html", date交易日期.ToString("yyyy-MM-dd"));
            string r1 = win.Util.Util_Http.HttpGet(url, string.Empty); //上海期货交易所，每日交易数据

            HtmlParser parser = new HtmlParser();
          
        }
    }
}
