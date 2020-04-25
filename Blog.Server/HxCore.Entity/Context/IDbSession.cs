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
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRequiredService<T>();

        /// <summary>
        ///  根据Id获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="keyValues">实体的ID</param>
        /// <returns></returns>
        T Find<T>(params object[] keyValues) where T : class;

        /// <summary>
        ///  根据Id获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="keyValues">实体的ID</param>
        /// <returns></returns>
        Task<T> FindAsync<T>(params object[] keyValues) where T:class;

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        IQueryable<T> QueryEntities<T>(Expression<Func<T, bool>> predicate) where T : class;
        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> ExistAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exist<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="handler"></param>
        bool Excute(EventHandler handler);
        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="handler"></param>
        Task<bool> ExcuteAsync(EventHandler handler);
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        Task<T> InsertAsync<T>(T entity) where T : class, new();
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task BatchInsertAsync<T>(IEnumerable<T> entityList) where T : class, new();
        #endregion
    }
}
