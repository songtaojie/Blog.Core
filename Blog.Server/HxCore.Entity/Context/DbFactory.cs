using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Entity.Context
{
    public class DbFactory
    {
        public DbFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        private static IServiceProvider ServiceProvider
        {
            get;set;
        }
        /// <summary>
        /// 获取ef上下文
        /// </summary>
        /// <returns></returns>
        public static DbContext GetDbContext()
        {
            HxContext context = ServiceProvider.GetRequiredService<HxContext>();
            return context;
        }

        /// <summary>
        /// 获取使用原生的DI注入的服务类(一般不不用这个，而是使用构造函数注入)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }

        /// <summary>
        /// 保存改变
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SaveChangeAsync()
        {
            DbContext context = GetDbContext();
            int result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
