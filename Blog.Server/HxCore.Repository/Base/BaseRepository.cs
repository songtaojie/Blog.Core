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
            DbContext = Entity.Context.DbFactory.GetDbContext();
        }
        #region 查询
        public async Task<T> QueryEntity(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> QueryEntityById(object id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> lambda)
        {
            var result = DbContext.Set<T>().AsNoTracking().Where(lambda);
            
            return await result.FirstOrDefaultAsync();
        }

        public IQueryable<T> QueryEntities(Expression<Func<T, bool>> lambda)
        {
            var result = DbContext.Set<T>().Where(lambda);
            return result;
        }

        public virtual IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda)
        {
            var result = DbContext.Set<T>()
                .AsNoTracking()
                .Where(lambda);
            return result;
        }
        #endregion

    }
}
