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
    public class BlogService : BaseService<T_Blog>, IBlogService
    {
        private IBlogTagRepository TagRepository { get; }
        public BlogService(IBlogRepository dal, IBlogTagRepository tagRepository, IDbSession dbSession)
            : base(dal, dbSession)
        {
            this.TagRepository = tagRepository;
        }
        #region 新增编辑
        public async Task<bool> InsertAsync(BlogCreateModel blogModel)
        {
            var entity = this.Mapper.Map<T_Blog>(blogModel);
            if (blogModel.IsPublish)
            {
                entity.PublishDate = DateTime.Now;
            }
            var imgList = WebHelper.GetHtmlImageUrlList(entity.Content).ToList();
            if (imgList.Count > 0)
            {
                entity.ImgUrl = imgList[0];
            }
            List<T_BlogTag> tagEntityList = new List<T_BlogTag>();
            if (blogModel.PersonTags != null && blogModel.PersonTags.Count > 0)
            {
                List<long> blogTagList = new List<long>();
                blogModel.PersonTags.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        if (string.IsNullOrEmpty(p.Id) || p.Id.Contains("newData"))
                        {
                            var newBlogTag = new T_BlogTag
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
                            long.TryParse(p.Id, out long longId);
                            //var blogTag = this.DbSession.FindById<T_BlogTag>(longId);
                            //if (blogTag != null)
                            //{
                            //}
                            blogTagList.Add(longId);
                        }
                    }
                });
                entity.BlogTags = string.Join(",", blogTagList);
            }
            bool result = await this.DbSession.ExcuteAsync(delegate
            {
                entity = this.BeforeInsert(entity);
                this.Repository.Insert(entity);
                if (tagEntityList.Count > 0)
                {
                    this.TagRepository.BatchInsert(tagEntityList);
                }
                this.Repository.SaveChangesAsync();
            });
            return result;
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
            var userList = this.DbSession.QueryEntities<T_UserInfo>(u => u.Delete == ConstKey.No);
            WebManager webManager = this.DbSession.GetRequiredService<WebManager>();
            var resultList = blogList.Join(userList, b => b.UserId, u => u.Id, (b, u) => new BlogQueryModel
            {
                Id = b.Id.ToString(),
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

        public async Task<BlogDetailModel> FindById(long id)
        {
            var blogModel = await (from b in Db.Set<T_Blog>()
                                   join u in Db.Set<T_UserInfo>() on b.UserId equals u.Id
                                   join c in Db.Set<T_Category>() on b.CategoryId equals c.Id into c_temp
                                   from c in c_temp.DefaultIfEmpty()
                                   where b.Id == id
                                   select new BlogDetailModel
                                   {
                                       Id = b.Id.ToString(),
                                       Title = b.Title,
                                       Publish = b.Publish,
                                       PublishDate = b.PublishDate,
                                       Content = b.Content,
                                       ReadCount = b.ReadCount,
                                       CmtCount = b.CmtCount,
                                       AvatarUrl = u.AvatarUrl,
                                       UserId = u.Id,
                                       UserName = u.UserName,
                                       NickName = u.NickName,
                                       CategoryName = c.Name,
                                       MarkDown = b.MarkDown
                                   }).FirstOrDefaultAsync();
            if (blogModel == null || (blogModel.Publish == ConstKey.No && (UserContext == null || UserContext.UserId != blogModel.UserId || !UserContext.IsAdmin))) throw new NotFoundException("找不到您访问的页面");
            //获取上一个和下一个博客
            var blogId = Convert.ToInt64(blogModel.Id);
            var preBlog = await this.Repository.QueryEntities(b => b.Id < blogId).OrderByDescending(b => b.Id).FirstOrDefaultAsync();
            if (preBlog != null)
            {
                blogModel.PreId = preBlog.Id.ToString();
                blogModel.PreTitle = preBlog.Title;
            }
            var nextBlog = await this.Repository.QueryEntities(b => b.Id > blogId).OrderBy(b => b.Id).FirstOrDefaultAsync();
            if (nextBlog != null)
            {
                blogModel.NextId = nextBlog.Id.ToString();
                blogModel.NextTitle = nextBlog.Title;
            }
            return blogModel;
        }
        #endregion

    }
}
