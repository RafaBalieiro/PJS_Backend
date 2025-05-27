using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._Perfil;
using PJS.Domain.Interfaces.Repository._Tarefa;
using PJS.Domain.Interfaces.Repository._UnitWork;
using PJS.Domain.Interfaces.Repository._Usuario;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;
using PJS.Infrastructure.Repositories._Perfil;
using PJS.Infrastructure.Repositories._Tarefa;
using PJS.Infrastructure.Repositories._UnitOfWork;
using PJS.Infrastructure.Repositories._Usuario;

namespace PJS.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}