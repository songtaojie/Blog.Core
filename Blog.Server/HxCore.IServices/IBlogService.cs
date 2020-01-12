using HxCore.Entity;
using HxCore.Entity.Dependency;
using HxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.IServices
{
    [ScropedDependency]
    public interface IBlogService:IBaseService<Blog>
    {
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="blogModel"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(BlogCreateModel blogModel);
        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        List<BlogViewModel> QueryBlogList();
        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        List<PersonTag> QueryTagList();
    }
}
