using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Common
{
    /// <summary>
    /// 主键接口
    /// </summary>
    /// <typeparam name="T">主键的类型</typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
         T Id { get; set; }
    }
}
