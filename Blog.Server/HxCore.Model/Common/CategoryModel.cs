using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model
{
    /// <summary>
    /// 分类
    /// </summary>
    public class CategoryModel: IAutoMapper<BlogType>
    {
        /// <summary>
        /// 主键（long）
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
