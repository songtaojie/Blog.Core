using HxCore.Common;
using HxCore.Web.SwaggerHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Extensions
{
    /// <summary>
    /// Swagger 启动服务
    /// </summary>
    public static class SwaggerSetup
    {
        /// <summary>
        /// 添加Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var basePath = AppContext.BaseDirectory;
            //var basePath2 = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            var ApiName = AppSettings.Get("Startup", "OpenApiName");

            services.AddSwaggerGen(c =>
            {
                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Version = version,
                        Title = $"{ApiName} 接口文档——Netcore 3.1",
                        Description = $"{ApiName} HTTP API " + version,
                        Contact = new OpenApiContact { Name = ApiName, Email = "stjworkemail@163.com", Url = new Uri("https://github.com/songtaojie") },
                        License = new OpenApiLicense { Name = ApiName, Url = new Uri("https://github.com/songtaojie") }
                    });
                    c.OrderActionsBy(o => o.RelativePath);
                });


                try
                {
                    //就是这里
                    var xmlPath = Path.Combine(basePath, "HxCore.Web.xml");//这个就是刚刚配置的xml文件名
                    c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                    var xmlEntityPath = Path.Combine(basePath, "HxCore.Entity.xml");//这个就是Model层的xml文件名
                    c.IncludeXmlComments(xmlEntityPath);

                    var xmlModelPath = Path.Combine(basePath, "HxCore.Model.xml");//这个就是Model层的xml文件名
                    c.IncludeXmlComments(xmlModelPath);
                }
                catch (Exception ex)
                {
                    //log.Error("HxCore.Web.xml和HxCore.Entity.xml 丢失，请检查并拷贝。\n" + ex.Message);
                }

                // 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();


                // 必须是 oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }
        /// <summary>
        /// 使用Swagger进行api文档的展示
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                var ApiName = AppSettings.Get("Startup", "OpenApiName");
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                    c.RoutePrefix = "";//路径配置，设置为空，表示直接访问该文件，
                    //路径配置，设置为空，表示直接在根域名（http://localhost:52909）访问该文件,注意http://localhost:52909/swagger是访问不到的，
                    //这个时候去launchSettings.json中把"launchUrl": "swagger/index.html"去掉， 然后直接访问http://localhost:52909/index.html即可
                });
            });
        }
    }
}
