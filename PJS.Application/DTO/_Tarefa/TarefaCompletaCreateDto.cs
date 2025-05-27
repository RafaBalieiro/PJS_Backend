using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Enum;

namespace PJS.Application.DTO._Tarefa
{
    public class TarefaCompletaCreateDto
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public CategoriaTarefa CategoriaTarefa { get; set; }

        [Required]
        public NivelConhecimento NivelConhecimento { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Dificuldade Dificuldade { get; set; }

        [Required]
        public TimeSpan TempoEstimado { get; set; }

        [Required]
        public Guid PerfilId { get; set; }

        [Required]
        public RotinaCreateDto? Rotina { get; set; }
    }

    public class RotinaCreateDto
    {
        [Required]
        public DateTime DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }

        [Required]
        public Periodicidade Periodicidade { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public List<EventoCreateDto>? Eventos { get; set; }
    }

    public class EventoCreateDto
    {
        [Required]
        public DateTime DataExecucao { get; set; }

        [Required]
        public DateTime DataFinalizacao { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}