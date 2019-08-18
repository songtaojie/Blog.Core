using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HxCore.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Filter;

namespace WebApi
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment _env)
        {
            Configuration = configuration;
            Environment = _env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 跨域CORS
            //services.AddCors(c=> {
            //    c.AddPolicy("AllRequests", policy =>
            //    {
            //        policy.WithOrigins();
            //    });
            //});
            #endregion

            #region Authorize 权限三步走
            // 1.使用基于角色的授权，仅仅在api上配置，第一步：[Authorize(Roles = "admin")]，第二步：配置统一认证服务，第三步：开启中间件
            //基于策略的
            services.AddAuthorization(c =>
            {
                c.AddPolicy("Admin", policy => policy.RequireRole("Admin", "System"));
            });

            //配置认证服务
            Auth.JwtSettings jwtSetting = Configuration.GetSection("JwtSettings").Get<Auth.JwtSettings>();
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.SecretKey));
            //令牌验证参数
            TokenValidationParameters tokenParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSetting.Issuer,
                ValidAudience = jwtSetting.Audience,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true
            };
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(c=> {
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
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v0.0.1",
                    Title= "API文档",
                    Description = "框架API文档",
                    TermsOfService = "None"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "HxCore",new string[]{ } }
                };
                c.AddSecurityRequirement(security);
                c.AddSecurityDefinition("HxCore", new ApiKeyScheme
                {
                    Description= "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                    Name="Authorization",//jwt默认的参数名称
                    In = "Header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
            });
            #endregion

            services.AddMvc(c=> {
                c.Filters.Add(typeof(ExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 单例模块
            services.AddSingleton(new AppSettings(Environment));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                #region Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
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
            app.UseMvc();
        }
    }
}
