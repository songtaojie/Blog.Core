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
        /// 用户名
        /// </summary>
        public string UserName { get; }
        /// <summary>
        /// 昵称名
        /// </summary>
        public string NickName { get; }

        /// <summary>
        /// 是否是管理员
        /// </summary>
        public bool IsAdmin { get; }
        /// <summary>
        /// 用户的id
        /// </summary>
        public string UserId { get; }

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
        /// <summary>
        /// 是否已授权
        /// </summary>
        public bool IsAuthenticated { get; }
       
        /// <summary>
        /// 根据claim获取相应的值
        /// </summary>
        /// <param name="ClaimType"></param>
        /// <returns></returns>
        public List<string> GetClaimValueByType(string ClaimType);
    }
}
