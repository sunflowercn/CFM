using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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
            catch
            {
                return default(T);
            }
        }
    }
}
