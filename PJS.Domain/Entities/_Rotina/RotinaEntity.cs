using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Evento;
using PJS.Domain.Enum;

namespace PJS.Domain.Entities._Rotina
{
    public class RotinaEntity : BaseEntity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; private set; }

        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; private set; }

        [Required]
        public Periodicidade Periodicidade { get; private set; }

        [Required]
        public Status Status { get; private set; }

        public ICollection<EventoEntity>? Eventos { get; private set; }

        protected RotinaEntity() { }

        public RotinaEntity(DateTime dataInicial, DateTime? dataFinal, Periodicidade periodicidade, Status status)
        {

            if (dataInicial == default)
                throw new ArgumentException("Data inicial inválida.");

            if (dataFinal != null && dataInicial > dataFinal)
                throw new InvalidOperationException("A data inicial não deve ser maior que a data final!");

            DataInicial = DateTime.SpecifyKind(dataInicial, DateTimeKind.Utc);
            DataFinal = dataFinal.HasValue ? DateTime.SpecifyKind(dataFinal.Value, DateTimeKind.Utc) : null;
            Periodicidade = periodicidade;
            Status = status;
            Eventos = new List<EventoEntity>();
        }
    }

}