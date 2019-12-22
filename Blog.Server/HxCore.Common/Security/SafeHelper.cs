using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HxCore.Common.Security
{
    /// <summary>
    /// 一些加密解密的操作类
    /// </summary>
    public class SafeHelper
    {
        #region Des加解密
        private static string EncryptKey = "60WE4U(7";
        /// <summary>
        /// 使用内置的秘钥进行加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的文本</param>
        /// <returns></returns>
        public static string DESEncrypt(string pToEncrypt)
        {
            return DESEncrypt(pToEncrypt, EncryptKey);
        }
        /// <summary>
        /// 使用内置的秘钥进行DES解密
        /// </summary>
        /// <param name="pToEncrypt">要解密的字符串</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DESDecrypt(string pToEncrypt)
        {
            return DESDecrypt(pToEncrypt, EncryptKey);
        }
        /// <summary>
        /// 进行DES加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <param name="sKey">密钥，必须为8位</param>
        /// <returns>以Base64格式返回的加密字符串</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            sKey = GetKey(sKey, 8);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        /// <summary>
        /// 进行DES解密
        /// </summary>
        /// <param name="pToDecrypt">要解密的字符串</param>
        /// <param name="sKey">密钥，必须为8位</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            sKey = GetKey(sKey, 8);
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        private static string GetKey(string sKey, int length)
        {
            if (sKey.Length > length)
                sKey = sKey.Substring(0, length);
            else if (sKey.Length < length)
                sKey = sKey.PadRight(length, ' ');
            return sKey;
        }
        #endregion
        /// <summary>
        /// 使用MD5对字符串进行加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <returns>已经加密的字符串</returns>
        public static string MD5Encrypt(string pToEncrypt)
        {
            return Md5Encrypt32(pToEncrypt);
        }
        /// <summary>
        /// 使用MD5对字符串进行两次加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <returns>已经加密的字符串</returns>
        public static string MD5TwoEncrypt(string pToEncrypt)
        {
            return Md5Encrypt32(Md5Encrypt32(pToEncrypt));
        }
        #region MD5加密

        // DES全称为Data Encryption Standard，即数据加密标准。
        // 1997年数据加密标准DES正式公布，其分组长度为64比特，密钥长度为64比特，
        // 其中8比特为奇偶校验位，所以实际长度为56比特。现在DES已经被AES所取代。
        /// <summary>
        /// string的扩展方法，使用DES进行加密(使用内置的秘钥)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DES3Encrypt(string data)
        {
            return DES3Encrypt(data, EncryptKey);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">必须16位的秘钥</param>
        /// <returns></returns>
        public static string DES3Encrypt(string data, string key)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(data);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// string的扩展方法，使用DES进行解密(使用内置的秘钥)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DES3Decrypt(string data)
        {
            return DES3Decrypt(data, EncryptKey);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DES3Decrypt(string data, string key)
        {
            byte[] inputArray = Convert.FromBase64String(data);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        /// <summary>
        /// 32位的MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Md5Encrypt32(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            byte[] bytes;
            using (var md5 = MD5.Create())
            {
                bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
            var result = new StringBuilder();
            foreach (byte t in bytes)
            {
                result.Append(t.ToString("X2"));
            }
            return result.ToString();
        }
        /// <summary>
        /// 64位的MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Encrypt64(string value)
        {
            string str = value;
            //string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(s);
        }


        #endregion
    }
}
