using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 附件控制器
    /// </summary>
    [Route("[controller]/[action]")]
    public class AttachController : BaseApiController
    {
        /// <summary>
        /// 附件上传
        /// </summary>
        /// <param name="upload">上传的文件</param>
        /// <returns></returns>
        [HttpPost]
        public Dictionary<string, object> Upload([FromForm] IFormFile upload)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("uploaded ", false);
            if (upload == null)
            {
                result.Add("error", new Dictionary<string, string>() { { "message", "请上传图片文件!" } });
                result.Add("message", "请上传图片文件!");
                return result;
            }
            string rootPath = AppSettings.Get("File", "RootPath");
            //判断是否是图片，并获取高度和宽度
            bool isImage = true;
            int imgWidth = 0, imgHeight = 0;
            //判断是否是图片类型
            List<string> imgtypelist = new List<string> { "image/pjpeg", "image/png", "image/x-png", "image/gif", "image/bmp" };
            if (imgtypelist.FindIndex(x => x == upload.ContentType) == -1)
            {
                result.Add("error", new Dictionary<string, string>() { { "message", "请上传图片文件!" } });
                result.Add("message", "请上传图片文件!");
                return result;
            }
            try
            {
                Image image = Image.FromStream(imgFile.InputStream);
                imgWidth = image.Width;
                imgHeight = image.Height;
            }
            catch
            {
                isImage = false;
            }

            if (!isImage)
            {
               
                return Json(result);
            }
            return "";
            //HttpPostedFileBase imgFile = Request.Files["upload"];
            //string rootPath = WebHelper.GetAppSettingValue(ConstInfo.UploadPath);
            //Dictionary<string, object> result = new Dictionary<string, object>();
            //result.Add("uploaded ", false);
            ////定义允许上传的文件扩展名
            ////Hashtable extTable = new Hashtable();
            ////extTable.Add("image", "gif,jpg,jpeg,png,bmp");

            //////最大文件大小
            ////int maxSize = 1000000;
            //if (imgFile == null)
            //{
            //    result.Add("error", new Dictionary<string, string>() { { "message", "请上传文件!" } });
            //    result.Add("message", "请上传文件!");
            //    return Json(result);
            //}
            
            //string fileName = imgFile.FileName;
            //long fileLength = imgFile.InputStream.Length;

            //long max = WebHelper.GetAppSettingValue(ConstInfo.maxLength, 5242880);
            //if (fileLength > max)
            //{
            //    result.Add("error", new Dictionary<string, string>() { { "message", string.Format("上传文件大小超过限制,最大上传[{0}]!", FileHelper.GetFileSizeDes(fileLength)) } });
            //    return Json(result);
            //}
            ////路径处理
            //string fileExt = Path.GetExtension(fileName).ToLower();
            //string dirPath = rootPath + "/article/" + UserContext.LoginUser.UserName + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month.ToString("00") + "/";
            ////绝对路径
            //string mapPath = Server.MapPath(dirPath);
            //FileHelper.TryCreateDirectory(mapPath);
            ////文件名
            //string guid = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond;
            ////文件全路径
            ////源文件
            //string sourceFileName = guid + fileExt;
            //string sourceFilePath = Path.Combine(mapPath, sourceFileName);
            //imgFile.SaveAs(sourceFilePath);
            //Task.Run(() => {
            //    //缩略图文件
            //    if (imgWidth >= 500 && imgHeight >= 260)
            //    {
            //        string _268FileName = string.Format("{0}_670x268{1}", guid, fileExt);
            //        string _268FilePath = Path.Combine(mapPath, _268FileName);
            //        ImageManager.MakeThumbnail(sourceFilePath, _268FilePath, 670, 268, ThumbnailMode.H);
            //    }
            //    if (imgWidth >= 150 && imgHeight >= 90)
            //    {
            //        string _120FileName = string.Format("{0}_200x120{1}", guid, fileExt);
            //        string _120FilePath = Path.Combine(mapPath, _120FileName);
            //        ImageManager.MakeThumbnail(sourceFilePath, _120FilePath, 200, 120, ThumbnailMode.H);
            //    }

            //});
            ////string letter = Request.Url.Scheme + ":" + Request.Url.Authority + "/" + UserContext.LoginUser.UserName;
            ////加水印
            ////ImageManager.LetterWatermark(newFilePath, 16, letter, System.Drawing.Color.WhiteSmoke, WaterLocation.RB);
            //result["success"] = 1;
            //result["uploaded"] = true;
            //result["url"] = WebHelper.GetFullUrl(WebHelper.ToRelativePath(sourceFilePath));
            //return Json(result);
        }
    }
}