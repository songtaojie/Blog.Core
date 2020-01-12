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
            services.AddAuthorizeSetup();
            //services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            #endregion

            #region Swagger
            services.AddSwaggerSetup();
            #endregion

            #region 单例模块
            // Httpcontext 注入
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddSingleton(new WebManager(Environment));
            #endregion

            #region AutoMapper
            services.AddAutoMapperSetup();
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
            //services.AddDIServices();
            //services.AddDIRepository();
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
            app.UseStaticFiles();
            app.UseRouting();//路由中间件
            //app.UseCors("AllRequests");
            //app.UseJwtTokenAuth();
            //使用官方的认证，ConfigureServices中的AddAuthentication和AddJwtBearer缺一不可
            // 先开启认证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();
            app.UseCookiePolicy();
            //app.UseStatusCodePages();
            app.UseHttpsRedirection();
            // 短路中间件，配置Controller路由
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
