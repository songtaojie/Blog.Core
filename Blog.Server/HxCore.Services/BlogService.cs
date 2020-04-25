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
using HxCore.Common.Extensions;

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
            var imgList = WebHelper.GetHtmlImageUrlList(entity.ContentHtml).ToList();
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
                        var tagTask = this.TagRepository.FindAsync(r => r.Name == p.Name.Trim() && r.UserId == UserContext.UserId);
                        var tag = tagTask.Result;
                        if (tag == null)
                        {
                            tag = new T_BlogTag
                            {
                                Id = Helper.GetLongSnowId(),
                                Name = p.Name,
                                UserId = UserContext.UserId,
                                UserName = UserContext.UserName
                            };
                            tagEntityList.Add(tag);
                            
                        }
                        blogTagList.Add(tag.Id);
                    }
                });
                entity.BlogTags = string.Join(",", blogTagList);
            }
            var result = await this.DbSession.ExcuteAsync(async delegate
            {
                this.BeforeInsert(entity);
                await this.Repository.InsertAsync(entity);
                if (tagEntityList.Count > 0)
                {
                    await this.TagRepository.BatchInsertAsync(tagEntityList);
                }
                await this.DbSession.SaveChangesAsync();
            });
            return result;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        public Task<PageModel<BlogQueryModel>> QueryBlogList(BlogQueryParam param)
        {
            WebManager webManager = this.DbSession.GetRequiredService<WebManager>();
            var query = from b in Db.Set<T_Blog>().AsNoTracking()
                        join u in Db.Set<T_UserInfo>().AsNoTracking() on b.UserId equals u.Id
                        where b.Publish == ConstKey.Yes
                        && b.Delete == ConstKey.No
                        && u.Delete == ConstKey.No
                        select new BlogQueryModel
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
                        };
            if (string.IsNullOrEmpty(param.SortKey))
            {
                param.SortKey = nameof(BlogQueryModel.PublishDate);
                param.SortType = SortTypeEnum.DESC;
            }
            return query.ToOrderAndPageListAsync(param);
        }

        /// <summary>
        /// 获取博客标签列表
        /// </summary>
        /// <returns></returns>
        public List<PersonTag> QueryTagList()
        {
            return this.TagRepository.QueryEntities(t => t.UserId == UserContext.UserId)
                .AsNoTracking()
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
            await GetPreBlogInfo(blogModel);
            await GetNextBlogInfo(blogModel);
            return blogModel;
        }
        private async Task GetPreBlogInfo(BlogDetailModel blogModel)
        {
            var blogId = Convert.ToInt64(blogModel.Id);
            var preBlog = await this.Repository.QueryEntities(b => b.Id < blogId && b.UserId == blogModel.UserId).OrderByDescending(b => b.Id).FirstOrDefaultAsync();
            if (preBlog != null)
            {
                blogModel.PreId = preBlog.Id.ToString();
                blogModel.PreTitle = preBlog.Title;
            }
        }

        private async Task GetNextBlogInfo(BlogDetailModel blogModel)
        {
            var blogId = Convert.ToInt64(blogModel.Id);
            var nextBlog = await this.Repository.QueryEntities(b => b.Id > blogId && b.UserId == blogModel.UserId).OrderBy(b => b.Id).FirstOrDefaultAsync();
            if (nextBlog != null)
            {
                blogModel.NextId = nextBlog.Id.ToString();
                blogModel.NextTitle = nextBlog.Title;
            }
        }
        #endregion

    }
}
