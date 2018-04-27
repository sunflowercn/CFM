using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Ext
{
    public static class Ext_Object
    {
        public static string ToString2(this object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }

        /// <summary>
        /// 简单对象（字段或属性不能包含引用类型）克隆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Clone<T>(this T obj) where T:new()
        {
            Type type = obj.GetType();

            T obj1 = new T();

            foreach (var f in type.GetFields())
            {              
                object data =f.GetValue(obj);               
                f.SetValue(obj1, data);             
            }

            foreach (var p in type.GetProperties())
            {
                if (!p.CanWrite) //没有这个只读属性会报错
                    continue;

                object data = type.GetProperty(p.Name).GetValue(obj, null);
                type.GetProperty(p.Name).SetValue(obj1, data, null);              
            }

            return obj1;
        }
    }
}
