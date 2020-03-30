using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.IRepository
{
    [ScropedDependency]
    public interface IBlogRepository:IBaseRepository<T_Blog>
    {
    }

    [ScropedDependency]
    public interface IBlogTagRepository : IBaseRepository<T_BlogTag>
    {
    }
}
