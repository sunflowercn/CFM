using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace win.form.Ext_Ctrl
{
    public static class Ext_ComBox
    {
        public static void DataBind<T>(this ComboBox cbx, List<T> dataSource, string valueMember, string displayMember, bool showSelAll = true) where T : new()
        {          
            if (showSelAll)
            {
                dataSource = dataSource.ToList();
                Type type = typeof(T);
                PropertyInfo piD = type.GetProperty(displayMember);
                PropertyInfo piV = type.GetProperty(valueMember);
                T temp = new T();            
                Type t = piV.PropertyType;
                if (t.Name == typeof(int).Name || t.Name == typeof(decimal).Name || t.Name == typeof(float).Name || t.Name == typeof(double).Name)
                    piV.SetValue(temp,-1,null);                   
                else if (t.Name == typeof(string).Name)
                    piV.SetValue(temp,string.Empty,null);
                else if (t.Name == typeof(Guid).Name)
                    piV.SetValue(temp, Guid.Empty, null);
                piD.SetValue(temp, "请选择", null);               
                dataSource.Insert(0, temp);                                       
            }           
            cbx.DisplayMember = displayMember;
            cbx.ValueMember = valueMember;   
            cbx.DataSource = dataSource.ToList();                                      
        }

        public static void DataBind(this ComboBox cbx, DataTable dataSource, string valueMember, string displayMember, bool showSelAll = true)
        {
            dataSource = dataSource.Copy();  
            if (showSelAll)
            {
                DataRow dr = dataSource.NewRow();
                dr[displayMember]="请选择";
                Type t = dataSource.Columns[valueMember].DataType;
                if (t.Name == typeof(int).Name || t.Name == typeof(decimal).Name || t.Name == typeof(float).Name || t.Name == typeof(double).Name)
                    dr[valueMember] = -1;
                else if (t.Name == typeof(string).Name)
                    dr[valueMember] = string.Empty;
                else if (t.Name == typeof(Guid).Name)
                    dr[valueMember] = Guid.Empty;
                dataSource.Rows.InsertAt(dr,0);                
            }
            cbx.DisplayMember = displayMember;
            cbx.ValueMember = valueMember;
            cbx.DataSource = dataSource;
        }
    }
}
