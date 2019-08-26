using Microsoft.AspNetCore.Builder;

namespace WebApi.Middlewares
{
    public static class MiddleWareExtension
    {
        public static void UseJwtTokenAuth(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtTokenAuth>();
        }
    }
}
