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
using Microsoft.EntityFrameworkCore;

namespace HxCore.Services
{
    /// <summary>
    /// 博客的服务类
    /// </summary>
    public class BlogService:BaseService<Blog>,IBlogService
    {
        private IBlogTagRepository TagRepository { get; }
        public BlogService(IBlogRepository dal, IBlogTagRepository tagRepository,IDbSession dbSession)
            :base(dal, dbSession)
        {
            this.TagRepository = tagRepository;
        }
        #region 新增编辑
        public async Task<bool> InsertAsync(BlogCreateModel blogModel)
        {
            var entity = this.Mapper.Map<Blog>(blogModel);
            if (blogModel.IsPublish)
            {
                entity.PublishDate = DateTime.Now;
            }
            var imgList = WebHelper.GetHtmlImageUrlList(entity.Content).ToList();
            if (imgList.Count > 0)
            {
                entity.ImgUrl = imgList[0];
            }
            List<BlogTag> tagEntityList = new List<BlogTag>();
            if (blogModel.PersonTags != null && blogModel.PersonTags.Count > 0)
            {
                List<long> blogTagList = new List<long>();
                blogModel.PersonTags.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        if (string.IsNullOrEmpty(p.Id) || p.Id.Contains("newData"))
                        {
                            var newBlogTag = new BlogTag
                            {
                                Id = Helper.GetLongSnowId(),
                                Name = p.Name,
                                UserId = UserContext.UserId,
                                UserName = UserContext.UserName
                            };
                            tagEntityList.Add(newBlogTag);
                            blogTagList.Add(newBlogTag.Id);
                        }
                        else
                        {
                            var blogTag = this.DbSession.FindById<BlogTag>(p.Id);
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
        #endregion

        #region 查询
        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        public Task<List<BlogQueryModel>> QueryBlogList()
        {
            var blogList = this.Repository.QueryEntitiesNoTrack(b => b.Publish == ConstKey.Yes);
            var userList = this.DbSession.QueryEntities<UserInfo>(u => u.Delete == ConstKey.No);
            WebManager webManager = this.DbSession.GetRequiredService<WebManager>();
            var resultList = blogList.Join(userList, b => b.UserId, u => u.Id, (b, u) => new BlogQueryModel
            {
                Id = b.Id,
                NickName = u.NickName,
                UserName = u.UserName,
                Title = b.Title,
                Content = b.Content,
                ReadCount = b.ReadCount,
                CmtCount = b.CmtCount,
                PublishDate = b.PublishDate,
                AvatarUrl = webManager.GetFullUrl(u.AvatarUrl)
            }).ToListAsync();
            return resultList;
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
                    Id = t.Id.ToString(),
                    Name = t.Name
                }).ToList();
        }

        public async Task<BlogViewModel> FindById(string id)
        {
            var blog = await this.FindEntityById(id);
            if (blog == null || (blog.Publish == ConstKey.No && (UserContext == null || UserContext.UserId != blog.UserId || !UserContext.IsAdmin))) throw new NotFoundException("找不到您访问的页面");
            var blogModel = this.Mapper.Map<BlogViewModel>(blog);
            var userInfo = await this.DbSession.FindEntity<UserInfo>(u => u.UserName == blog.UserName);
            blogModel.NickName = userInfo.NickName;
            return blogModel;
        }
        #endregion

    }
}
