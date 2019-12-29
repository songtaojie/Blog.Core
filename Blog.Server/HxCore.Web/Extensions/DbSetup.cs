using HxCore.Entity.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Extensions
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public static class DbSetup
    {
        /// <summary>
        /// 添加数据库上下文
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddDbContext<HxContext>();
            services.AddScoped<IDbSession,DbSession>();
            services.AddDIServices();
            services.AddDIRepository();
        }
    }
}
