# 博客系统
ASP.NET Core 3.1，前后端分离后端接口，vue
系统环境
windows 10、SQL server 2012/MySql、Visual Studio 2019


后端技术：

  * .Net Core 3.1 API（因为想单纯搭建前后端分离，因此就选用的API）
  
  * Swagger 前后端文档说明，基于RESTful风格编写接口

  * Repository + Service 仓储模式编程

  * Async和Await 异步编程

  * Cors 简单的跨域解决方案

  * Autofac 轻量级IoC和DI依赖注入(暂时使用.Net core中自带的依赖注入)

  * JWT权限验证



数据库技术

  * EF Core ORM框架，CodeFirst

  * AutoMapper 自动对象映射


分布式缓存技术

  * Redis 轻量级分布式缓存


前端技术

  * Vue 2.0 框架全家桶 Vue2 + VueRouter2 + Webpack + Axios + vue-cli + vuex

  * Bootstrap vue 基于Vue 2.0的组件库


组件模块：

 使用 Swagger 做api文档；
 使用 Automapper 处理对象映射；
 使用 AutoFac 做依赖注入容器，并提供批量服务注入（暂时使用.Net core中自带的依赖注入）；
 支持 CORS 跨域；
 封装 JWT 自定义策略授权；
 使用 NLog 日志框架，集成原生 ILogger 接口做日志记录；
 计划 Redis 做缓存处理；

