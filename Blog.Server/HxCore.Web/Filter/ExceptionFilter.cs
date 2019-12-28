using HxCore.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Filter
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class ExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(IHostEnvironment env, ILogger<ExceptionFilter> logger )
        {
            _env = env;
            _logger = logger;
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="context">异常上下文</param>
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
                if (!_env.IsDevelopment())
                {
                    result.Message = "服务器端错误!";
                }
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
