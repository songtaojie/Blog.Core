using HxCore.Common;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HxCore.Web.Auth
{
    /// <summary>
    /// 权限授权处理器
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// 验证方案提供对象
        /// </summary>
        public IAuthenticationSchemeProvider Schemes { get; set; }
        private IUserContext _userContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="schemes"></param>
        /// <param name="roleModulePermissionServices"></param>
        public PermissionHandler(IAuthenticationSchemeProvider schemes,IUserContext userContext)
        {
            Schemes = schemes;
            _userContext = userContext;
        }

        // 重载异步处理程序
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // 将最新的角色和接口列表更新
            //从AuthorizationHandlerContext转成HttpContext，以便取出表求信息
            AuthorizationFilterContext filterContext = context.Resource as AuthorizationFilterContext;
            HttpContext httpContext = filterContext.HttpContext;
            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
                //如果没登录result.Succeeded为false
                if (result.Succeeded)
                {
                    httpContext.User = result.Principal;
                    //当前访问的Controller
                    string controllerName = filterContext.RouteData.Values["Controller"].ToString();//通过ActionContext类的RouteData属性获取Controller的名称：Home
                                                                                                    //当前访问的Action
                    string actionName = filterContext.RouteData.Values["Action"].ToString();//通过ActionContext类的RouteData属性获取Action的名称：Index
                    string name = httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Name)?.Value;
                    // 获取当前用户的角色信息
                    var currentUserRoles = (from item in httpContext.User.Claims
                                            where item.Type == requirement.ClaimType
                                            select item.Value).ToList();

                    var permisssionRoles = requirement.Roles.Where(r => currentUserRoles.Contains(r));
                    if (permisssionRoles.Any())
                    {
                        context.Succeed(requirement);
                        return;
                    }
                }
                //else
                //{
                //    var questUrl = httpContext.Request.Path.Value.ToLower();
                //    if (!Helper.AreEqual(questUrl, requirement.LoginPath) &&
                //        (!httpContext.Request.Method.Equals("POST") ||
                //        !httpContext.Request.HasFormContentType))
                //    {
                //        //string  _userContext.GetCookieValue(ConstInfo.CookieName);
                //    }
                //    else
                //    {

                //    }
                //    context.Fail();
                //}
            }
            context.Fail();
        }
    }
}
