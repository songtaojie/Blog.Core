using HxCore.Common.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 用户上下文操作类
    /// </summary>
    public class UserContext : IUserContext
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
        /// 用户的名字
        /// </summary>
        public string UserName => HttpContext.User.Identity.Name;

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string NickName => GetClaimValueByType(HxCoreClaimTypes.NickName).FirstOrDefault();

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public bool IsAdmin => GetClaimValueByType<bool>(HxCoreClaimTypes.IsAdmin);
        /// <summary>
        /// 用户的id
        /// </summary>
        public string UserId => GetClaimValueByType(JwtRegisteredClaimNames.Jti).FirstOrDefault();

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
        public bool IsAuthenticated => HttpContext.User.Identity.IsAuthenticated;
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            return HttpContext.Request.Headers["Authorization"].ObjToString().Replace("Bearer ", "");
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="ClaimType"></param>
        /// <returns></returns>
        public List<string> GetUserInfoFromToken(string ClaimType)
        {

            var jwtHandler = new JwtSecurityTokenHandler();
            if (!string.IsNullOrEmpty(GetToken()))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(GetToken());

                return (from item in jwtToken.Claims
                        where item.Type == ClaimType
                        select item.Value).ToList();
            }
            else
            {
                return new List<string>() { };
            }
        }
        /// <summary>
        /// 获取claims集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return HttpContext.User.Claims;
        }
        /// <summary>
        /// 根据claim获取相应的值
        /// </summary>
        /// <param name="ClaimType"></param>
        /// <returns></returns>
        public List<string> GetClaimValueByType(string ClaimType)
        {

            return (from item in GetClaimsIdentity()
                    where item.Type == ClaimType
                    select item.Value).ToList();

        }

        public T GetClaimValueByType<T>(string ClaimType)
        {
            var claim = GetClaimValueByType(ClaimType).FirstOrDefault();
            if (claim == null) return default;
            var type = typeof(T);
            if (type == typeof(int) || type == typeof(int?))
            {
                int.TryParse(claim, out int result);
                return (T)(object)result;
            }
            else if (type == typeof(bool) || type == typeof(bool?))
            {
                bool.TryParse(claim, out bool result);
                return (T)(object)result;
            }
            else if (type == typeof(decimal) || type == typeof(decimal?))
            {
                decimal.TryParse(claim, out decimal result);
                return (T)(object)result;
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                DateTime.TryParse(claim, out DateTime result);
                return (T)(object)result;
            }
            return default;
        }
    }
}
