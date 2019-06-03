using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace win.Tools.Encryptor
{
    public class RSAEncryptor:IEncryptor,IDecryptor
    {
    
        //private static  int MAX_ENCRYPT_BLOCK = 117; //RSA最大加密明文大小  暂时用不到分段加密解密
        //private static  int MAX_DECRYPT_BLOCK = 128; //RSA最大解密密文大小
        
        private string publickey;
        private string privateKey;

        public RSAEncryptor()
        {
            this.privateKey = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAKJGE9CQ36mYi2dCsQKiZ2x///9e6UcTnmaFiUcDz/E15gb3Fd5E7RH/Uci2XtsBVeDWXlYZAtHBqQh9BJt4/N25clAGTl62+fnXWIKZ26YrDEYYtDejO/27K715u+FB8CL7ews6Qb2X7Orz+Yj98rTd5UT3PiqXsvtD2yZ5a3hbAgMBAAECgYAeLP/kSfx9kjNiKWG3RrIK2Canu2OP5xMOp4hmn0vc5BP5eZskcRbQwPTZaShse2wX2mVCh3YhwWyIeo8PxkjnOpWjB03NU0ciB5toS45DhpvUIuFPvIN0ElXsY8l2gP2TCa+P8o+TZw80/ToXjxB8SXQSjGhWZSoAeAqWFLeMgQJBAM135ef0LGxGievq9t9lyzry3D0ry+mfoxuFKuFH6gCjPUVcIt9NIIIgETX/R8oI/t0qzyzjmAx9t7Trgp0jYcECQQDKLq+AqfbHuA1SryZKjLqiI3sRTH+vNXRRgizOe8YiMFl9r6Antf7azXVt7AnDwtJMmC2lUpgkT/hggv6ZmGkbAkEAqy0TXa4gAEi4CNLkv3Ln4IGKGHBPXqA/W+MSuUKXYdadahZ7evufdKlQjWLTJS9fXVSX6zblaqqmDNUUKOPcQQJAfuYahZkoKWaeBh2k3PnDUm0Om2b2ZVQZs+cOlHMfgunx4W9QCFy0n0SBxgJ2hoZLVIPXcoKKt4/yBzFw95qvrQJAPRWtRT+oEj8HE/IjELoLkJrR82WR2yXe0YSZ+RKL8EpE0i0beYXtrvQZSr0BUfHx0vFU7DDLhCsZTxDrN/naMQ==";
        }
        public RSAEncryptor(string privatekey,string publickey)
        {
            this.privateKey = privatekey;
            this.publickey = publickey;
        }

        public  string[] GenerateKeys()
        {
            string[] sKeys = new String[2];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            sKeys[0] = rsa.ToXmlString(true); //私钥
            sKeys[1] = rsa.ToXmlString(false); //公钥
            return sKeys;
        }

        public  string Encrypt(string strInput)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string sss = rsa.SignatureAlgorithm;         
            string plaintext = strInput;
            rsa.FromXmlString(publickey);
            byte[] cipherbytes;
            //byte[] byteEn = rsa.Encrypt(Encoding.UTF8.GetBytes("a"), false);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);

            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < cipherbytes.Length; i++)
            {
                sbString.Append(cipherbytes[i] + ",");
            }
            return sbString.ToString();
        }

        /// <summary>
        /// 用私钥进行解密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  string Decrypt(string input)
        {
            try
            {               
                string xmlkey = RSAPrivateKeyJava2DotNet(privateKey);
                RSACryptoServiceProvider rsa =  new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlkey);                
                byte[] arr = Convert.FromBase64String(input);                  
                byte[] plaintbytes = rsa.Decrypt(arr, false);
                string str = Encoding.Default.GetString(plaintbytes);
                return str;
                
            }
            catch (Exception e)
            {
                throw new Exception("客户数据库密码设置无效！");
            }
        }


        /// <summary>  
        /// RSA私钥格式转换，java->.net  
        /// </summary>  
        /// <param name="privateKey">java生成的RSA私钥</param>  
        /// <returns></returns>  
        public static string RSAPrivateKeyJava2DotNet(string privateKey)
        {
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>  
        /// RSA私钥格式转换，.net->java  
        /// </summary>  
        /// <param name="privateKey">.net生成的私钥</param>  
        /// <returns></returns>  
        public static string RSAPrivateKeyDotNet2Java(string privateKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(privateKey);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
            BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
            BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
            BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
            BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));

            RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);

            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
            byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
            return Convert.ToBase64String(serializedPrivateBytes);
        }

        /// <summary>  
        /// RSA公钥格式转换，java->.net  
        /// </summary>  
        /// <param name="publicKey">java生成的公钥</param>  
        /// <returns></returns>  
        public static string RSAPublicKeyJava2DotNet(string publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>  
        /// RSA公钥格式转换，.net->java  
        /// </summary>  
        /// <param name="publicKey">.net生成的公钥</param>  
        /// <returns></returns>  
        public static string RSAPublicKeyDotNet2Java(string publicKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicKey);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            RsaKeyParameters pub = new RsaKeyParameters(false, m, p);

            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pub);
            byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
            return Convert.ToBase64String(serializedPublicBytes);
        }
    }
}
