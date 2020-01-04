using HxCore.IRepository;
using HxCore.IServices;
using HxCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Services
{
    public class UserInfoServices:BaseService<UserInfo>, IUserInfoService
    {
        public UserInfoServices(IUserInfoRepository userDal):base(userDal)
        {
        }
    }
}
