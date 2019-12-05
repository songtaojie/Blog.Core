using HxCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filter
{
    /// <summary>
    /// 返回结果统一处理
    /// </summary>
    public class ApiResultAttribute: ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult.Value == null)
                {
                    context.Result = new ObjectResult(new AjaxResult { Code = StatusCodes.Status404NotFound, Message = "未找到资源", Data = "" });
                }
                else
                {
                    context.Result = new ObjectResult(new AjaxResult { Code = StatusCodes.Status200OK, Data = objectResult.Value });
                }
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(new AjaxResult { Code = StatusCodes.Status404NotFound, Message = "未找到资源", Data = "" });
            }
            else if (context.Result is ContentResult)
            {
                var contentResult = context.Result as ContentResult;
                context.Result = new ObjectResult(new AjaxResult { Code = StatusCodes.Status200OK, Data = contentResult.Content });
            }
            else if (context.Result is StatusCodeResult)
            {
                context.Result = new ObjectResult(new AjaxResult { Code = (context.Result as StatusCodeResult).StatusCode });
            }
            else
            {
                base.OnResultExecuting(context);
            }
        }
    }
}
