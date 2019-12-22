using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    public class UserContext: IUserContext
    {
        /// <summary>
        /// HttpContext访问器
        /// </summary>
        private IHttpContextAccessor _contextAccessor;

        public HttpContext HttpContext
        {
            get
            {
                return _contextAccessor.HttpContext;
            }
        }

        public UserContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// 获取cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public string GetCookieValue(string cookieName)
        {
            return HttpContext.Request.Cookies[cookieName];
        }

        /// <summary>
        /// 设置cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="value"></param>
        /// <param name="expires">过期时间</param>
        public void SetCookieValue(string cookieName, string value, DateTime? expires = null)
        {
            string cookieValue = GetCookieValue(cookieName);
            if (!string.IsNullOrEmpty(cookieValue)) HttpContext.Response.Cookies.Delete(cookieName);
            if (expires.HasValue)
            {
                HttpContext.Response.Cookies.Append(cookieName, value, new CookieOptions
                {
                    Expires = new DateTimeOffset(expires.Value)
                });
            }
            else
            {
                HttpContext.Response.Cookies.Append(cookieName, value);
            }
        }
        /// <summary>
        /// 是否已经验证，即是否一登录
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
