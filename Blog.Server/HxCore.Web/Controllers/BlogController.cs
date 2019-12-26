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
    public class BlogController : BaseApiController
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpPost]
        public List<Blog> GetList()
        {
            var result = _blogService.QueryEntitiesNoTrack(b => true).ToList();
            return result;
        }

    }
}