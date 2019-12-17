using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common.Security;
using HxCore.IServices;
using HxCore.Model;
using Microsoft.AspNetCore.Mvc;
using HxCore.Web.Auth;
using HxCore.Web.Model;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 账户相关的控制器类
    /// </summary>
    [ApiController]
    public class AccountController : Controller
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
        [Route("api/login")]
        [HttpPost]
        public async Task<UserModel> Login([FromForm] UserParam param)
        {
            string md5pwd = SafeHelper.MD5TwoEncrypt(param.PassWord);
            UserInfo userInfo = await _userService.QueryEntity(u => u.UserName == param.UserName && u.PassWord == md5pwd);
            if (userInfo == null) throw new UserFriendlyException("用户名或密码错误");
            JwtModel jwtModel = new JwtModel
            {
                Uid = userInfo.Id,
                //Role = "admin"
            };
            string jwtStr= JwtHelper.IssueJwt(jwtModel);

            return new UserModel
            { 
                Token = jwtStr,
                UserId = userInfo.HexId,
                UserName =userInfo.UserName,
                NickName =userInfo.NickName,
                AvatarUrl =userInfo.AvatarUrl,
            };
        }
    }
}