using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.IRepository
{
    public interface IBaseRepository<T>where T:class,new()
    {
        /// <summary>
        /// 根据Id获取模型数据
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>模型数据</returns>
        Task<T> GetEntityById(object id);

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> GetEntity(Expression<Func<T, bool>> predicate);
    }
}
