using System;
using System.Text;
using System.Threading.Tasks;
using HxCore.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using HxCore.Web.Filter;
using HxCore.Web.Services;
using HxCore.Web.Common;
using HxCore.Web.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using HxCore.Entity.Context;
using HxCore.Web.Extensions;

namespace HxCore.Web
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        
        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置</param>
        /// <param name="_env">环境</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment _env)
        {
            Configuration = configuration;
            Environment = _env;
        }
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new AppSettings(Environment));
            #region 跨域CORS
            //services.AddCors(c=> {
            //    c.AddPolicy("AllRequests", policy =>
            //    {
            //        policy.WithOrigins();
            //    });
            //});
            #endregion

            #region Authorize 权限三步走
            Auth.JwtSettings jwtSetting = Configuration.GetSection("JwtSettings").Get<Auth.JwtSettings>();
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
            //services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            #endregion

            #region Swagger
            services.AddSwaggerSetup();
            #endregion
            #region 单例模块
            // Httpcontext 注入
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserContext, UserContext>();
            
            #endregion

            #region 数据库链接，上下文
            services.AddDbSetup();
            #endregion

            #region MVC，路由配置
            services.AddControllers(c =>
            {
                c.AddFilters(typeof(ExceptionFilter), typeof(ApiResultAttribute));
                c.AddGlobalRoutePrefix(new RouteAttribute(ConstInfo.RoutePrefix));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #endregion


            #region 业务类映射
            services.AddDIServices();
            services.AddDIRepository();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                #region Swagger
                app.UseSwaggerSetup();
                #endregion
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseCors("AllRequests");
            //app.UseJwtTokenAuth();
            //使用官方的认证，ConfigureServices中的AddAuthentication和AddJwtBearer缺一不可
            app.UseAuthentication();
            app.UseCookiePolicy();
            //app.UseStatusCodePages();
            app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseRouting();//路由中间件
                             // 短路中间件，配置Controller路由
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
