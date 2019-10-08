using HxCore.Model.Dependency;
using HxCore.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace WebApi.Services
{
    public static class ServicesExtension
    {
        /// <summary>
        /// 使用自带的依赖注入注入服务类
        /// </summary>
        /// <param name="services"></param>
        public static void AddDIServices(this IServiceCollection services)
        {
            DIServices(services, "HxCore.Services.dll");
        }
        /// <summary>
        /// 使用自带的依赖注入注入仓库类
        /// </summary>
        /// <param name="services"></param>
        public static void AddDIRepository(this IServiceCollection services)
        {
            DIServices(services,"HxCore.Repository.dll");
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="services">服务描述集合</param>
        /// <param name="dllName">程序集dll</param>
        private static void DIServices(IServiceCollection services,string dllName)
        {
            string basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            string servicesDllFile = Path.Combine(basePath, dllName);
            Assembly assembly = Assembly.LoadFrom(servicesDllFile);
            Type[] types = assembly.GetExportedTypes();
            foreach (Type type in types)
            {
                Type[] interTypes = type.GetInterfaces();
                if (interTypes.Length == 0) continue;
                Type interType = interTypes.FirstOrDefault(t => t.HasAttribute<SingletonDependencyAttribute>());
                if (interType != null)
                {
                    services.AddSingleton(interType, type);
                }
                else
                {
                    interType = interTypes.FirstOrDefault(t => t.HasAttribute<ScropedDependencyAttribute>());
                    if (interType != null)
                    {
                        services.AddScoped(interType, type);
                    }
                    else
                    {
                        interType = interTypes.FirstOrDefault(t => t.HasAttribute<TransientDependencyAttribute>());
                        if (interType != null)
                        {
                            services.AddTransient(interType, type);
                        }
                    }
                }
            }
        }
    }
}
