using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace speck.Frameworks.Cryptography
{
    /// <summary>
    /// 加密和解密算法
    /// </summary>
    public static class CryptionManage
    {

        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="cryptionType">解密类型</param>
        /// <param name="data">密文</param>
        /// <param name="key">密匙
        /// <para>CryptionType.AES:长度可以为：128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        /// <para>CryptionType.DES:长度必须为64位（byte[8]）)</para>
        /// <para>CryptionType.Rijndael:长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        ///  <para>CryptionType.Rijndael:长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        /// <para>CryptionType.TripleDES:长度可以为：128位(byte[16])，192位(byte[24])</para>
        /// </param>
        /// <param name="iv">iv向量
        /// <para>CryptionType.AES:长度必须为128位（byte[16]）</para>
        /// <para>CryptionType.DES:长度必须为64位（byte[8]）</para>
        /// <para>CryptionType.Rijndael:长度为128（byte[16]）</para>
        /// <para>CryptionType.Rijndael:长度为128（byte[16]）</para>
        /// <para>CryptionType.TripleDES:长度必须为64位（byte[8]）</para>
        /// </param>
        /// <returns></returns>
        public static string Descryption(CryptionType cryptionType, string data, Byte[] key, Byte[] iv)
        {
            string strRes = null;
            if (!string.IsNullOrWhiteSpace(data) && key != null && iv != null)
            {
                ICryptoTransform decryptor = null;
                Byte[] tmpData = Convert.FromBase64String(data);//转换的格式挺重要  
                switch (cryptionType)
                {
                    case CryptionType.AES:
                        var aes = Aes.Create();
                        if (aes != null)
                        {
                            decryptor = aes.CreateDecryptor(key, iv);
                            aes.Dispose();
                            aes.Clear();
                        }
                        break;
                    case CryptionType.DES:
                        var des = DES.Create();
                        decryptor = des.CreateDecryptor(key, iv);
                        des.Dispose();
                        des.Clear();
                        break;
                    case CryptionType.Md5:
                        strRes = data;
                        break;
                    case CryptionType.Rijndael:
                        var rijndael = Rijndael.Create();
                        decryptor = rijndael.CreateDecryptor(key, iv);
                        rijndael.Dispose();
                        rijndael.Clear();
                        break;
                    case CryptionType.TripleDES:
                        var tripleDes = TripleDES.Create();
                        decryptor = tripleDes.CreateDecryptor(key, iv);
                        tripleDes.Dispose();
                        tripleDes.Clear();
                        break;
                }
                if (decryptor != null)
                {
                    using (var memoryStream = new MemoryStream(tmpData))
                    {
                        using (var cs = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var reader = new StreamReader(cs);
                            strRes = reader.ReadLine();
                        }
                    }
                }
            }
            return strRes;
        }

        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="cryptionType">加密类型</param>
        /// <param name="data">密文</param>
        /// <param name="key">密匙
        /// <para>CryptionType.AES:长度可以为：128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        /// <para>CryptionType.DES:长度必须为64位（byte[8]）)</para>
        /// <para>CryptionType.Rijndael:长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        ///  <para>CryptionType.Rijndael:长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])</para>
        /// <para>CryptionType.TripleDES:长度可以为：128位(byte[16])，192位(byte[24])</para>
        /// </param>
        /// <param name="iv">iv向量
        /// <para>CryptionType.AES:长度必须为128位（byte[16]）</para>
        /// <para>CryptionType.DES:长度必须为64位（byte[8]）</para>
        /// <para>CryptionType.Rijndael:长度为128（byte[16]）</para>
        /// <para>CryptionType.Rijndael:长度为128（byte[16]）</para>
        /// <para>CryptionType.TripleDES:长度必须为64位（byte[8]）</para>
        /// </param>
        /// <returns></returns>
        public static string Encryption(CryptionType cryptionType, string data, Byte[] key, Byte[] iv)
        {
            string strRes = null;
            if (!string.IsNullOrWhiteSpace(data) && key != null && iv != null)
            {
                ICryptoTransform encryptor = null;
                switch (cryptionType)
                {
                    case CryptionType.AES://密匙，长度可以为：128位(byte[16])，192位(byte[24])，256位(byte[32])  iv向量，长度必须为128位（byte[16]）
                        var aes = Aes.Create();
                        if (aes != null)
                        {
                            encryptor = aes.CreateEncryptor(key, iv);
                            aes.Dispose();
                            aes.Clear();
                        }
                        break;
                    case CryptionType.DES://密匙，长度必须为64位（byte[8]）)   iv向量，长度必须为64位（byte[8]）
                        var des = DES.Create();
                        encryptor = des.CreateEncryptor(key, iv);
                        des.Dispose();
                        des.Clear();
                        break;
                    case CryptionType.Md5:
                        strRes = Md5(data);
                        break;
                    case CryptionType.Rijndael://密匙，长度可以为：64位(byte[8])，128位(byte[16])，192位(byte[24])，256位(byte[32])       iv向量，长度为128（byte[16]）
                        var rijndael = Rijndael.Create();
                        encryptor = rijndael.CreateEncryptor(key, iv);
                        rijndael.Dispose();
                        rijndael.Clear();
                        break;
                    case CryptionType.TripleDES://密匙，长度可以为：128位(byte[16])，192位(byte[24])   iv向量，长度必须为64位（byte[8]）
                        var tripleDes = TripleDES.Create();
                        encryptor = tripleDes.CreateEncryptor(key, iv);
                        tripleDes.Dispose();
                        tripleDes.Clear();
                        break;
                }
                if (encryptor != null)
                {
                    Byte[] encryptoData;
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var writer = new StreamWriter(cs))
                            {
                                writer.Write(data);
                                writer.Flush();
                                writer.Close();
                                writer.Dispose();
                            }
                            cs.Close();
                            cs.Dispose();
                        }
                        encryptoData = memoryStream.ToArray();
                    }
                    strRes = Convert.ToBase64String(encryptoData);
                }
            }
            return strRes;
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <returns></returns>
        private static string Md5(string data)
        {
            string strRes = null;
            if (!string.IsNullOrWhiteSpace(data))
            {
                var md5 = new MD5CryptoServiceProvider();
                strRes = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(data)), 4, 8);
            }
            return strRes;
        }
    }
}
