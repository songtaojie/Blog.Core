using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.IRepository
{
    public interface IBaseRepository<T>where T:class,new()
    {
        #region 查询
        /// <summary>
        /// 根据Id获取模型数据
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>模型数据</returns>
        Task<T> FindEntityById(object id);

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> FindEntity(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据lambda表达式查询出单个实体（不进行跟踪）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryEntities(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询符合条件的集合（不进行跟踪）
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda);
        #endregion

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        Task<T> Insert(T entity);
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task Insert(IEnumerable<T> entityList);
        #endregion

        #region 更新
        T Update(T entity);
        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        void UpdatePartial(T entity, IEnumerable<string> fields);

        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        void UpdatePartial(T entity, params string[] fields);
        #endregion

        #region 保存更改
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        #endregion

        #region 判断
        /// <summary>
        /// 判断是否存在满足条件的数据
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}
