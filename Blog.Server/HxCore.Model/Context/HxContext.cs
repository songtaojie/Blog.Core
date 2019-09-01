using HxCore.Common;
using HxCore.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Model.Context
{
    public class HxContext : DbContext
    {
        public HxContext() : base()
        {
        }
        public HxContext(DbContextOptions<DbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                   AppSettings.GetConnectionString("MySqlConnection"),
                   o =>
                   {
                       o.MigrationsAssembly("HxCore.Migrate");
                   });
            bool? enable =  AppSettings.Get("Logging", "EnableSql").ToBool();
            if (enable.HasValue && enable.Value)
            {
                optionsBuilder.UseLoggerFactory(new LoggerFactory().AddNLog());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new HxCore.Model.UserInfo()
            {
                Id = 1000,
                UserName = "Admin",
                PassWord = Common.Security.SafeHelper.MD5TwoEncrypt("123456"),
                Activate = "Y",
                Email = "stjworkemail@163.com",
                NickName = "超级管理员",
                LastLoginTime = DateTime.Now
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Blog> Blog { get; set; }
    }
}
