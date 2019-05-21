using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace win.Tools.Encryptor
{
    public class DESEncryptor:IEncryptor,IDecryptor
    {
        //对称加密密钥
        private string secKey;

        public DESEncryptor(string secKey)
        {
            this.secKey = secKey;
        }

        public  string Encrypt(string strInput)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byKey = System.Text.Encoding.UTF8.GetBytes(secKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strInput);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public  string Decrypt(string input)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[input.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(secKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(input);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
        }
    }
}
