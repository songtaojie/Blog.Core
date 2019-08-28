using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Model.Context
{
    public interface IDbSession
    {
        /// <summary>
        ///  根据Id获取实体数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="keyValues">实体的ID</param>
        /// <returns></returns>
        Task<T> GetEntityById<T>(params object[] keyValues) where T:class;

        /// <summary>
        /// 获取满足指定条件的一条数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">获取数据的条件lambda</param>
        /// <returns>满足当前条件的一个实体</returns>
        Task<T> GetEntity<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
