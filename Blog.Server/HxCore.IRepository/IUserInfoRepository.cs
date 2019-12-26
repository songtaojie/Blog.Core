using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.IRepository
{
    [TransientDependency]
    public interface IUserInfoRepository:IBaseRepository<UserInfo>
    {
    }
}
