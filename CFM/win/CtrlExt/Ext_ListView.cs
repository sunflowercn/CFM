using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.CtrlExt
{
    public static class Ext_ListView
    {
        public static void EnableSort(this ListView lvi)
        {
          
            lvi.ColumnClick += lvi_ColumnClick;
        }

        static void lvi_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lvi = sender as ListView;
            lvi.ListViewItemSorter = new IntCompare(lvi.Columns[e.Column],lvi.Sorting);       
            lvi.Sort();
        }
    }

    class IntCompare : IComparer
    {
        ColumnHeader ch;

        public IntCompare(ColumnHeader ch,SortOrder sortorder)
        {
            this.ch = ch;            
        }
        public int Compare(object x, object y)
        {
           
            ListViewItem lvi1 = x as ListViewItem;
            ListViewItem lvi2 = y as ListViewItem;

            if (ch.Tag.ToString() == "int")
            {
                int val1 = Convert.ToInt32(lvi1.SubItems[ch.Index].Text);
                int val2 = Convert.ToInt32(lvi2.SubItems[ch.Index].Text);
                return val1.CompareTo(val2);
            }
            else if (ch.Tag.ToString() == "string")
            {
                return string.Compare(lvi1.SubItems[ch.Index].Text, lvi2.SubItems[ch.Index].Text);
            }

            return 1;
           
        }
    }
}
