using HxCore.Common;
using HxCore.Entity;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("完成");
            Console.ReadKey();
        }

        public static async void Test()
        {
            string result = await Tasks();
            Console.WriteLine(result);
        }
        public static string TaskReturn()
        {
            Task.Delay(1000);
            Console.WriteLine("Task测试");
            return "这是一个return";
        }
        public static async Task<string> Tasks()
        {
            string result = await Task.Run(() => TaskReturn());
            return result;
        }
    }
}
