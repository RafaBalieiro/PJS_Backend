using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PJS.Application.Services._Base;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra o serviço base genérico
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            // Registros de serviços específicos (exemplos)
            //services.AddScoped<IClienteService, ClienteService>();
            //services.AddScoped<IPedidoService, PedidoService>();
            // Adicione os demais serviços específicos aqui

            return services;
        }
    }
}