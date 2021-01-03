using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace win.Tools.Encryptor
{
    public class HMACSHA256Encryptor : IEncryptor
    {
        private string securityKey;
        public  HMACSHA256Encryptor(string securityKey)
        {
            this.securityKey = securityKey;
            this.securityKey = "your-256-bit-secret"; //王长 jwt.io的示例私钥
        }

        public string Decrypt(string secrettext)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string plaintext)
        {            
            var hs256 = new HMACSHA256(Encoding.ASCII.GetBytes(securityKey));
            string ss= Encoding.UTF8.GetString(hs256.ComputeHash(Encoding.UTF8.GetBytes(plaintext)));
            return ss;
        }
    }

    public class JWTToken
    {
        public static string HEADER = "{\"alg\": \"HS256\",\"typ\": \"JWT\"}";
        public static string PAYLOAD = "{\"sub\": \"1234567890\",\"name\": \"John Doe\",\"iat\": 1516239022}";
    }
}
