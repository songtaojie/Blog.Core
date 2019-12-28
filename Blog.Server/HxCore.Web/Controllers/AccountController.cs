﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common.Security;
using HxCore.IServices;
using HxCore.Model;
using Microsoft.AspNetCore.Mvc;
using HxCore.Web.Auth;
using HxCore.Web.Common;
using HxCore.Common;
using HxCore.Model.ViewModels;
using HxCore.Entity;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 账户相关的控制器类
    /// </summary>
    [Route("[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 用户服务类
        /// </summary>
        private IUserInfoService _userService;
        public AccountController(IUserInfoService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LoginViewModel> Login([FromForm] LoginParam param)
        {
            string md5pwd = SafeHelper.MD5TwoEncrypt(param.PassWord);
            UserInfo userInfo = await _userService.QueryEntity(u => u.UserName == param.UserName && u.PassWord == md5pwd);
            if (userInfo == null) throw new UserFriendlyException("用户名或密码错误");
            JwtModel jwtModel = new JwtModel
            {
                UserHexId = userInfo.Id,
                UserName = userInfo.UserName,
                Expiration = TimeSpan.FromSeconds(60),
                Role = userInfo.IsAdmin ? string.Join(",", ConstInfo.ClientPolicy, ConstInfo.AdminPolicy)
               : ConstInfo.ClientPolicy
            };
            var result=JwtHelper.BuildJwtToken(jwtModel);
            result.NickName = userInfo.NickName;
            result.AvatarUrl = userInfo.AvatarUrl;
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LoginViewModel> RefreshToken([FromForm]string token)
        {
            if (string.IsNullOrEmpty(token)) throw new  NoAuthorizeException("token无效，请重新登录！");
            var tokenModel = JwtHelper.SerializeJwt(token);
            long userId = Convert.ToInt64(Helper.FromHex(tokenModel.UserHexId));
            UserInfo userInfo = await _userService.QueryEntityById(userId);
            if (userInfo == null) throw new NoAuthorizeException("token无效，请重新登录！");
            JwtModel jwtModel = new JwtModel
            {
                UserHexId = userInfo.Id,
                UserName = userInfo.UserName,
                Expiration = TimeSpan.FromSeconds(60),
                Role = userInfo.IsAdmin ? string.Join(",", ConstInfo.ClientPolicy, ConstInfo.AdminPolicy)
               : ConstInfo.ClientPolicy
            };
            var result = JwtHelper.BuildJwtToken(jwtModel);
            result.NickName = userInfo.NickName;
            result.AvatarUrl = userInfo.AvatarUrl;
            return result;
        }
    }
}