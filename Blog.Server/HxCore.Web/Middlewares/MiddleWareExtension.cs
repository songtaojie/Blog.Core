using Microsoft.AspNetCore.Builder;

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
    }
}
