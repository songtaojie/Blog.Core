﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Auth
{
    /// <summary>
    /// jwt的配置
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// 谁颁发的jwt
        /// </summary>
        public string Issuer
        {
            get;set;
        }

        /// <summary>
        /// 谁使用这个jwt
        /// </summary>
        public string Audience
        {
            get;set;
        }

        /// <summary>
        /// secret是保存在服务器端的，jwt的前发声明也是在服务器端的，secret就是用来进行jwt的
        /// 签发和jwt的验证，所以他就是你服务器端的私钥，在任何场景都不应该流露出去。
        /// 一旦客户端得知这个secret, 那就意味着客户端是可以自我签发jwt了
        /// 通过jwt header中声明的加密方式进行加盐secret组合加密，然后就构成了jwt的第三部分
        /// </summary>
        public string SecretKey
        {
            get;set;
        }
    }

    public class JwtModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; }
    }
}
