using HxCore.Model;
using HxCore.Model.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.IServices
{
    [TransientDependency]
    public interface IUserInfoService: IBaseService<UserInfo>
    {
    }
}
