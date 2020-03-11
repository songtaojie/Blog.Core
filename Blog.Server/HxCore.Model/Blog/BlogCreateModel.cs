using HxCore.Common;
using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model
{
    /// <summary>
    /// 博客创建所用模型
    /// </summary>
    public class BlogCreateModel : IAutoMapper<Blog>
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
        /// 文章类型
        /// </summary>
        public string BlogTypeId
        {
            get; set;
        }
        /// <summary>
        /// 系统分类
        /// </summary>
        public string CategoryId
        {
            get; set;
        }
        /// <summary>
        /// 个人置顶
        /// </summary>
        public string PersonTop
        {
            get; set;
        } = ConstKey.No;
        /// <summary>
        /// 仅自己可见
        /// </summary>
        public string Private
        {
            get; set;
        } = ConstKey.No;
        /// <summary>
        /// 是否发布
        /// </summary>
        public string Publish
        {
            get; set;
        } = ConstKey.No;
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish => Helper.IsYes(Publish);
        /// <summary>
        /// 是否可评论
        /// </summary>
        public string CanCmt
        {
            get; set;
        } = ConstKey.Yes;
        /// <summary>
        /// 个人标签
        /// </summary>
        public List<PersonTag> PersonTags
        {
            get; set;
        }
        /// <summary>
        /// 是否是markdown
        /// </summary>
        public string MarkDown
        {
            get; set;
        } = ConstKey.No;
    }
}
