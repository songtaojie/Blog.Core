using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 用户友好的异常提示
    /// </summary>
    public class UserFriendlyException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public UserFriendlyException(string message)
       : base(message)
        {
        }
    }
    /// <summary>
    /// 没有被授权的异常
    /// </summary>
    public class NoAuthorizeException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public NoAuthorizeException(string message)
        : base(message)
        {
        }
    }
    /// <summary>
    /// 没有发现文件的异常
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message)
       : base(message)
        {
        }
    }
}
