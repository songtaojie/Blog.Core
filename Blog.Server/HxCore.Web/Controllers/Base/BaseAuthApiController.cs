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
    /// 客户端使用的api
    /// </summary>
    [Authorize(Policy = ConstInfo.ClientPolicy)]
    [ApiController]
    public class BaseAuthApiController: ControllerBase
    {
    }
}
