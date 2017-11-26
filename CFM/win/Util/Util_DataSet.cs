using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace win.Util
{
    public class Util_DataSet
    {
        public static List<T> DataSetToList<T>(DataTable dt)
        {                        
            IList<T> list = new List<T>();
            PropertyInfo[] tMembersAll = typeof(T).GetProperties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T t = Activator.CreateInstance<T>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    foreach (PropertyInfo tMember in tMembersAll)
                    {
                        if (dt.Columns[j].ColumnName.ToUpper().Equals(tMember.Name.ToUpper()))
                        {
                            if (dt.Rows[i][j] != DBNull.Value)
                            {
                                tMember.SetValue(t, dt.Rows[i][j], null);
                            }
                            else
                            {
                                tMember.SetValue(t, null, null);
                            }
                            break;
                        }
                    }
                }
                list.Add(t);
            }
            return list.ToList();
        }  
    }
}
