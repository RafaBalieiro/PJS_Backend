using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PJS.Application.DTO._Nivel;
using PJS.Application.Interfaces.Services._Nivel;

namespace PJS.WebApi.Controllers._Nivel
{
    [ApiController]
    [Route("api/[controller]")]
    public class NivelController : ControllerBase
    {

        private readonly INivelService _nivelService;

        public NivelController(INivelService nivelService)
        {
            _nivelService = nivelService;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NivelCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var nivelCriado = await _nivelService.CreateAsync(dto);
                return Ok(nivelCriado); // Retorna NivelResponseDto
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar nível!" });
            }
        }
    }
}