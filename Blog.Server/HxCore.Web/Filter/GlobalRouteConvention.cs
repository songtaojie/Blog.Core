﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HxCore.Web.Filter
{
    /// <summary>
    /// 全局路由公约
    /// </summary>
    public class GlobalRouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _centralPrefix;
        /// <summary>
        /// 全局路由公约
        /// </summary>
        /// <param name="routeTemplateProvider"></param>
        public GlobalRouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }
        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            //遍历所有的 Controller
            foreach (var controller in application.Controllers)
            {
                // 已经标记了 RouteAttribute 的 Controller
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        // 在 当前路由上 再 添加一个 路由前缀
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                // 没有标记 RouteAttribute 的 Controller
                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        // 添加一个 路由前缀
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
    }
}
