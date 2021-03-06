﻿using HxCore.Common;
using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.ViewModels
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginViewModel: IAutoMapper<T_UserInfo>
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

        /// <summary>
        /// 使用MarkDown编辑器
        /// </summary>
        public bool IsUseMdEdit => Helper.IsYes(UseMdEdit);

        /// <summary>
        /// 使用MarkDown编辑器
        /// </summary>
        public string UseMdEdit { get; set; } = "N";
    }
}
