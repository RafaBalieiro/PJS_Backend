using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Usuario;
using PJS.Domain.Entities._Usuario;

namespace PJS.Domain.Interfaces.Services._Usuario
{
    public interface IUsuarioService : IServiceBase<UsuarioEntity>
    {
        Task<UsuarioResponseDto> Login(string email, string senha);
        Task<UsuarioResponseDto> Register(UsuarioCadastroDto user);
    }
}