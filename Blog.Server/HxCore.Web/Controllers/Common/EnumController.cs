using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.Entity;
using HxCore.Entity.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 枚举的控制器
    /// </summary>
    [Route("[controller]/[action]")]
    public class EnumController : BaseApiController
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
        public List<BlogType> GetBlogTypeList()
        {
            var list = this.db.QueryEntities<BlogType>(b => b.Delete == "N").ToList();
            return list;
        }

        /// <summary>
        /// 获取博客类型的列表
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public List<Category> GetCategoryList()
        {
            return this.db.QueryEntities<Category>(b => b.Delete == "N").ToList();
        }
    }
}