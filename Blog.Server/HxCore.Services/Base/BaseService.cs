using HxCore.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Services
{
    public class BaseService<T>where T:class,new()
    {
        protected IBaseRepository<T> baseDal;

        public async Task<T> QueryEntity(Expression<Func<T, bool>> predicate)
        {
            return await baseDal.QueryEntity(predicate);
        }

        public async Task<T> QueryEntityById(object id)
        {
            return await baseDal.QueryEntityById(id);
        }

        public async Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> lambda)
        {
            return await baseDal.QueryEntityNoTrack(lambda);
        }

        public IQueryable<T> QueryEntities(Expression<Func<T, bool>> lambda)
        {
            return baseDal.QueryEntities(lambda);
        }

        public virtual IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda)
        {
            return baseDal.QueryEntitiesNoTrack(lambda);
        }
    }
}
