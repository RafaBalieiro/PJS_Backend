using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Usuario;
using PJS.Domain.Entities._Usuario;

namespace PJS.Application.Interfaces.Services._Auth
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioEntity user);
    }
}