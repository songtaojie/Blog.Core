using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.IRepository
{
    [TransientDependency]
    public interface IBlogRepository:IBaseRepository<Blog>
    {
    }
}
