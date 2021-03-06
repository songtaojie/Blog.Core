﻿using HxCore.IRepository;
using HxCore.Entity;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HxCore.Repository
{
    public class UserInfoRepository:BaseRepository<T_UserInfo>,IUserInfoRepository
    {
        public UserInfoRepository(DbContext dbSession) : base(dbSession)
        { }
    }
}
