using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PJS.Application.DTO._Usuario;
using PJS.Domain.Interfaces.Services._Usuario;

namespace PJS.WebApi.Controllers._Usuario
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioCadastroDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.Register(dto);
                return Created("", usuario); // 201 Created
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message }); // 409 Conflict
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
        {
            try
            {
                var token = await _usuarioService.Login(dto.Email, dto.Senha);
                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensagem = ex.Message }); // 401
            }
        }
    }
}