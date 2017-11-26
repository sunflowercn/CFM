using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win.form.Ext_Ctrl
{
    public static class Ext_ListView
    {        
        private static string Asc = ((char)0x2191).ToString().PadLeft(1, ' '); 
        private static string Des = ((char)0x2193).ToString().PadLeft(1, ' ');
       
        /// <summary>
        /// 可在ListView的column上设置tag属性（）
        /// </summary>
        /// <param name="lvi"></param>
        public static void EnableSort(this ListView lvi)
        {
          
            lvi.ColumnClick += lvi_ColumnClick;
        }

        static void lvi_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lvi = sender as ListView;

            if (lvi.Tag != null)
            {
                int index= (lvi.Tag as ColumnHeader).Index;
                 lvi.Columns[index].Text = lvi.Columns[index].Text.Replace(Asc, string.Empty).Replace(Des, string.Empty);
            }
            ListViewItemCompare precompare = lvi.ListViewItemSorter as ListViewItemCompare;

            if(precompare==null || e.Column != precompare.ch.Index)                        
                lvi.ListViewItemSorter = new ListViewItemCompare(lvi.Columns[e.Column],SortOrder.Ascending);                          
            else            
                lvi.ListViewItemSorter = new ListViewItemCompare(lvi.Columns[e.Column], lvi.Sorting==SortOrder.Descending ? SortOrder.Ascending:SortOrder.Descending);                          
            lvi.Sort();

            lvi.Columns[e.Column].Text += lvi.Sorting == SortOrder.Descending ? Des : Asc;
        }
    }

    class ListViewItemCompare : IComparer
    {        
        public ColumnHeader ch;
        public SortOrder sortorder;
        public ListViewItemCompare(ColumnHeader ch,SortOrder sortorder)
        {
            this.ch = ch;
            this.sortorder = sortorder;
        }
        public int Compare(object x, object y)
        {           
            ListViewItem lvi1 = x as ListViewItem;
            ListViewItem lvi2 = y as ListViewItem;         

            if (lvi1 == null)                           
                return -1;
            
            if (lvi2 == null)                      
                return 1;            

            string strval1= lvi1.SubItems[ch.Index].Text;
            string strval2= lvi2.SubItems[ch.Index].Text;

            int returnval = 1;
            
            if (string.IsNullOrWhiteSpace(strval1))                    
                returnval = -1;
            else if (string.IsNullOrWhiteSpace(strval2))
                returnval = 1;
            else
            {
                if (ch.Tag==null || string.IsNullOrWhiteSpace(ch.Tag.ToString()) || ch.Tag.ToString() == "string")
                {
                    returnval = string.Compare(lvi1.SubItems[ch.Index].Text, lvi2.SubItems[ch.Index].Text);
                }
                else if (ch.Tag.ToString() == "int")
                {
                    int val1, val2;
                    int.TryParse(strval1, out val1);
                    int.TryParse(strval2, out val2);
                    returnval = val1.CompareTo(val2);
                }
                else if (ch.Tag.ToString() == "double")
                {
                    double val1, val2;
                    double.TryParse(strval1, out val1);
                    double.TryParse(strval2, out val2);
                    returnval = val1.CompareTo(val2);
                }
                else if (ch.Tag.ToString() == "float")
                {
                    float val1, val2;
                    float.TryParse(strval1, out val1);
                    float.TryParse(strval2, out val2);
                    returnval = val1.CompareTo(val2);
                }
                else if (ch.Tag.ToString() == "decimal")
                {
                    decimal val1, val2;
                    decimal.TryParse(strval1, out val1);
                    decimal.TryParse(strval2, out val2);
                    returnval = val1.CompareTo(val2);
                }               
                else if (ch.Tag.ToString() == "datetime")
                {
                    DateTime val1, val2;
                    DateTime.TryParse(strval1, out val1);
                    DateTime.TryParse(strval2, out val2);
                    returnval = val1.CompareTo(val2);
                }
            }

            lvi1.ListView.Sorting =this.sortorder;
            lvi1.ListView.Tag = this.ch;          
           
            if (this.sortorder == SortOrder.Descending)
                returnval *= -1;          

            return returnval;
           
        }
    }
}
