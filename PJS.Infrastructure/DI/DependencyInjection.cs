using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            // outros repositórios e configurações

            return services;
        }
    }
}