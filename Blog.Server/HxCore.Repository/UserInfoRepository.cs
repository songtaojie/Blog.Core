using HxCore.IRepository;
using HxCore.Entity;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Repository
{
    public class UserInfoRepository:BaseRepository<UserInfo>,IUserInfoRepository
    {
        public UserInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
