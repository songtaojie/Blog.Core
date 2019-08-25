using HxCore.IRepository;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Services
{
    public class BaseService<T>where T:class,new()
    {
        protected IBaseRepository<T> baseDal;

        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate)
        {
            return await baseDal.GetEntity(predicate);
        }

        public async Task<T> GetEntityById(object id)
        {
            return await baseDal.GetEntityById(id);
        }
    }
}
