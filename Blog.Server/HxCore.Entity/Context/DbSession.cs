using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace HxCore.Entity.Context
{
    /// <summary>
    /// 如果没有提供对应模型的服务类，可以使用该方法进行CRUD操作
    /// </summary>
    public class DbSession:IDbSession
    {
        /// <summary>
        /// 服务的实例
        /// </summary>
        public IServiceProvider ServiceProvider { get;}
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">服务的实例</param>
        /// <param name="db">服务的实例</param>
        public DbSession(IServiceProvider service, DbContext db)
        {
            ServiceProvider = service;
            this.Db = db;
        }
        /// <summary>
        /// ef数据库上下文
        /// </summary>
        public DbContext Db
        {
            get;
        }
        /// <summary>
        /// 获取使用原生的DI注入的服务类(一般不不用这个，而是使用构造函数注入)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public T FindById<T>(params object[] keyValues) where T : class
        {
            return this.Db.Find<T>(keyValues);
        }
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public Task<T> FindByIdAsync<T>(params object[] keyValues) where T : class
        {
            return this.Db.FindAsync<T>(keyValues).AsTask();
        }
        /// <summary>
        /// 获取满足条件的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<T> FindEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Db.Set<T>().FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        public IQueryable<T> QueryEntities<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Db.Set<T>().Where(predicate);
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="handler"></param>
        public bool Excute(EventHandler handler)
        {
            using (IDbContextTransaction transaction = Db.Database.BeginTransaction())
            {
                try
                {
                    handler?.Invoke(null, EventArgs.Empty);
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new System.Reflection.TargetInvocationException(e);
                }
            }
        }
        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="handler"></param>
        public async Task<bool> ExcuteAsync(EventHandler handler)
        {
            using (IDbContextTransaction transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    handler?.Invoke(null, EventArgs.Empty);
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception e)
                {

                    await transaction.RollbackAsync();
                    throw new System.Reflection.TargetInvocationException(e);
                }
            }
        }

        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Exist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Db.Set<T>().Any(predicate);
        }
        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<bool> ExistAsync<T>(Expression<Func<T, bool>> predicate)where T:class
        {
            return this.Db.Set<T>().AnyAsync(predicate);
        }
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            var result = this.Db.SaveChanges();
            return result > 0;
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            var result = await this.Db.SaveChangesAsync();
            return result > 0;
        }

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public async Task<T> InsertAsync<T>(T entity)where T:class,new()
        {
            var result = await this.Db.Set<T>().AddAsync(entity);
            return result.Entity;
        }
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public Task InsertAsync<T>(IEnumerable<T> entityList) where T : class, new()
        {
            return this.Db.Set<T>().AddRangeAsync(entityList);
        }
        #endregion
    }
}
