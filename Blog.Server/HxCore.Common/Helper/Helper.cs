using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public class Helper
    {
        #region 字符串
        /// <summary>
        /// 比较字符串，忽略大小写
        /// </summary>
        public static bool AreEqual(string value1, string value2)
        {
            return string.Equals(value1, value2, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断当前字符串是否为Y
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsYes(string value)
        {
            return Helper.AreEqual(value, "Y");
        }

        /// <summary>
        /// 判断当前字符串是否为N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNo(string value)
        {
            return Helper.AreEqual(value, "N");
        }

        /// <summary>
        /// 转化为字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStr(object value)
        {
            if (value != null && value != DBNull.Value)
            {
                return string.Format("{0}", value);
            }
            return string.Empty;
        }

        /// <summary>
        /// 将对象转换成16进制的字符形式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHex(object value)
        {
            StringBuilder builder = new StringBuilder();
            byte[] byteList = Encoding.Unicode.GetBytes(string.Format("{0}", value));
            foreach (byte b in byteList)
            {
                builder.Append(string.Format("{0:X2}", b));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 将16进制的字符形式转换成字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromHex(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.ToUpper();
                List<byte> arrayList = new List<byte>();
                for (int index = 0; index < value.Length - 1; index += 2)
                {
                    arrayList.Add(Convert.ToByte(ToInt(value[index]) * 16 + ToInt(value[index + 1])));
                }
                return Encoding.Unicode.GetString(arrayList.ToArray());
            }
            return value;
        }
        private static int ToInt(char ch)
        {
            if (ch >= 'A') return ch - 'A' + 10;
            return ch - '0';
        }
        #endregion
        /// <summary>
        /// 获取雪花ID
        /// </summary>
        /// <returns></returns>
        public static long GetSnowId()
        {
            return Snowflake.Instance().GetId();
        }
    }
}
