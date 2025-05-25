using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PJS.Application.Interfaces.Services._Auth;
using PJS.Application.Services._Auth;
using PJS.Application.Services._Base;
using PJS.Application.Services._Usuario;
using PJS.Domain.Interfaces.Services;
using PJS.Domain.Interfaces.Services._Usuario;

namespace PJS.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra o serviço base genérico
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}