using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clothing.Application.Interfaces;

namespace Clothing.Infrastrucure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration cfg)
        {
            var conectionString = cfg.GetConnectionString("Default");

            services.AddDbContext<ClothingDbContext>(options =>
            {
                options.UseNpgsql(conectionString);
            });

            services.AddScoped<IClothingDbContext, ClothingDbContext>();

            return services;
        }
    }
}
