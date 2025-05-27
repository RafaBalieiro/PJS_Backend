using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Rotina;
using PJS.Domain.Enum;

namespace PJS.Domain.Entities._Evento
{
    public class EventoEntity : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataExecucao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DataFinalizacao { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Guid RotinaId { get; set; }
        public RotinaEntity Rotina { get; set; }

        protected EventoEntity() { }

        public EventoEntity(DateTime dataExecucao, DateTime dataFinalizacao, Status status, Guid rotinaId)
        {

            if (dataExecucao == default)
                throw new ArgumentException("Data de execucao é inválida.");


            if (dataFinalizacao != null && dataExecucao > dataFinalizacao)
                throw new InvalidOperationException("A data de execucao não deve ser maior que a data finalizacao!");

            DataExecucao = DateTime.SpecifyKind(dataExecucao, DateTimeKind.Utc);
            DataFinalizacao = DateTime.SpecifyKind(dataFinalizacao, DateTimeKind.Utc);
            Status = status;
            RotinaId = rotinaId;
        }
    }
}