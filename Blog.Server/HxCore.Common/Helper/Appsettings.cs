using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    
    /// <summary>
    /// 读取appsettings.json中的配置的类
    /// </summary>
    public class AppSettings
    {
        static IConfiguration Configuration { get; set; }
        static string ContentPath { get; set; }
        /// <summary>
        /// appsettings.json
        /// </summary>
        static string Path = "appsettings.json";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="env">环境对象</param>
        public AppSettings(IHostingEnvironment env)
        {
            ContentPath = env.ContentRootPath;
            //可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ContentPath)
                .Add(new JsonConfigurationSource() {Path=Path,ReloadOnChange=true,Optional =false })
                .Build();
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">配置节点</param>
        /// <returns></returns>
        public static string Get(params string[] sections)
        {
            try
            {
                string section = string.Join(':', sections);
                return Configuration[section];
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <typeparam name="T">要映射的类</typeparam>
        /// <param name="section">配置节点</param>
        /// <returns></returns>
        public static T Get<T>(string section)
            where T:class,new()
        {
            T config = new T();
            try
            {
                config = Configuration.GetSection(section).Get<T>();
            }
            catch (Exception)
            {
            }
            return config;
        }
    }
}
