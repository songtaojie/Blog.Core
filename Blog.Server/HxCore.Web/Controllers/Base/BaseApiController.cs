using AutoMapper;
using HxCore.Entity.Context;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 基础的api
    /// </summary>
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        /// <summary>
        /// automapper
        /// </summary>
        protected IMapper Mapper { get; }
        /// <summary>
        /// automapper
        /// </summary>
        protected IDbSession Db { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseApiController() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="dbSession"></param>
        public BaseApiController(IMapper mapper,IDbSession dbSession)
        {
            Mapper = mapper;
            Db = dbSession;
        }
    }
}
