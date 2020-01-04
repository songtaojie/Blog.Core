using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.IServices
{
    public interface IBaseService<T>where T:class
    {
        /// <summary>
        /// 根据Id获取模型数据
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>模型数据</returns>
        Task<T> QueryEntityById(object id);

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> QueryEntity(Expression<Func<T, bool>> predicate, bool defaultFilter = true);

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
    }
}
