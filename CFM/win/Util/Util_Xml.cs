using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace win.Util
{
    public class Util_Xml
    {
        public static string ToXML(object obj)
        {
            StringWriter sw = new StringWriter();
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            xs.Serialize(sw, obj);
            return sw.ToString();
        }
        public static T FromXML<T>(string data)
        {
            try
            {
                StringReader sr = new StringReader(data);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(sr);
            }
            catch(Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="parentNode">xml中每一个parentNode代表了集合中得一个元素</param>
        /// <returns></returns>
        public static List<T> FromXML1<T>(string data,string parentNode) where T:new()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

           
            List<T> list = new List<T>();

            foreach (XmlNode node in doc.GetElementsByTagName(parentNode))
            {
                T temp = CreateNewT<T>(node);
                list.Add(temp);
            }

            return list;

          
        }

        /// <summary>
        /// 把node中得内容转换成类得实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        private static T CreateNewT<T>(XmlNode node) where T : new()
        {
            T temp = new T();
            Type t = typeof(T);

            foreach (XmlNode item in node.ChildNodes)
            {
                PropertyInfo p = t.GetProperty(item.Name);
                p.SetValue(temp, item.InnerText, null);
            }

            return temp;
        }
    }
}
