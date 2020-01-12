using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 附件控制器
    /// </summary>
    [Route("[controller]/[action]")]
    public class AttachController : BaseApiController
    {
        private readonly WebHelper webHelper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="webHelper"></param>
        public AttachController(WebHelper webHelper)
        {
            this.webHelper = webHelper;
        }
        /// <summary>
        /// 附件上传
        /// </summary>
        /// <param name="upload">上传的文件</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public string Upload([FromForm] IFormFile file)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("uploaded ", false);
            if (file == null) return "请上传图片文件!";
            //{
            //    result.Add("error", new Dictionary<string, string>() { { "message", "请上传图片文件!" } });
            //    result.Add("message", "请上传图片文件!");
            //    return result;
            //}
            string rootPath = AppSettings.Get("File", "RootPath");
            //判断是否是图片，并获取高度和宽度
            string fileName = file.FileName;
            //判断是否是图片类型
            string fileExt = Path.GetExtension(fileName);
            if (!ImageManager.IsImage(fileExt)) return "请上传图片文件!";
            //{
            //    result.Add("error", new Dictionary<string, string>() { { "message", "请上传图片文件!" } });
            //    result.Add("message", "请上传图片文件!");
            //    return result;
            //}
            ////最大文件大小
            string maxSizeStr = AppSettings.Get("File", "MaxSize");
            long.TryParse(maxSizeStr, out long maxSize);
            if (file.Length > maxSize)
            {
                string message = string.Format("上传文件大小超过限制,最大上传[{0}]!", FileHelper.GetFileSizeDes(maxSize));
                result.Add("error", new Dictionary<string, string>() { { "message", message } });
                result.Add("message", message);
                return message;
            }
            //路径处理
            string userName = User.Identity.IsAuthenticated ? User.Identity.Name : "Anonymous";
            string dirPath = rootPath + "/article/" + userName + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month.ToString("00") + "/";
            //绝对路径
            string mapRootPath = Path.Combine(webHelper.WebRootPath, dirPath);
            FileHelper.TryCreateDirectory(mapRootPath);
            //文件名
            string guid = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond;
            //文件全路径
            //源文件
            string sourceFileName = guid + fileExt;
            string sourceFilePath = Path.Combine(mapRootPath, sourceFileName);
            using (FileStream fs = System.IO.File.Create(sourceFilePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            Task.Run(() =>
            {
                ImageManager.GetImageSize(sourceFilePath, out int imgWidth, out int imgHeight);
                //缩略图文件
                if (imgWidth >= 500 && imgHeight >= 260)
                {
                    string _268FileName = string.Format("{0}_670x268{1}", guid, fileExt);
                    string _268FilePath = Path.Combine(mapRootPath, _268FileName);
                    ImageManager.MakeThumbnail(sourceFilePath, _268FilePath, 670, 268, ThumbnailMode.Max);
                }
                if (imgWidth >= 150 && imgHeight >= 90)
                {
                    string _120FileName = string.Format("{0}_200x120{1}", guid, fileExt);
                    string _120FilePath = Path.Combine(mapRootPath, _120FileName);
                    ImageManager.MakeThumbnail(sourceFilePath, _120FilePath, 200, 120, ThumbnailMode.Max);
                }
            });
            string fullUrl = webHelper.GetFullUrl(webHelper.ToRelativePath(sourceFilePath));
            result["success"] = 1;
            result["uploaded"] = true;
            result["url"] = fullUrl;
            return fullUrl;
        }
    }
}