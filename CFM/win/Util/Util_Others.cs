using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace win.Util
{
    public class Util_Others
    {
        /// <summary>
        /// 对属性赋值，字段不处理，两个对象中名字相同的属性，可能类型不一致的赋值
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="aimobj">将要被赋值的对象</param>
        /// <param name="sourceobj">sourceobj中的值赋值导aimobj中</param>
        public static void UpdateObjVal<M, N>(M aimobj, N sourceobj)
        {
            Type taim = typeof(M);

            Type tsou = typeof(N);
            PropertyInfo[] pis = tsou.GetProperties();

            foreach (PropertyInfo item in taim.GetProperties())
            {
                if (!item.CanWrite)
                    continue;

                Type aimtype = item.PropertyType;

                PropertyInfo pi = pis.FirstOrDefault(p => p.Name == item.Name);
                if (pi == null)
                    continue;

                object obj = pi.GetValue(sourceobj, null);
                if (obj == null)
                    continue;

                try
                {
                    object newval = null;

                    if (aimtype.IsGenericType && aimtype.GetGenericTypeDefinition() == typeof(Nullable<>)) //如果是可为空的类型
                        newval = Convert.ChangeType(obj, Nullable.GetUnderlyingType(aimtype));
                    else
                        newval = Convert.ChangeType(obj, aimtype);

                    item.SetValue(aimobj, newval, null);

                }
                catch (Exception ex)
                {
                    ex.Publish();
                }
            }
        }

    }
}
