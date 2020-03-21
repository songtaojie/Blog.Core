using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// ajax返回结果统一封装
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = true;//默认是成功

        /// <summary>
        /// 信息描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取 Ajax操作结果编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 获取 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}
