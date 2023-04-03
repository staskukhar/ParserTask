using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkingWithDbFromCollage
{
    public static class MyDbExtension
    {
        public static IServiceCollection AddShopDbContext(
            this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(@"Server=Stas;Database=TestDB;Trusted_Connection=True;");
                
            });
            return services;
        }
    }
}