using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Entities._Rotina;
using PJS.Domain.Enum;

namespace PJS.Domain.Entities._Tarefas
{
    public class TarefaEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; private set; }

        [Required]
        public CategoriaTarefa CategoriaTarefa { get; private set; }

        [Required]
        public NivelConhecimento NivelConhecimento { get; private set; }

        [Required]
        public Status Status { get; private set; }

        [Required]
        public Dificuldade Dificuldade { get; private set; }

        [Required]
        public TimeSpan TempoEstimado { get; private set; }

        [Required]
        public Guid PerfilId { get; private set; }

        public PerfilEntity Perfil { get; private set; }

        [Required]
        public Guid RotinaId { get; private set; }

        public RotinaEntity Rotina { get; private set; }

        protected TarefaEntity() { }

        public TarefaEntity(string nome,CategoriaTarefa categoriaTarefa,NivelConhecimento nivelConhecimento, Status status, Dificuldade dificuldade, TimeSpan tempoEstimado, Guid perfilId, Guid rotinaId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");

            if (tempoEstimado.TotalMinutes <= 0)
                throw new ArgumentException("Tempo estimado deve ser maior que zero.");

            Nome = nome;
            CategoriaTarefa = categoriaTarefa;
            NivelConhecimento = nivelConhecimento;
            Status = status;
            Dificuldade = dificuldade;
            TempoEstimado = tempoEstimado;
            PerfilId = perfilId;
            RotinaId = rotinaId;
        }

        public void Concluir()
        {
            if (Status == Status.Concluida)
                throw new InvalidOperationException("Tarefa já está como concluída!");

            if (Status == Status.Cancelada)
                throw new InvalidOperationException("Não é possível concluir uma tarefa cancelada!");

            Status = Status.Concluida;
        }

        public void Cancelar()
        {
            if (Status == Status.Cancelada)
                throw new InvalidOperationException("Tarefa já está como cancelada!");

            if (Status == Status.Concluida)
                throw new InvalidOperationException("Não pode cancelar uma tarefa concluída!");


            Status = Status.Concluida;
        }
    }
}