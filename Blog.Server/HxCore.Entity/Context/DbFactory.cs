using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Entity.Context
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public class DbFactory:IDbFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">HttpContext</param>
        public DbFactory(IServiceProvider service)
        {
            ServiceProvider = service;
        }
        /// <summary>
        /// 当前请求的ServiceProvider实例
        /// </summary>
        public IServiceProvider ServiceProvider
        {
            get;set;
        }
        /// <summary>
        /// 获取ef上下文
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            HxContext context = GetRequiredService<HxContext>();
            return context;
        }

        /// <summary>
        /// 获取使用原生的DI注入的服务类(一般不不用这个，而是使用构造函数注入)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
