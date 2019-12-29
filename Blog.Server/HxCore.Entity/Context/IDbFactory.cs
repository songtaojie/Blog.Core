using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Entity.Context
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// 当前请求的ServiceProvider实例
        /// </summary>
        IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
        /// <summary>
        /// 获取服务的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRequiredService<T>();
    }
}
