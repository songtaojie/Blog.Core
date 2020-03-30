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
    public class BlogViewModel:IAutoMapper<T_Blog>
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
        /// 这条记录属于哪个用户
        /// </summary>
        public  string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 阅读量
        /// </summary>
        public long ReadCount { get; set; }
       
        /// <summary>
        /// 被评论次数
        /// </summary>
        public long CmtCount { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public string Publish { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// 头像链接
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 系统分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 上一篇博客的id
        /// </summary>
        public string PreId { get; set; }

        /// <summary>
        /// 上一篇博客的名字
        /// </summary>
        public string PreName { get; set; }

        /// <summary>
        /// 下一篇博客的id
        /// </summary>
        public string NextId { get; set; }

        /// <summary>
        /// 下一篇博客的名字
        /// </summary>
        public string NextName { get; set; }

    }
    
}
