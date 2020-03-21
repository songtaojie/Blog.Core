using System;
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
using AutoMapper;

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
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        public AccountController(IUserInfoService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="param">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LoginViewModel> Login([FromForm] LoginParam param)
        {
            string md5pwd = SafeHelper.MD5TwoEncrypt(param.PassWord);
            UserInfo userInfo = await _userService.FindEntity(u => u.UserName == param.UserName && u.PassWord == md5pwd);
            if (userInfo == null) throw new UserFriendlyException("用户名或密码错误");
            
            JwtModel jwtModel = new JwtModel
            {
                IsAdmin = userInfo.IsAdmin,
                UserId = userInfo.Id,
                NickName = userInfo.NickName,
                UserName = userInfo.UserName,
                Expiration = TimeSpan.FromSeconds(60*60),
                Role = userInfo.IsAdmin ? string.Join(",", ConstInfo.ClientPolicy, ConstInfo.AdminPolicy)
               : ConstInfo.ClientPolicy
            };
            var result=JwtHelper.BuildJwtToken(jwtModel);
            result.NickName = userInfo.NickName;
            result.AvatarUrl = userInfo.AvatarUrl;
            result.UseMdEdit = userInfo.UseMdEdit;
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="token">旧的token</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LoginViewModel> RefreshToken([FromForm]string token)
        {
            if (string.IsNullOrEmpty(token)) throw new  NoAuthorizeException("token无效，请重新登录！");
            var tokenModel = JwtHelper.SerializeJwt(token);
            UserInfo userInfo = await _userService.FindEntityById(tokenModel.UserId);
            if (userInfo == null) throw new NoAuthorizeException("token无效，请重新登录！");
            JwtModel jwtModel = new JwtModel
            {
                IsAdmin = userInfo.IsAdmin,
                UserId = userInfo.Id,
                NickName = userInfo.NickName,
                UserName = userInfo.UserName,
                Expiration = TimeSpan.FromSeconds(60*60),
                Role = userInfo.IsAdmin ? string.Join(",", ConstInfo.ClientPolicy, ConstInfo.AdminPolicy)
               : ConstInfo.ClientPolicy
            };
            var result = JwtHelper.BuildJwtToken(jwtModel);
            result.NickName = userInfo.NickName;
            result.AvatarUrl = userInfo.AvatarUrl;
            result.UseMdEdit = userInfo.UseMdEdit;
            return result;
        }
    }
}