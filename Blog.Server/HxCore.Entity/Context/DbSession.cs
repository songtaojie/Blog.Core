using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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
        public DbSession(IServiceProvider service)
        {
            ServiceProvider = service;
        }
        /// <summary>
        /// ef数据库上下文
        /// </summary>
        public DbContext DbContext
        {
            get { return GetRequiredService<HxContext>(); }
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
        public Task<T> QueryById<T>(params object[] keyValues) where T : class
        {
            return this.DbContext.FindAsync<T>(keyValues).AsTask();
        }
        /// <summary>
        /// 获取满足条件的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<T> QueryEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        public IQueryable<T> QueryEntities<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.DbContext.Set<T>().Where(predicate);
        }

    }
}
