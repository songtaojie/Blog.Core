using HxCore.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Common
{
    /// <summary>
    /// web帮助类
    /// </summary>
    public class WebHelper
    {
        private readonly IWebHostEnvironment env;
        /// <summary>
        /// web帮助类
        /// </summary>
        /// <param name="env"></param>
        public WebHelper(IWebHostEnvironment env)
        {
            this.env = env;
        }
        /// <summary>
        /// web应用程序根路径
        /// </summary>
        public string WebRootPath => env.WebRootPath;

        /// <summary>
        /// web应用程序根路径
        /// </summary>
        public string ContentRootPath => env.ContentRootPath;
        /// <summary>
        /// 把绝对路径转换成相对路径
        /// </summary>
        /// <param name="imagesurl1"></param>
        /// <returns></returns>
        public string ToRelativePath(string imagesurl1)
        {
            string imagesurl2 = imagesurl1.Replace(WebRootPath, "/"); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            return imagesurl2;
        }

        /// <summary>
        /// 获取路由的全路径
        /// </summary>
        /// <param name="routeUrl"></param>
        /// <returns></returns>
        public string GetFullUrl(string routeUrl)
        {
            string host = AppSettings.Get("HxCore.Web", "Host");

            while (!string.IsNullOrEmpty(host) && host.Last() == '/')
            {
                host = host.Remove(host.Length - 1);
            }
            while (!string.IsNullOrEmpty(routeUrl) && routeUrl.First() == '/')
            {
                routeUrl = routeUrl.Substring(1);
            }
            return host + "/" + routeUrl;
        }
    }
}
