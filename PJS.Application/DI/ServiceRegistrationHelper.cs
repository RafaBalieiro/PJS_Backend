using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Base;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.DI
{
    public static class ServiceRegistrationHelper
    {
        public static IServiceCollection AddGenericService<TEntity, TCreateDto, TUpdateDto, TReadDto>(
           this IServiceCollection services)
           where TEntity : BaseEntity
        {
            services.AddScoped<IServiceBase<TEntity, TCreateDto, TUpdateDto, TReadDto>,
                               ServiceBase<TEntity, TCreateDto, TUpdateDto, TReadDto>>();
            return services;
        }
    }
}