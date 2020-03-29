using HxCore.Common;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Repository
{
    public abstract class BaseRepository<T>where T:class,new()
    {
        protected DbContext Db { get; }
        public BaseRepository(DbContext db)
        {
            this.Db = db;
        }
        #region 查询
        public async Task<T> FindEntity(Expression<Func<T, bool>> predicate)
        {
            return await Db.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindEntityById(object id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public async Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> lambda)
        {
            var result = Db.Set<T>().AsNoTracking().Where(lambda);
            
            return await result.FirstOrDefaultAsync();
        }

        public IQueryable<T> QueryEntities(Expression<Func<T, bool>> lambda)
        {
            var result = Db.Set<T>().Where(lambda);
            return result;
        }

        public virtual IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda)
        {
            var result = Db.Set<T>()
                .AsNoTracking()
                .Where(lambda);
            return result;
        }
        #endregion

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public async Task<T> Insert(T entity)
        {
            var result= await this.Db.Set<T>().AddAsync(entity);
            return result.Entity;
        }
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public Task BatchInsert(IEnumerable<T> entityList)
        {
            var result = this.Db.Set<T>().AddRangeAsync(entityList);
            return result;
        }
        #endregion

        #region 更新
        public T Update(T entity)
        {
            var result = Db.Set<T>().Update(entity);
            return result.Entity;
        }
        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        public void UpdatePartial(T entity, IEnumerable<string> fields)
        {
            if (entity != null && fields != null)
            {
                this.Db.Set<T>().Attach(entity);
                foreach (var item in fields)
                {
                    this.Db.Entry<T>(entity).Property(item).IsModified = true;
                }
            }
        }

        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        public void UpdatePartial(T entity, params string[] fields)
        {
            if (entity != null && fields != null)
            {
                this.Db.Set<T>().Attach(entity);
                foreach (var item in fields)
                {
                    this.Db.Entry<T>(entity).Property(item).IsModified = true;
                }
            }
        }
        #endregion

        #region  删除
        #endregion

        #region 保存更改
        public bool SaveChanges()
        {
            return this.Db.SaveChanges() > 0;
        }
        public async Task<bool> SaveChangesAsync()
        {
            var result = await this.Db.SaveChangesAsync();
            return result > 0;
        }
        #endregion

        #region 判断
        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        public Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return this.Db.Set<T>().AnyAsync(predicate);
        }
        #endregion
    }
}
