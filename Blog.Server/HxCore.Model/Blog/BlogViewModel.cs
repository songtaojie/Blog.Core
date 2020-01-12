using HxCore.Common;
using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model
{
    /// <summary>
    /// 博客视图模型
    /// </summary>
    public class BlogViewModel:IAutoMapper<Blog>
    {
        /// <summary>
        /// 博客id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 博客标题
        /// </summary>
        public string Title
        {
            get; set;
        }
        /// <summary>
        /// 博客内容
        /// </summary>
        public string Content
        {
            get; set;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 首页显示的内容
        /// </summary>
        public string HomeContent => WebHelper.FilterHtmlP(Content, 100);

        /// <summary>
        /// 阅读量
        /// </summary>
        public long ReadCount { get; set; }
       
        /// <summary>
        /// 被评论次数
        /// </summary>
        public long CmtCount { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// 头像链接
        /// </summary>
        public string AvatarUrl { get; set; }
    }
    /// <summary>
    /// 个人标签
    /// </summary>
    public class PersonTag
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool? Editable { get; set; } = false;
    }
}
