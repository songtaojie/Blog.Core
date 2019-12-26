using HxCore.IRepository;
using HxCore.IServices;
using HxCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Services
{
    public class BlogService:BaseService<Blog>,IBlogService
    {
        public BlogService(IBlogRepository _blogDal)
        {
            this.baseDal = _blogDal;
        }
    }
}
