using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Common;
using HxCore.Entity;
using HxCore.Entity.Context;
using HxCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 枚举的控制器
    /// </summary>
    [Route("[controller]/[action]")]
    public class EnumController : BaseAuthApiController
    {
        private IDbSession db;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbSession"></param>
        public EnumController(IDbSession dbSession)
        {
            db = dbSession;
        }
        /// <summary>
        /// 获取博客类型的列表
        /// </summary>
        /// <returns></returns>
        [HttpPost,HttpGet]
        public List<BlogTypeModel> GetBlogTypeList()
        {
            var list = this.db.QueryEntities<T_BlogType>(b => b.Delete == ConstKey.No).Select(b=>new BlogTypeModel
            {
                Id = b.Id.ToString(),
                Name = b.Name
            }).ToList();
            return list;
        }

        /// <summary>
        /// 获取博客类型的列表
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public List<CategoryModel> GetCategoryList()
        {
            return this.db.QueryEntities<T_Category>(b => b.Delete == ConstKey.No)
                .Select(c => new CategoryModel
                { 
                    Id = c.Id.ToString(),
                    Name = c.Name
                }).ToList();
        }
    }
}