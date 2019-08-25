using HxCore.Common;
using HxCore.Model;
using HxCore.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HxContext hxContext = new HxContext();
            long key = 1000;
            UserInfo user = hxContext.Set<UserInfo>().Find(key);
            Console.WriteLine(user.UserName);
            Console.ReadKey();
        }
    }
}
