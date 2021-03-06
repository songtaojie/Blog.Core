﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateWebHostBuilder(args).Build();
                logger.Info("应用程序启动成功!");
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program");
                throw;
            }
            finally
            {
                // 确保在应用程序退出之前刷新和停止内部计时器/线程（避免Linux上的分段错误）
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Warning);
            })
            .UseNLog();
    }
}
