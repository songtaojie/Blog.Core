using HxCore.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filter
{
    public class ExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(IHostingEnvironment env, ILogger<ExceptionFilter> logger )
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            WriteLog(context);
            context.ExceptionHandled = true;
            AjaxResult result = new AjaxResult { Success = false, Message = context.Exception.Message };
            var response = context.HttpContext.Response;
            var request = context.HttpContext.Request;
            if (context.Exception is UserFriendlyException)
            {
                result.Code = response.StatusCode = StatusCodes.Status200OK;
                context.Result = new JsonResult(result);
            }
            else if (context.Exception is NoAuthorizeException)
            {
                result.Code = response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(result);
            }
            else if (context.Exception is NotFoundException)
            {
                result.Code = response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new JsonResult(result);
            }
            else
            {
                result.Code = response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new JsonResult(result);
            }
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }

        // <summary>
        /// 写入日志（log4net）
        /// </summary>
        /// <param name="context">提供使用</param>
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            _logger.LogError(context.Exception, context.Exception.Message);
        }
    }
}
