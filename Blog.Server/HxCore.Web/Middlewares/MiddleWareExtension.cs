using HxCore.Web.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace HxCore.Web.Middlewares
{
    /// <summary>
    /// 中间件扩展
    /// </summary>
    public static class MiddleWareExtension
    {
        /// <summary>
        /// 使用jwt授权
        /// </summary>
        /// <param name="app"></param>
        public static void UseJwtTokenAuth(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtTokenAuth>();
        }
        #region 路由相关
        /// <summary>
        /// 使用全局路由前缀设置
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="routeAttribute"></param>
        public static void AddGlobalRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            // 添加我们自定义 实现IApplicationModelConvention的GlobalRouteConvention
            opts.Conventions.Insert(0, new GlobalRouteConvention(routeAttribute));
        }

        /// <summary>
        /// 使用过滤器
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="routeAttribute"></param>
        public static void AddFilters(this MvcOptions opts, params Type[] types)
        {
            if (types != null && types.Length > 0)
            {
                foreach (Type type in types)
                {
                    opts.Filters.Add(type);
                }
            }
        }
        #endregion
    }
}
