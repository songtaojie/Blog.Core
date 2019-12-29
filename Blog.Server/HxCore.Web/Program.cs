using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace HxCore.Web
{
    /// <summary>
    /// 主程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 主函数
        /// </summary>
        /// <param name="args">参数</param>
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
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
        /// <summary>
        /// 创建Host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Warning);
                })
                .UseNLog();
            });

    }
}
