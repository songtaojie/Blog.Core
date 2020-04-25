using HxCore.Common;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Web.Extensions
{
    /// <summary>
    /// 权限启动服务注册
    /// </summary>
    public static class AuthorizeSetup
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthorizeSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            Auth.JwtSettings jwtSetting = AppSettings.Get<Auth.JwtSettings>("JwtSettings");
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.SecretKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            // 1.使用基于角色的授权，仅仅在api上配置，第一步：[Authorize(Roles = "admin")]，第二步：配置统一认证服务，第三步：开启中间件
            services.AddAuthorization(c =>
            {
                c.AddPolicy(ConstInfo.AdminPolicy, policy => policy.RequireRole(ConstInfo.AdminPolicy));
                c.AddPolicy(ConstInfo.ClientPolicy, policy => policy.RequireRole(ConstInfo.ClientPolicy));
            });

            //配置认证服务

            //令牌验证参数
            TokenValidationParameters tokenParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSetting.Issuer,
                ValidAudience = jwtSetting.Audience,
                ClockSkew = TimeSpan.FromSeconds(1),
                RequireExpirationTime = true
            };
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(c =>
            {
                c.TokenValidationParameters = tokenParams;
                c.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context => {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context => 
                    {
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
