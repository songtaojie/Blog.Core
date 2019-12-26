using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HxCore.Entity
{
    /// <summary>
    /// 博客分类
    /// </summary>
    [Serializable]
    public class Category : Base.BaseEntity
    {
        /// <summary>
        /// 分类名字
        /// </summary>
        [StringLength(40)]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}
