using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace HxCore.Web.Common
{
    /// <summary>
    /// 运行时的帮助类
    /// </summary>
    public class RuntimeHelper
    {
        private static IEnumerable<Assembly> _allAssemblies;
        /// <summary>
        /// 获取所有的程序集
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAllAssembly()
        {
            if (_allAssemblies == null)
            {
                var list = new List<Assembly>();
                var deps = DependencyContext.Default;
                //var libs = deps.CompileLibraries.Where(lib =>!lib.Serviceable && lib.Type != "package" && !lib.Name.StartsWith("Microsoft")
                //&& !lib.Name.StartsWith("System"));//排除所有的系统程序集、Nuget下载包
                var libs = deps.CompileLibraries.Where(lib => lib.Type == "project");//只取项目程序
                foreach (var lib in libs)
                {
                    try
                    {
                        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                        list.Add(assembly);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                _allAssemblies = list;
            }
            
            return _allAssemblies;
        }

        /// <summary>
        /// 获取指定程序集名称的程序集
        /// </summary>
        /// <param name="assemblyName">程序集的全名</param>
        /// <returns></returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            return GetAllAssembly().FirstOrDefault(assembly => assembly.FullName.Contains(assemblyName));
        }
    }
}
