using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoviApp.Application.Interfaces;
using NoviApp.Infraestructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Infraestructure.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NoviAppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("dylanCadena"));
            });


            services.AddScoped<IApplicationDbContext, NoviAppContext>();

            return services;
        }
    }
}
