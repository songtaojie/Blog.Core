﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HxCore.Entity
{
    /// <summary>
    /// 博客分类
    /// </summary>
    [Serializable]
    [Table("T_Category")]
    public class T_Category : BaseEntity
    {
        /// <summary>
        /// 分类名字
        /// </summary>
        [StringLength(40)]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Order { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}
