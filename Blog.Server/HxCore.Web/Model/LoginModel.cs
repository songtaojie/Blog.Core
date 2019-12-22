using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Model
{
    public class LoginModel
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; } 

        /// <summary>
        /// 过期时间
        /// </summary>
        public double Expires { get; set; }

        /// <summary>
        /// token的前缀
        /// </summary>
        public string TokenType { get; set; } = "Bearer";

        /// <summary>
        /// 用户的id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户头像链接
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
