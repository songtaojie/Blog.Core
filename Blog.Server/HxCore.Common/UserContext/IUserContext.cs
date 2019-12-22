using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    public interface IUserContext
    {
        /// <summary>
        /// Http上下文
        /// </summary>
        HttpContext HttpContext { get; }
        /// <summary>
        /// 设置cookie的值
        /// </summary>
        /// <param name="cookieName">cookie的名称</param>
        /// <param name="value">cookie的值</param>
        /// <param name="expires">过期时间</param>
        void SetCookieValue(string cookieName, string value, DateTime? expires = null);
        /// <summary>
        /// 获取cookie的值
        /// </summary>
        /// <param name="cookieName">cookie的键</param>
        /// <returns></returns>
        string GetCookieValue(string cookieName);
    }
}
