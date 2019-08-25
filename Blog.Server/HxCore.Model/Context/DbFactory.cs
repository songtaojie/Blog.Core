using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Model.Context
{
    public class DbFactory
    {
        public DbFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        private static IServiceProvider ServiceProvider
        {
            get;set;
        }
        public static DbContext GetDbContext()
        {
            HxContext context = ServiceProvider.GetRequiredService<HxContext>();
            return context;
        }

        public static async Task<bool> SaveChangeAsync()
        {
            DbContext context = GetDbContext();
            int result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
