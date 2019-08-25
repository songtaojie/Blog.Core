using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.Auth;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login([FromForm]string username, [FromForm]string password)
        {
            string jwtStr = string.Empty;
            AjaxResult result = new AjaxResult();
            if (username == "Admin" && password == "123456")
            {
                JwtModel jwtModel = new JwtModel
                {
                    Uid = 3100,
                    Role = "admin"
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