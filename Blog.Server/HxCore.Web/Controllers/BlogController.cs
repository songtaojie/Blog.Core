using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.IServices;
using HxCore.Model;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 博客相关的控制器类
    /// </summary>
    [Authorize(Policy =ConstInfo.ClientPolicy)]
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet,HttpPost]
        public List<Blog> GetList()
        {
            return this._blogService.QueryEntities(s=>true).ToList();
        }
    }
}