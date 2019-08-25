using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Repository
{
    public abstract class BaseRepository<T>where T:class,new()
    {
        protected DbContext DbContext { get; }
        public BaseRepository()
        {
            DbContext = Model.Context.DbFactory.GetDbContext();
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetEntityById(object id)
        {
            return await DbContext.Set<T>().FindAsync();
        }
    }
}
