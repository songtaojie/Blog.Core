using AutoMapper;
using HxCore.Web.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Extensions
{
    /// <summary>
    /// autoMapper启动类
    /// </summary>
    public static class AutoMapperSetup
    {
        /// <summary>
        /// 添加数据库上下文
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(MyMapperProfile));
            //AutoMapperConfig.RegisterMappings();
        }
    }
}
