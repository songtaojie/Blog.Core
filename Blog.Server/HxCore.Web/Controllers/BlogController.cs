using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.IServices;
using HxCore.Entity;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 博客相关的控制器类
    /// </summary>
    [Route("[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="blogService"></param>
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Blog> GetList()
        {
            var result = _blogService.QueryEntitiesNoTrack(b => true).ToList();
            return result;
        }

    }
}