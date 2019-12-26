using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.ViewModels
{
    public class BlogViewModel
    {
        /// <summary>
        /// 博客标题
        /// </summary>
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
        public string MarkDown { get; set; } = "N";

        /// <summary>
        /// 是否是私人的
        /// </summary>
        public string Private { get; set; } = "N";
        /// <summary>
        /// 是否是转发文章
        /// </summary>
        public string Forward { get; set; } = "N";
        /// <summary>
        /// 是否发布，true代表发布，false代表不发布即是草稿
        /// </summary>
        public string Publish { get; set; } = "Y";

        /// <summary>
        /// 原链接
        /// </summary>
        public string ForwardUrl { get; set; }

        /// <summary>
        /// 博客的个人标签，对应的是BlogTag表中主键，以，号隔开
        /// </summary>
        public string BlogTags { get; set; }
        /// <summary>
        /// 允许评论
        /// </summary>
        public string CanCmt { get; set; } = "Y";

        /// <summary>
        /// 个人置顶 标识该文档是否置顶,置顶的文章在个人主页中排序靠前
        /// </summary>
        public string PersonTop { get; set; } = "N";
        
        public string Carousel { get; set; } = "N";
    }
}
