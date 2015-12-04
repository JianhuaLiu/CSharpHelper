//--------------------------------------------
// Copyright (C) 北京日升天信科技股份有限公司
// filename :KeyHelper
// created by 陈星宇
// at 2015/10/14 11:41:00
//--------------------------------------------
namespace CSharpHelper
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// 加密解密帮助类
    /// </summary>
    public static class KeyHelper
    {
        #region 哈希加密

        #region MD5加密

        public static byte[] MD5(this byte[] data)
        {
            return System.Security.Cryptography.MD5.Create().ComputeHash(data);
        }

        public static string MD5(this string strData)
        {
            byte[] data = Encoding.UTF8.GetBytes(strData);
            return System.Security.Cryptography.MD5.Create().ComputeHash(data).ToStringByte();
        }

        #endregion MD5加密

        #region SHA1加密

        public static byte[] SHA1(this byte[] data)
        {
            return System.Security.Cryptography.SHA1.Create().ComputeHash(data);
        }

        public static string SHA1(this string strData)
        {
            byte[] data = Encoding.Unicode.GetBytes(strData);
            return System.Security.Cryptography.SHA1.Create().ComputeHash(data).ToStringByte();
        }

        #endregion SHA1加密

        #region SHA256加密

        public static byte[] SHA256(this byte[] data)
        {
            return System.Security.Cryptography.SHA256.Create().ComputeHash(data);
        }

        public static string SHA256(this string strData)
        {
            byte[] data = Encoding.Unicode.GetBytes(strData);
            return System.Security.Cryptography.SHA256.Create().ComputeHash(data).ToStringByte();
        }

        #endregion SHA256加密

        #region SHA384

        public static byte[] SHA384(this byte[] data)
        {
            return System.Security.Cryptography.SHA384.Create().ComputeHash(data);
        }

        public static string SHA384(this string strData)
        {
            byte[] data = Encoding.Unicode.GetBytes(strData);
            return System.Security.Cryptography.SHA384.Create().ComputeHash(data).ToStringByte();
        }

        #endregion SHA384

        #region SHA512

        public static byte[] SHA512(this byte[] data)
        {
            return System.Security.Cryptography.SHA512.Create().ComputeHash(data);
        }

        public static string SHA512(this string strData)
        {
            byte[] data = Encoding.Unicode.GetBytes(strData);
            return System.Security.Cryptography.SHA512.Create().ComputeHash(data).ToStringByte();
        }

        #endregion SHA512

        #endregion 哈希加密

        #region 对称加密

        #region DES

        /// <summary>
        /// 对称加密-->DES加密
        /// </summary>
        /// <param name="data">待加密的字符数据</param>
        /// <param name="key">密钥，长度必须为64位(byte[8])</param>
        /// <param name="iv">iv向量，长度必须为64位(byte[8])</param>
        /// <returns>加密后的字符串</returns>
        public static string EnDES(this string data, byte[] key, byte[] iv)
        {
            DES des = DES.Create();//定义DES对象
            byte[] tmp = data.ToByte();//转换字节序列
            byte[] encryptoData;
            ICryptoTransform encryptor = des.CreateEncryptor(key, iv);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (var cs = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(data);
                        writer.Flush();
                    }
                }
                encryptoData = memoryStream.ToArray();
            }
            des.Clear();
            return Convert.ToBase64String(encryptoData);
        }

        /// <summary>
        /// 对称加密-->DES解密
        /// </summary>
        /// <param name="data">加密后的字符串</param>
        /// <param name="key">密钥，长度必须为64位(byte[8])</param>
        /// <param name="iv">iv向量，长度必须为64位(byte[8])</param>
        /// <returns>待加密的字符数据</returns>
        public static string DeDES(this string data, byte[] key, byte[] iv)
        {
            string resultData = string.Empty;
            byte[] tmpData = Convert.FromBase64String(data);//转换的格式
            DES des = DES.Create();
            ICryptoTransform decryptor = des.CreateDecryptor(key, iv);
            using (var memoryStream = new MemoryStream(tmpData))
            {
                using (var cs = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    StreamReader reader = new StreamReader(cs);
                    resultData = reader.ReadLine();
                }
            }
            return resultData;
        }

        #endregion DES

        #region TripleDES

        /// <summary>
        /// 对称加密-->TripleDES加密
        /// </summary>
        /// <param name="data">待加密的字符数据</param>
        /// <param name="key">密匙，长度可以为：128位(byte[16])，192位(byte[24])</param>
        /// <param name="iv">iv向量，长度必须为64位(byte[8])</param>
        /// <returns>加密后的字符串</returns>
        public static string EnTripleDES(this string data, byte[] key, byte[] iv)
        {
            byte[] tmp = null;
            byte[] tmpData = data.ToByte();
            TripleDES tripleDes = TripleDES.Create();
            ICryptoTransform encryptor = tripleDes.CreateEncryptor(key, iv);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(data);
                    writer.Flush();
                }
                tmp = ms.ToArray();
            }
            return Convert.ToBase64String(tmp);
        }

        /// <summary>
        /// 对称加密-->TripleDES解密
        /// </summary>
        /// <param name="data">加密后的字符串</param>
        /// <param name="key">密匙，长度可以为：128位(byte[16])，192位(byte[24])</param>
        /// <param name="iv">iv向量，长度必须为64位(byte[8])</param>
        /// <returns>待加密的字符数据</returns>
        public static string DeTripleDES(this string data, byte[] key, byte[] iv)
        {
            byte[] tmp = Convert.FromBase64String(data);
            string result = string.Empty;
            TripleDES tripleDES = TripleDES.Create();
            ICryptoTransform decryptor = tripleDES.CreateDecryptor(key, iv);
            using (MemoryStream ms = new MemoryStream(tmp))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    StreamReader reader = new StreamReader(cs);
                    result = reader.ReadLine();
                }
            }
            tripleDES.Clear();
            return result;
        }

        #endregion TripleDES

        #region AES

        /// <summary>
        /// 对称加密-->AES加密
        /// </summary>
        /// <param name="data">待加密的字符数据</param>
        /// <param name="key">密匙，长度可以为：128位(byte[16])，192位(byte[24])，256位(byte[32])</param>
        /// <param name="iv">iv向量，长度必须为128位（byte[16]）</param>
        /// <returns>加密后的字符</returns>
        public static string EnAES(this string data, byte[] key, byte[] iv)
        {
            Aes aes = Aes.Create();
            byte[] tmp = null;
            ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(data);
                    writer.Flush();
                    writer.Close();
                }
                tmp = ms.ToArray();
            }
            return Convert.ToBase64String(tmp);
        }

        /// <summary>
        /// 对称加密-->AES解密
        /// </summary>
        /// <param name="data">加密后的字符</param>
        /// <param name="key">密匙，长度可以为：128位(byte[16])，192位(byte[24])，256位(byte[32])</param>
        /// <param name="iv">iv向量，长度必须为128位（byte[16]）</param>
        /// <returns>待加密的字符数据</returns>
        public static string DeAES(this string data, byte[] key, byte[] iv)
        {
            string result = string.Empty;
            Aes aes = Aes.Create();
            ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    StreamReader reader = new StreamReader(cs);
                    result = reader.ReadLine();
                    reader.Close();
                }
            }
            aes.Clear();
            return result;
        }

        #endregion AES

        #region Rijndael

        /// <summary>
        /// 对称加密-->Rijndael加密
        /// </summary>
        /// <param name="data">需要加密的字符数据</param>
        /// <param name="key">密匙，长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</param>
        /// <param name="iv">iv向量，长度为128（byte[16]）</param>
        /// <returns>加密后的字符</returns>
        public static string EnRijndael(this string data, byte[] key, byte[] iv)
        {
            Rijndael rijndael = Rijndael.Create();
            byte[] tmp = null;
            ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(data);
                    writer.Flush();
                }
                tmp = ms.ToArray();
            }
            return Convert.ToBase64String(tmp);
        }

        /// <summary>
        /// Rijndael解密
        /// </summary>
        /// <param name="data">需要加密的字符数据</param>
        /// <param name="key">密匙，长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</param>
        /// <param name="iv">iv向量，长度为128（byte[16]）</param>
        /// <returns>解密后的字符</returns>
        public static string DeRijndael(this string data, byte[] key, byte[] iv)
        {
            string result = string.Empty;
            Rijndael rijndael = Rijndael.Create();
            ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    StreamReader reader = new StreamReader(cs);
                    result = reader.ReadLine();
                    reader.Close();
                }
            }
            return result;
        }

        #endregion Rijndael

        #endregion 对称加密

        #region 非对称加密

        #region RSA

        public static string EnRSA(this string data, string publickey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipher;
            rsa.FromXmlString(publickey);
            cipher = rsa.Encrypt(data.ToByte(), false);
            return Convert.ToBase64String(cipher);
        }

        public static string DeRSA(this string data, string publickey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipher;
            rsa.FromXmlString(publickey);
            cipher = rsa.Decrypt(Convert.FromBase64String(data), false);
            return Encoding.Default.GetString(cipher);
        }

        #endregion RSA

        #region DSA

        public static string EnDSA(this string data, string publickey)
        {
            DSA dsa = DSA.Create();
            Byte[] result;
            dsa.FromXmlString(publickey);
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            result = dsa.CreateSignature(sha1.ComputeHash(Convert.FromBase64String(data)));
            return Convert.ToBase64String(result);
        }

        public static bool DeDSA(this string data, string privatekey, string originalData)
        {
            //Byte[] result;
            DSA dsa = DSA.Create();
            dsa.FromXmlString(privatekey);
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            return dsa.VerifySignature(sha1.ComputeHash(Convert.FromBase64String(originalData)), Convert.FromBase64String(data));
        }

        #endregion DSA

        #region ECDsa

        public static string EnCDsa(this string data, CngKey key)
        {
            ECDsa ecdsa = new ECDsaCng(key);
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] result = ecdsa.SignHash(sha1.ComputeHash(Convert.FromBase64String(data)));
            return Convert.ToBase64String(result);
        }

        public static bool DeCDsa(this string data, CngKey key, string originalData)
        {
            ECDsaCng ecdsa = new ECDsaCng(key);
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            return ecdsa.VerifyHash(sha1.ComputeHash(Convert.FromBase64String(originalData)), Convert.FromBase64String(data));
        }

        #endregion ECDsa

        #endregion 非对称加密
    }
}