using HxCore.IRepository;
using HxCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace HxCore.Repository
{
    public class BlogRepository:BaseRepository<T_Blog>,IBlogRepository
    {
        public BlogRepository(DbContext db) : base(db)
        { }
    }

    public class BlogTagRepository : BaseRepository<T_BlogTag>, IBlogTagRepository
    {
        public BlogTagRepository(DbContext db) : base(db)
        { }
    }
}
