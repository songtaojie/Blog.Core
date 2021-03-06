﻿using HxCore.Entity;
using HxCore.Entity.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.IServices
{
    [TransientDependency]
    public interface IUserInfoService: IBaseService<T_UserInfo>
    {
    }
}
