using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PJS.Application.DTO._Tarefa;
using PJS.Application.Interfaces.Services._Tarefa;
using PJS.Application.Services._Tarefa;

namespace PJS.WebApi.Controllers._Tarefa
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] TarefaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarefaCriada = await _tarefaService.CriarTarefaCompletaAsync(dto);
                return Ok(tarefaCriada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao criar tarefa!", detalhe = ex.Message,inner = ex.InnerException?.Message, stackTrace = ex.StackTrace });
            }
        }
    }
}