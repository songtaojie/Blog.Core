﻿using HxCore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HxCore.Entity
{
    /// <summary>
    /// 博客类
    /// </summary>
    [Table("T_Blog")]
    [Serializable]
    public class T_Blog : BaseEntity
    {
        /// <summary>
        /// 博客标题
        /// </summary>
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 内容，html格式
        /// </summary>
        public string ContentHtml { get; set; }
        /// <summary>
        /// 是否使用MarkDown编辑的
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string MarkDown { get; set; } = ConstKey.No;

        /// <summary>
        /// 是否是私人的
        /// </summary>
        public string Private { get; set; } = ConstKey.No;
        /// <summary>
        /// 是否是转发文章
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Forward { get; set; } = ConstKey.No;
        /// <summary>
        /// 是否发布，true代表发布，false代表不发布即是草稿
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Publish { get; set; } = ConstKey.Yes;

        /// <summary>
        /// 发布日期
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// 置顶 Y权值加10年
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Top { get; set; } = ConstKey.No;
        /// <summary>
        /// 精华 Y权值加10天
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Essence { get; set; } = ConstKey.No;
        /// <summary>
        /// 原链接
        /// </summary>
        [StringLength(255)]
        public string ForwardUrl { get; set; }
        /// <summary>
        /// 原博客发表时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? OldPublishTime { get; set; }
        /// <summary>
        /// 博客的个人标签，对应的是BlogTag表中主键，以，号隔开
        /// </summary>
        [StringLength(40)]
        public string BlogTags { get; set; }
        /// <summary>
        /// 允许评论
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string CanCmt { get; set; } = ConstKey.Yes;

        /// <summary>
        /// 阅读量
        /// </summary>
        public long ReadCount { get; set; }
        /// <summary>
        /// 博客被推荐的次数
        /// </summary>
        public long LikeCount { get; set; }
        /// <summary>
        /// 被收藏次数
        /// </summary>
        public long FavCount { get; set; }
        /// <summary>
        /// 被评论次数
        /// </summary>
        public long CmtCount { get; set; }
        /// <summary>
        /// 个人置顶 标识该文档是否置顶,置顶的文章在个人主页中排序靠前
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string PersonTop { get; set; } = ConstKey.No;
        /// <summary>
        /// 主题中的第一张图的地址
        /// </summary>
        [StringLength(255)]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 主题中第一张图的名字
        /// </summary>
        [StringLength(100)]
        public string ImgName { get; set; }

        /// <summary>
        /// 发改主题时的坐标
        /// </summary>
        [StringLength(255)]
        public string Location { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }
        /// <summary>
        /// 热门程度
        /// </summary>
        [Column]
        //[DecimalPrecision]
        public decimal OrderFactor { get; set; }

        /// <summary>
        /// 系统分类，前端、后端、编程语言等
        /// </summary> 
        public long CategoryId { get; set; }

        /// <summary>
        /// 博客类型，是转发，原创，还是翻译等
        /// </summary> 
        public long BlogTypeId { get; set; }

        /// <summary>
        /// 是否是轮播图
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string Carousel { get; set; } = ConstKey.No;
    }
}
