using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// image帮助类
    /// </summary>
    public class ImageManager
    {
        /// <summary>
        /// 根据扩展名判断是否是图片
        /// </summary>
        /// <param name="ext">文件扩展</param>
        /// <param name="hasPoint">是否包含点</param>
        /// <returns></returns>
        public static bool IsImage(string ext, bool hasPoint = true)
        {
            string[] extList = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp", ".icon" };
            ext = string.IsNullOrEmpty(ext) ? ext : ext.ToLower();
            return hasPoint ? extList.Contains(ext) : extList.Contains("." + ext);
        }

        /// <summary>
        /// 获取图片大大小
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        public static void GetImageSize(string imagePath, out int width, out int height)
        {
            using (Image<Rgba32> originalImage = Image.Load(imagePath))
            {
                width = originalImage.Width;
                height = originalImage.Height;
            }
        }

        /// <summary>
        /// 获取图片大大小
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        public static void GetImageSize(Stream stream, out int width, out int height)
        {
            using (Image<Rgba32> originalImage = Image.Load(stream))
            {
                width = originalImage.Width;
                height = originalImage.Height;
            }
        }
        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ThumbnailMode mode)
        {
            ResizeOptions options = new ResizeOptions();
            
            using (Image<Rgba32> originalImage = Image.Load(originalImagePath))
            {
                int towidth = width;
                int toheight = height;
                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;
                switch (mode)
                {
                    case ThumbnailMode.Stretch:  //指定高宽缩放（可能变形） 
                        options.Mode = ResizeMode.Stretch;
                        break;
                    case ThumbnailMode.Max:   //指定宽，高按比例   
                        options.Mode = ResizeMode.Max;
                        toheight = originalImage.Height * width / originalImage.Width;
                        break;
                    case ThumbnailMode.Min:   //指定高，宽按比例
                        options.Mode = ResizeMode.Min;
                        options.Position = AnchorPositionMode.BottomLeft;
                        towidth = originalImage.Width * height / originalImage.Height;
                        break;
                    case ThumbnailMode.BoxPad: //指定高宽裁减（不变形） 
                        options.Mode = ResizeMode.BoxPad;
                        if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                        {
                            oh = originalImage.Height;
                            ow = originalImage.Height * towidth / toheight;
                            y = 0;
                            x = (originalImage.Width - ow) / 2;
                        }
                        else
                        {
                            ow = originalImage.Width;
                            oh = originalImage.Width * height / towidth;
                            x = 0;
                            y = (originalImage.Height - oh) / 2;
                        }
                        break;
                    default:
                        options.Mode = ResizeMode.Max;
                        break;
                }
                options.Size = new Size(width, height);
                originalImage.Mutate(x => x.Resize(options));
                originalImage.Save(thumbnailPath);
            }
        }
        #endregion
    }

    /// <summary>
    /// 缩略图的模式
    /// </summary>
    public enum ThumbnailMode
    {
        /// <summary>
        /// 指定高宽缩放,拉伸（会变形） 
        /// </summary>
        Stretch,
        /// <summary>
        ///调整图像大小，直到最短的一面达到设定的给定尺寸。 
        ///在此模式下禁用升频功能，如果尝试则将返回原始图像。
        /// </summary>
        Min,
        /// <summary>
        ///约束调整大小的图像以适合其容器的边界，并保持原始宽高比。
        /// </summary>
        Max,
        /// <summary>
        ///填充图像以适合容器的边界，而无需调整原始源的大小。
        /// </summary>
        BoxPad
    }
}
