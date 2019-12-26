using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Controllers
{
    [Authorize(Policy = ConstInfo.ClientPolicy)]
    [ApiController]
    public class BaseApiController: ControllerBase
    {
    }
}
