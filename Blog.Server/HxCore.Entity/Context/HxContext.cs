using HxCore.Common;
using HxCore.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Entity.Context
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class HxContext : DbContext
    {
        private ILoggerFactory _loggerFactory;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="loggerFactory">日志工厂</param>
        public HxContext(DbContextOptions<HxContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string dbName = AppSettings.GetConnectionString("DbName");
            //if (Helper.AreEqual(dbName, ConstKey.MySqlName))
            //{
            //    optionsBuilder.UseMySQL(
            //        AppSettings.GetConnectionString("MySqlConnection")
            //      ,
            //      o =>
            //      {
            //          o.MigrationsAssembly("HxCore.Migrate");
            //      });
            //}
            //else
            //{
            //    optionsBuilder.UseSqlServer(AppSettings.GetConnectionString("SqlServerConnection"),
            //      o =>
            //      {
            //          o.MigrationsAssembly("HxCore.Migrate");
            //      });
            //}
            optionsBuilder.UseSqlServer(AppSettings.GetConnectionString("SqlServerConnection"),
                 o =>
                 {
                     o.MigrationsAssembly("HxCore.Migrate");
                 });
            bool? enable = AppSettings.Get("Logging", "EnableSql").ToBool();
            if (enable.HasValue && enable.Value)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(_loggerFactory);
            }
        }
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserInfo userInfo = new UserInfo()
            {
                Id = Helper.GetSnowId(),
                UserName = "Admin",
                PassWord = Common.Security.SafeHelper.MD5TwoEncrypt("123456"),
                Activate = "Y",
                Email = "stjworkemail@163.com",
                NickName = "超级管理员",
                LastLoginTime = DateTime.Now
            };
            modelBuilder.Entity<UserInfo>().HasData(userInfo);
            modelBuilder.Entity<BlogType>().HasData(new BlogType[] {
                new BlogType
                {
                    Id = Helper.GetSnowId(),
                    Name="原创",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new BlogType
                {
                    Id = Helper.GetSnowId(),
                    Name="转载",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new BlogType
                {
                    Id = Helper.GetSnowId(),
                    Name="翻译",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                }
            });
            modelBuilder.Entity<Category>().HasData(new Category[] {
                new Category{
                    Name="前端",
                    Id = Helper.GetSnowId(),
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new Category
                {
                    Name="后端",
                    Id = Helper.GetSnowId(),
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now},
                new Category
                {
                    Name="编程语言",
                    Id = Helper.GetSnowId(),
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                }
            });
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }
        /// <summary>
        /// 用户工作情况
        /// </summary>
        public DbSet<JobInfo> JobInfo { get; set; }
        /// <summary>
        /// 用户基础信息
        /// </summary>
        public DbSet<BasicInfo> BasicInfo { get; set; }
        /// <summary>
        /// 博客
        /// </summary>
        public DbSet<Blog> Blog { get; set; }
        /// <summary>
        /// 博客类型
        /// </summary>
        public DbSet<BlogType> BlogType { get; set; }
        /// <summary>
        /// 博客分类
        /// </summary>
        public DbSet<Category> Category { get; set; }
    }
}
