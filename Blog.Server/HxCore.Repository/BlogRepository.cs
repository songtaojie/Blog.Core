using HxCore.IRepository;
using HxCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using HxCore.Entity.Context;

namespace HxCore.Repository
{
    public class BlogRepository:BaseRepository<Blog>,IBlogRepository
    {
        public BlogRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
