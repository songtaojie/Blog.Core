using HxCore.Entity;
using HxCore.Entity.Dependency;
using HxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.IServices
{
    [ScropedDependency]
    public interface IBlogService:IBaseService<Blog>
    {
        Task<bool> Insert(BlogViewModel blogModel);
    }
}
