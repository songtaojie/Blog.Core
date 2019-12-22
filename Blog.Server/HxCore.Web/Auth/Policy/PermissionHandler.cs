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
            //从AuthorizationHandlerContext转成HttpContext，以便取出表求信息
            AuthorizationFilterContext filterContext = context.Resource as AuthorizationFilterContext;
            HttpContext httpContext = filterContext.HttpContext;
            AuthenticateResult result = await httpContext.AuthenticateAsync(Schemes.GetDefaultAuthenticateSchemeAsync().Result.Name);
            //如果没登录result.Succeeded为false
            if (result.Succeeded)
            {
                httpContext.User = result.Principal;
                //当前访问的Controller
                string controllerName = filterContext.RouteData.Values["Controller"].ToString();//通过ActionContext类的RouteData属性获取Controller的名称：Home
                //当前访问的Action
                string actionName = filterContext.RouteData.Values["Action"].ToString();//通过ActionContext类的RouteData属性获取Action的名称：Index
                string name = httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Name)?.Value;
                //if (lst.Where(w => w.controllerName == controllerName && w.actionName == actionName).Count() > 0)
                //{
                //    //如果在配置的权限表里正常走
                //    context.Succeed(requirement);
                //}
                //else
                //{
                //    //不在权限配置表里 做错误提示
                //    //如果是AJAX请求 (包含了VUE等 的ajax)
                //    string requestType = filterContext.HttpContext.Request.Headers["X-Requested-With"];
                //    if (!string.IsNullOrEmpty(requestType) && requestType.Equals("XMLHttpRequest", StringComparison.CurrentCultureIgnoreCase))
                //    {
                //        //ajax 的错误返回
                //        //filterContext.Result = new StatusCodeResult(499); //自定义错误号 ajax请求错误 可以用来错没有权限判断 也可以不写 用默认的
                //        context.Fail();
                //    }
                //    else
                //    {
                //        //普通页面错误提示 就是跳转一个页面
                //        //httpContext.Response.Redirect("/Home/visitDeny");//第一种方式跳转
                //        filterContext.Result = new RedirectToActionResult("visitDeny", "Home", null);//第二种方式跳转
                //        context.Fail();
                //    }
                //}
                context.Succeed(requirement);
            }
            else
            {
                var questUrl = httpContext.Request.Path.Value.ToLower();
                if (!Helper.AreEqual(questUrl, requirement.LoginPath) &&
                    (!httpContext.Request.Method.Equals("POST") ||
                    !httpContext.Request.HasFormContentType))
                {
                    //string  _userContext.GetCookieValue(ConstInfo.CookieName);
                }
                else
                { 
                    
                }
                context.Fail();
            }
        }
    }
}
