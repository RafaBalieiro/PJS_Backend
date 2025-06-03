using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PJS.Application.DTO._Conquista;
using PJS.Application.DTO._Nivel;
using PJS.Application.DTO._Perfil;
using PJS.Application.DTO._Tarefa;
using PJS.Application.DTO._Usuario;
using PJS.Application.DTO._Usuario._Perfil;
using PJS.Application.Interfaces.Services._Auth;
using PJS.Application.Interfaces.Services._Conquista;
using PJS.Application.Interfaces.Services._Nivel;
using PJS.Application.Interfaces.Services._Perfil;
using PJS.Application.Interfaces.Services._Tarefa;
using PJS.Application.Services._Auth;
using PJS.Application.Services._Base;
using PJS.Application.Services._Conquista;
using PJS.Application.Services._Nivel;
using PJS.Application.Services._Perfil;
using PJS.Application.Services._Tarefa;
using PJS.Application.Services._Usuario;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Entities._Tarefas;
using PJS.Domain.Entities._Usuario;
using PJS.Domain.Interfaces.Services;
using PJS.Domain.Interfaces.Services._Usuario;

namespace PJS.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra o serviço base genérico

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IConquistaService, ConquistaService>();

            //services.AddGenericService<UsuarioEntity, UsuarioCreateDto, UsuarioUpdateDto, UsuarioResponseDto>();
            //services.AddGenericService<PerfilEntity, PerfilCreateDto, PerfilUpdateDto, PerfilResponseDto>();
            //services.AddGenericService<TarefaEntity, TarefaCreateDto, TarefaUpdateDto, TarefaResponseDto>();
            //services.AddGenericService<NivelEntity, NivelCreateDto, NivelUpdateDto, NivelResponseDto>();
            //services.AddGenericService<ConquistaEntity, ConquistaCreateDto, ConquistaUpdateDto, ConquistaResponseDto>();
            return services;
        }
    }
}