using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common.Security;
using HxCore.IServices;
using HxCore.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private IUserInfoService _userService;
        public AccountController(IUserInfoService userService)
        {
            _userService = userService;
        }
        [Route("api/login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromForm]string username, [FromForm]string password)
        {
            string jwtStr = string.Empty;
            AjaxResult result = new AjaxResult();
            string md5pwd = SafeHelper.MD5TwoEncrypt(password);
            UserInfo userInfo = await _userService.GetEntity(u => u.UserName == username && u.PassWord == md5pwd);
            if (userInfo != null)
            {
                JwtModel jwtModel = new JwtModel
                {
                    Uid = userInfo.Id,
                    //Role = "admin"
                };
                result.Resultdata = JwtHelper.IssueJwt(jwtModel);
            }
            else
            {
                result.Success = false;
                result.Message = "用户名或密码错误";
            }
            return Ok(result);
        }
    }
}