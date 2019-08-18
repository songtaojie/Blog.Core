using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Auth;

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
