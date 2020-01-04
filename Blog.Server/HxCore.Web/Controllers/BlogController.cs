using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HxCore.IServices;
using HxCore.Entity;
using HxCore.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HxCore.Model;
using HxCore.Entity.Context;
using AutoMapper;
using HxCore.Common;

namespace HxCore.Web.Controllers
{
    /// <summary>
    /// 博客相关的控制器类
    /// </summary>
    [Route("[controller]/[action]")]
    public class BlogController : BaseApiController
    {
        private readonly IBlogService blogService;
        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="_blogService"></param>
        public BlogController(IBlogService _blogService)
        {
            blogService = _blogService;
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Blog> GetList()
        {
            var user = User;
            var result = blogService.QueryEntitiesNoTrack(b => true).ToList();
            return result;
        }

        #region 博客的保存编辑
        /// <summary>
        /// 博客的编辑
        /// </summary>
        /// <param name="editInfo"></param>
        /// <returns></returns>
        [Authorize(Policy =ConstInfo.ClientPolicy)]
        [HttpPost]
        public bool Save([FromForm]BlogViewModel editInfo)
        {
            bool isEdit = false;
            var user = User;
            blogService.Insert(editInfo);
            return true;
            //if (ModelState.IsValid)
            //{
               
            //    //TransactionManager.Excute(delegate
            //    //{
            //    //    Blog blogInfo = MapperManager.Map<Blog>(editInfo);
            //    //    if (!string.IsNullOrEmpty(editInfo.HexId))
            //    //    {
            //    //        isEdit = true;
            //    //        blogInfo.Id = Convert.ToInt64(Helper.FromHex(editInfo.HexId));
            //    //    }
            //    //    DbContextManager dbContext = new DbContextManager();
            //    //    string[] imgList = WebHelper.GetHtmlImageUrlList(blogInfo.ContentHtml);
            //    //    if (imgList.Length > 0)
            //    //    {
            //    //        blogInfo.ImgUrl = string.Join(",", imgList);
            //    //    }
            //    //    if (!blogInfo.IsMarkDown)
            //    //    {
            //    //        blogInfo.Content = HttpUtility.HtmlEncode(blogInfo.ContentHtml);
            //    //    }
            //    //    if (blogInfo.IsPublish)
            //    //    {
            //    //        blogInfo.PublishDate = DateTime.Now;
            //    //    }
            //    //    List<string> tagList = new List<string>();
            //    //    if (!string.IsNullOrEmpty(editInfo.PersonTags))
            //    //    {
            //    //        int fakeId = 0;
            //    //        Dictionary<string, string> dicts = JsonConvert.DeserializeObject<Dictionary<string, string>>(editInfo.PersonTags);
            //    //        foreach (KeyValuePair<string, string> item in dicts)
            //    //        {
            //    //            if (!string.IsNullOrEmpty(item.Value))
            //    //            {
            //    //                if (item.Key.Contains("newData"))
            //    //                {
            //    //                    string value = item.Value.Trim();
            //    //                    BlogTag tag = _tagService.GetEntity(b => b.Name == value);
            //    //                    if (tag == null)
            //    //                    {
            //    //                        tag = new BlogTag()
            //    //                        {
            //    //                            Id = fakeId++,
            //    //                            Name = value,
            //    //                        };
            //    //                        if (UserContext.LoginUser != null)
            //    //                        {
            //    //                            tag.UserId = UserContext.LoginUser.Id;
            //    //                        }
            //    //                        FillAddModel(tag);
            //    //                        tag = _tagService.Insert(tag);
            //    //                        // tag = dbContext.Add(tag);
            //    //                    }
            //    //                    tagList.Add(tag.Id.ToString());
            //    //                }
            //    //                else if (!string.IsNullOrEmpty(item.Key))
            //    //                {
            //    //                    tagList.Add(item.Key);
            //    //                }
            //    //            }
            //    //        }
            //    //    }
            //    //    blogInfo.BlogTags = string.Join(",", tagList);
            //    //    if (isEdit)
            //    //    {
            //    //        _blogService.UpdateEntityFields(blogInfo,
            //    //            "Title", "ContentHtml", "Content", "TypeId", "CatId", "PersonTop", "Private",
            //    //            "Publish", "CanCmt", "MarkDown", "BlogTags", "PublishDate");
            //    //    }
            //    //    else
            //    //    {
            //    //        blogInfo = FillAddModel(blogInfo);
            //    //        blogInfo = _blogService.Insert(blogInfo);
            //    //    }
            //    //    result.Resultdata = "/article/" + blogInfo.UserName + "/" + blogInfo.HexId;
            //    //});
            //}
            //else
            //{
            //    result.Success = false;
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var modelstate = ModelState[key];
            //        if (modelstate.Errors.Any())
            //        {
            //            result.Message = modelstate.Errors.FirstOrDefault().ErrorMessage;
            //            break;
            //        }
            //    }
            //}
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}