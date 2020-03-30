using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HxCore.Entity
{
    /// <summary>
    /// 博客标签
    /// </summary>
    [Table("T_BlogTag")]
    [Serializable]
    public class T_BlogTag : BaseEntity
    {
        /// <summary>
        /// 标签名字
        /// </summary>
        [StringLength(40)]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Order { get; set; }
    }
}
