using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Domain.Entities._Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public DateTime DataCriacao { get; protected set; }

        [Required]
        public DateTime DataAlteracao { get; set; }

        [Required]
        public bool Ativo { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        public void MarcarComoAtualizado()
        {
            DataAlteracao = DateTime.UtcNow;
        }

        public void Ativa()
        {
            Ativo = true;
            MarcarComoAtualizado();
        }

        public void Desativar()
        {
            Ativo = false;
            MarcarComoAtualizado();
        }
    }
}