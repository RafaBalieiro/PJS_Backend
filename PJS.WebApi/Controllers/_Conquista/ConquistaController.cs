using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PJS.Application.DTO._Conquista;
using PJS.Application.Interfaces.Services._Conquista;

namespace PJS.WebApi.Controllers._Conquista
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConquistaController : ControllerBase
    {
        private readonly IConquistaService _conquistaService;

        public ConquistaController(IConquistaService conquistaService)
        {
            _conquistaService = conquistaService;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ConquistaCreateDto dto)
        {
            try
            {
                var result = await _conquistaService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar conquista!",detalhe = ex.Message});
            }
        }
    }
}