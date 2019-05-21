/*
       对标java中 
       PBEKeySpec spec = new PBEKeySpec(password, salt, iterations, bytes * 8);
       SecretKeyFactory skf = SecretKeyFactory.getInstance(PBKDF2_ALGORITHM);
       return skf.generateSecret(spec).getEncoded();
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using win.Util;

namespace win.Tools.Encryptor
{
    /// <summary>
    /// 
    /// </summary>
    public class HMACSHA1Encryptor:IEncryptor
    {
        public string salt;
        public int iterations;
        public int hashbytesize;

        public HMACSHA1Encryptor(string salt, int iterations,int hashbytesize=15)
        {
            this.salt = salt;
            this.iterations = iterations;
            this.hashbytesize = hashbytesize;
        }


        public string Encrypt(string plaintext)
        {
            //byte[] unsaltedplaintext = Encoding.Default.GetBytes(plaintext);
            //byte[] arrsalt = Encoding.Default.GetBytes(salt);

            //byte[] unsaltedplaintext = Util_Encoding.fromHex(plaintext);
            byte[] arrsalt = Util_Encoding.fromHex(salt);

            Rfc2898DeriveBytes dd = new Rfc2898DeriveBytes(plaintext, arrsalt, iterations);
            var ss = dd.GetBytes(hashbytesize);

            return Util_Encoding.toHex(ss);

            //[24, 110, 86, 120, -56, -76, 9, 33, -27, 110, -124, 120, 7, -73, -34]


           
        }
   
    }

}
