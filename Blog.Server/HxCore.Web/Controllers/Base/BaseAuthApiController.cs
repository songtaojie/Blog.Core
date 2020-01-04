using AutoMapper;
using HxCore.Common.Extensions;
using HxCore.Entity.Context;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 客户端使用的api
    /// </summary>
    [Authorize(Policy = ConstInfo.ClientPolicy)]
    public abstract class BaseAuthApiController: BaseApiController
    {
       
    }
}
