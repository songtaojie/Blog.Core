using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model
{
    /// <summary>
    /// 博客类型的模型
    /// </summary>
    public class BlogTypeModel: IAutoMapper<T_BlogType>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
