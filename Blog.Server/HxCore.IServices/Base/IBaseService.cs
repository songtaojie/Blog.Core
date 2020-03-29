using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.IServices
{
    public interface IBaseService<T>where T:class
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
        Task<T> FindEntity(Expression<Func<T, bool>> predicate, bool defaultFilter = true);

        /// <summary>
        /// 根据lambda表达式查询出单个实体（不进行跟踪）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> QueryEntityNoTrack(Expression<Func<T, bool>> predicate, bool defaultFilter = true);

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryEntities(Expression<Func<T, bool>> predicate, bool defaultFilter = true);

        /// <summary>
        /// 查询符合条件的集合（不进行跟踪）
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> QueryEntitiesNoTrack(Expression<Func<T, bool>> lambda, bool defaultFilter = true);
        #endregion

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        Task<bool> Insert(T entity);
        /// <summary>
        /// 插入集合
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task<bool> BatchInsert(IEnumerable<T> entityList);
        #endregion

        #region 更新
        Task<bool> Update(T entity);
        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        Task<bool> UpdatePartial(T entity, IEnumerable<string> fields);

        /// <summary>
        /// 更新实体的部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fields">要更新的字段的集合</param>
        Task<bool> UpdatePartial(T entity, params string[] fields);
        #endregion

        #region 判断
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}
