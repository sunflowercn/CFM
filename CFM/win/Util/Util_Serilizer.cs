using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace win.Util
{   
    public class Util_Serilizer
    {
        public static string Serialize(object obj)
        {
            StringWriter sw = new StringWriter();
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            xs.Serialize(sw, obj);
            return sw.ToString();
        }

        public static T Deserialize<T>(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return default(T);
                StringReader sr = new StringReader(data);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(sr);
            }
            catch
            {
                return default(T);
            }
        }

        public static string SerializeXML(object obj)
        {
            StringWriter sw = new StringWriter();
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            xs.Serialize(sw, obj);
            return Util_Encoding.ToUnicode(sw.ToString());

        }

        public static T DeserializeXML<T>(string data)
        {
            try
            {
                data = Util_Encoding.ToGB2312(data);
                StringReader sr = new StringReader(data);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(sr);
            }
            catch
            {
                return default(T);
            }
        }
    }   
}
