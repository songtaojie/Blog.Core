using HxCore.IRepository;
using HxCore.IServices;
using HxCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HxCore.Model;
using HxCore.Common;
using AutoMapper;

namespace HxCore.Services
{
    public class BlogService:BaseService<Blog>,IBlogService
    {
        public BlogService(IBlogRepository dal,IUserContext userContext,IMapper mapper)
            :base(dal, userContext, mapper)
        {
        }
        public async Task<bool> Insert(BlogViewModel blogModel)
        {
            var entity = this.Mapper.Map<Blog>(blogModel);
            return await base.Insert(entity);
        }
    }
}
