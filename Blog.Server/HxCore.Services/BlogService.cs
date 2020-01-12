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
using System.Linq;

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
        public async Task<bool> InsertAsync(BlogCreateModel blogModel)
        {
            var entity = this.Mapper.Map<Blog>(blogModel);
            if (blogModel.IsPublish)
            {
                entity.PublishDate = DateTime.Now;
            }
            var imgList = Helper.GetHtmlImageUrlList(entity.Content).ToList();
            if (imgList.Count > 0)
            {
                entity.ImgUrl = imgList[0];
            }
            List<BlogTag> tagEntityList = new List<BlogTag>();
            if (blogModel.PersonTags != null && blogModel.PersonTags.Count > 0)
            {
                List<string> blogTagList = new List<string>();
                blogModel.PersonTags.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        if (string.IsNullOrEmpty(p.Id) || p.Id.Contains("newData"))
                        {
                            var newBlogTag = new BlogTag
                            {
                                Id = Helper.GetSnowId(),
                                Name = p.Name,
                                UserId = UserContext.UserId,
                                UserName = UserContext.UserName
                            };
                            tagEntityList.Add(newBlogTag);
                            blogTagList.Add(newBlogTag.Id);
                        }
                        else
                        {
                            var blogTag = this.DbSession.GetById<BlogTag>(p.Id);
                            if (blogTag != null)
                            {
                                blogTagList.Add(blogTag.Id);
                            }
                        }
                    }
                });
                entity.BlogTags = string.Join(",", blogTagList);
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

        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        public List<BlogViewModel> QueryBlogList()
        {
            var blogList = this.Repository.QueryEntitiesNoTrack(b => true)
                .Select(s => this.Mapper.Map<BlogViewModel>(s))
                .ToList();
            this.UserContext.UserName
            //var blog = this.Repository.QueryEntitiesNoTrack(b => true);
            //var tagList = this.TagRepository.QueryEntitiesNoTrack(t => true);
            //blog.Join(tagList,b=>b.BlogTags)
            return blogList;
        }

        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        public List<PersonTag> QueryTagList()
        {
            return this.TagRepository.QueryEntitiesNoTrack(t => t.UserId == UserContext.UserId)
                .Select(t => new PersonTag
                { 
                    Id = t.Id,
                    Name = t.Name
                }).ToList();
        }
    }
}
