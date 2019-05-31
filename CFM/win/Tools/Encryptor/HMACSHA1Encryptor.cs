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

        public HMACSHA1Encryptor(string salt, int iterations=800,int hashbytesize=15)
        {
            this.salt = salt;
            this.iterations = iterations;
            this.hashbytesize = hashbytesize;           
        }

        public string Encrypt(string plaintext)
        {           
            byte[] arrsalt = Util_Encoding.fromHex(salt);
            Rfc2898DeriveBytes dd = new Rfc2898DeriveBytes(plaintext, arrsalt, iterations);
            var ss = dd.GetBytes(hashbytesize);
            return Util_Encoding.toHex(ss);           
        }   
    }

}
