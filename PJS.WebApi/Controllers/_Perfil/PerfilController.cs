using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PJS.Application.Interfaces.Services._Perfil;

namespace PJS.WebApi.Controllers._Perfil
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [Authorize]
        [HttpGet("perfil")]

        public async Task<IActionResult> ObterPerfil()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized(new { mensagem = "Usuário não autenticado" });

            var perfil = await _perfilService.ObterPerfilPorUsuarioIdAsync(Guid.Parse(userId));

            if (perfil == null)
                return NotFound(new { mensagem = "Perfil não encontrado" });

            return Ok(perfil);
        }
    }
}