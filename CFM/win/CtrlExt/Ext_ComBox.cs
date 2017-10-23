using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace win.CtrlExt
{
    public static class Ext_ComBox
    {
        public static void DataBind(this ComboBox cbx, object dataSource, string displayMember, string valueMember, int selectedIndex = 0)
        {
            cbx.DataSource = dataSource;
            cbx.DisplayMember = displayMember;
            cbx.ValueMember = valueMember;
            cbx.SelectedIndex = selectedIndex;          
        }
    }
}
