using HxCore.Common.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HxCore.Common
{
    public class WebManager
    {
        private readonly IHostEnvironment env;
        /// <summary>
        /// web帮助类
        /// </summary>
        /// <param name="env"></param>
        public WebManager(IHostEnvironment env)
        {
            this.env = env;
            var propInfo = env.GetType().GetProperty("WebRootPath");
            if (propInfo == null)
            {
                WebRootPath = Path.Combine(env.ContentRootPath, "wwwroot");
            }
            else
            {
                WebRootPath = propInfo.GetValue(env).ObjToString();
            }
        }
        /// <summary>
        /// web应用程序根路径
        /// </summary>
        public string WebRootPath { get; }

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
        /// 把相对路径转换成绝对路径
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public string ToAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return relativePath;
            if (relativePath.First() == '/')
            {
                relativePath = relativePath.Substring(1);
            }
            return Path.Combine(WebRootPath, relativePath);
        }

        /// <summary>
        /// 获取路由的全路径
        /// </summary>
        /// <param name="routeUrl"></param>
        /// <returns></returns>
        public string GetFullUrl(string routeUrl)
        {
            if (string.IsNullOrEmpty(routeUrl)) return routeUrl;
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

        /// <summary>
        /// 获取头像的url
        /// </summary>
        /// <param name="type">0：代表32*32,1代表80*80,2代表160*160</param>
        /// <returns></returns>
        public string GetAvatarUrl(string userAvatarUrl,bool thumb = true)
        {
            string avatarUrl = string.Empty;
            if (!string.IsNullOrEmpty(userAvatarUrl))
            {
                avatarUrl = userAvatarUrl;
                if (!thumb)
                {
                    int index = avatarUrl.LastIndexOf("32x32");
                    if (index >= 0)
                    {
                        string newUrl = avatarUrl.Substring(0, index);
                        newUrl = newUrl + "160x160.png";

                        string fullPath = ToAbsolutePath(newUrl);
                        if (File.Exists(fullPath))
                            avatarUrl = newUrl;
                    }
                }
            }
            if (string.IsNullOrEmpty(avatarUrl)) avatarUrl = "/images/avatar.png";
            return GetFullUrl(avatarUrl);
        }
    }

    public static class WebHelper
    {

        #region Html
        /// <summary>
        ///从html文本中获取图片链接
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetHtmlImageUrlList(string sHtmlText)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(sHtmlText)) return result;
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);

            // 取得匹配项列表   
            foreach (Match match in matches)
            {
                result.Add(match.Groups["imgUrl"].Value);
            }
            return result;
        }

        /// <summary>
        /// 过滤html中的p标签
        /// </summary>
        /// <param name="html">html字符串</param>
        /// <param name="maxSize">返回的字符串最大长度为多少</param>
        /// <param name="onlyText">是否只返回纯文本，还是返回带有标签的</param>
        /// <returns></returns>
        public static string FilterHtml(string html, int maxSize, bool onlyText = true)
        {
            if (string.IsNullOrEmpty(html)) return "";

            //删除脚本
            html =Regex.Replace(html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            html = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"-->", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<!--.*", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            html.Replace("<", "");
            html.Replace(">", "");
            html.Replace("\r\n", "");

            //Regex rReg = new Regex(@"<P>[\s\S]*?</P>", RegexOptions.IgnoreCase);
            //var matchs = Regex.Matches(html, @"<P>[\s\S]*?</P>", RegexOptions.IgnoreCase);
            //StringBuilder sb = new StringBuilder();
            //foreach (Match match in matchs)
            //{
            //    string pContent = match.Value;
            //    if (onlyText)
            //    {
            //        pContent = Regex.Replace(pContent, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //        pContent = Regex.Replace(pContent, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            //    }
            //    sb.Append(pContent);
            //}
            //string result = sb.ToString();
            if (html.Length < maxSize) return html;
            return html.Substring(0, maxSize);
        }
        #endregion
    }
}
