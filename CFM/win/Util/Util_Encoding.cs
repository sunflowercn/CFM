using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace win.Util
{  
    public class Util_Encoding
    {
        /// <summary>
        /// 汉字转换为Unicode编码
        /// </summary>
        /// <param name="str">要编码的汉字字符串</param>
        /// <returns>Unicode编码的的字符串</returns>
        public static string ToUnicode(string str)
        {
            byte[] bts = Encoding.Unicode.GetBytes(str);
            string r = "";
            for (int i = 0; i < bts.Length; i += 2) r += "\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return r;
        }
        /// <summary>
        /// 将Unicode编码转换为汉字字符串
        /// </summary>
        /// <param name="str">Unicode编码字符串</param>
        /// <returns>汉字字符串</returns>
        public static string ToGB2312(string str)
        {
            string r = "";
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            foreach (Match m in mc)
            {
                bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                r += Encoding.Unicode.GetString(bts);
            }
            return r;
        }

        /// <summary>
        /// 串口通讯中的某种转换方法
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="charset">gb2312、utf-8......</param>
        /// <returns></returns>
        public static string UnHex(string hex, string charset)
        {
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }


     
	    public static byte[] fromHex(String hex)
        {
            byte[] binary = new byte[hex.Length / 2];
            for (int i = 0; i < binary.Length; i++)
            {
                binary[i] = Convert.ToByte(hex.Substring(2 * i,2),16);
            }
            return binary;
        }

  
        public static string toHex(byte[] array)
        {
            char[] chars = "0123456789ABCDEF".ToCharArray();
            StringBuilder sb = new StringBuilder("");
           
            int bit;
            for (int i = 0; i < array.Length; i++)
            {
                bit = (array[i] & 0x0f0) >> 4;
                sb.Append(chars[bit]);
                bit = array[i] & 0x0f;
                sb.Append(chars[bit]);
            }
            return sb.ToString();

        }

    }
}
