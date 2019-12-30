using AutoMapper;
using HxCore.Entity.Dependency;
using HxCore.Web.Common;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using HxCore.Common.Extensions;

namespace HxCore.Web.AutoMapper
{
    /// <summary>
    /// automapper配置文件
    /// </summary>
    public class MyMapperProfile: Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MyMapperProfile()
        {
            Assembly assembly =  RuntimeHelper.GetAssembly("HxCore.Model");
            Type baseType = typeof(IAutoMapper<>);
            if (assembly != null)
            {
                try
                {
                    var types = assembly.GetExportedTypes().Where(t => t.IsClass && !t.IsAbstract);
                    foreach (Type sourceType in types)
                    {
                        var genericTypes = sourceType.GetGenericInterfaces(baseType);
                        if (genericTypes != null && genericTypes.Count() > 0)
                        {
                            foreach (Type t in genericTypes)
                            {
                                Type destType = t.GetGenericElementType();
                                if (destType.IsClass)
                                {
                                    CreateMap(sourceType, destType);
                                    CreateMap(destType, sourceType);
                                }
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }
    }

    /// <summary>
    /// 静态全局 AutoMapper 配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyMapperProfile>();
            });
        }
    }
}
