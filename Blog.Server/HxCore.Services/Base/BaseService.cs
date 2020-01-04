using HxCore.Common.Extensions;
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

        public async Task<T> QueryEntity(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return await baseDal.QueryEntity(GetLambda(predicate,defaultFilter));
        }

        public async Task<T> QueryEntityById(object id)
        {
            return await baseDal.QueryEntityById(id);
        }

        public async Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return await baseDal.QueryEntityNoTrack(GetLambda(predicate, defaultFilter));
        }

        public IQueryable<T> QueryEntities(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return baseDal.QueryEntities(GetLambda(predicate, defaultFilter));
        }

        public virtual IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda, bool defaultFilter = true)
        {
            return baseDal.QueryEntitiesNoTrack(GetLambda(lambda, defaultFilter));
        }


        #region 获取新的lambda
        protected virtual Expression<Func<T, bool>> GetLambda(Expression<Func<T, bool>> lambdaWhere, bool defaultFilter)
        {
            if (defaultFilter && typeof(Entity.BaseEntity).IsAssignableFrom(typeof(T)))
            {
                ParameterExpression parameterExp = Expression.Parameter(typeof(T), "table");
                MemberExpression deleteProp = Expression.Property(parameterExp, "Delete");
                var lambda = Expression.Lambda<Func<T, bool>>(Expression.Equal(deleteProp, Expression.Constant("N")), parameterExp);
                return lambdaWhere.And(lambda);
            }
            return lambdaWhere;
        }
        #endregion
    }
}
