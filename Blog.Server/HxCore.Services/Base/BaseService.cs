using AutoMapper;
using HxCore.Common;
using HxCore.Common.Extensions;
using HxCore.Entity;
using HxCore.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Services
{
    public abstract class BaseService<T>where T: BaseModel, new()
    {
        protected IBaseRepository<T> Repository { get; }
        protected IUserContext UserContext { get; }
        protected IMapper Mapper { get; }
        public BaseService(IBaseRepository<T> repository)
        {
            this.Repository = repository;
        }
        public BaseService(IBaseRepository<T> repository, IUserContext userContext)
        {
            this.Repository = repository;
            this.UserContext = userContext;
        }
        public BaseService(IBaseRepository<T> repository,IUserContext userContext,IMapper mapper)
        {
            this.Repository = repository;
            this.UserContext = userContext;
            this.Mapper = mapper;
        }
        #region 查询
        public async Task<T> QueryEntity(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return await Repository.QueryEntity(GetLambda(predicate,defaultFilter));
        }

        public async Task<T> QueryEntityById(object id)
        {
            return await Repository.QueryEntityById(id);
        }

        public async Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return await Repository.QueryEntityNoTrack(GetLambda(predicate, defaultFilter));
        }

        public IQueryable<T> QueryEntities(Expression<Func<T, bool>> predicate, bool defaultFilter = true)
        {
            return Repository.QueryEntities(GetLambda(predicate, defaultFilter));
        }

        public virtual IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda, bool defaultFilter = true)
        {
            return Repository.QueryEntitiesNoTrack(GetLambda(lambda, defaultFilter));
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

        #endregion

        #region 新增
        public virtual T BeforeInsert(T entity)
        {
            if (entity != null && typeof(Entity.BaseEntity).IsAssignableFrom(typeof(T)))
            {
                entity["Id"] = Helper.GetSnowId();
                if (UserContext.IsAuthenticated)
                { 
                    entity["UserId"] = UserContext.UserId;
                    entity["UserName"] = UserContext.UserName;
                }
            }
            return entity;
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public async Task<bool> Insert(T entity)
        {
            entity = this.BeforeInsert(entity);
            await Repository.Insert(entity);
            var result = await this.Repository.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public virtual async Task<bool> Insert(IEnumerable<T> entityList)
        {
            Repository.Insert(entityList);
            var result = await this.Repository.SaveChangesAsync();
            return result;
        }
        #endregion

        #region 更新
        public virtual T BeforeUpdate(T entity)
        {
            if (entity != null && typeof(Entity.BaseEntity).IsAssignableFrom(typeof(T)))
            {
                entity["LastModifyTime"] = DateTime.Now;
            }
            return entity;
        }
        public virtual async Task<bool> Update(T entity)
        {
            entity = this.BeforeUpdate(entity);
            Repository.Update(entity);
            var result = await this.Repository.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        public virtual async Task<bool> UpdatePartial(T entity, IEnumerable<string> fields)
        {
            Repository.UpdatePartial(entity, fields);
            var result = await this.Repository.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        public virtual async Task<bool> UpdatePartial(T entity, params string[] fields)
        {
            Repository.UpdatePartial(entity, fields);
            var result = await this.Repository.SaveChangesAsync();
            return result;
        }
        #endregion

    }
}
