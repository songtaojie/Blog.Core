using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Entity.Context
{
    /// <summary>
    /// 数据库上下文操作类
    /// </summary>
    public interface IDbSession
    {
        /// <summary>
        /// 服务的实例
        /// </summary>
        IServiceProvider ServiceProvider { get;}
        /// <summary>
        /// 数据库上下文
        /// </summary>
        DbContext DbContext { get; }
        /// <summary>
        ///  根据Id获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="keyValues">实体的ID</param>
        /// <returns></returns>
        Task<T> QueryById<T>(params object[] keyValues) where T:class;

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> QueryEntity<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        IQueryable<T> QueryEntities<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="handler"></param>
        void Excute(EventHandler handler);
    }
}
