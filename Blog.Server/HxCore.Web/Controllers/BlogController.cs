using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 博客相关的控制器类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

    }
}