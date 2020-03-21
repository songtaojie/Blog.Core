﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 错误帮助类
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// 如果对象为null时，抛出异常
        /// </summary>
        /// <param name="value">对象信息</param>
        /// <param name="message">异常信息</param>
        public static void ThrowIfNull(object value,string message = "对象为空")
        {
            if (value == null) throw new UserFriendlyException(message);
        }

        /// <summary>
        /// 如果对象为null时，抛出异常
        /// </summary>
        /// <param name="value">对象信息</param>
        /// <param name="message">异常信息</param>
        public static void ThrowIfTrue(bool? value, string message = "服务器端异常")
        {
            if(value == true) throw new UserFriendlyException(message);
        }
    }
}
