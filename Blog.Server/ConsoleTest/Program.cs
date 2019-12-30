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
            Console.WriteLine(typeof(IAutoMapper).IsAssignableFrom(typeof(UserInfo)));
            Console.ReadKey();
        }
    }

    interface IAutoMapper { }
    class UserInfo : IAutoMapper
    { }
        
}
