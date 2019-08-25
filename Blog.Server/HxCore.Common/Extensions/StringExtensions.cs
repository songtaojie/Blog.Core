using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 字符串转为bool值
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns>如果转换成功，返回转换后的值，否则返回null</returns>
        public static bool? ToBool(this string value)
        {
            bool? result = null;
            bool.TryParse(value, out bool r);
            result = r;
            return result;
        }
    }
}
