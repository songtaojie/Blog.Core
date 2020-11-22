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
            //optionsBuilder.UseSqlServer(AppSettings.GetConnectionString("SqlServerConnection"),
            //     o =>
            //     {
            //         o.MigrationsAssembly("HxCore.Migrate");
            //     });
            optionsBuilder.UseMySQL(AppSettings.GetConnectionString("MySqlConnection"),
                  o =>
                  {
                      o.MigrationsAssembly("HxCore.Migrate");
                  });
            bool ? enable = AppSettings.Get("Logging", "EnableSql").ToBool();
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
            T_UserInfo userInfo = new T_UserInfo()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                PassWord = Common.Security.SafeHelper.MD5TwoEncrypt("123456"),
                Activate = "Y",
                Email = "stjworkemail@163.com",
                NickName = "超级管理员",
                LastLoginTime = DateTime.Now
            };
            modelBuilder.Entity<T_UserInfo>().HasData(userInfo);
            modelBuilder.Entity<T_BlogType>().HasData(new T_BlogType[] {
                new T_BlogType
                {
                    Id = Helper.GetLongSnowId(),
                    Name="原创",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new T_BlogType
                {
                    Id = Helper.GetLongSnowId(),
                    Name="转载",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new T_BlogType
                {
                    Id = Helper.GetLongSnowId(),
                    Name="翻译",
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                }
            });
            modelBuilder.Entity<T_Category>().HasData(new T_Category[] {
                new T_Category{
                    Name="前端",
                    Id = Helper.GetLongSnowId(),
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now
                },
                new T_Category
                {
                    Name="后端",
                    Id = Helper.GetLongSnowId(),
                    UserId = userInfo.Id,
                    UserName = userInfo.UserName,
                    CreateTime = DateTime.Now},
                new T_Category
                {
                    Name="编程语言",
                    Id = Helper.GetLongSnowId(),
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
        public DbSet<T_UserInfo> UserInfo { get; set; }
        /// <summary>
        /// 用户工作情况
        /// </summary>
        public DbSet<T_JobInfo> JobInfo { get; set; }
        /// <summary>
        /// 用户基础信息
        /// </summary>
        public DbSet<T_BasicInfo> BasicInfo { get; set; }
        /// <summary>
        /// 博客
        /// </summary>
        public DbSet<T_Blog> Blog { get; set; }
        /// <summary>
        /// 博客类型
        /// </summary>
        public DbSet<T_BlogType> BlogType { get; set; }
        /// <summary>
        /// 博客分类
        /// </summary>
        public DbSet<T_Category> Category { get; set; }

        /// <summary>
        /// 博客个人标签
        /// </summary>
        public DbSet<T_BlogTag> BlogTag { get; set; }
    }
}
