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
using HxCore.Entity.Context;

namespace HxCore.Services
{
    public class BlogService:BaseService<Blog>,IBlogService
    {
        private IBlogTagRepository TagRepository { get; }
        public BlogService(IBlogRepository dal, IBlogTagRepository tagRepository,IDbSession dbSession)
            :base(dal, dbSession)
        {
            this.TagRepository = tagRepository;
        }
        public async Task<bool> Insert(BlogViewModel blogModel)
        {
            var entity = this.Mapper.Map<Blog>(blogModel);
            List<BlogTag> tagEntityList = new List<BlogTag>();
            if (blogModel.PersonTags != null && blogModel.PersonTags.Count > 0)
            {
                blogModel.PersonTags.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Value))
                    {
                        var exist = this.Repository.Exist<BlogTag>(t => t.Name.IndexOf(p.Value) >= 0);
                        if (!exist.Result)
                        {
                            tagEntityList.Add(new BlogTag
                            {
                                Id = Helper.GetSnowId(),
                                Name = p.Value,
                                UserId = UserContext.UserId,
                                UserName = UserContext.UserName
                            });
                        }
                    }
                });
            }
            Task<bool> result = Task.FromResult(false);
            await this.DbSession.ExcuteAsync(delegate
            {
                entity = this.BeforeInsert(entity);
               this.Repository.Insert(entity);
               this.TagRepository.Insert(tagEntityList);
                result = this.DbSession.SaveChangesAsync();
            });
            return await result;
        }
    }
}
