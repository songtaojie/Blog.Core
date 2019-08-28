using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Model.Context
{
    /// <summary>
    /// 如果没有提供对应模型的服务类，可以使用该方法进行CRUD操作
    /// </summary>
    public class DbSession:IDbSession
    {
        private DbContext DbContext
        {
            get;
        }
        public DbSession(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Task<T> GetEntityById<T>(params object[] keyValues) where T : class
        {
            return this.DbContext.FindAsync<T>(keyValues);
        }

        public Task<T> GetEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

    }
}
