using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Common
{
    /// <summary>
    /// 常量
    /// </summary>
    public class ConstInfo
    {
        /// <summary>
        /// cookie中存储的名字
        /// </summary>
        public const string CookieName = "mUSQAcsBu";
        /// <summary>
        /// 缓存中存储的名字
        /// </summary>

        public const string CacheKeyCookieName = "0uM9eFqf";
        /// <summary>
        /// 用来模拟session的标志
        /// </summary>
        public const string SessionID = "sessionId";
        /// <summary>
        /// 验证码存储在Session中的标志
        /// </summary>
        public const string VCode = "validateCode";

        /// <summary>
        /// 文件上传时根目录
        /// </summary>
        public const string UploadPath = "uploadRootPath";
        /// <summary>
        /// 最大上传文件大小
        /// </summary>
        public const string maxLength = "maxRequestLength";

        /// <summary>
        /// 返回连接
        /// </summary>
        public const string returnUrl = "returnUrl";

        /// <summary>
        /// 系统配置
        /// </summary>
        public const string systemConfig = "SystemConfig";
        /// <summary>
        /// 轮播图存放的文件
        /// </summary>
        public const string carouselPath = "carouselPath";
        /// <summary>
        /// 缩略图存放的文件
        /// </summary>
        public const string thumbPath = "thumbPath";
        #region 策略
        /// <summary>
        /// 系统策略
        /// </summary>
        public const string SystemPolicy = "SYSTEM";
        /// <summary>
        /// 客户端
        /// </summary>
        public const string ClientPolicy = "CLIENT";
        /// <summary>
        /// 管理员
        /// </summary>
        public const string AdminPolicy = "ADMIN";
        /// <summary>
        /// PermissionPolicy
        /// </summary>
        public const string PermissionPolicy = "Permission";
        #endregion
        #region 路有前缀
        /// <summary>
        /// 路有前缀
        /// </summary>
        public const string RoutePrefix = "/api";
        #endregion
    }
}
