using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 根据字节大小获取文件的大小描述
        /// </summary>
        /// <param name="Size"></param>
        /// <returns></returns>
        public static string GetFileSizeDes(long Size)
        {
            string strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                strSize = (FactSize / 1024.00).ToString("F2") + " K";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " M";
            else if (FactSize >= 1073741824)
                strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " G";
            return strSize;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void TryCreateDirectory(string path)
        {
            if (ExistDirectory(path))
                return;
            Directory.CreateDirectory(path);
        }
        /// <summary>
        /// 判断是否存在文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistDirectory(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 读取文件的文本
        /// </summary>
        /// <param name="fileFullPath">文件路径</param>
        /// <returns></returns>
        public static string GetString(string fileFullPath)
        {
            return GetString(fileFullPath, Encoding.UTF8);
        }
        /// <summary>
        /// 使用指定的编码读取文件的文本
        /// </summary>
        /// <param name="fileFullPath">文件路径</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string GetString(string fileFullPath, Encoding encoding)
        {
            if (!File.Exists(fileFullPath))
                throw new DirectoryNotFoundException("找不到文件!");
            return File.ReadAllText(fileFullPath, encoding);
        }
        /// <summary>
        /// 读取文件的字节数组
        /// </summary>
        /// <param name="fileFullPath">文件的全路径</param>
        /// <returns></returns>
        public static byte[] GetFile(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
                throw new DirectoryNotFoundException("找不到文件!");
            using (FileStream fileStream = new FileStream(fileFullPath, FileMode.Open))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                return buffer;
            }
        }
    }
}
