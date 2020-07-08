using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.AspNetIdentity;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Blog.IdentityServer.Data;

namespace Blog.IdentityServer
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            //var connectionString = Configuration.GetConnectionString("SqlServerConnection");
            //if (connectionString == "")
            //{
            //    throw new Exception("数据库配置异常");
            //}
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //var builder = services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseErrorEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //})
            //.AddAspNetIdentity<ApplicationUser>()
            //// 添加配置数据（客户端 和 资源）
            //.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = b =>
            //        b.UseSqlServer(connectionString,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //})
            //.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = b =>
            //        b.UseSqlServer(connectionString,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //    // 自动清理 token ，可选
            //    options.EnableTokenCleanup = true;
            //});

            //// 数据库配置系统应用用户数据上下文
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            // 启用 Identity 服务 添加指定的用户和角色类型的默认标识系统配置
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            ////.AddTestUsers(InMemoryConfig.Users().ToList())
            ////.AddInMemoryApiResources(InMemoryConfig.GetApiResources())
            ////.AddInMemoryClients(InMemoryConfig.GetClients());
            //builder.AddDeveloperSigningCredential();
            //services.AddAuthentication();

            services.AddMvc();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            // in-memory, code config
            .AddTestUsers(InMemoryConfig.Users().ToList())
            .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
            .AddInMemoryClients(InMemoryConfig.GetClients());


            builder.AddDeveloperSigningCredential();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

            services.AddAuthentication();//配置认证服务
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name:"default",pattern:"{controller=home}/{action=index}/{id?}");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
