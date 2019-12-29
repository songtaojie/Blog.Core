using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.ViewModels
{
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginParam
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        public bool? Remember { get; set; }
    }
}
