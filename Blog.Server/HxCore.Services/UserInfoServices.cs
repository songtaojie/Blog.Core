using HxCore.IRepository;
using HxCore.IServices;
using HxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Services
{
    public class UserInfoServices:BaseService<UserInfo>, IUserInfoService
    {
        private IUserInfoRepository _dal;
        public UserInfoServices(IUserInfoRepository userDal)
        {
            this.baseDal = userDal;
            this._dal = userDal;
        }
    }
}
